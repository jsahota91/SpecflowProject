using OpenQA.Selenium;

namespace AutomationPracticeTestFramework
{
    public class AP_ProductPage
    {
        public IWebDriver SeleniumDriver { get; }
        private IWebElement _tshirtTabBtn => SeleniumDriver.FindElement(By.ClassName("sfHoverforce"));
        private IWebElement _addToCartBtn => SeleniumDriver.FindElement(By.CssSelector(".ajax_add_to_cart_button > span"));
        private IWebElement _alertMsg => SeleniumDriver.FindElement(By.Id("icon-ok"));
        private IWebElement _crossBtn => SeleniumDriver.FindElement(By.CssSelector(".cross"));

        public AP_ProductPage(IWebDriver seleniumDriver)
        {
            SeleniumDriver = seleniumDriver;
        }

        public void TshirtTabBtn()
        {
            _tshirtTabBtn.Click();
        }

        public void ClickAddToCartBtn()
        {
            _addToCartBtn.Click();
        }

        public string AlertMessage()
        {
            return _alertMsg.Text;
        }

        public void ClickCrossBtn()
        {
            _crossBtn.Click();
        }

        
    }
}
