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
        
        //Choose item to add to cart
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
            _website.AP_ProductPage.GetQuantityInput(quantity);
        }

        // Click more button
        [When(@"I choose an item and click more")]
        public void WhenIChooseAnItemAndClickMore()
        {
            _website.AP_ProductPage.ClickMoreBtn();
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

        [Given(@"I click the more button")]
        public void GivenIClickTheMoreButton()
        {
            _website.AP_ProductPage.ClickMoreBtn();
        }

        [When(@"I enter a string in the quantity field ""(.*)""")]
        public void WhenIEnterAStringInTheQuantityField(string quantity)
        {
            _website.AP_ProductPage.GetQuantityInput(quantity);
        }

        [When(@"I click the add to cart button")]
        public void WhenIClickTheAddToCartButton()
        {
            _website.AP_ProductPage.ClickPPAddToCartBtn();
            Thread.Sleep(3000);
        }

        // Cart item remove
        [When(@"I hover my mouse over the cart and click the cart cross button")]
        public void WhenIHoverMyMouseOverTheCartAndClickTheCartCrossButton()
        {
            _website.AP_ProductPage.RemoveItemClick();
            Thread.Sleep(2000);
        }

        [Then(@"I should get an error alert ""(.*)""")]
        public void ThenIShouldGetAnErrorAlert(string nullAlertMsg)
        {
            Assert.That(_website.AP_ProductPage.NullQuantityAlert, Does.Contain(nullAlertMsg));
        }

        // Cart quantity success
        [Then(@"The quantity of items in the cart should be ""(.*)""")]
        public void ThenTheQuantityOfItemsInTheCartShouldBe(string expResult)
        {
            Assert.That(_website.AP_ProductPage.CartQuantity(), Is.EqualTo(expResult));
        }

        [When(@"I select the size L")]
        public void WhenISelectTheSizeL()
        {
            _website.AP_ProductPage.GetSizeSelected();
        }

        [Then(@"I should get a success alert with the selected size ""(.*)""")]
        public void ThenIShouldGetASuccessAlertWithTheSelectedSize(string sizeSelected)
        {
            Assert.That(_website.AP_ProductPage.DisplaySelectedItem, Does.Contain(sizeSelected));
        }

        [Then(@"The Quantity should be ""(.*)""")]
        public void ThenTheQuantityShouldBe(int quantity)
        {
            Assert.That(_website.AP_ProductPage.CheckQuantitySize(), Is.EqualTo(quantity.ToString()));
        }

        [When(@"I select the color")]
        public void WhenISelectTheColor()
        {
            _website.AP_ProductPage.GetSelectedColor();
        }

        [Then(@"I should get a success alert with the selected color ""(.*)""")]
        public void ThenIShouldGetASuccessAlertWithTheSelectedColor(string colorSelected)
        {
            Assert.That(_website.AP_ProductPage.DisplaySelectedItem, Does.Contain(colorSelected));
        }

        [When(@"I click add to wishlist")]
        public void WhenIClickAddToWishlist()
        {
            _website.AP_ProductPage.ClickAddToWishList();
        }

        [Then(@"I will get a pop up saying ""(.*)""")]
        public void ThenIWillGetAPopUpSaying(string error)
        {
            Assert.That(_website.AP_ProductPage.ErrorMessage(), Is.EqualTo(error));
        }

        [AfterScenario]
        public void DisposeWebDriver()
        {
            _website.SeleniumDriver.Quit();
            _website.SeleniumDriver.Dispose();
        }
    }
}
