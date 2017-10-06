using DemoApp.Stations.Services;
using Shouldly;
using Xunit;
using Sensor = DemoApp.DTO.Sensor;

namespace DemoApp.Tests
{
    public class GiosApiServiceTests
    {
        public class GivenTheClientIsMakingAnApiCall
        {
            [Fact]
            [Trait(Constants.TestKind, Constants.IntegrationTest)]
            public void WhenCallingGetAllStations_AllStationsArrayShouldBeReturned()
            {
                var svc = new GiosApiService();
                var response = svc.GetAllStationsAsync()
                    .GetAwaiter()
                    .GetResult();

                response.ShouldNotBeNull();
                response.Length.ShouldBeGreaterThan(0);
            }

            [Theory]
            [Trait(Constants.TestKind, Constants.IntegrationTest)]
            [InlineData(236, 3)]
            [InlineData(605, 4)]
            [InlineData(606, 3)]
            public void WhenCallingGetStationSensors_AllStationSensorsShouldBeReturned(int stationId, int expectedSensors)
            {
                var svc = new GiosApiService();
                var response = svc.GetStationSensors(new DTO.Station { Id = stationId })
                    .GetAwaiter()
                    .GetResult();

                response.ShouldNotBeNull();
                response.Length.ShouldBe(expectedSensors);
            }

            [Theory]
            [InlineData(88, "NO2")]
            [InlineData(402, "SO2")]
            [InlineData(4013, "O3")]
            public void WhenCallingGetSensorData_AllRecentSensorDataShouldBeReturned(int sensorId, string expectedKey)
            {
                var svc = new GiosApiService();
                var response = svc.GetSensorData(new Sensor { Id = sensorId })
                    .GetAwaiter()
                    .GetResult();

                response.ShouldNotBeNull();
                response.Key.ShouldBe(expectedKey);
                response.Values.Length.ShouldBeGreaterThan(0);
            }
        }
    }
}