using OpenQA.Selenium;

namespace AIT.Pages
{
    //this class uses : to inherit the classes within the abstract PageBase class
    public class OrdersPage : PageBase
    {
        //this class does things with the mapped elements listed below
        public readonly OrdersPageMap Map;

        public OrdersPage(IWebDriver driver) : base(driver)
        {
            Map = new OrdersPageMap(driver);
        }

       public OrdersPage Goto()
       {
            HeaderNav.GotoSupportPage();
            return this;
       }

        public OrdersPage Login(string name, string password)
       {
           Map.Name.Clear();
           Map.Name.SendKeys(name);
           Map.Password.Clear();
           Map.Password.SendKeys(password);
           Map.LoginButton.Click();
           return this;
       }


    //      public OrdersPage thankyouMessage()
    //    {
    //        //v
    //        Map.ThankyouMessage.Contains();
    //        return this;
    //    }
    }

    //    public IWebElement GetLinkByName(string LinkHRef)
        // {
        //     // Given the cardName "Link+Name" => should turn into "Link Name" to work with our locator.
        //     if (LinkHRef.Contains("+"))
        //     {
        //         LinkHRef = LinkHRef.Replace("+", " ");
        //     }

        //    return Map.Link(LinkHRef);
 //       }
    

    //this class maps all the elements you need on this page
    public class OrdersPageMap
    {
        IWebDriver _driver;

        public OrdersPageMap(IWebDriver driver)
        {
            _driver = driver;
        }
        //example of dynamic element reference
        public IWebElement Name => _driver.FindElement(By.Id("input-username"));

         public IWebElement Password => _driver.FindElement(By.Id("input-password"));

        public IWebElement LoginButton => _driver.FindElement(By.XPath("//button[contains(text(),'Login')]"));
//*[@id='select-students-update-panel']//*[contains(text(), 'Update students')]
        public IWebElement OrdersPageTitle => _driver.FindElement(By.XPath("//*[h1]//*[contains(text(), 'Please enter your login details.')]"));
  //      public IWebElement ThankyouMessage =>_driver.FindElement(By.CssSelector("div[class='row contact']"));
    }
}