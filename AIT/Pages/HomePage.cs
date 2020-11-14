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

        public HomePage GoTo()
        {
            HeaderNav.GotoOrdersPage();
            return this;
        }

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
        //example of dynamic element reference
        public IWebElement DashboardTitle => _driver.FindElement(By.XPath("//*[h1='Dashboard']"));

        public IWebElement Phone => _driver.FindElement(By.Id("phone"));

        public IWebElement Subject => _driver.FindElement(By.Id("subject"));

        public IWebElement SubmitButton => _driver.FindElement(By.Id("submitContact"));

        public IWebElement Description => _driver.FindElement(By.Id("description"));
        public IWebElement LogoutButton => _driver.FindElement(RelativeBy.WithTagName("li").RightOf(By.ClassName("dropdown")));
    }
}