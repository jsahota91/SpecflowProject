using OpenQA.Selenium;

namespace AutomationPracticeTestFramework
{
    public class AP_ForgotPassword
    {
        public IWebDriver SeleniumDriver { get; }
        private string SignInPageUrl = AppConfigReader.SignInPageUrl;
        private string ForgotPasswordUrl = AppConfigReader.ForgotPasswordUrl;
        private IWebElement _emailField => SeleniumDriver.FindElement(By.Id("email"));
        private IWebElement _alertMsg => SeleniumDriver.FindElement(By.ClassName("alert"));
        private IWebElement _retrievePasswordBtn => SeleniumDriver.FindElement(By.CssSelector("p.submit > button.button-medium"));
        public AP_ForgotPassword(IWebDriver seleniumDriver)
        {
            SeleniumDriver = seleniumDriver;
        }

        public void GetEmailInput(string inputEmail)
        {
            _emailField.SendKeys(inputEmail);
        }

        public string AlertMessage()
        {
            return _alertMsg.Text;
        }

        public void VisitForgotPasswordPage()
        {
            SeleniumDriver.Navigate().GoToUrl(ForgotPasswordUrl);
        }
        public void ClickRetrievePasswordButton()
        {
            _retrievePasswordBtn.Click();
        }
        public string GetPageTitle()
        {
            return SeleniumDriver.Title;
        }

    }
}