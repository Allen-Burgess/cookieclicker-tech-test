﻿using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AireLogic.CookieClicker.Tests.Helpers
{
    public static class SeleniumUtils
    {
        /// <summary>
        /// Waits for element to be visible on page
        /// </summary>
        /// <param name="driver">web driver</param>
        /// <param name="locator">element locator</param>
        /// <param name="timeout">wait timeout in seconds</param>
        public static void WaitForElementToBeVisible(this IWebDriver driver, By locator, int timeout = 30)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeout));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(locator));
        }

        public static List<dynamic> ReturnListOfObjects(this Type type, ISearchContext container, IWebDriver driver, By objContainer)
        {
            List<IWebElement> objElement = container.FindElements(objContainer).ToList();
            List<dynamic> objList = new List<dynamic>();

            foreach (var element in objElement)
            {
                dynamic obj = Activator.CreateInstance(type, element, driver);
                objList.Add(obj);
            }

            return objList;
        }
    }
}
