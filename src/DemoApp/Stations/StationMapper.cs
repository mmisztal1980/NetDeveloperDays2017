namespace DemoApp.Stations
{
    internal static class StationMapper
    {
        internal static Station MapDtoToDomain(DTO.Station dto)
        {
            var result = new Station()
            {
                Name = dto.Name,
                ExternalId = dto.Id,
                Lon = dto.Lon,
                Lat = dto.Lat
            };

            return result;
        }

        internal static Station MapModelToDomain(Model.Station entity)
        {
            return entity != null ? new Station()
            {
                Id = entity.Id,
                ExternalId = entity.ExternalId,
                Name = entity.Name,
                Lon = entity.Lon,
                Lat = entity.Lat
            } : null;
        }

        internal static Model.Station MapDomainToModel(Station station)
        {
            var result = new Model.Station()
            {
                Name = station.Name,
                ExternalId = station.ExternalId,
                Lon = station.Lon,
                Lat = station.Lat
            };

            return result;
        }
    }
}