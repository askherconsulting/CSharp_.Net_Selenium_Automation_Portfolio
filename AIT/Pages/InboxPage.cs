using OpenQA.Selenium;

namespace AIT.Pages
{
    //this class uses : to inherit the classes within the abstract PageBase class
    public class InboxPage : PageBase
    {
        //this class does things with the mapped elements listed below
        public readonly InboxPageMap Map;

        public InboxPage(IWebDriver driver) : base(driver)
        {
            Map = new InboxPageMap(driver);
        }

        public InboxPage openEmail(IWebDriver driver)
       {
           Map.email.Click();
           return this;
       }
    }

    //this class maps all the elements you need on this page
    public class InboxPageMap
    {
        IWebDriver _driver;

        public InboxPageMap(IWebDriver driver)
        {
            _driver = driver;
        }

        public IWebElement email => _driver.FindElement(By.XPath("//*[contains(text(),'TEST - Alert')]"));

    }
}
