using OpenQA.Selenium;

namespace AutomationPracticeTestFramework
{
    public class AP_SigninPage
    {
        public IWebDriver SeleniumDriver { get; }
        private string SignInPageUrl = AppConfigReader.SignInPageUrl;
        private IWebElement _emailField => SeleniumDriver.FindElement(By.Id("email"));
        private IWebElement _passwordField => SeleniumDriver.FindElement(By.Id("passwd"));
        private IWebElement _signinButton => SeleniumDriver.FindElement(By.Id("SubmitLogin"));
        private IWebElement _alertMsg => SeleniumDriver.FindElement(By.ClassName("alert"));
        private IWebElement _retrievePasswordBtn => SeleniumDriver.FindElement(By.CssSelector("p.submit > button.button-medium"));
        public AP_SigninPage(IWebDriver seleniumDriver)
        {
            SeleniumDriver = seleniumDriver;
        }

        public void VisitSignInPage()
        {
            SeleniumDriver.Navigate().GoToUrl(SignInPageUrl);
        }

        public void GetEmailInput(string inputEmail)
        {
            _emailField.SendKeys(inputEmail);
        }

        public void GetPasswordInput(string inputPassword)
        {
            _passwordField.SendKeys(inputPassword);
        }

        public string AlertMessage()
        {
            return _alertMsg.Text;
        }

        public void ClickSignInButton()
        {
            _signinButton.Click();
        }
        public void VisitForgotPasswordPage()
        {
            SeleniumDriver.Navigate().GoToUrl("http://automationpractice.com/index.php?controller=password");
        }
        public void ClickRetrievePasswordButton()
        {
            _retrievePasswordBtn.Click();
        }

        
        //public void ExampleHover()
        //{
        //    //Instantiate an action which we can use
        //    OpenQA.Selenium.Actions action = new Actions(driver);
        //    action.MoveToElement(homeAndGardenElement).Perform();
        //}
    }
}