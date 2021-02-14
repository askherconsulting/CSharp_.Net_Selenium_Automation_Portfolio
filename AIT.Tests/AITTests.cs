using System.Security.Cryptography;
using System.Text;
using System.Runtime.CompilerServices;
using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using AIT.Pages;
using Config.Base;
using Framework;
using OpenQA.Selenium.Support.UI;
using Tests.Base;



namespace AIT.Tests
{
    public class AITTests : TestBase


    {
        
        [Test, Category("e2e")]
        public void private_inbox_Click_Email_Link()
        {         
            //go to website e.g. mailchimp
            //sign up
            //open new tab
            //go to mailinator and do the below  
            //Login
            driver.Url = ("https://www.mailinator.com/v4/private/inboxes.jsp?to=beth");
            var homePage = new HomePage(driver);
            homePage.clickLoginButton(driver);
            var loginPage = new LoginPage(driver);
            loginPage.Login(username, password);
            //Go to private inbox
            var inboxPage = new InboxPage(driver);
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(driver => inboxPage.Map.email.Displayed);
            // Click on the email
            inboxPage.openEmail(driver);
            var messagePage = new MessagePage(driver);
            // Now switch to the email body iframe:
            driver.SwitchTo().Frame("html_msg_body");
            wait.Until(driver => messagePage.Map.button.Displayed);
            // Click on the email link 
            messagePage.clickButton(driver);
            // If you need to go back to the menu, don't forget to switch back:
            driver.SwitchTo().DefaultContent();
            //check a new tab has been opened
            wait.Until(driver => driver.WindowHandles.Count == 2);
            Assert.AreEqual(2, driver.WindowHandles.Count);
        }


[Test, Category("e2e")]
        public void public_inbox_switch_to_mailinator_tab()
        {         
            //go to public inbox
            driver.Url = ("https://www.mailinator.com/v4/public/inboxes.jsp?to=beth123");
            //switch to new tab
            driver = driver.SwitchTo().NewWindow(WindowType.Tab);
            //open new URL
            driver.Url = ("https://testproject.io/platform/");
            //go back to first tab
            driver.SwitchTo().Window(driver.WindowHandles[0]);
            //open email
            var inboxPage = new InboxPage(driver);
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(driver => inboxPage.Map.email.Displayed);
            // Click on the email
            inboxPage.openEmail(driver);
            var messagePage = new MessagePage(driver);
            // Now switch to the email body iframe:
            driver.SwitchTo().Frame("html_msg_body");
            wait.Until(driver => messagePage.Map.button.Displayed);
            // Click on the email link 
            messagePage.clickButton(driver);
            // If you need to go back to the menu, don't forget to switch back:
            driver.SwitchTo().DefaultContent();
            //check a new tab has been opened
            wait.Until(driver => driver.WindowHandles.Count == 3);
            Assert.AreEqual(3, driver.WindowHandles.Count);
        }


        [Test, Category("e2e")]
            public void straight_to_mailinator()
        {           
            //go to public inbox
            driver.Url = ("https://www.mailinator.com/v4/public/inboxes.jsp?to=beth123");            
            var inboxPage = new InboxPage(driver);
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(driver => inboxPage.Map.email.Displayed);
            // Click on the email
            inboxPage.openEmail(driver);
            var messagePage = new MessagePage(driver);
            // Now switch to the email body iframe:
            driver.SwitchTo().Frame("html_msg_body");
            wait.Until(driver => messagePage.Map.button.Displayed);
            // Click on the email link 
            messagePage.clickButton(driver);
            // If you need to go back to the menu, don't forget to switch back:
            driver.SwitchTo().DefaultContent();
            //check a new tab has been opened
            wait.Until(driver => driver.WindowHandles.Count == 2);
            Assert.AreEqual(2, driver.WindowHandles.Count);
        }

        [Test, Category("e2e")]
        public void e2e_signup_register_and_login_test()
        {         
            //1. generate random Mailinator Email address
            string Username = generateUniqueUsername(driver);
            string Email = generateUniqueMailinatorEmail(driver);
            string Password = generateUniquePassword(driver);
            //2. go to sign in
            driver.Url = ("https://timelesstales.in/wp-login.php?action=register");
            //3. click sign in button
            var registerPage = new RegisterPage(driver);
            registerPage.CreateAccount(Username, Email);
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
             //4. switch to new tab
             driver = driver.SwitchTo().NewWindow(WindowType.Tab);
             //5. go to public inbox
             driver.Url = ("https://www.mailinator.com/v4/public/inboxes.jsp?to=" + Email);
             //6. open email
             var inboxPage = new InboxPage(driver);
             wait.Until(driver => inboxPage.Map.email.Displayed);
             inboxPage.openEmail(driver);
             //7.Now switch to the email body iframe (remember to check the name of the HTML AND REMEMBER TO SWITCH BACK AFTERWARDS!)          
             var messagePage = new MessagePage(driver);
             //note - the frame will either be html_msg_body or texthtml_msg_body so use a try catch block to try both
             try {
             driver.SwitchTo().Frame("html_msg_body");
             wait.Until(driver => messagePage.Map.textLink.Displayed);}
             catch (WebDriverException ) {
                 driver.SwitchTo().DefaultContent();
                 driver.SwitchTo().Frame("texthtml_msg_body");
                 wait.Until(driver => messagePage.Map.textLink.Displayed);
             }
             //8. Click on the email link 
             messagePage.clickTextLink(driver);
             //9. user auto-navigates to tab 3
             var passwordPage = new PasswordPage(driver);
             //10. switch back to window from iframe and switch to latest tab
             driver.SwitchTo().Window(driver.WindowHandles[2]);
             //11. wait for auto-generated password to appear
             wait.Until(driver => passwordPage.Map.passStrengthResult.Displayed);
             //12. clear field and enter password
             passwordPage.enterPassword(Password);
             passwordPage.clickResetPasswordButton(driver);
             //13. login
             var resetPasswordPage = new ResetPasswordPage(driver);
             resetPasswordPage.clickLogin(driver);
             registerPage.Login(Email, Password);
             //14. assert you have landed on the correct page
             var wordPressAdminPage = new WordPressAdminPage(driver);
             String title = driver.Title;
             Assert.AreEqual(title, "Dashboard ‹ My Blog — WordPress");
        }

    }
}