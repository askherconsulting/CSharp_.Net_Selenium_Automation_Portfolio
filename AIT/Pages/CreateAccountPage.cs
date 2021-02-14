using System;
using OpenQA.Selenium;
using Framework;

namespace AIT.Pages
{
    //this class uses : to inherit the classes within the abstract PageBase class
    public class CreateAccountPage : PageBase
    {
        //this class does things with the mapped elements listed below
        public readonly CreateAccountPageMap Map;

        public CreateAccountPage(IWebDriver driver) : base(driver)
        {
            Map = new CreateAccountPageMap(driver);
        }

        public CreateAccountPage CreateAccount(string FirstName, string LastName, string Email, string Password)
       {
           
           Map.FirstName.SendKeys(FirstName);
           Map.LastName.SendKeys(LastName);
           Map.Email.SendKeys(Email);
           Map.Password.SendKeys(Password);
           Map.CreateAccountButton.Click();
           return this;
       }

        public CreateAccountPage ClickCreateAccountButton (IWebDriver driver)
       {
           Map.CreateAccountButton.Click();
           return this;
       }


    }

    //this class maps all the elements you need on this page
    public class CreateAccountPageMap
    {
        IWebDriver _driver;

        public CreateAccountPageMap(IWebDriver driver)
        {
            _driver = driver;
        }

        
        public IWebElement FirstName => _driver.FindElement(By.Id("first-name-su"));

        public IWebElement LastName => _driver.FindElement(By.Id("last-name-su"));

         public IWebElement Email => _driver.FindElement(By.Id("email-su"));

         public IWebElement Password => _driver.FindElement(By.Id("password-su"));

         public IWebElement CreateAccountButton => _driver.FindElements(By.XPath("//button[contains(text(),'Create account')]"))[1];

    }
}