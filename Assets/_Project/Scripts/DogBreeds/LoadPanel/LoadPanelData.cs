using UnityEngine;

namespace _Project.Scripts.DogBreeds
{
    [CreateAssetMenu(fileName = "LoadPanelData", menuName = "LoadPanelData", order = 0)]
    public class LoadPanelData : ScriptableObject
    {
            [field: SerializeField] public float SpeedRotate { get; private set; }
    }
}