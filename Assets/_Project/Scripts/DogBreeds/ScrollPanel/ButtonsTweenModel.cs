using DG.Tweening;
using UnityEngine;

namespace _Project.Scripts.DogBreeds
{
    public class ButtonsTweenModel
    {
        private Tween _tween;

        public void SetActiveTween(Tween tween)
        {
            _tween = tween;
        }
        
        public void StopActiveTween()
        {
            if (_tween != null)
            {
                RectTransform targetTransform = _tween.target as RectTransform;

                if (targetTransform != null)
                    targetTransform.gameObject.SetActive(false);

                _tween.Kill();
            }
        }
    }
}