using DemoApp.DTO;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace DemoApp.Stations.Services
{
    public sealed class GiosApiService : ISensorApiService
    {
        public const string ApiBaseAddress = "http://api.gios.gov.pl";
        private readonly HttpClient client = new HttpClient() { BaseAddress = new Uri(ApiBaseAddress) };

        public async Task<DTO.Station[]> GetAllStationsAsync()
        {
            return await GetDeserializedResponseAsync<DTO.Station[]>("/pjp-api/rest/station/findAll");
        }

        public async Task<SensorData> GetSensorData(DTO.Sensor sensor)
        {
            return await GetDeserializedResponseAsync<SensorData>($"/pjp-api/rest/data/getData/{sensor.Id}");
        }

        public async Task<DTO.Sensor[]> GetStationSensors(DTO.Station station)
        {
            return await GetDeserializedResponseAsync<DTO.Sensor[]>($"/pjp-api/rest/station/sensors/{station.Id}");
        }

        private static T DeserializeFromString<T>(string response)
        {
            return JsonConvert.DeserializeObject<T>(response);
        }

        private async Task<T> GetDeserializedResponseAsync<T>(string query)
        {
            return DeserializeFromString<T>(await client.GetStringAsync(query));
        }
    }
}