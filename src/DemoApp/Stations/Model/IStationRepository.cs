using System.Threading.Tasks;

namespace DemoApp.Stations.Model
{
    public interface IStationRepository
    {
        Task<DemoApp.Stations.Station> GetAsync(long id);

        Task<DemoApp.Stations.Station[]> GetAsync(long[] ids);

        Task<DemoApp.Stations.Station[]> GetByExternalIdAsync(params long[] ids);

        Task<long> InsertAsync(DemoApp.Stations.Station station);

        Task<long[]> InsertAsync(DemoApp.Stations.Station[] stations);
    }
}