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

        public IWebElement OrdersLink => _driver.FindElement(By.XPath("//*[@id='menu-sale']//*[@id='menu-sale']"));

    }
}