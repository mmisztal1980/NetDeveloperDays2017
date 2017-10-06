using Newtonsoft.Json;

namespace DemoApp.DTO
{
    public class Station
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("stationName")]
        public string Name { get; set; }

        [JsonProperty("gegrLon")]
        public double Lon { get; set; }

        [JsonProperty("gegrLat")]
        public double Lat { get; set; }

        [JsonProperty("addressStreet")]
        public string Address { get; set; }

        [JsonProperty("city")]
        public City City { get; set; }
    }

    public class City
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("commune")]
        public Commune Commune { get; set; }
    }

    public class Commune
    {
        [JsonProperty("provinceName")]
        public string Province { get; set; }

        [JsonProperty("districtName")]
        public string District { get; set; }

        [JsonProperty("communeName")]
        public string Name { get; set; }
    }
}