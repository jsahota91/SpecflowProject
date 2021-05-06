using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System.Threading;

namespace AutomationPracticeTestFramework
{
    public class AP_ProductPage
    {
        public IWebDriver SeleniumDriver { get; }
        private IWebElement _womanLink => SeleniumDriver.FindElement(By.ClassName("sf-with-ul"));
        private IWebElement _tshirtLink => SeleniumDriver.FindElement(By.LinkText("T-shirts"));
        private IWebElement _addToCartBtn => SeleniumDriver.FindElement(By.CssSelector(".ajax_add_to_cart_button > span"));
        private IWebElement _alertMsg => SeleniumDriver.FindElement(By.ClassName("layer_cart_product"));
        private IWebElement _crossBtn => SeleniumDriver.FindElement(By.CssSelector(".cross"));
        private IWebElement _cartEmpty => SeleniumDriver.FindElement(By.ClassName("ajax_cart_no_product"));
        private IWebElement _moreBtn => SeleniumDriver.FindElement(By.CssSelector(".lnk_view > span"));
        private IWebElement _productPageAddToCartBtn => SeleniumDriver.FindElement(By.Name("Submit"));
        private IWebElement _nullQuantity => SeleniumDriver.FindElement(By.ClassName("fancybox-error"));
        private IWebElement _quantityField => SeleniumDriver.FindElement(By.Id("quantity_wanted"));
        private IWebElement _dropdown => SeleniumDriver.FindElement(By.Id("group_1"));
        private IWebElement _selectedItem => SeleniumDriver.FindElement(By.Id("layer_cart_product_attributes"));
        private IWebElement _selectedColor => SeleniumDriver.FindElement(By.Id("color_14"));
        private IWebElement _popupCartQuantity => SeleniumDriver.FindElement(By.ClassName("ajax_cart_quantity"));
        private IWebElement _cartQuantity => SeleniumDriver.FindElement(By.CssSelector(".ajax_cart_quantity:nth-child(2)"));
        private IWebElement _cart => SeleniumDriver.FindElement(By.CssSelector(".shopping_cart > a"));
        private IWebElement _removeBtn => SeleniumDriver.FindElement(By.CssSelector(".ajax_cart_block_remove_link"));

        public AP_ProductPage(IWebDriver seleniumDriver)
        {
            SeleniumDriver = seleniumDriver;
        }

        public void TshirtTabBtn()
        {
            Actions action = new Actions(SeleniumDriver);
            action.MoveToElement(_womanLink).Perform();
            Thread.Sleep(5000);
            _tshirtLink.Click();
        }

        public void ClickAddToCartBtn()
        {
            _addToCartBtn.Click();
        }
        public string AlertMessage()
        {
            return _alertMsg.Text;
        }

        public void ClickMoreBtn()
        {
            _moreBtn.Click();
        }

        public string NullQuantityAlert()
        {
            return _nullQuantity.Text;
        }

        public void ClickExclusiveBtn()
        {
            _productPageAddToCartBtn.Click();
        }

        
        public void GetQuantityInput(string inputQuantity)
        {
            _quantityField.Clear();
            _quantityField.SendKeys(inputQuantity);
            
        }

        public void ClickCrossBtn()
        {
            _crossBtn.Click();
        }

        public string CartEmpty()
        {
            return _cartEmpty.Text;
        }

        public void ClickPPAddToCartBtn()
        {
            _productPageAddToCartBtn.Click();
        }

        public string CartQuantity()
        {
            return _cartQuantity.Text;
        }

        public void RemoveItemClick()
        {
            Actions action = new Actions(SeleniumDriver);
            action.MoveToElement(_cart).Perform();
            Thread.Sleep(5000);
            _removeBtn.Click();
        }

        public void GetSizeSelected()
        {
            _dropdown.FindElement(By.XPath("//option[. = 'L']")).Click();
        }

        public string DisplaySelectedItem()
        {
            return _selectedItem.Text;
        }

        public void GetSelectedColor()
        {
            _selectedColor.Click();
        }
        public string CheckQuantitySize()
        {
            return _popupCartQuantity.Text;
        }
    }
}
