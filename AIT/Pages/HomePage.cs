using OpenQA.Selenium;
using Framework;


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

        public HomePage GoToSalesMenu()
        {
            FW.Log.Step("Navigate to Sales side bar menu");
            HeaderNav.GotoSalesMenuDropdown();
            return this;
        }

        public HomePage GoToOrdersMenu()
        {
            FW.Log.Step("Navigate to Sales -> orders side bar menu");
            HeaderNav.GotoOrdersMenuDropdown();
            return this;
        }

/* this code comes from Carlos Kidmans course and is an example of how to get rid of an accept cookies prompt by waiting for it to not be visible anymore
       
        public void AcceptCookies()
        {
            Map.AcceptCookiesButton.Click();
            Driver.Wait.Until(drvr => !Map.AcceptCookiesButton.Displayed);
        }

*/

        public HomePage EnterBookingDetails( string phone, string subject, string description)
       {
  
           Map.Phone.SendKeys(phone);
           Map.Subject.SendKeys(subject);
           Map.Description.SendKeys(description);
           Map.SubmitButton.Click();
           return this;
       }

        public HomePage Logout(IWebDriver driver)
       {
           Map.LogoutButton.Click();
           return this;
       }
    }
   
     //this class maps all the elements you need on this page
    public class HomePageMap
    {
        IWebDriver _driver;

        public HomePageMap(IWebDriver driver)
        {
            _driver = driver;
        }
        public IWebElement Phone => _driver.FindElement(By.Id("phone"));

        public IWebElement Subject => _driver.FindElement(By.Id("subject"));

        public IWebElement SubmitButton => _driver.FindElement(By.Id("submitContact"));

        public IWebElement Description => _driver.FindElement(By.Id("description"));
        
        //relative locator example
        public IWebElement LogoutButton => _driver.FindElement(RelativeBy.WithTagName("li").RightOf(By.ClassName("dropdown")));
        /*
        /the same command in Java would be:-
        / public IWebElement LogoutButtonJava => _driver.FindElement(withTagName("li").toRightOf(By.ClassName("dropdown")));
        */
    }
}