using AireLogic.CookieClicker.Tests.Helpers;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System.Linq;

namespace AireLogic.CookieClicker.Tests.POM
{
    class HighScoreUsers
    {
        public ISearchContext SearchContext { get; set; }
        public IWebDriver Driver { get; set; }

        public HighScoreUsers(ISearchContext searchContext, IWebDriver driver)
        {
            SearchContext = searchContext;
            Driver = driver;
            PageFactory.InitElements(SearchContext, this);
        }

        [FindsBy(How = How.CssSelector, Using = "tr td:nth-child(1) a")]
        public IWebElement Username { get; set; }

        [FindsBy(How = How.CssSelector, Using = "tr td:nth-child(2)")]
        public IWebElement Score { get; set; }


        /// <summary>
		/// Returns a list of all users in high scores on the page 
		/// </summary>
		/// <param name="searchContext">What element/driver to use as the search context</param>
		/// <param name="driver">The web driver</param>
		public static HighScoreUsers[] GetList(ISearchContext searchContext, IWebDriver driver)
        {
            return typeof(HighScoreUsers).ReturnListOfObjects(driver, driver, By.CssSelector("tbody tr")).Cast<HighScoreUsers>().ToArray();
        }

    }
}
