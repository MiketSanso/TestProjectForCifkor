using System;
using Zenject;

namespace _Project.Scripts.Weather
{
    public class WeatherPresenter : IInitializable, IDisposable
    {
        private readonly WeatherView _weatherView;
        private readonly WeatherRequester _weatherRequester;

        public WeatherPresenter(WeatherView weatherView,
            WeatherRequester weatherRequester)
        {
            _weatherView = weatherView;
            _weatherRequester = weatherRequester;
        }

        public void Initialize()
        {
            _weatherRequester.OnTextLoad += _weatherView.ChangeText;
            _weatherView.OnCloseView += _weatherRequester.StopRequests;
        }

        public void Dispose()
        {
            _weatherView.OnCloseView -= _weatherRequester.StopRequests;
            _weatherRequester.OnTextLoad -= _weatherView.ChangeText;
        }
    }
}