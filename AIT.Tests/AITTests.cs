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
            var loginPage = new LoginPage(driver);
            loginPage.Login("bethmarshall2013@hotmail.co.uk", "Shameful-rabbit0");
            var inboxPage = new InboxPage(driver);
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(driver => inboxPage.Map.email.Displayed);
            inboxPage.openEmail(driver);
            var messagePage = new MessagePage(driver);
            // Click on the email

            // Now switch to the email body iframe:
            driver.SwitchTo().Frame("html_msg_body");
            wait.Until(driver => messagePage.Map.button2.Displayed);
            // Click on the email link 
            messagePage.clickButton(driver);
            // If you need to go back to the menu, don't forget to switch back:
            driver.SwitchTo().DefaultContent();
            
            
        //    messagePage.clickText(driver);
        //    var textPage = new TextPage(driver);
        //    textPage.clickLink("smoothwall.cloud");
            
        //    messagePage.clickButton("View event");
            wait.Until(driver => driver.WindowHandles.Count == 2);
            Assert.AreEqual(2, driver.WindowHandles.Count);
        //    messagePage.clickLinks(driver);
        //    var linksPage = new LinksPage(driver);
        //    linksPage.viewLinks(driver);
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