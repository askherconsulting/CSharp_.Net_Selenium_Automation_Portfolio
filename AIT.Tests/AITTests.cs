using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.IO;
using AIT.Pages;
using OpenQA.Selenium.Support.UI;

namespace AIT.Tests
{
    public class AITTests

    {
        IWebDriver driver;

        [SetUp]
        public void BeforeEach()
        {
            driver = new ChromeDriver(Path.GetFullPath(@"../../../../" + "_drivers"));
            driver.Manage().Window.Maximize();
            driver.Url = "https://demo.opencart.com/admin/";
        }

        [TearDown]
        public void AfterEach()
        {
            driver.Quit();
        }

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