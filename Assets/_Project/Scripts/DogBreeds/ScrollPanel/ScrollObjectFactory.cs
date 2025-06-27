using System.Collections.Generic;
using _Project.Scripts.Common.DOTweenServices;
using _Project.Scripts.DogBreeds.Requester;
using UnityEngine;
using Object = UnityEngine.Object;

namespace _Project.Scripts.DogBreeds
{
    public class ScrollObjectFactory
    {
        private ScrollObjectView _buttonPrefab;
        private Transform _parent;
        private int _poolSize;
        private List<ScrollObjectView> _pool = new List<ScrollObjectView>();
        
        private readonly RotationSystem _rotationSystem = new RotationSystem();
        private readonly BreedInfoModel _breedInfo;
        private readonly BreedDescriptionsRequester _breedDescriptionsRequester;
        private readonly ScrollPanelData _scrollPanelData;
        private readonly ButtonsTweenModel _buttonsTweenModel;

        public ScrollObjectFactory(BreedDescriptionsRequester breedDescriptionsRequester,
            BreedInfoModel breedInfo,
            ScrollPanelData scrollPanelData,
            ButtonsTweenModel buttonsTweenModel)
        {
            _breedDescriptionsRequester = breedDescriptionsRequester;
            _breedInfo = breedInfo;
            _scrollPanelData = scrollPanelData;
            _buttonsTweenModel = buttonsTweenModel;
        }

        public void Init(Transform parent, int poolSize)
        {
            _parent = parent;
            _poolSize = poolSize;

            if (_breedInfo.BreedInfo.data.Count == 0)
            {
                Debug.LogError("Breed Info is empty");
                return;
            }
            
            for (int i = 0; i < _poolSize; i++)
            {
                CreateObject(_breedInfo.BreedInfo.data[i].id, (i+1).ToString(), _breedInfo.BreedInfo.data[i].attributes.name);
            }
        }

        private void CreateObject(string id, string textIndex, string textName)
        {
            ScrollObjectView button = Object.Instantiate(_scrollPanelData.PrefabScrollObject, _parent);
            _pool.Add(button);
            button.Init(id);
            button.ChangeTexts(textIndex, textName);
            button.OnClickForAnimation += AnimateObject;
            button.OnClick += _breedDescriptionsRequester.SendDescriptionRequest;
        }

        private void AnimateObject(RectTransform transform)
        {
            _buttonsTweenModel.StopActiveTween();
            _buttonsTweenModel.SetActiveTween(_rotationSystem.Rotate(transform, _scrollPanelData.SpeedRotate));
        }
    }
}