using Microsoft.VisualBasic;
using System.Collections;
using System.Collections.ObjectModel;
using System.Reflection;
using System;
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
            //1. Maximise window
            driver.Manage().Window.Maximize();
            driver.Url = "https://automationintesting.online/#/";
        }

        [TearDown]
        public void AfterEach()
        {
         //   driver.Quit();
        }

        [Test]
        public void Book_A_Room()
        {
            
            //1. go to Homepage and fill out form
            var homePage = new HomePage(driver);
            homePage.EnterBookingDetails("Beth", "test@test.com", "07707393333", "wow", "please can I book this room its awesome thanks!");
            

        //    new HomePage(driver).Goto().GetLinkByName("")
      //      var homePage = new HomePage(driver);
            // driver.FindElement(By.Id("quicklook-principes")).Click();
          //  var support = cardsPage.Goto();
            // Assert.That(principles.Displayed);
         //   new CardsPage(driver).Goto().GetCardByName("Three Musketeers").Click();
         //   var iceSpirit = AITHomePage.Goto().GetCardByName("Ice Spirit");
         
        //    Assert.That(principles.Displayed);
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
        
          [Test]
        public void Bandit_headers_are_correct_on_Card_Details_Page()
        {
      //      new CardsPage(driver).Goto().GetCardByName("Three Musketeers").Click();
            var cardDetails = new BlogPage(driver);

            var (category, arena) = cardDetails.GetCardCategory();
            var cardName = cardDetails.Map.BlogName.Text;
            var cardRarity = cardDetails.Map.BlogDate.Text;

            Assert.AreEqual("Three Musketeers", cardName);
            Assert.AreEqual("Troop", category);
            Assert.AreEqual("Arena 7", arena);
            Assert.AreEqual("Rarity\r\nRare", cardRarity);
        }
    }
}