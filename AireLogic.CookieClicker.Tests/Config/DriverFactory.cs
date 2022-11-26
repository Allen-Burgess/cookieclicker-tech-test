using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using System;

namespace AireLogic.CookieClicker.Tests.Config
{
    class DriverFactory
    {
        public IWebDriver InitDriver(string browser)
        {
            IWebDriver driver = browser.ToLower() switch
            {
                "chrome" => new ChromeDriver(),
                "firefox" => new FirefoxDriver(),
                "edge" => new EdgeDriver(),
                _ => throw new NotSupportedException($"Browser: '{browser}' not recognised or supported"),
            };

            driver.Manage().Window.Maximize();

            return driver;
        }
    }
}
