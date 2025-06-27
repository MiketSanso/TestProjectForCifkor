using _Project.Scripts.Clicker;
using _Project.Scripts.DogBreeds;
using _Project.Scripts.DogBreeds.Requester;
using _Project.Scripts.MainUI;
using _Project.Scripts.Weather;
using UnityEngine;
using Zenject;

namespace _Project.Scripts.Infrastructure
{
    public class SceneInstaller : MonoInstaller
    {
        [SerializeField] private WeatherView _weatherView;
        [SerializeField] private WeatherRequesterData _weatherRequesterData;
        [SerializeField] private MainView _mainUIPresenter;
        [SerializeField] private ClickerView _clickerView;
        [SerializeField] private ClickerData _clickerData;
        [SerializeField] private LoadPanelView _loadPanelView;
        [SerializeField] private BreedsRequesterData _breedsRequesterData;
        [SerializeField] private LoadPanelData _loadPanelData;
        [SerializeField] private ScrollPanelData _scrollPanelData;
        [SerializeField] private ScrollPanelView _scrollPanelView;
        [SerializeField] private PopUpView _popUpView;
        [SerializeField] private PanelBreedsView _panelBreedsView;
        
        public override void InstallBindings()
        {
            BindClicker();
            BindWeather();
            BindDogBreeds();
            
            Container.BindInterfacesAndSelfTo<MainUIPresenter>().AsSingle().WithArguments(_mainUIPresenter);
        }

        private void BindClicker()
        {
            Container.Bind<ClickerModel>().AsSingle().WithArguments(_clickerData);
            Container.BindInterfacesAndSelfTo<ClickerPresenter>().AsSingle().WithArguments(_clickerView,_clickerData);
            Container.Bind<EnergyRecharger>().AsSingle().WithArguments(_clickerData);
            Container.Bind<AutoClicker>().AsSingle().WithArguments(_clickerData);
        }

        private void BindWeather()
        {
            Container.BindInterfacesAndSelfTo<WeatherPresenter>().AsSingle().WithArguments(_weatherView);
            Container.Bind<WeatherRequester>().AsSingle().WithArguments(_weatherRequesterData);
        }

        private void BindDogBreeds()
        {
            Container.Bind<ButtonsTweenModel>().AsSingle();
            Container.Bind<BreedInfoModel>().AsSingle();
            Container.Bind<BreedNamesRequester>().AsSingle().WithArguments(_breedsRequesterData);
            Container.Bind<BreedDescriptionsRequester>().AsSingle();
            Container.Bind<ScrollObjectFactory>().AsSingle().WithArguments(_scrollPanelData);
            Container.BindInterfacesAndSelfTo<PanelBreedsPresenter>().AsSingle().WithArguments(_panelBreedsView);
            Container.BindInterfacesAndSelfTo<ScrollPanelPresenter>().AsSingle().WithArguments(_scrollPanelView);
            Container.BindInterfacesAndSelfTo<PopUpPresenter>().AsSingle().WithArguments(_popUpView);
            Container.BindInterfacesAndSelfTo<LoadPanelPresenter>().AsSingle().WithArguments(_loadPanelView, _loadPanelData);
        }
    }
}