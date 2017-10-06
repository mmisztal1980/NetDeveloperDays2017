using DemoApp.DTO;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DemoApp.Stations.Services
{
    public class FakeGiosApiService : ISensorApiService
    {
        public async Task<DTO.Station[]> GetAllStationsAsync()
        {
            return await Task.FromResult<DTO.Station[]>(new[]
            {
                new DTO.Station() { Id = 1, Name = "Station-1", Lon = 21.0, Lat = 53 },
                new DTO.Station() { Id = 2, Name = "Station-2", Lon = 22.0, Lat = 52 },
                new DTO.Station() { Id = 3, Name = "Station-3", Lon = 23.0, Lat = 51 },
            });
        }

        public Task<SensorData> GetSensorData(DTO.Sensor sensor)
        {
            throw new NotImplementedException();
        }

        public async Task<DTO.Sensor[]> GetStationSensors(DTO.Station station)
        {
            return await Task.FromResult<DTO.Sensor[]>(new[]
            {
                new DTO.Sensor()
                {
                    StationId = station.Id,
                    Id = 1,
                    Params = new Dictionary<string, string>() {{ "paramCode", "NO2"}}
                },
                new DTO.Sensor()
                {
                    StationId = station.Id,
                    Id = 2,
                    Params = new Dictionary<string, string>() {{ "paramCode", "O3"}}
                },
                new DTO.Sensor()
                {
                    StationId = station.Id,
                    Id = 3,
                    Params = new Dictionary<string, string>() {{"paramCode", "SO2"}}
                }
            });
        }
    }
}