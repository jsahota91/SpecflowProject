using System;
using TechTalk.SpecFlow;
using NUnit.Framework;
using System.Threading;

namespace AutomationPracticeTestFramework.BDD
{
    [Binding]
    public class AP_CreateAccountSteps
    {
        private AP_Website _website = new AP_Website("chrome");

        [Given(@"I go to the signin page")]
        public void GivenIGoToTheSigninPage()
        {
            _website.AP_SigninPage.VisitSignInPage();
        }

        [Given(@"I have entered an exisiting email ""(.*)""")]
        public void GivenIHaveEnteredAnExisitingEmail(string email)
        {
            //_website.AP_SigninPage.VisitSignInPage();
            _website.AP_CreateAccount.GetEmailInput(email);
        }


        [Then(@"there should be an alert containing the error message ""(.*)""")]
        public void ThenThereShouldBeAnAlertContainingTheErrorMessage(string alertmsg)
        {
            Assert.That(_website.AP_CreateAccount.AlertMessage(), Does.Contain(alertmsg));
        }


        [Given(@"I have entered a valid email ""(.*)""")]
        public void GivenIHaveEnteredAValidEmail(string email)
        {
            _website.AP_CreateAccount.GetEmailInput(email);
        }
        
        [When(@"I click the create account button")]
        public void WhenIClickTheCreateAccountButton()
        {
            _website.AP_CreateAccount.ClickCreateAccountButton();
            Thread.Sleep(5000);
        }


        [Given(@"I have entered an invalid email ""(.*)""")]
        public void GivenIHaveEnteredAnInvalidEmail(string email)
        {
            _website.AP_CreateAccount.GetEmailInput(email);
        }

        [Then(@"I should navigate to the url ""(.*)""")]
        public void ThenIShouldNavigateToTheUrl(string url)
        {
            Assert.That(_website.AP_CreateAccount.SeleniumDriver.Url, Is.EqualTo(url));
        }



        [AfterScenario]
        public void DisposeWebDriver()
        {
            _website.SeleniumDriver.Quit();
            _website.SeleniumDriver.Dispose();
        }
    }
}
