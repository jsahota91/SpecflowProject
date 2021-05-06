using System;
using TechTalk.SpecFlow;
using NUnit.Framework;
using System.Threading;

namespace AutomationPracticeTestFramework.BDD
{
    [Binding]
    public class AP_ProductSteps
    {
        private AP_Website _website = new AP_Website("chrome");
       
        [Given(@"I go to the homepage")]
        public void GivenIGoToTheHomepage()
        {
            _website.AP_HomePage.VisitHomePage();
        }

        [Given(@"I click the T-shirts tab")]
        public void GivenIClickTheT_ShirtsTab()
        {
            _website.AP_ProductPage.TshirtTabBtn();
            Thread.Sleep(2000);
        }
        
        [When(@"I choose an item and click add to cart")]
        public void WhenIChooseAnItemAndClickAddToCart()
        {
            _website.AP_ProductPage.ClickAddToCartBtn();
            Thread.Sleep(2000);
        }
        
        [Then(@"I should get a success alert ""(.*)""")]
        public void ThenIShouldGetASuccessAlert(string successmsg)
        {
            Assert.That(_website.AP_ProductPage.AlertMessage(), Does.Contain(successmsg));
        }

        [AfterScenario]
        public void DisposeWebDriver()
        {
            _website.SeleniumDriver.Quit();
            _website.SeleniumDriver.Dispose();
        }
    }
}
