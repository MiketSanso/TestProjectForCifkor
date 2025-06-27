using UnityEngine;

namespace _Project.Scripts.Weather
{
    [CreateAssetMenu(fileName = "WeatherRequesterData", menuName = "WeatherRequesterData", order = 0)]
    public class WeatherRequesterData : ScriptableObject
    {
        [field: SerializeField] public float TimeDelaySending { get; private set; }
    }
}