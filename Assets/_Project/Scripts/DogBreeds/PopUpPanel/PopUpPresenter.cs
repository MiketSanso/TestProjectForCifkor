using System;
using _Project.Scripts.DogBreeds.Requester;
using Zenject;

namespace _Project.Scripts.DogBreeds
{
    public class PopUpPresenter : IInitializable, IDisposable
    {
        private readonly PopUpView _popUpView;
        private readonly BreedDescriptionsRequester _breedDescriptionsRequester;
        private readonly ButtonsTweenModel _buttonsTweenModel;

        public PopUpPresenter(PopUpView popUpView, 
            BreedDescriptionsRequester breedDescriptionsRequester,
            ButtonsTweenModel buttonsTweenModel)
        {
            _popUpView = popUpView;
            _breedDescriptionsRequester = breedDescriptionsRequester;
            _buttonsTweenModel = buttonsTweenModel;
        }

        public void Initialize()
        {
            _breedDescriptionsRequester.OnDetailsLoad += ActivatePanel;
        }

        public void Dispose()
        {
            _breedDescriptionsRequester.OnDetailsLoad -= ActivatePanel;
        }

        private void ActivatePanel(BreedDetailsResponse breedDetails)
        {
            _popUpView.ActivatePanel();
            _popUpView.ChangeTextsPopup(breedDetails.data.attributes.name, breedDetails.data.attributes.description);
            _buttonsTweenModel.StopActiveTween();
        }
    }
}