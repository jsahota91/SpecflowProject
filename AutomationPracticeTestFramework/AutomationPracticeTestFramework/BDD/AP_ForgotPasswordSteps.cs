using System;
using TechTalk.SpecFlow;
using NUnit.Framework;
using System.Threading;

namespace AutomationPracticeTestFramework.BDD
{
    [Binding]
    public class AP_ForgotPasswordSteps
    {
        private AP_Website _website = new AP_Website("chrome");
        [Given(@"I am currently on the signin page")]
        public void GivenIAmCurrentlyOnTheSigninPage()
        {
            _website.AP_SigninPage.VisitSignInPage();
        }
        
        [Given(@"I have clicked the forgot your password link")]
        public void GivenIHaveClickedTheForgotYourPasswordLink()
        {
            _website.AP_SigninPage.VisitForgotPasswordPage();
        }
        
        [Then(@"I will go to the forgot your password page")]
        public void ThenIWillGoToTheForgotYourPasswordPage()
        {
            Assert.That(_website.AP_ForgotPassword.GetPageTitle(), Is.EqualTo("Forgot your password - My Store"));
        }

        [Given(@"I am on the forgot your password page")]
        public void GivenIAmOnTheForgotYourPasswordPage()
        {
            _website.AP_SigninPage.VisitForgotPasswordPage();
        }

        [Given(@"I enter an unregistered email ""(.*)""")]
        public void GivenIEnterAnUnregisteredEmail(string email)
        {
            _website.AP_SigninPage.GetEmailInput(email);
        }

        [Given(@"I enter an invalid email ""(.*)""")]
        public void GivenIEnterAnInvalidEmail(string invalidEmail)
        {
            _website.AP_SigninPage.GetEmailInput(invalidEmail);
        }

        [Given(@"I enter a registered email ""(.*)""")]
        public void GivenIEnterARegisteredEmail(string registeredEmail)
        {
            _website.AP_SigninPage.GetEmailInput(registeredEmail);
        }

        [When(@"I click retrieve password button")]
        public void WhenIClickRetrievePasswordButton()
        {
            _website.AP_SigninPage.ClickRetrievePasswordButton();
        }

        [Then(@"I will get an alert with the message ""(.*)""")]
        public void ThenIWillGetAnAlertWithTheMessage(string alert)
        {
            Assert.That(_website.AP_SigninPage.AlertMessage(), Does.Contain(alert));
        }

        [AfterScenario]
        public void DisposeWebDriver()
        {
            _website.SeleniumDriver.Quit();
            _website.SeleniumDriver.Dispose();
        }

    }
}
