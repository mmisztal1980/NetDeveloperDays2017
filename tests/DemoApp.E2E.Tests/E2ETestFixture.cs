using OpenQA.Selenium;
using System;

namespace DemoApp.E2E.Tests
{
    public class E2ETestFixture<TDriver> : IDisposable
        where TDriver : IWebDriver, new()
    {
        protected IWebDriver Driver { get; }

        protected E2ETestFixture()
        {
            Driver = new TDriver();
        }

        public void Dispose()
        {
            Driver.Quit();
            Driver.Dispose();

            GC.SuppressFinalize(this);
        }
    }
}