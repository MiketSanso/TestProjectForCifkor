using System;
using _Project.Scripts.Common.DOTweenServices;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using Object = UnityEngine.Object;

namespace _Project.Scripts.Clicker.ObjectsPool
{
    public class ImageFactory
    {
        private readonly VFXData _vfxData;
        private readonly Transform _objectsParent;
        private readonly MoveItemSystem _moveItemSystem = new MoveItemSystem();
        private readonly FadeSystem _fadeSystem = new FadeSystem();

        public AnimationObjectsPool<Image> ObjectsPool { get; private set; }
        
        public ImageFactory(VFXData vfxData,
            Transform transformParent)
        {
            _vfxData = vfxData;
            _objectsParent = transformParent;
            ObjectsPool = new AnimationObjectsPool<Image>(Preload, Get, Return, _vfxData.CountImages);
        }
        
        private Image Preload()
        {
            Image image = Object.Instantiate(_vfxData.PrefabAnimationObject, 
                _objectsParent);
            
            image.gameObject.SetActive(false);

            return image;
        }

        private async void Get(Image image)
        {
            image.gameObject.SetActive(true);
            _fadeSystem.FadeOutImage(image, _vfxData.DurationFade);
            _moveItemSystem.Move(image.GetComponent<RectTransform>(), _vfxData.DurationMove, _vfxData.MoveDistance, Vector3.up);
            
            await UniTask.Delay(TimeSpan.FromSeconds(_vfxData.TimeReturnImages));

                ObjectsPool.Return(image);
        }

        private void Return(Image image)
        {
            image.gameObject.SetActive(false);
        }
    }
}