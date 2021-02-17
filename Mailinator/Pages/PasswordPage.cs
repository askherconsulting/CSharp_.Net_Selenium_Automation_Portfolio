using OpenQA.Selenium;

namespace Mailinator.Pages
{
    //this class uses : to inherit the classes within the abstract PageBase class
    public class PasswordPage : PageBase
    {
        //this class does things with the mapped elements listed below
        public readonly PasswordPageMap Map;

        public PasswordPage(IWebDriver driver) : base(driver)
        {
            Map = new PasswordPageMap(driver);
        }

        public PasswordPage enterPassword(string password)
       {          
           Map.passwordField.Clear();
           Map.passwordField.SendKeys(password);
           return this;
       }

       
        public PasswordPage clickResetPasswordButton(IWebDriver driver)
       {
           Map.button.Click();
           return this;
       }

    }

    //this class maps all the elements you need on this page
    public class PasswordPageMap
    {
        IWebDriver _driver;

        public PasswordPageMap(IWebDriver driver)
        {
            _driver = driver;
        }

        public IWebElement passwordField => _driver.FindElement(By.XPath("//*[@id='pass1']"));

        public IWebElement button => _driver.FindElement(By.Id("wp-submit"));

        public IWebElement passStrengthResult => _driver.FindElement(By.XPath("//*[@id='pass-strength-result'][text()='Strong']"));


    }
}
