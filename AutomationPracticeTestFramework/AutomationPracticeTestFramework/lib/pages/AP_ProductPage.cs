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

        public void ClickCrossBtn()
        {
            _crossBtn.Click();
        }

        
    }
}
