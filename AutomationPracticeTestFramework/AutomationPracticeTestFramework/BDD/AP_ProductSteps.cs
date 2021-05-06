﻿using System;
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

        // Click close button
        [When(@"I close the success popup")]
        public void WhenICloseTheSuccessPopup()
        {
            _website.AP_ProductPage.ClickCrossBtn();
        }

        // Change Quantity
        [When(@"I change the quantity to ""(.*)""")]
        public void WhenIChangeTheQuantityTo(string quantity)
        {
            _website.AP_ProductPage.ChangeQuantity(quantity);
        }

        // Click more button
        [When(@"I choose an item and click more")]
        public void WhenIChooseAnItemAndClickMore()
        {
            _website.AP_ProductPage.ClickMoreBtn();
        }

        // Add to cart from product page
        [When(@"I click the product page add to cart")]
        public void WhenIClickTheProductPageAddToCart()
        {
            _website.AP_ProductPage.ClickPPAddToCartBtn();
            Thread.Sleep(2000);
        }

        // Assert Cart Quantity
        [Then(@"The items in the cart should be ""(.*)""")]
        public void ThenTheItemsInTheCartShouldBe(string expecString)
        {
            Assert.That(_website.AP_ProductPage.CartEmpty(), Is.EqualTo(expecString));
        }


        [Then(@"I should get a success alert ""(.*)""")]
        public void ThenIShouldGetASuccessAlert(string successmsg)
        {
            Assert.That(_website.AP_ProductPage.AlertMessage(), Does.Contain(successmsg));
        }

        // Null quantity error pop up
        [Then(@"An error popup should appear with the message ""(.*)""")]
        public void ThenAnErrorPopupShouldAppearWithTheMessage(string expResult)
        {
            Assert.That(_website.AP_ProductPage.NullQuantity(), Is.EqualTo(expResult));
        }


        [AfterScenario]
        public void DisposeWebDriver()
        {
            _website.SeleniumDriver.Quit();
            _website.SeleniumDriver.Dispose();
        }
    }
}
