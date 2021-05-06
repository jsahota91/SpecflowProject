using System;
using TechTalk.SpecFlow;
using NUnit.Framework;
using System.Threading;

namespace AutomationPracticeTestFramework.BDD
{
    [Binding]
    public class AP_SigninSteps
    {
        private AP_Website _website = new AP_Website("chrome");
        [Given(@"I am on the signin page")]
        public void GivenIAmOnTheSigninPage()
        {
            _website.AP_SigninPage.VisitSignInPage();
        }
        
        [Given(@"I have entered the email ""(.*)""")]
        public void GivenIHaveEnteredTheEmail(string email)
        {
            _website.AP_SigninPage.GetEmailInput(email);
        }
        
        [Given(@"I have entered the password (.*)")]
        public void GivenIHaveEnteredThePassword(string password)
        {
            _website.AP_SigninPage.GetPasswordInput(password);
        }
        
        [When(@"I click the sign in button")]
        public void WhenIClickTheSignInButton()
        {
            _website.AP_SigninPage.ClickSignInButton();
        }
        
        [Then(@"I should see an alert containing the error message ""(.*)""")]
        public void ThenIShouldSeeAnAlertContainingTheErrorMessage(string alertmsg)
        {
            Assert.That(_website.AP_SigninPage.AlertMessage(), Does.Contain(alertmsg));
        }

        [Given(@"I have not entered the email ""(.*)""")]
        public void GivenIHaveNotEnteredTheEmail(string email)
        {
            _website.AP_SigninPage.GetEmailInput(email);
        }

        [Given(@"I have entered a password ""(.*)""")]
        public void GivenIHaveEnteredAPassword(string password)
        {
            _website.AP_SigninPage.GetPasswordInput(password);
        }


        [Given(@"I am on the home page")]
        public void GivenIAmOnTheHomePage()
        {
            _website.AP_HomePage.VisitHomePage();
        }

        [Given(@"I have clicked the signin link")]
        public void GivenIHaveClickedTheSigninLink()
        {
            _website.AP_HomePage.ClickSignInLink();
            Thread.Sleep(2000);
        }

        [Then(@"I will be on the sigin page")]
        public void ThenIWillBeOnTheSiginPage()
        {
            Assert.That(_website.GetPageTitle(), Is.EqualTo("Login - My Store"));
        }


        [AfterScenario]
        public void DisposeWebDriver()
        {
            _website.SeleniumDriver.Quit();
            _website.SeleniumDriver.Dispose();
        }
    }
}
