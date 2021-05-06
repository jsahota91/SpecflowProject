using System;
using NUnit.Framework;
using System.Threading;

namespace AutomationPracticeTestFramework
{
    public class Selinium_AP_ForgotPasswordTests
    {
        //create a AP_Website instance
        public AP_Website AP_Website { get; } = new AP_Website("chrome");

        [Test]
        public void GivenIAmOnTheSignInPage_WhenIClickTheForgotYourPasswordLink_ThenIGoToTheForgotPasswordPage()
        {
            AP_Website.AP_SigninPage.VisitForgotPasswordPage();
            Assert.That(AP_Website.AP_ForgotPassword.GetPageTitle(), Is.EqualTo("Forgot your password - My Store"));
        }

        [Test]
        public void GivenIAmOnForgotPasswordPage_WhenIEnterAnUnregisteredEmail_ThenIGetAnErrorMessage()
        {
            //Arrange
            //click the Forgot your password link and nvaigate to that page
            AP_Website.AP_SigninPage.VisitForgotPasswordPage();
            //get a reference to the email input field and enter invalid email
            AP_Website.AP_SigninPage.GetEmailInput("tinker123@gmail.com");

            //Act
            //get a reference to the retrieve password button click the button
            AP_Website.AP_SigninPage.ClickRetrievePasswordButton();

            //Assert
            //get a reference to the alert message and check the error message is correct
            Assert.That(AP_Website.AP_SigninPage.AlertMessage(), Does.Contain("There is no account registered for this email address."));
        }

        [Test]
        public void GivenIAmOnForgotPasswordPage_WhenIEnterAValidRegisteredEmail_ThenIGetASuccessMessage()
        {
            //Arrange
            //click the Forgot your password link and nvaigate to that page
            AP_Website.AP_SigninPage.VisitForgotPasswordPage();
            //get a reference to the email input field and enter invalid email
            AP_Website.AP_SigninPage.GetEmailInput("test@test.com");

            //Act
            //get a reference to the retrieve password button click the button
            AP_Website.AP_SigninPage.ClickRetrievePasswordButton();

            //Assert
            //get a reference to the alert message and check the error message is correct
            Assert.That(AP_Website.AP_SigninPage.AlertMessage(), Does.Contain("A confirmation email has been sent to your address: test@test.com"));
        }

        [Test]
        public void GivenIAmForgotPasswordPage_WhenIEnterAnInvalidEmail_ThenIGetAnErrorMessage()
        {
            //Arrange
            //click the Forgot your password link and nvaigate to that page
            AP_Website.AP_SigninPage.VisitForgotPasswordPage();
            //get a reference to the email input field and enter invalid email
            AP_Website.AP_SigninPage.GetEmailInput("tim");

            //Act
            //get a reference to the retrieve password button click the button
            AP_Website.AP_SigninPage.ClickRetrievePasswordButton();

            //Assert
            //get a reference to the alert message and check the error message is correct
            Assert.That(AP_Website.AP_SigninPage.AlertMessage(), Does.Contain("Invalid email address."));
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            //quits the driver, closing all assoicated windows
            AP_Website.SeleniumDriver.Quit();
            //release resources
            AP_Website.SeleniumDriver.Dispose();
        }
        
    }
}
