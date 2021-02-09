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
        
        [Test, Category("basics")]
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


[Test, Category("basics")]
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


        [Test, Category("basics")]
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


        [Test, Category("basics")]
        public void Logout()
        {
            var loginPage = new LoginPage(driver);
            loginPage.Login("demo", "demo");
            var homePage = new HomePage(driver);
            homePage.Logout(driver);
            var logoutPageText = loginPage.Map.LoginPageTitle.Text;
            Assert.AreEqual("Please enter your login details.", logoutPageText);
        }

        [Test, Category("basics")]
        public void viewOrders()
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            var loginPage = new LoginPage(driver);
            loginPage.Login("demo", "demo");
            var homePage = new HomePage(driver);
            var goToSalesMenu = homePage.GoToSalesMenu();
            wait.Until(driver => homePage.HeaderNav.Map.OrdersLink.Displayed);
            var goToOrdersMenu = homePage.GoToOrdersMenu();
            Assert.AreEqual("Orders", driver.Title);
        }
    }
}