using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.IO;

namespace Royale.Tests
{
   public class AITTestsChrome

    {
        IWebDriver driver;

        [SetUp]
        public void BeforeEach()
        {
            driver = new ChromeDriver(Path.GetFullPath(@"../../../../" + "_drivers"));
        }

        [TearDown]
        public void AfterEach()
        {
            driver.Quit();
        }

        [Test]
        public void Principles_Is_Naviable()
        {
            //1. Maximise window
            driver.Manage().Window.Maximize();
            //2. go to AIT home page         
            driver.Url = "https://automationintesting.com";
            //4. click principles area
            driver.FindElement(By.Id("quicklook-principes")).Click();
            //5. Assert principles section shown
            var principles = driver.FindElement(By.Id("principles"));
            Assert.That(principles.Displayed);
        }

        [Test]
        public void SupportUs_Link_Redirects()
        {
            //1. Maximise window
            driver.Manage().Window.Maximize();
            //2. go to AIT home page         
            driver.Url = "https://automationintesting.com";
            //4. click principles area
            driver.FindElement(By.CssSelector("a[href*='/support']")).Click();
            //5. Assert principles section shown
            var support = driver.FindElement(By.ClassName("info-title")).Text;
            Assert.That(support.Equals("SUPPORT AUTOMATION IN TESTING"));
        }
    }
}