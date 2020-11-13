using OpenQA.Selenium;

//note this is where anything which affects everything is stored (global stuff)

namespace AIT.Pages
{
    //abstract means this class cannot be instantiated by itself only through another class inheriting it
    public abstract class PageBase
    {
        public readonly HeaderNav HeaderNav;

        public PageBase(IWebDriver driver)
        {
            HeaderNav = new HeaderNav(driver);
        }
    }
}