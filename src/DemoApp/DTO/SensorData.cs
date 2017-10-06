using Newtonsoft.Json;
using System;

namespace DemoApp.DTO
{
    public class SensorData
    {
        [JsonProperty("key")]
        public string Key { get; set; }

        [JsonProperty("values")]
        public SensorDataPoint[] Values { get; set; }
    }

    public class SensorDataPoint
    {
        [JsonProperty("date")]
        public DateTime Date { get; set; }

        [JsonProperty("value")]
        public double? Value { get; set; }
    }
}