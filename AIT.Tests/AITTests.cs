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
            loginPage.Login("demo", "demo");
            Assert.That(driver.Title, Contains.Substring("Dashboard"));
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