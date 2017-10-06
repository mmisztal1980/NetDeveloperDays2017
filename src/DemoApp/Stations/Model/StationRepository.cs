using DemoApp.Repositories;
using System.Linq;
using System.Threading.Tasks;

namespace DemoApp.Stations.Model
{
    public class StationRepository : Repository<Station, long>, IStationRepository
    {
        public StationRepository(Context context)
            : base(context)
        {
        }

        public async Task<Stations.Station> GetAsync(long id)
        {
            return await base.GetAsync(id, StationMapper.MapModelToDomain);
        }

        public async Task<Stations.Station[]> GetAsync(long[] ids)
        {
            return await base.GetAsync(ids, StationMapper.MapModelToDomain);
        }

        public async Task<Stations.Station[]> GetByExternalIdAsync(params long[] externalIds)
        {
            return await base.GetAsync(x => externalIds.Contains(x.ExternalId), StationMapper.MapModelToDomain);
        }

        public Task<long> InsertAsync(DemoApp.Stations.Station station)
        {
            return base.InsertAsync(StationMapper.MapDomainToModel(station));
        }

        public Task<long[]> InsertAsync(DemoApp.Stations.Station[] stations)
        {
            var entities = stations.Select(StationMapper.MapDomainToModel).ToArray();

            return base.InsertAsync(entities);
        }
    }
}