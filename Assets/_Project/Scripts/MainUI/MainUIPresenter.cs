using System;
using _Project.Scripts.Clicker;
using _Project.Scripts.DogBreeds.Requester;
using _Project.Scripts.Weather;
using Zenject;

namespace _Project.Scripts.MainUI
{
    public class MainUIPresenter : IInitializable, IDisposable
    {
        private readonly MainView _view;
        private readonly WeatherRequester _weatherRequester;
        private readonly EnergyRecharger _energyRecharger;
        private readonly AutoClicker _autoClicker;
        private readonly BreedNamesRequester _breedNamesRequester;

        public MainUIPresenter(MainView view,
            WeatherRequester weatherRequester,
            EnergyRecharger energyRecharge,
            AutoClicker autoClicker,
            BreedNamesRequester breedNamesRequester)
        {
            _view = view;
            _weatherRequester = weatherRequester;
            _energyRecharger = energyRecharge;
            _autoClicker = autoClicker;
            _breedNamesRequester = breedNamesRequester;
        }
        
        public void Initialize()
        {
            _view.OnClickerActive += _energyRecharger.StartRecharge;
            _view.OnClickerActive += _autoClicker.StartClicks;
            _view.OnWeatherActive += _weatherRequester.StartSendRequests;
            _view.OnDogsActive += _breedNamesRequester.SendNamesRequest;
        }

        public void Dispose()
        {
            _view.OnClickerActive -= _energyRecharger.StartRecharge;
            _view.OnClickerActive -= _autoClicker.StartClicks;
            _view.OnWeatherActive -= _weatherRequester.StartSendRequests;
            _view.OnDogsActive -= _breedNamesRequester.SendNamesRequest;

        }
    }
}