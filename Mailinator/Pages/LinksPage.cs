using OpenQA.Selenium;

namespace Mailinator.Pages
{
    //this class uses : to inherit the classes within the abstract PageBase class
    public class LinksPage : PageBase
    {
        //this class does things with the mapped elements listed below
        public readonly LinksPageMap Map;

        public LinksPage(IWebDriver driver) : base(driver)
        {
            Map = new LinksPageMap(driver);
        }

        public LinksPage viewLinks(IWebDriver driver)
       {
           Map.links.ToString();
           return this;
       }
    }

    //this class maps all the elements you need on this page
    public class LinksPageMap
    {
        IWebDriver _driver;

        public LinksPageMap(IWebDriver driver)
        {
            _driver = driver;
        }

        public IWebElement email => _driver.FindElement(By.XPath("//*[contains(text(),subject)]"));

        public IWebElement links => _driver.FindElement(By.Id("clicklinks"));

    }
}
