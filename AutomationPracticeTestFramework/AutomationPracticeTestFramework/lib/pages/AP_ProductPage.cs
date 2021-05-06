﻿using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System.Threading;

namespace AutomationPracticeTestFramework
{
    public class AP_ProductPage
    {
        public IWebDriver SeleniumDriver { get; }
        //private IWebElement _tshirtTabBtn => SeleniumDriver.FindElement(By.XPath("//*[@id=block_top_menu]/ul/li[3]/a"));
        private IWebElement _womanLink => SeleniumDriver.FindElement(By.ClassName("sf-with-ul"));
        private IWebElement _tshirtLink => SeleniumDriver.FindElement(By.LinkText("T-shirts"));

        private IWebElement _addToCartBtn => SeleniumDriver.FindElement(By.CssSelector(".ajax_add_to_cart_button > span"));
        private IWebElement _alertMsg => SeleniumDriver.FindElement(By.ClassName("layer_cart_product"));
        private IWebElement _crossBtn => SeleniumDriver.FindElement(By.CssSelector(".cross"));
        private IWebElement _moreBtn => SeleniumDriver.FindElement(By.CssSelector(".lnk_view > span"));
        private IWebElement _exclusiveAddToCartBtn => SeleniumDriver.FindElement(By.CssSelector(".exclusive > span"));
        private IWebElement _nullQuantity => SeleniumDriver.FindElement(By.ClassName("fancybox-error"));
        private IWebElement _quantityField => SeleniumDriver.FindElement(By.Id("quantity_wanted"));

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
            //_tshirtTabBtn.Click();
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
            _exclusiveAddToCartBtn.Click();
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

        
    }
}
