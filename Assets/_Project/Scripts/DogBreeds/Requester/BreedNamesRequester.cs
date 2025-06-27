using System;
using System.Collections.Generic;
using System.Threading;
using _Project.Scripts.Common.WebRequestService;
using Cysharp.Threading.Tasks;
using Newtonsoft.Json;
using UnityEngine;
using UnityEngine.Networking;

namespace _Project.Scripts.DogBreeds.Requester
{
    public class BreedNamesRequester
    {
        private const string API_URL = "https://dogapi.dog/api/v2/breeds";
        
        public event Action OnNamesListLoad;
        
        private RequestWrapper _currentRequest;

        private readonly BreedInfoModel _breedInfoModel;
        private readonly IRequestService _requestQueueService;
        private readonly BreedsRequesterData _breedsRequesterData;

        public BreedNamesRequester(IRequestService requestQueueService,
            BreedInfoModel breedInfoModel,
            BreedsRequesterData breedsRequesterData)
        {
            _requestQueueService = requestQueueService;
            _breedInfoModel = breedInfoModel;
            _breedsRequesterData = breedsRequesterData;
        }

        public void SendNamesRequest()
        {
            if (_breedInfoModel.BreedInfo.data == null)
            {
                RequestWrapper requestWrapper = new RequestWrapper();
                UniTask _task = RequestBreedNames(requestWrapper.Cts.Token);
                requestWrapper.Init(_task);
            
                _currentRequest = requestWrapper;
                _requestQueueService.AddRequest(_currentRequest);
            }
        }

        public void StopRequests()
        {
            _requestQueueService.RemoveRequest(_currentRequest);
            _requestQueueService.CancelCurrentRequest(_currentRequest);
        }

        private async UniTask RequestBreedNames(CancellationToken cancellationToken)
        {
            var request = UnityWebRequest.Get(API_URL);

            try
            {
                await request.SendWebRequest().WithCancellation(cancellationToken);

                if (request.result == UnityWebRequest.Result.Success)
                {
                    string json = request.downloadHandler.text;
                    var response = JsonConvert.DeserializeObject<BreedInfoResponse>(json);
                    
                    if (response == null || response.data == null)
                    {
                        Debug.LogError("Invalid API response");
                        return;
                    }

                    BreedInfoResponse breedInfoResponse = new BreedInfoResponse();
                    breedInfoResponse.data = new List<BreedItem>();
            
                    for (int i = 0; i < _breedsRequesterData.CountNames && i < response.data.Count; i++)
                    {
                        breedInfoResponse.data.Add(response.data[i]);
                    }
            
                    if (_breedsRequesterData.CountNames > response.data.Count)
                        Debug.Log("API doesn't have that many names!");
            
                    _breedInfoModel.SetBreedInfos(breedInfoResponse);
                    OnNamesListLoad?.Invoke();
                }
            }
            catch (OperationCanceledException)
            {
                Debug.Log("Weather request was cancelled");
                request.Abort();
            }
            catch (Exception e)
            {
                Debug.LogException(e);
            }
        }
    }
}