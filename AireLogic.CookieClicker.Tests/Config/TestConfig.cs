using NUnit.Framework;
using OpenQA.Selenium;

namespace AireLogic.CookieClicker.Tests.Config
{
    abstract class TestConfig
    {
        protected IWebDriver Driver { get; set; }

        [SetUp]
        protected void SetUp()
        {
            var driverFactory = new DriverFactory();
            Driver = driverFactory.InitDriver(TestContext.Parameters["BROWSER"]);
        }

        [TearDown]
        protected void Teardown()
        {
            Driver.Quit();
        }
    }
}
