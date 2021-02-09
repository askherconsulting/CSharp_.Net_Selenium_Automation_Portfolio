﻿using OpenQA.Selenium;

namespace AIT.Pages
{
    //this class uses : to inherit the classes within the abstract PageBase class
    public class TextPage : PageBase
    {
        //this class does things with the mapped elements listed below
        public readonly TextPageMap Map;

        public TextPage(IWebDriver driver) : base(driver)
        {
            Map = new TextPageMap(driver);
        }

        public TextPage clickLink(string linkText)
       {
           Map.Text.Click();
           return this;
       }
    }

    //this class maps all the elements you need on this page
    public class TextPageMap
    {
        IWebDriver _driver;

        public TextPageMap(IWebDriver driver)
        {
            _driver = driver;
        }

        public IWebElement email => _driver.FindElement(By.XPath("//*[contains(text(subject))]"));

        public IWebElement Text => _driver.FindElement(By.XPath("//*[contains(text(),linkText)]"));

    }
}