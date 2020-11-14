using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.IO;
using AIT.Pages;



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
            var homePage = new HomePage(driver);
            var dashboardTitleText = homePage.Map.DashboardTitle.Text.Split("Home ")[1];
            Assert.AreEqual("Dashboard", dashboardTitleText);
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
            var loginPage = new LoginPage(driver);
            loginPage.Login("demo", "demo");
            var homePage = new HomePage(driver);
            var goToOrdersPage = homePage.GoTo();
            var ordersPage = new OrdersPage(driver);
            var orderPageText = ordersPage.Map.OrdersPageTitle.Text;
            Assert.AreEqual("Orders", orderPageText);
        }
    }
}