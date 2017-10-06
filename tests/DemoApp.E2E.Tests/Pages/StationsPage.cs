using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace DemoApp.E2E.Tests.Pages
{
    public class StationsPage
    {
        public static StationsPage NavigateTo(IWebDriver driver)
        {
            driver.Navigate().GoToUrl("http://localhost:8080/Stations/Index");

            return new StationsPage();
        }

        [FindsBy(How = How.Id, Using = "update-stations-btn")]
        public IWebElement UpdateStationsButton { get; set; }

        [FindsBy(How = How.Id, Using = "stations-table")]
        public IWebElement StationsTable { get; set; }
    }
}