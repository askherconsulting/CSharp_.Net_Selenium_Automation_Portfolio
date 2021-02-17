using OpenQA.Selenium;

namespace Mailinator.Pages
{
    //this class uses : to inherit the classes within the abstract PageBase class
    public class ResetPasswordPage : PageBase
    {
        //this class does things with the mapped elements listed below
        public readonly ResetPasswordPageMap Map;

        public ResetPasswordPage(IWebDriver driver) : base(driver)
        {
            Map = new ResetPasswordPageMap(driver);
        }

        public ResetPasswordPage clickLogin(IWebDriver driver)
       {
           Map.loginLink.Click();
           return this;
       }

    }

    //this class maps all the elements you need on this page
    public class ResetPasswordPageMap
    {
        IWebDriver _driver;

        public ResetPasswordPageMap(IWebDriver driver)
        {
            _driver = driver;
        }

        public IWebElement passwordField => _driver.FindElement(By.Id("pass1"));

        public IWebElement loginLink => _driver.FindElement(By.XPath("//*[contains(text(), 'Log in')]"));


    }
}
