using DG.Tweening;
using UnityEngine;

namespace _Project.Scripts.Common.DOTweenServices
{
    public class PunchScale
    {
        public void Punch(RectTransform transform, Vector3 baseScale, float duration)
        {
            transform.DOKill();
            Vector3 originalScale = transform.localScale;
            Vector3 smallerScale = originalScale * 0.9f; 
            Vector3 biggerScale = originalScale * 1.1f; 
    
            Sequence pulseSequence = DOTween.Sequence();
            pulseSequence.Append(transform.DOScale(smallerScale, duration)); 
            pulseSequence.Append(transform.DOScale(biggerScale, duration)); 
            pulseSequence.Append(transform.DOScale(baseScale, duration));
            pulseSequence.SetEase(Ease.OutQuad);
        }
    }
}