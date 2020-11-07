using System.Collections;
using System.Collections.ObjectModel;
using System.Reflection;
using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.IO;
using Royale.Pages;


namespace Royale.Tests
{
   public class CardTests

    {
        IWebDriver driver;

        [SetUp]
        public void BeforeEach()
        {
            driver = new ChromeDriver(Path.GetFullPath(@"../../../../" + "_drivers"));
            //1. Maximise window
            driver.Manage().Window.Maximize();
            driver.Url = "https://automationintesting.com";
        }

        [TearDown]
        public void AfterEach()
        {
            driver.Quit();
        }

        [Test]
        public void Principles_Is_Navigable()
        {
            
           // var AITHomePage = new CardsPage(driver);
            //4. click principles area
            var cardsPage = new CardsPage(driver);
            // driver.FindElement(By.Id("quicklook-principes")).Click();
         var support = cardsPage.Goto();
            // Assert.That(principles.Displayed);
         //   new CardsPage(driver).Goto().GetCardByName("Three Musketeers").Click();
         //   var iceSpirit = AITHomePage.Goto().GetCardByName("Ice Spirit");
         
        //    Assert.That(principles.Displayed);
        }

        [Test]
        public void Ice_Spirit_is_on_Cards_Page()
        {
            // //1. Maximise window
            // driver.Manage().Window.Maximize();
            // //2. go to AIT home page         
            // driver.Url = "https://automationintesting.com";
            // //4. click principles area
            // driver.FindElement(By.CssSelector("a[href*='/support']")).Click();
            // //5. Assert principles section shown
            // var support = driver.FindElement(By.ClassName("info-title")).Text;
            // Assert.That(support.Equals("SUPPORT AUTOMATION IN TESTING"));
            var cardsPage = new CardsPage(driver);
            var support1 = cardsPage.Goto();
             // //5. Assert principles section shown
            var support = driver.FindElement(By.ClassName("info-title")).Text;
             Assert.That(support.Equals("SUPPORT AUTOMATION IN TESTING"));
       //     var iceSpirit = cardsPage.Goto().GetCardByName("Ice Spirit");
       //     Assert.That(iceSpirit.Displayed);
        }
        
          [Test]
        public void Bandit_headers_are_correct_on_Card_Details_Page()
        {
            new CardsPage(driver).Goto().GetCardByName("Three Musketeers").Click();
            var cardDetails = new CardDetailsPage(driver);

            var (category, arena) = cardDetails.GetCardCategory();
            var cardName = cardDetails.Map.CardName.Text;
            var cardRarity = cardDetails.Map.CardRarity.Text;

            Assert.AreEqual("Three Musketeers", cardName);
            Assert.AreEqual("Troop", category);
            Assert.AreEqual("Arena 7", arena);
            Assert.AreEqual("Rarity\r\nRare", cardRarity);
        }
    }
}