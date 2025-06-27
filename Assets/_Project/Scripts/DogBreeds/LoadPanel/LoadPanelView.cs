using UnityEngine;
using UnityEngine.UI;

namespace _Project.Scripts.DogBreeds
{
    public class LoadPanelView : MonoBehaviour
    {
        [SerializeField] private GameObject _panel;
        [field: SerializeField] public Image LoadingImage { get; private set; }

        public void DeactivatePanel()
        {
            _panel.SetActive(false);
        }
    }
}