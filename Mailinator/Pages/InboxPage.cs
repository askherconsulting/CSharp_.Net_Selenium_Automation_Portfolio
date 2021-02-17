using OpenQA.Selenium;

namespace Mailinator.Pages
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

        public InboxPage openEmail(IWebElement email)
       {
           email.Click();
           return this;
       }

         public InboxPage selectInbox(string inboxName)
       {
           Map.inboxName.Clear();
           Map.inboxName.SendKeys(inboxName);
           Map.inboxName.SendKeys(Keys.Enter);
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

        public IWebElement emailWP => _driver.FindElement(By.XPath("//*[contains(text(),'WordPress')]"));

        public IWebElement emailSW => _driver.FindElement(By.XPath("//*[contains(text(),'View event')]"));
        public IWebElement inboxName => _driver.FindElement(By.Id("inbox_field"));

    }
}
