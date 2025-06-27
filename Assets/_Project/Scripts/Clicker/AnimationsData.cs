using UnityEngine;
using UnityEngine.UI;

namespace _Project.Scripts.Clicker
{
    [CreateAssetMenu(fileName = "AnimationsData", menuName = "AnimationsData", order = 0)]
    public class AnimationsData : ScriptableObject
    {
        [field: SerializeField] public float Duration { get; private set; }
        [field: SerializeField] public float MoveDistance { get; private set; }
        [field: SerializeField] public int CountAnimateObjects { get; private set; }
        [field: SerializeField] public Image PrefabAnimationObject { get; private set; }
    }
}