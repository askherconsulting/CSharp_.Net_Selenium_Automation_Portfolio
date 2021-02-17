using OpenQA.Selenium;
using Framework;

namespace Mailinator.Pages
{
    public class HeaderNav
    {
        public readonly HeaderNavMap Map;

        public HeaderNav(IWebDriver driver)
        {
            Map = new HeaderNavMap(driver);
        }

    }


    public class HeaderNavMap
    {
        IWebDriver _driver;

        public HeaderNavMap(IWebDriver driver)
        {
            _driver = driver;
        }

 
    }
}