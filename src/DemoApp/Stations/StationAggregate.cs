using DemoApp.Stations.Model;
using System.Linq;
using System.Threading.Tasks;

namespace DemoApp.Stations
{
    public static class StationAggregate
    {
        public static async Task<Station> LoadAsync(IStationRepository repository, long id)
        {
            return await repository.GetAsync(id);
        }

        public static async Task<Station> NewAsync(IStationRepository repository, DTO.Station dto)
        {
            var result = StationMapper.MapDtoToDomain(dto);

            result.Id = await repository.InsertAsync(result);

            return result;
        }

        public static async Task<Station[]> NewAsync(IStationRepository repository, DTO.Station[] dtos)
        {
            var stations = dtos.Select(StationMapper.MapDtoToDomain)
                .ToArray();

            var ids = await repository.InsertAsync(stations);

            return await repository.GetAsync(ids);
        }
    }
}