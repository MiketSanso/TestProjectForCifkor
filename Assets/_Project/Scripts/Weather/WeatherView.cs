using System;
using TMPro;
using UnityEngine;

namespace _Project.Scripts.Weather
{
    public class WeatherView : MonoBehaviour
    {
        public event Action OnCloseView;
        
        [SerializeField] private TMP_Text text;

        private void OnDisable()
        {
            OnCloseView?.Invoke();
        }
        
        public void ChangeText(string temperature)
        {
            text.text = $"Сегодня: {temperature}";
        }
    }
}