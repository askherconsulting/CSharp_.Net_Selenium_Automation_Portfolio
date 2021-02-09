using OpenQA.Selenium;
using Framework;

namespace AIT.Pages
{
    //this class uses : to inherit the classes within the abstract PageBase class
    public class LoginPage : PageBase
    {
        //this class does things with the mapped elements listed below
        public readonly LoginPageMap Map;

        public LoginPage(IWebDriver driver) : base(driver)
        {
            Map = new LoginPageMap(driver);
        }

        public LoginPage Login(IWebDriver driver)
       {
           FW.Log.Step("Logging in");
           Map.Email.SendKeys("Bethmarshall2013@hotmail.co.uk");
           Map.Password.SendKeys("Shameful-rabbit0");
           Map.LoginButton.Click();
           return this;
       }

    }

    //this class maps all the elements you need on this page
    public class LoginPageMap
    {
        IWebDriver _driver;

        public LoginPageMap(IWebDriver driver)
        {
            _driver = driver;
        }
        public IWebElement Email => _driver.FindElement(By.Id("many_login_email"));

        public IWebElement Password => _driver.FindElement(By.Id("many_login_password"));

        public IWebElement LoginButton => _driver.FindElement(By.XPath("//*[contains(text(),'Log in')]"));
        
        public IWebElement LoginPageTitle => _driver.FindElement(By.XPath("//*[h1]//*[contains(text(), 'Please enter your login details.')]"));
    }
}