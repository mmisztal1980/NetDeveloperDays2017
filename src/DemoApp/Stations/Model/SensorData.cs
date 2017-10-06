using DemoApp.Model;

namespace DemoApp.Stations.Model
{
    public class SensorData : Entity<long>
    {
        public Sensor Sensor { get; set; }
    }
}