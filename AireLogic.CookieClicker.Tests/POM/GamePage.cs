using AireLogic.CookieClicker.Tests.Helpers;
using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace AireLogic.CookieClicker.Tests.POM
{
    class GamePage : BasePom
    {
        public GamePage(IWebDriver driver) : base(driver) { }

        [FindsBy(How = How.CssSelector, Using = "h1 a")]
        public IWebElement TitleLink { get; set; }

        [FindsBy(How = How.CssSelector, Using = "body p:nth-child(2)")]
        public IWebElement WelcomeMessage { get; set; }

        public void VerifyWelcomeMessage(string username)
        {
            Assert.True(WelcomeMessage.Text.Equals("Hello " + username), $"Invalid welcome message - expected: 'Hello {username}', actual '{WelcomeMessage.Text}'");
        }

        public void WaitForPageToLoad()
        {
            Driver.WaitForElementToBeVisible(By.XPath("//h1/a[text()='Cookie Clicker!']"));
        }
    }
}
