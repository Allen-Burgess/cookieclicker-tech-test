using AireLogic.CookieClicker.Tests.Helpers;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

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

        public void StartGame()
        {
            StartButton.Click();
        }

        public void WaitForPageToLoad()
        {
            Driver.WaitForElementToBeVisible(By.XPath("//h1[text()='Cookie Clicker!']"));
        }
    }
}
