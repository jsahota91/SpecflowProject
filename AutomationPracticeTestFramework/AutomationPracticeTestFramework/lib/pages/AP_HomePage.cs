﻿using OpenQA.Selenium;

namespace AutomationPracticeTestFramework
{
    public class AP_HomePage
    {
        public IWebDriver SeleniumDriver { get; }
        private string HomePageUrl = AppConfigReader.BaseUrl;
        private IWebElement _signinLink => SeleniumDriver.FindElement(By.LinkText("Sign in"));

        public AP_HomePage(IWebDriver seleniumDriver)
        {
            SeleniumDriver = seleniumDriver;
        }

        public void VisitHomePage()
        {
            SeleniumDriver.Navigate().GoToUrl(HomePageUrl);
        }

        public void ClickSignInLink()
        {
            _signinLink.Click();
        }

    }
}