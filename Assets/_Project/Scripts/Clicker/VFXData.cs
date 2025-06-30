using UnityEngine;
using UnityEngine.UI;

namespace _Project.Scripts.Clicker
{
    [CreateAssetMenu(fileName = "AnimationsData", menuName = "AnimationsData", order = 0)]
    public class VFXData : ScriptableObject
    {
        [field: SerializeField] public AudioClip AudioClip;
        
        [field: SerializeField] public ParticleSystem PrefabParticleSystem;
        [field: SerializeField] public int CountParticles { get; private set; }
        [field: SerializeField] public float TimeReturnParticles { get; private set; }

        [field: SerializeField] public Image PrefabAnimationObject { get; private set; }
        [field: SerializeField] public float TimeReturnImages { get; private set; }
        [field: SerializeField] public int CountImages { get; private set; }
        [field: SerializeField] public float MoveDistance { get; private set; }
        [field: SerializeField] public float DurationMove { get; private set; }
        [field: SerializeField] public float DurationFade { get; private set; }
        [field: SerializeField] public float DurationPunch { get; private set; }
    }
}