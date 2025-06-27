using System;
using _Project.Scripts.DogBreeds.Requester;
using Zenject;

namespace _Project.Scripts.DogBreeds
{
    public class ScrollPanelPresenter : IInitializable, IDisposable
    {
        private readonly BreedNamesRequester _breedNamesRequester;
        private readonly ScrollObjectFactory _scrollObjectFactory;
        private readonly ScrollPanelView _scrollPanelView;
        private readonly BreedInfoModel _breedInfo;

        public ScrollPanelPresenter(BreedNamesRequester breedNamesRequester,
            ScrollPanelView scrollPanelView,
            ScrollObjectFactory scrollObjectFactory,
            BreedInfoModel breedInfo)
        {
            _breedNamesRequester = breedNamesRequester;
            _scrollPanelView = scrollPanelView;
            _scrollObjectFactory = scrollObjectFactory;
            _breedInfo = breedInfo;
        }
        
        public void Initialize()
        {
            _breedNamesRequester.OnNamesListLoad += CreateObjects;
        }

        public void Dispose()
        {
            _breedNamesRequester.OnNamesListLoad -= CreateObjects;
        }

        private void CreateObjects()
        {
            _scrollObjectFactory.Init(_scrollPanelView.ParentObjectSpawn, _breedInfo.BreedInfo.data.Count);
        }
    }
}