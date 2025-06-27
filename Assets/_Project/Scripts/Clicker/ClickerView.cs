using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace _Project.Scripts.Clicker
{
    public class ClickerView : MonoBehaviour
    {
        public event Action OnClickAnimation;
        public event Action OnButtonClick;
        
        [SerializeField] private Slider _slider;
        [SerializeField] private TMP_Text _textEnergy;
        [SerializeField] private TMP_Text _textMoney;
        [SerializeField] private Button _button;
        
        [field: SerializeField] public RectTransform TransformButton { get; private set; }

        private void Start()
        {
            _button.onClick.AddListener(Click);
        }

        private void OnDestroy()
        {
            _button.onClick.RemoveListener(Click);
        }

        public void ChangeEnergy(float valueEnergy, string textEnergy)
        {
            _slider.value = valueEnergy;
            _textEnergy.text = textEnergy;
        }

        public void ChangeMoney(string textMoney)
        {
            _textMoney.text = textMoney;
        }

        private void Click()
        {
            OnButtonClick?.Invoke();
            OnClickAnimation?.Invoke();
        }
    }
}