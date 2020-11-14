using System.Threading;
using System;
using OpenQA.Selenium;

namespace AIT.Pages
{
    public class HeaderNav
    {
        public readonly HeaderNavMap Map;

        public HeaderNav(IWebDriver driver)
        {
            Map = new HeaderNavMap(driver);
        }

        public void GotoOrdersPage()
        {
            Map.SalesLink.Click();
            
            Map.OrdersLink.Click();
        }
    }

    public class HeaderNavMap
    {
        IWebDriver _driver;

        public HeaderNavMap(IWebDriver driver)
        {
            _driver = driver;
        }

        public IWebElement OrdersLink => _driver.FindElement(By.XPath("//*[@id='menu-sale']//*[contains(text(),'Orders')]"));

        public IWebElement SalesLink => _driver.FindElement(By.XPath("//*[@id='menu-sale']"));
 
    }
}