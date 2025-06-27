using DG.Tweening;
using UnityEngine;

namespace _Project.Scripts.Common.DOTweenServices
{
    public class MoveItemSystem
    {
        public void Move(RectTransform moveObject, float duration, float moveDistance, Vector3 to)
        {
            Vector3 startPos = moveObject.position;
            Vector3 endPos = startPos + to * moveDistance;
        
            moveObject.DOMove(endPos, duration)
                .SetEase(Ease.InOutSine);
        }
    }
}