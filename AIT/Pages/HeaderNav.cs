using OpenQA.Selenium;
using Framework;

namespace AIT.Pages
{
    public class HeaderNav
    {
        public readonly HeaderNavMap Map;

        public HeaderNav(IWebDriver driver)
        {
            Map = new HeaderNavMap(driver);
        }

        public void GotoSalesMenuDropdown()
        {
            FW.Log.Step("Navigate to Sales side bar menu");
            Map.SalesLink.Click();
        }
    

        public void GotoOrdersMenuDropdown()
        {  
            FW.Log.Step("Navigate to Sales -> orders side bar menu");
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