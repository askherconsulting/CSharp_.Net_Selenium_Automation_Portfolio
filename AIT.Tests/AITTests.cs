using System.Runtime.CompilerServices;
using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using AIT.Pages;
using Framework;
using OpenQA.Selenium.Support.UI;
using Tests.Base;


namespace AIT.Tests
{
    public class AITTests : TestBase


    {
        
        [Test, Category("basics")]
        public void Login()
        { 
            //Login
            var loginPage = new LoginPage(driver);
            loginPage.Login(driver);
            //Go to private inbox
            var inboxPage = new InboxPage(driver);
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(driver => inboxPage.Map.email.Displayed);
            // Click on the email
            inboxPage.openEmail(driver);
            var messagePage = new MessagePage(driver);
            // Now switch to the email body iframe:
            driver.SwitchTo().Frame("html_msg_body");
            wait.Until(driver => messagePage.Map.button2.Displayed);
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
            loginPage.Login(driver);
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
            loginPage.Login(driver);
            var homePage = new HomePage(driver);
            var goToSalesMenu = homePage.GoToSalesMenu();
            wait.Until(driver => homePage.HeaderNav.Map.OrdersLink.Displayed);
            var goToOrdersMenu = homePage.GoToOrdersMenu();
            Assert.AreEqual("Orders", driver.Title);
        }
    }
}