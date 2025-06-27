using System;
using Newtonsoft.Json;

namespace _Project.Scripts.Weather
{
    [Serializable]
    public class WeatherData
    {
        [JsonProperty("@context")]
        public object[] Context { get; set; }
    
        public string type { get; set; }
    
        public Geometry geometry { get; set; }
    
        public Properties properties { get; set; }
    }

    [Serializable]
    public class Geometry
    {
        public string type { get; set; }
        public float[][][] coordinates { get; set; }
    }

    [Serializable]
    public class Properties
    {
        public string units { get; set; }
        public Period[] periods { get; set; }
    }

    [Serializable]
    public class Period
    {
        public int number { get; set; }
        public string name { get; set; }
        public int temperature { get; set; }
        public string temperatureUnit { get; set; }
    }
}