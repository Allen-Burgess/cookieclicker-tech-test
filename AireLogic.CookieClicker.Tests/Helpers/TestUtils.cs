using System;

namespace AireLogic.CookieClicker.Tests.Helpers
{
    public static class TestUtils
    {
        /// <summary>
        /// Generates a string out of the date/time to be used as a name in tests
        /// </summary>
        /// <return>String in the format TA followed by date and time</returns>
        public static string GenerateTestName()
        {
            return "TA" + DateTime.Now.ToString("YYmmddhhmmss");
        }
    }
}
