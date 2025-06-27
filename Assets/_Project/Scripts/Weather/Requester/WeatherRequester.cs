using System;
using System.Threading;
using _Project.Scripts.Common.WebRequestService;
using Cysharp.Threading.Tasks;
using Newtonsoft.Json;
using UnityEngine;
using UnityEngine.Networking;

namespace _Project.Scripts.Weather
{
    public class WeatherRequester
    {
        private const string API_URL = "https://api.weather.gov/gridpoints/TOP/32,81/forecast";
        
        public event Action<string> OnTextLoad;
        
        private CancellationTokenSource _cts;
        private RequestWrapper _currentRequest;

        private readonly IRequestService _requestQueueService;
        private readonly WeatherRequesterData _weatherRequesterData;

        public WeatherRequester(IRequestService requestQueueService,
            WeatherRequesterData weatherRequesterData)
        {
            _requestQueueService = requestQueueService;
            _weatherRequesterData = weatherRequesterData;
        }

        public async void StartSendRequests()
        {
            if (_cts != null && !_cts.IsCancellationRequested)
                StopSendTasks();

            _cts = new CancellationTokenSource();
            await RepeatSendTask();
        }

        public void StopRequests()
        {
            StopSendTasks();
            _requestQueueService.RemoveRequest(_currentRequest);
            _requestQueueService.CancelCurrentRequest(_currentRequest);
        }

        private void StopSendTasks()
        {
            _cts.Cancel();
            _cts.Dispose();
        }

        private async UniTask RepeatSendTask()
        {
            try
            {
                while (_cts != null && !_cts.IsCancellationRequested)
                {
                    RequestWrapper requestWrapper = new RequestWrapper();
                    UniTask _task = Request(requestWrapper.Cts.Token);
                    requestWrapper.Init(_task);
                    
                    _currentRequest = requestWrapper;
                    _requestQueueService.AddRequest(_currentRequest);
                    
                    await UniTask.Delay(TimeSpan.FromSeconds(_weatherRequesterData.TimeDelaySending),
                        cancellationToken: _cts.Token);
                }
            }
            catch (OperationCanceledException)
            {
                Debug.Log("Request was cancelled");
            }
        }

        private async UniTask Request(CancellationToken cancellationToken)
        {
            var request = UnityWebRequest.Get(API_URL);

            try
            {
                await request.SendWebRequest().WithCancellation(cancellationToken);

                if (request.result == UnityWebRequest.Result.Success)
                {
                    string jsonResponse = request.downloadHandler.text;
                    var weatherData = JsonConvert.DeserializeObject<WeatherData>(jsonResponse);

                    if (weatherData?.properties?.periods?.Length > 0)
                    {
                        var today = weatherData.properties.periods[0];
                        OnTextLoad?.Invoke(today.temperature + today.temperatureUnit);
                    }
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