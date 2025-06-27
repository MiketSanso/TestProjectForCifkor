using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace _Project.Scripts.DogBreeds
{
    public class ScrollObjectView : MonoBehaviour
    {
        public event Action<RectTransform> OnClickForAnimation;
        public event Action<string> OnClick;
        
        [SerializeField] private Button _button;
        [SerializeField] private TMP_Text _textIndex;
        [SerializeField] private TMP_Text _textName;
        [SerializeField] private Image _imageLoad;

        private string _id;

        public RectTransform LoadImage { get; private set;  }

        public void Init(string id)
        {
            _id = id;
        }

        public void ChangeTexts(string textIndex, string textName)
        {
            _textIndex.text = textIndex;
            _textName.text = textName;
        }
        
        private void Start()
        {
            _button.onClick.AddListener(Click);
        }

        private void OnDestroy()
        {
            _button.onClick.RemoveListener(Click);
        }
        
        private void Click()
        {
            OnClickForAnimation?.Invoke(_imageLoad.GetComponent<RectTransform>());
            _imageLoad.gameObject.SetActive(true);
            OnClick?.Invoke(_id);
        }
    }
}