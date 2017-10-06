using DemoApp.DTO;
using System.Threading.Tasks;

namespace DemoApp.Stations.Services
{
    public interface ISensorApiService
    {
        Task<DTO.Station[]> GetAllStationsAsync();

        Task<SensorData> GetSensorData(DTO.Sensor sensor);

        Task<DTO.Sensor[]> GetStationSensors(DTO.Station station);
    }
}