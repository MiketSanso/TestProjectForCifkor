using System;
using System.Threading;
using _Project.Scripts.Common.WebRequestService;
using Cysharp.Threading.Tasks;
using Newtonsoft.Json;
using UnityEngine;
using UnityEngine.Networking;

namespace _Project.Scripts.DogBreeds.Requester
{
    public class BreedDescriptionsRequester
    {
        private const string DETAILS_API_URL = "https://dogapi.dog/api/v2/breeds/{0}";
        
        public event Action<BreedDetailsResponse> OnDetailsLoad;
        
        private RequestWrapper _currentRequest;

        private readonly IRequestService _requestQueueService;

        public BreedDescriptionsRequester(IRequestService requestQueueService)
        {
            _requestQueueService = requestQueueService;
        }

        public void SendDescriptionRequest(string breedId)
        {
            if (_currentRequest != null)
                StopRequests();
            
            RequestWrapper requestWrapper = new RequestWrapper();
            UniTask _task = RequestBreedNames(requestWrapper.Cts.Token, breedId);
            requestWrapper.Init(_task);
            
            _currentRequest = requestWrapper;
            _requestQueueService.AddRequest(_currentRequest);
        }

        public void StopRequests()
        {
            _requestQueueService.RemoveRequest(_currentRequest);
            _requestQueueService.CancelCurrentRequest(_currentRequest);
        }

        private async UniTask RequestBreedNames(CancellationToken cancellationToken, string breedId)
        {
            var request = UnityWebRequest.Get(string.Format(DETAILS_API_URL, breedId));

            try
            {
                await request.SendWebRequest().WithCancellation(cancellationToken);

                if (request.result == UnityWebRequest.Result.Success)
                {
                    string json = request.downloadHandler.text;
                    var response = JsonConvert.DeserializeObject<BreedDetailsResponse>(json);
            
                    if (response?.data?.attributes != null)
                    {
                        var detailsResponse = new BreedDetailsResponse
                        {
                            data = new BreedDetailData
                            {
                                attributes = new BreedDetailAttributes
                                {
                                    name = response.data.attributes.name,
                                    description = response.data.attributes.description
                                }
                            }
                        };
                        
                        OnDetailsLoad?.Invoke(detailsResponse);
                    }
                }
            }
            catch (OperationCanceledException)
            {
                Debug.Log("Breed details request was cancelled");
                request.Abort();
            }
            catch (Exception e)
            {
                Debug.LogException(e);
            }
            finally
            {
                if (_currentRequest != null)
                    _currentRequest = null;
            }
        }
    }
}