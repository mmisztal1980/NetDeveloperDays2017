using DemoApp.E2E.Tests.Pages;
using OpenQA.Selenium.PhantomJS;
using Shouldly;
using Xunit;

namespace DemoApp.E2E.Tests
{
    public class StationsPageTests : E2ETestFixture<PhantomJSDriver>
    {
        [Fact]
        public void WhenNavigatingToStationsPage_UIElementsShouldBeDisplayed()
        {
            var page = StationsPage.NavigateTo(this.Driver);

            page.UpdateStationsButton.Displayed.ShouldBe(true);
            page.StationsTable.Displayed.ShouldBe(true);
        }
    }
}