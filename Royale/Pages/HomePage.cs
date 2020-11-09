using OpenQA.Selenium;

namespace Royale.Pages
{
    public class HomePage : PageBase
    {
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


        public IWebElement GetLinkByName(string LinkHRef)
        {
            // Given the cardName "Link+Name" => should turn into "Link Name" to work with our locator.
            if (LinkHRef.Contains("+"))
            {
                LinkHRef = LinkHRef.Replace("+", " ");
            }

            return Map.Link(LinkHRef);
        }
    }

    public class HomePageMap
    {
        IWebDriver _driver;

        public HomePageMap(IWebDriver driver)
        {
            _driver = driver;
        }
        //example of dynamic element reference
        public IWebElement Link(string name) => _driver.FindElement(By.CssSelector($"a[href*='{name}']"));


    }
}