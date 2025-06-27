using DG.Tweening;
using UnityEngine;

namespace _Project.Scripts.Common.DOTweenServices
{
    public class RotationSystem
    {
        public Tween Rotate(RectTransform rotateObject, float duration)
        {
            return rotateObject.DORotate(new Vector3(0, 0, -360), duration, RotateMode.LocalAxisAdd)
                .SetEase(Ease.Linear)
                .SetLoops(-1, LoopType.Restart);
        }
    }
}