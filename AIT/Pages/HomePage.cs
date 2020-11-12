using OpenQA.Selenium;

namespace AIT.Pages
{
    //this class uses : to inherit the classes within the abstract PageBase class
    public class HomePage : PageBase
    {
        //this class does things with the mapped elements listed below
        public readonly HomePageMap Map;

        public HomePage(IWebDriver driver) : base(driver)
        {
            Map = new HomePageMap(driver);
        }

       public HomePage Goto()
       {
            HeaderNav.GotoSupportPage();
            return this;
       }

        public HomePage EnterBookingDetails(string name, string email, string phone, string subject, string description)
       {
           Map.Name.SendKeys(name);
           Map.Email.SendKeys(email);
           Map.Phone.SendKeys(phone);
           Map.Subject.SendKeys(subject);
           Map.Description.SendKeys(description);
           Map.SubmitButton.Click();
           return this;
       }

    //      public HomePage thankyouMessage()
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
    public class HomePageMap
    {
        IWebDriver _driver;

        public HomePageMap(IWebDriver driver)
        {
            _driver = driver;
        }
        //example of dynamic element reference
        public IWebElement Name => _driver.FindElement(By.Id("name"));

        public IWebElement Email => _driver.FindElement(By.Id("email"));

        public IWebElement Phone => _driver.FindElement(By.Id("phone"));

        public IWebElement Subject => _driver.FindElement(By.Id("subject"));

        public IWebElement SubmitButton => _driver.FindElement(By.Id("submitContact"));

         public IWebElement Description => _driver.FindElement(By.Id("description"));

  //      public IWebElement ThankyouMessage =>_driver.FindElement(By.CssSelector("div[class='row contact']"));
    }
}