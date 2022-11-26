using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace AireLogic.CookieClicker.Tests.POM
{
    abstract class BasePom
    {
        protected IWebDriver Driver;

        public BasePom(IWebDriver driver)
        {
            Driver = driver;
            PageFactory.InitElements(Driver, this);

        }
    }
}
