using System;
using NUnit.Framework;
using System.Threading;

namespace AutomationPracticeTestFramework
{
    public class Selinium_AP_SigninTests
    {
        //create a AP_Website instance
        public AP_Website AP_Website { get; } = new AP_Website("chrome");

        [Test]
        public void GivenIAmOnTheHomePage_WhenIClickTheSignInLink_ThenIGoToTheSigninPage()
        {
            AP_Website.AP_HomePage.VisitHomePage();
            AP_Website.AP_HomePage.ClickSignInLink();
            Assert.That(AP_Website.GetPageTitle(), Is.EqualTo("Login - My Store"));
        }

        [Test]
        public void GivenIAmOnTheSigninPage_AndIEnteredA4DigitPassword_WhenIClickTheSignInButton_ThenIGetAnErrorMessage()
        {
            //Arrange
            //navigate to the sign in page
            AP_Website.AP_SigninPage.VisitSignInPage();
            //get a reference to the email input field and enter a valid email
            AP_Website.AP_SigninPage.GetEmailInput("testing@snailmail.com");
            //get a reference to the password input field and enter a password of less than four characters
            AP_Website.AP_SigninPage.GetPasswordInput("four");

            //Act
            //get a reference to the sign in button click the sign in button
            AP_Website.AP_SigninPage.ClickSignInButton();

            //Assert
            //get a reference to the alert message and check the error message is correct
            Assert.That(AP_Website.AP_SigninPage.AlertMessage(), Does.Contain("Invalid password."));           
        }

        [Test]
        public void GivenIAmOnTheSigninPage_AndIEnterAnInvalidEmail_WhenIClickTheSignInButton_ThenIGetAnErrorMessage()
        {
            //Arrange
            //navigate to the sign in page
            AP_Website.AP_SigninPage.VisitSignInPage();
            //get a reference to the email input field and enter an Invalid email
            AP_Website.AP_SigninPage.GetEmailInput("tinker123@gmail.com");
            //get a reference to the password input field and enter a password of ten characters
            AP_Website.AP_SigninPage.GetPasswordInput("animation20");
           
            //Act
            //get a reference to the sign in button click the sign in button
            AP_Website.AP_SigninPage.ClickSignInButton();

            //Assert
            //get a reference to the alert message and check the error message is correct
            Assert.That(AP_Website.AP_SigninPage.AlertMessage(), Does.Contain("Authentication failed."));          
        }

        [Test]
        public void GivenIAmOnTheSigninPage_AndIDoNotEnterAnEmail_WhenIClickTheSignInButton_ThenIGetAnErrorMessage()
        {
            //Arrange
            //navigate to the sign in page
            AP_Website.AP_SigninPage.VisitSignInPage();
            //get a reference to the email input field and do not enter email
            AP_Website.AP_SigninPage.GetEmailInput("");
            //get a reference to the password input field
            //get a reference to the password input field and enter a password of ten characters
            AP_Website.AP_SigninPage.GetPasswordInput("animation20");

            //Act
            //get a reference to the sign in button click the sign in button
            AP_Website.AP_SigninPage.ClickSignInButton();

            //Assert
            //get a reference to the alert message and check the error message is correct
            Assert.That(AP_Website.AP_SigninPage.AlertMessage(), Does.Contain("An email address required."));          
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
