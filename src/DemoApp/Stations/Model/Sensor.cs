using DemoApp.Model;
using System.Collections.Generic;

namespace DemoApp.Stations.Model
{
    public class Sensor : Entity<long>
    {
        public Station Station { get; set; }

        public List<SensorData> Data { get; set; }
    }
}