using AireLogic.CookieClicker.Tests.Helpers;
using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Threading;

namespace AireLogic.CookieClicker.Tests.POM
{
    class GamePage : BasePom
    {
        public GamePage(IWebDriver driver) : base(driver) { }


        [FindsBy(How = How.CssSelector, Using = "h1 a")]
        public IWebElement TitleLink { get; set; }

        [FindsBy(How = How.CssSelector, Using = "body p:nth-child(2)")]
        public IWebElement WelcomeMessage { get; set; }

        [FindsBy(How = How.Id, Using = "cookies")]
        public IWebElement CookieBalance { get; set; }

        [FindsBy(How = How.Id, Using = "factories")]
        public IWebElement Factories { get; set; }

        [FindsBy(How = How.Id, Using = "money")]
        public IWebElement Money { get; set; }

        [FindsBy(How = How.Id, Using = "click")]
        public IWebElement ClickCookieButton { get; set; }

        [FindsBy(How = How.Id, Using = "cookies-to-sell")]
        public IWebElement SellCookiesField { get; set; }

        [FindsBy(How = How.Id, Using = "sell-cookies")]
        public IWebElement SellCookiesButton { get; set; }

        [FindsBy(How = How.Id, Using = "factories-to-buy")]
        public IWebElement BuyFactoriesField { get; set; }

        [FindsBy(How = How.Id, Using = "buy-factories")]
        public IWebElement BuyFactoriesButton { get; set; }



        public void AddCookie(bool verifyIncrement = false)
        {
            // Records the cookie balance before and after
            int cookiesBefore = Convert.ToInt32(CookieBalance.Text.Trim());

            ClickCookieButton.Click();
            Thread.Sleep(250); // Gives time for cookies to update

            int cookiesAfter = Convert.ToInt32(CookieBalance.Text.Trim());

            // Will only verify the increment if specified prior incase any factories have been bought
            if (verifyIncrement)
                Assert.True(cookiesAfter.Equals(cookiesBefore + 1), 
                    $"Cookies did not increment as expected after adding a cookie - expected cookies: {cookiesBefore + 1}, actual: {cookiesAfter}");
        }

        public void BuyFactories(int factories)
        {
            double moneyBefore = Convert.ToDouble(Money.Text);
            int factoriesBefore = Convert.ToInt32(Factories.Text);

            BuyFactoriesField.SendKeys(factories.ToString());
            BuyFactoriesButton.Click();

            Thread.Sleep(250); // Gives time for fields to update

            double moneyAfter = Convert.ToDouble(Money.Text);
            int factoriesAfter = Convert.ToInt32(Factories.Text);

            double buyPrice = factories * 3.00;

            Assert.True(factoriesAfter.Equals(factoriesBefore + factories),
                $"Invalid number of factories - expected: {factoriesBefore + factories}, actual: {factoriesAfter}");

            Assert.True(moneyAfter.Equals(moneyBefore - buyPrice),
                $"Invalid value deducted purchasing factory - expected: {(moneyBefore - buyPrice)}, actual: {this.Money}");

        }

        public void ReturnToLandingPage()
        {
            TitleLink.Click();
        }

        public void SellCookies(int cookies)
        {
            double moneyBefore = Convert.ToDouble(Money.Text);

            SellCookiesField.SendKeys(cookies.ToString());
            SellCookiesButton.Click();

            Thread.Sleep(250); // Gives time for fields to update

            double moneyAfter = Convert.ToDouble(Money.Text);
            double sellPrice = cookies * 0.25;

            Assert.True(moneyAfter.Equals(moneyBefore + sellPrice), 
                $"Invalid cash balance after selling cookie - actual: {moneyAfter}, expected: {moneyBefore + sellPrice}");
        }

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
