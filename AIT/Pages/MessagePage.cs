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

        public MessagePage clickText(IWebDriver driver)
       {
           Map.textTab.Click();
           return this;
       }

        public MessagePage clickButton(IWebDriver driver)
       {
           Map.button2.Click();
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

        public IWebElement email => _driver.FindElement(By.XPath("//*[contains(text(),subject)]"));

        public IWebElement button => _driver.FindElement(By.XPath("//*[contains(text(),ButtonText)]"));
        public IWebElement textTab => _driver.FindElement(By.Id("pills-textbuthtml-tab"));

        public IWebElement button2 => _driver.FindElement(By.PartialLinkText("View event"));
        

    }
}
