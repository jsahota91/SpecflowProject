using System;
using NUnit.Framework;
using System.Threading;

namespace AutomationPracticeTestFramework
{
    public class Selinium_AP_CreateAccount
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
        public void GivenIAmOnTheSigninPage_AndIEnterAnInvalidEmail_WhenIClickTheCreateAccountButton_ThenIGetAnErrorMessage()
        {
            //Arrange
            //navigate to the sign in page
            AP_Website.AP_SigninPage.VisitSignInPage();
            //get a reference to the email input field and do not enter email
            AP_Website.AP_CreateAccount.GetEmailInput("invalid");

            //Act
            //get a reference to the Create Account button and click the button
            AP_Website.AP_CreateAccount.ClickCreateAccountButton();
            Thread.Sleep(2000);
            //Assert
            //get a reference to the alert message and check the error message is correct
            Assert.That(AP_Website.AP_CreateAccount.AlertMessage(), Does.Contain("Invalid email address."));           
        }

        [Test]
        public void GivenIAmOnTheSigninPage_AndIEnterAnExistingEmail_WhenIClickTheCreateAccountButton_ThenIGetAnErrorMessage()
        {
            //Arrange
            //navigate to the sign in page
            AP_Website.AP_SigninPage.VisitSignInPage();
            //get a reference to the email input field and enter an Invalid email
            AP_Website.AP_CreateAccount.GetEmailInput("test@test.com");

            //Act
            //get a reference to the Create Account button and click the button
            AP_Website.AP_CreateAccount.ClickCreateAccountButton();
            Thread.Sleep(2000);

            //Assert
            //get a reference to the alert message and check the error message is correct
            Assert.That(AP_Website.AP_CreateAccount.AlertMessage(), Does.Contain("An account using this email address has already been registered."));
        }

        [Test]
        public void GivenIAmOnTheSigninPage_AndIEnterAEmail_WhenIClickTheCreateAccountButton_ThenIGetTakenToCreateAccountPage()
        {
            //Arrange
            //navigate to the sign in page
            AP_Website.AP_SigninPage.VisitSignInPage();
            //get a reference to the email input field and enter valid email
            AP_Website.AP_CreateAccount.GetEmailInput("tinker123@gmail.com");           

            //Act
            //get a reference to the sign in button click the sign in button
            AP_Website.AP_CreateAccount.ClickCreateAccountButton();
            Thread.Sleep(2000);

            //Assert
            //get a reference to the alert message and check the error message is correct
            Assert.That(AP_Website.AP_CreateAccount.SeleniumDriver.Url, Is.EqualTo("http://automationpractice.com/index.php?controller=authentication#account-creation"));
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
