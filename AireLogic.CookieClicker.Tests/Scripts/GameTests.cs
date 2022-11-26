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
    }
}
