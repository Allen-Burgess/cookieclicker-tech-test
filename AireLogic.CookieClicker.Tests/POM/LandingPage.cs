using AireLogic.CookieClicker.Tests.Helpers;
using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Linq;

namespace AireLogic.CookieClicker.Tests.POM
{
    class LandingPage : BasePom
    {
        public LandingPage(IWebDriver driver) : base(driver) { }

        [FindsBy(How = How.XPath, Using = "//input[@name='name']")]
        public IWebElement NameTextField { get; set; }

        [FindsBy(How = How.XPath, Using = "//button[text()='Start!']")]
        public IWebElement StartButton { get; set; }

        public void EnterName(string name)
        {
            NameTextField.SendKeys(name);
        }

        public void OpenExistingUser(string username)
        {
            var users = HighScoreUsers.GetList(Driver, Driver);
            users.Single(user => user.Username.Text.Equals(username)).Username.Click();
        }

        public void StartGame()
        {
            StartButton.Click();
        }

        public void VerifyHighScore(string username, int score)
        {
            var users = HighScoreUsers.GetList(Driver, Driver);
            // Gets the user with the same username
            var user = users.Single(user => user.Username.Text.Equals(username));

            Assert.True(Convert.ToInt32(user.Score.Text).Equals(score),
                $"Invalid score displayed for user $'{username}' - expected: {score}, actual: {user.Score.Text}");

        }

        public void WaitForPageToLoad()
        {
            Driver.WaitForElementToBeVisible(By.XPath("//h1[text()='Cookie Clicker!']"));
        }
    }
}
