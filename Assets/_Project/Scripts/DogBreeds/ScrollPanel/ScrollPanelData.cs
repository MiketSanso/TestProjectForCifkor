using UnityEngine;

namespace _Project.Scripts.DogBreeds
{
    [CreateAssetMenu(fileName = "ScrollPanelData", menuName = "ScrollPanelData", order = 0)]
    public class ScrollPanelData : ScriptableObject
    {
        [field: SerializeField] public ScrollObjectView PrefabScrollObject { get; private set; }
        [field: SerializeField] public float SpeedRotate { get; private set; }
    }
}