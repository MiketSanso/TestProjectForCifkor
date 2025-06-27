using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace _Project.Scripts.DogBreeds
{
    public class PopUpView : MonoBehaviour
    {
        [SerializeField] private GameObject _popUp;
        [SerializeField] private Button _button;
        [SerializeField] private TMP_Text _textTitle;
        [SerializeField] private TMP_Text _textDescription;
        [SerializeField] private Image _background;

        private void Start()
        {
            _button.onClick.AddListener(Click);
        }
        
        private void OnDestroy()
        {
            _button.onClick.RemoveListener(Click);
        }

        public void ActivatePanel()
        {
            _popUp.SetActive(true);
        }

        public void ChangeTextsPopup(string textTitile, string textDescription)
        {
            _textTitle.text = textTitile;
            _textDescription.text = textDescription;
        }

        private void Click()
        {
            _popUp.SetActive(false);
        }
    }
}