using UnityEngine;
using UnityEngine.UI;

namespace _Project.Scripts.Clicker
{
    [CreateAssetMenu(fileName = "AnimationsData", menuName = "AnimationsData", order = 0)]
    public class VFXData : ScriptableObject
    {
        [field: SerializeField] public AudioClip AudioClip;
        [field: SerializeField] public ParticleSystem ParticleSystem;
        [field: SerializeField] public float DurationPunch { get; private set; }
        [field: SerializeField] public float DurationRotation{ get; private set; }
        [field: SerializeField] public float DurationMove { get; private set; }
        [field: SerializeField] public float DurationFade { get; private set; }
        [field: SerializeField] public float MoveDistance { get; private set; }
        [field: SerializeField] public int CountAnimateObjects { get; private set; }
        [field: SerializeField] public Image PrefabAnimationObject { get; private set; }
    }
}