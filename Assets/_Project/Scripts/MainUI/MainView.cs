using System;
using UnityEngine;
using UnityEngine.UI;

namespace _Project.Scripts.MainUI
{
    public class MainView : MonoBehaviour
    {
        public event Action OnClickerActive;
        public event Action OnWeatherActive;
        public event Action OnDogsActive;
        
        [SerializeField] private Button _buttonClicker;
        [SerializeField] private Button _buttonWeather;
        [SerializeField] private Button _buttonDogsBreeds;
        [SerializeField] private GameObject _clickerPanel;
        [SerializeField] private GameObject _weatherPanel;
        [SerializeField] private GameObject _dogsBreedsPanel;

        private void Start()
        {
            _buttonClicker.onClick.AddListener(ActivateClicker);
            _buttonWeather.onClick.AddListener(ActivateWeather);
            _buttonDogsBreeds.onClick.AddListener(ActivateDogsBreeds);
        }

        private void OnDestroy()
        {
            _buttonClicker.onClick.RemoveListener(ActivateClicker);
            _buttonWeather.onClick.RemoveListener(ActivateWeather);
            _buttonDogsBreeds.onClick.RemoveListener(ActivateDogsBreeds);
        }

        private void ActivateClicker()
        {
            ChangeActivePanels(_clickerPanel);
            OnClickerActive?.Invoke();
        }

        private void ActivateWeather()
        {
            ChangeActivePanels(_weatherPanel);
            OnWeatherActive?.Invoke();
        }

        private void ActivateDogsBreeds()
        {
            ChangeActivePanels(_dogsBreedsPanel);
            OnDogsActive?.Invoke();
        }

        private void ChangeActivePanels(GameObject activePanel)
        {
            _clickerPanel.SetActive(false);
            _weatherPanel.SetActive(false);
            _dogsBreedsPanel.SetActive(false);
            
            activePanel.SetActive(true);
        }
    }
}