using DG.Tweening;
using UnityEngine;

namespace _Project.Scripts.Common.DOTweenServices
{
    public class MoveItemSystem
    {
        public Tween Move(RectTransform moveObject, float duration, float moveDistance)
        {
            Vector3 startPos = moveObject.position;
            Vector3 endPos = startPos + new Vector3(moveDistance, 0, 0);
        
            return moveObject.DOMoveX(endPos.x, duration)
                .SetEase(Ease.InOutSine);
        }
    }
}