using System;
using _Project.Scripts.Common.DOTweenServices;
using _Project.Scripts.DogBreeds.Requester;
using DG.Tweening;
using UnityEngine;
using Zenject;

namespace _Project.Scripts.DogBreeds
{
    public class LoadPanelPresenter : IInitializable, IDisposable
    {
        private Tween _tween;
        
        private readonly LoadPanelView _loadPanelView;
        private readonly RotationSystem _rotationSystem = new RotationSystem();
        private readonly BreedNamesRequester _breedNamesRequester;
        private readonly LoadPanelData _loadPanelData;

        public LoadPanelPresenter(LoadPanelView loadPanelView, 
            BreedNamesRequester breedNamesRequester,
            LoadPanelData loadPanelData)
        {
            _loadPanelView = loadPanelView;
            _breedNamesRequester = breedNamesRequester;
            _loadPanelData = loadPanelData;
        }
        
        public void Initialize()
        {
            StartAnimation();
            _breedNamesRequester.OnNamesListLoad += StopAnimation;
            _breedNamesRequester.OnNamesListLoad += _loadPanelView.DeactivatePanel;

        }

        public void Dispose()
        {
            _breedNamesRequester.OnNamesListLoad -= StopAnimation;
            _breedNamesRequester.OnNamesListLoad -= _loadPanelView.DeactivatePanel;
        }

        private void StartAnimation()
        {
            RectTransform rotationObject = _loadPanelView.LoadingImage.GetComponent<RectTransform>();
            _tween =  _rotationSystem.Rotate(rotationObject, _loadPanelData.SpeedRotate);
        }

        private void StopAnimation()
        {
            _tween?.Kill();
        }
    }
}