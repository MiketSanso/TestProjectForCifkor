using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace _Project.Scripts.Common.DOTweenServices
{
    public class FadeSystem
    {
        public void FadeOutImage(Image image, float duration)
        {
            float targetAlpha = 0f;
            Color startColor = image.color;
            startColor.a = 1f;
            image.color = startColor;

            image.DOFade(targetAlpha, duration)
                .SetEase(Ease.InOutSine);
        }
    }
}