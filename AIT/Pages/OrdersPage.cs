using OpenQA.Selenium;

namespace AIT.Pages
{
    //this class uses : to inherit the classes within the abstract PageBase class
    public class OrdersPage : PageBase
    {
        //this class does things with the mapped elements listed below
        public readonly OrdersPageMap Map;

        public OrdersPage(IWebDriver driver) : base(driver)
        {
            Map = new OrdersPageMap(driver);
        }
    }

    //this class maps all the elements you need on this page
    public class OrdersPageMap
    {
        IWebDriver _driver;

        public OrdersPageMap(IWebDriver driver)
        {
            _driver = driver;
        }

    }
}
