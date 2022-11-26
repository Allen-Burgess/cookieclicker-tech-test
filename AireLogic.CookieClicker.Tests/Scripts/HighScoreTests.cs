using AireLogic.CookieClicker.Tests.Config;
using AireLogic.CookieClicker.Tests.Helpers;
using AireLogic.CookieClicker.Tests.POM;
using NUnit.Framework;

namespace AireLogic.CookieClicker.Tests.Scripts
{
    class HighScoreTests : TestConfig
    {
        /// <summary>
        /// Tests that the user's name and score is recorded
        /// </summary>
        [Test]
        public void RecordHighScoreTest()
        {
            var landingPage = new LandingPage(Driver);
            var gamePage = new GamePage(Driver);
            var username = TestUtils.GenerateTestName();

            landingPage.EnterName(username);
            landingPage.StartGame();
            gamePage.WaitForPageToLoad();
            gamePage.AddCookie();
            gamePage.ReturnToLandingPage();
            landingPage.VerifyHighScore(username, 1);
        }

        [Test]
        public void OpenExistingUserTest()
        {
            var landingPage = new LandingPage(Driver);
            var gamePage = new GamePage(Driver);
            var username = TestUtils.GenerateTestName();

            landingPage.EnterName(username);
            landingPage.StartGame();
            gamePage.WaitForPageToLoad();
            gamePage.AddCookie();
            gamePage.ReturnToLandingPage();
            landingPage.OpenExistingUser(username);
            gamePage.WaitForPageToLoad();
            gamePage.VerifyWelcomeMessage(username);
        }
    }
}
