using OpenQA.Selenium;

namespace AIT.Pages
{
    //this class uses : to inherit the classes within the abstract PageBase class
    public class MessagePage : PageBase
    {
        //this class does things with the mapped elements listed below
        public readonly MessagePageMap Map;

        public MessagePage(IWebDriver driver) : base(driver)
        {
            Map = new MessagePageMap(driver);
        }

        public MessagePage clickButton(IWebDriver driver)
       {
           Map.button.Click();
           return this;
       }

        public MessagePage clickTextLink(IWebDriver driver)
       {
           Map.textLink.Click();
           return this;
       }
    }

    //this class maps all the elements you need on this page
    public class MessagePageMap
    {
        IWebDriver _driver;

        public MessagePageMap(IWebDriver driver)
        {
            _driver = driver;
        }

        public IWebElement button => _driver.FindElement(By.XPath("//*[contains(text(),'login=')]"));

         public IWebElement textLink => _driver.FindElement(By.XPath("//*[contains(text(),'login=')]"));
        

    }
}
