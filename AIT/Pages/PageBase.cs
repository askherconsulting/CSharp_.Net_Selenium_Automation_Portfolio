using OpenQA.Selenium;

namespace AIT.Pages
{
    public abstract class PageBase
    {
        public readonly HeaderNav HeaderNav;

        public PageBase(IWebDriver driver)
        {
            HeaderNav = new HeaderNav(driver);
        }
    }
}