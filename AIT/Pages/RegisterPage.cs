using OpenQA.Selenium;
using Framework;
using Config.Base;

namespace AIT.Pages
{
    //this class uses : to inherit the classes within the abstract PageBase class
    public class RegisterPage : PageBase
    {
        //this class does things with the mapped elements listed below
        public readonly RegisterPageMap Map;

        public RegisterPage(IWebDriver driver) : base(driver)
        {
            Map = new RegisterPageMap(driver);
        }

        public RegisterPage Register(IWebDriver driver)
       {
           Map.Button.Click();
           return this;
       }

         public RegisterPage CreateAccount(string Username, string Email)
       {   
           Map.Username.SendKeys(Username);
           Map.Email.SendKeys(Email);
           Map.Button.Click();
           return this;
       }

          public RegisterPage Login(string Email, string Password)
       {   
           Map.Username.SendKeys(Email);
           Map.Password.SendKeys(Password);
           Map.Button.Click();
           return this;
       }

    }

    //this class maps all the elements you need on this page
    public class RegisterPageMap
    {
        IWebDriver _driver;

        public RegisterPageMap(IWebDriver driver)
        {
            _driver = driver;
        }
 
        public IWebElement Button => _driver.FindElement(By.Id("wp-submit"));

        public IWebElement Username => _driver.FindElement(By.Id("user_login"));

        public IWebElement Email => _driver.FindElement(By.Id("user_email"));
         public IWebElement Password => _driver.FindElement(By.Id("user_pass"));
    }
}