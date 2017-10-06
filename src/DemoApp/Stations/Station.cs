namespace DemoApp.Stations
{
    public class Station
    {
        public long ExternalId { get; internal set; }
        public long Id { get; internal set; }
        public double Lat { get; internal set; }
        public double Lon { get; internal set; }
        public string Name { get; internal set; }
    }
}