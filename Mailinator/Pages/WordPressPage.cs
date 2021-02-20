using System.Threading;
using OpenQA.Selenium;

namespace Mailinator.Pages
{
    //this class uses : to inherit the classes within the abstract PageBase class
    public class WordPressPage : PageBase
    {
        //this class does things with the mapped elements listed below
        public readonly WordPressPageMap Map;

        public WordPressPage(IWebDriver driver) : base(driver)
        {
            Map = new WordPressPageMap(driver);
        }

        public WordPressPage ScrollToBottom(IWebDriver driver)
            {
                ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", Map.RegisterLink);
                Thread.Sleep(1000);
                return this;
            }


         public WordPressPage ClickRegister(IWebDriver driver)
       {   
             
           Map.RegisterLink.Click();
           return this;
       }

    }

    //this class maps all the elements you need on this page
    public class WordPressPageMap
    {
        IWebDriver _driver;

        public WordPressPageMap(IWebDriver driver)
        {
            _driver = driver;
        }


 
        public IWebElement RegisterLink => _driver.FindElement(By.PartialLinkText("Register"));
    }
}