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

        [Test]
        public void Login()
        {
            
            var loginPage = new LoginPage(driver);
            loginPage.Login("demo", "demo");
            var homePage = new HomePage(driver);
            //do an assert
            var dashboardTitleText = homePage.Map.DashboardTitle.Text;
            Assert.AreEqual("Dashboard Home Dashboard", dashboardTitleText);
        }

        [Test]
        public void Logout()
        {
            var loginPage = new LoginPage(driver);
            loginPage.Login("demo", "demo");
            var homePage = new HomePage(driver);
            homePage.Logout(driver);
            var logoutPageText = loginPage.Map.LoginPageTitle.Text;
            Assert.AreEqual(" Please enter your login details.", logoutPageText);
        }

        [Test]
        public void Support_is_Navigable()
        {
     //     new HomePage(driver).Goto().GetLinkByName("SUPPORT AUTOMATION IN TESTING").Click();
       //   var support = HeaderNavMap.
       //   Assert.AreEqual("SUPPORT AUTOMATION IN TESTING", support);
            // //1. Maximise window
            // driver.Manage().Window.Maximize();
            // //2. go to AIT home page         
            // driver.Url = "https://automationintesting.com";
            // //4. click principles area
            // driver.FindElement(By.CssSelector("a[href*='/support']")).Click();
            // //5. Assert principles section shown
            // var support = driver.FindElement(By.ClassName("info-title")).Text;
            // Assert.That(support.Equals("SUPPORT AUTOMATION IN TESTING"));

            //1. 
      //      var cardsPage = new CardsPage(driver);

      //      var support1 = CardDetailsPage.Map
      //      var support1 = cardsPage.Goto();
             // //5. Assert principles section shown
         //   var support = driver.FindElement(By.ClassName("info-title")).Text;
            
       //     Assert.That(support.Equals("SUPPORT AUTOMATION IN TESTING"));
        //    Assert.AreEqual("SUPPORT AUTOMATION IN TESTING", support);
       //     var iceSpirit = cardsPage.Goto().GetCardByName("Ice Spirit");
       //     Assert.That(iceSpirit.Displayed);
        }
    }
}