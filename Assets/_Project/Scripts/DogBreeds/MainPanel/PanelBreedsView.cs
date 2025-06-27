using System;
using UnityEngine;

namespace _Project.Scripts.DogBreeds
{
    public class PanelBreedsView : MonoBehaviour
    {
        public event Action OnClose;

        private void OnDisable()
        {
            OnClose?.Invoke();
        }
    }
}