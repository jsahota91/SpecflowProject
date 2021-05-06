﻿using System;
using OpenQA.Selenium;


namespace AutomationPracticeTestFramework
{
    public class AP_Website
    {
        public IWebDriver SeleniumDriver { get; internal set; }
        public AP_HomePage AP_HomePage { get; internal set; }
        public AP_SigninPage AP_SigninPage { get; internal set; }
        public AP_CreateAccount AP_CreateAccount { get; internal set; }
        public AP_ForgotPassword AP_ForgotPassword { get; internal set; }
        public AP_ProductPage AP_ProductPage { get; internal set; }

        public AP_Website(string driver, int pageLoadSecs =10, int waitSecs =10)
        {
            //construct and configure the driver
            SeleniumDriver = new SeleniumDriverConfig(driver, pageLoadSecs, waitSecs).Driver;
            //construct the page objects with a reference to the driver
            AP_HomePage = new AP_HomePage(SeleniumDriver);
            AP_SigninPage = new AP_SigninPage(SeleniumDriver);
            AP_CreateAccount = new AP_CreateAccount(SeleniumDriver);
            AP_ForgotPassword = new AP_ForgotPassword(SeleniumDriver);
            AP_ProductPage = new AP_ProductPage(SeleniumDriver);
        }

        //delete cookies (optional)
        public void DeleteCookies()
        {
            SeleniumDriver.Manage().Cookies.DeleteAllCookies();
        }

        public string GetPageTitle()
        {
            return SeleniumDriver.Title;
        }
    }
}
