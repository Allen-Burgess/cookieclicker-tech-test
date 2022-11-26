using AireLogic.CookieClicker.Tests.POM;
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
            // Starts up new driver and navigates to url
            var driverFactory = new DriverFactory();
            Driver = driverFactory.InitDriver(TestContext.Parameters["BROWSER"]);
            Driver.Url = TestContext.Parameters["URL"];

            // Waits for landing page to load
            var landingPage = new LandingPage(Driver);
            landingPage.WaitForPageToLoad();
        }

        [TearDown]
        protected void Teardown()
        {
            Driver.Quit();
        }
    }
}
