using DemoApp.Model;
using System.Collections.Generic;

namespace DemoApp.Stations.Model
{
    public class Station : Entity<long>, IAggregateRoot
    {
        public long ExternalId { get; set; }
        public double Lat { get; set; }
        public double Lon { get; set; }
        public string Name { get; set; }
        public List<Sensor> Sensors { get; set; }
    }
}