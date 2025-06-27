using System;
using _Project.Scripts.DogBreeds.Requester;
using Zenject;

namespace _Project.Scripts.DogBreeds
{
    public class PanelBreedsPresenter : IInitializable, IDisposable
    {
        private readonly PanelBreedsView _panelBreedsView;
        private readonly BreedNamesRequester _breedNamesRequester;
        private readonly BreedDescriptionsRequester _breedDescriptionsRequester;

        public PanelBreedsPresenter(PanelBreedsView panelBreedsView,
            BreedNamesRequester breedNamesRequester,
            BreedDescriptionsRequester breedDescriptionsRequester)
        {
            _panelBreedsView = panelBreedsView;
            _breedNamesRequester = breedNamesRequester;
            _breedDescriptionsRequester = breedDescriptionsRequester;
        }

        public void Initialize()
        {
            _panelBreedsView.OnClose += _breedDescriptionsRequester.StopRequests;
            _panelBreedsView.OnClose += _breedNamesRequester.StopRequests;
        }

        public void Dispose()
        {            
            _panelBreedsView.OnClose -= _breedDescriptionsRequester.StopRequests;
            _panelBreedsView.OnClose -= _breedNamesRequester.StopRequests;
        }
    }
}