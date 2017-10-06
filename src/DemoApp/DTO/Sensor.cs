using Newtonsoft.Json;
using System.Collections.Generic;

namespace DemoApp.DTO
{
    public class Sensor
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("stationId")]
        public long StationId { get; set; }

        [JsonProperty("param")]
        public Dictionary<string, string> Params { get; set; } = new Dictionary<string, string>();
    }
}