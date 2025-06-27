using UnityEngine;

namespace _Project.Scripts.DogBreeds.Requester
{
    [CreateAssetMenu(fileName = "ScrollPanelData", menuName = "ScrollPanelData", order = 0)]
    public class BreedsRequesterData : ScriptableObject
    {
        [field: SerializeField] public int CountNames { get; private set; }
    }
}