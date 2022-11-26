using AireLogic.CookieClicker.Tests.Config;
using AireLogic.CookieClicker.Tests.Helpers;
using AireLogic.CookieClicker.Tests.POM;
using NUnit.Framework;

namespace AireLogic.CookieClicker.Tests.Scripts
{
    class GameTests : TestConfig
    {

        /// <summary>
        /// Enters a name, starts the game and verifies the welcome message is correct
        /// </summary>
        [Test]
        public void StartNewGameTest()
        {
            var landingPage = new LandingPage(Driver);
            var gamePage = new GamePage(Driver);
            var username = TestUtils.GenerateTestName();

            landingPage.EnterName(username);
            landingPage.StartGame();
            gamePage.WaitForPageToLoad();
            gamePage.VerifyWelcomeMessage(username);
        }

        /// <summary>
        /// Starts a new game and verifies that the user can click to gain cookies
        /// </summary>
        [Test]
        public void ClickCookieTest()
        {
            var landingPage = new LandingPage(Driver);
            var gamePage = new GamePage(Driver);
            var username = TestUtils.GenerateTestName();

            landingPage.EnterName(username);
            landingPage.StartGame();
            gamePage.WaitForPageToLoad();

            // Verifies each cookie increments the total by 1
            for (int i = 0; i < 10; i++)
                gamePage.AddCookie(true);

        }

        /// <summary>
        /// Starts a game and verifies the user is able to click and sell a cookie for $0.25
        /// </summary>
        [Test]
        public void SellCookiesTest()
        {
            var landingPage = new LandingPage(Driver);
            var gamePage = new GamePage(Driver);
            var username = TestUtils.GenerateTestName();

            landingPage.EnterName(username);
            landingPage.StartGame();
            gamePage.WaitForPageToLoad();
            gamePage.AddCookie();
            gamePage.SellCookies(1);

        }

        /// <summary>
        /// Accumulates money and verifies the user can buy a factory
        /// </summary>
        [Test]
        public void BuyFactoriesTest()
        {
            var landingPage = new LandingPage(Driver);
            var gamePage = new GamePage(Driver);
            var username = TestUtils.GenerateTestName();

            landingPage.EnterName(username);
            landingPage.StartGame();
            gamePage.WaitForPageToLoad();

            for (int i = 0; i < 15; i++)
                gamePage.AddCookie();

            // For purposes of this tech test I'm adding a work around for cookie min being 1
            gamePage.SellCookies(12);
            gamePage.BuyFactories(1);
        }
    }
}
