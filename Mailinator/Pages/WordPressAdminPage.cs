using System.Threading;
using OpenQA.Selenium;

namespace Mailinator.Pages
{
    //this class uses : to inherit the classes within the abstract PageBase class
    public class WordPressAdminPage : PageBase
    {
        //this class does things with the mapped elements listed below
        public readonly WordPressAdminPageMap Map;

        public WordPressAdminPage(IWebDriver driver) : base(driver)
        {
            Map = new WordPressAdminPageMap(driver);
        }

        public WordPressAdminPage clickResetPasswordButton(IWebDriver driver)
       {
           Map.button.Click();
           return this;
       }

    }

    //this class maps all the elements you need on this page
    public class WordPressAdminPageMap
    {
        IWebDriver _driver;

        public WordPressAdminPageMap(IWebDriver driver)
        {
            _driver = driver;
        }

        public IWebElement button => _driver.FindElement(By.Id("wp-submit"));

        public IWebElement passStrengthResult => _driver.FindElement(By.XPath("//*[@id='pass-strength-result'][text()='Strong']"));
    }
}
