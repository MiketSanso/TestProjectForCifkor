using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace _Project.Scripts.Common.DOTweenServices
{
    public class FadeSystem
    {
        public Tween FadeOutImage(Image image, float duration, float targetAlpha = 0f)
        {
            image.gameObject.SetActive(true);
            Color startColor = image.color;
            startColor.a = 1f;
            image.color = startColor;

            return image.DOFade(targetAlpha, duration)
                .SetEase(Ease.InOutSine)
                .OnComplete(() =>
                {
                    if (targetAlpha <= 0.1f)
                    {
                        image.gameObject.SetActive(false);
                    }
                });
        }
    }
}