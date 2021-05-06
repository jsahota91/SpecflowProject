using OpenQA.Selenium;

namespace AutomationPracticeTestFramework
{
    public class AP_CreateAccount
    {
        public IWebDriver SeleniumDriver { get; }
        private string SignInPageUrl = AppConfigReader.SignInPageUrl;
        private string CreateAccountUrl = AppConfigReader.CreateAccountUrl;
        private IWebElement _emailField => SeleniumDriver.FindElement(By.Id("email_create"));
        private IWebElement _createAccountBtn => SeleniumDriver.FindElement(By.Id("SubmitCreate"));
        private IWebElement _alertMsg => SeleniumDriver.FindElement(By.Id("create_account_error"));
        public AP_CreateAccount(IWebDriver seleniumDriver)
        {
            SeleniumDriver = seleniumDriver;
        }
        
        public void GetEmailInput(string inputEmail)
        {
            _emailField.SendKeys(inputEmail);
        }

        public void ClickCreateAccountButton()
        {
            _createAccountBtn.Click();
        }

        public string AlertMessage()
        {
            return _alertMsg.Text;
        }
    }
}
