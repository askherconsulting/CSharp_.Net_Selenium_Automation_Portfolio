using System;
using Framework;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;



namespace Config.Base
{


    public abstract class ConfigBase
    {
        public string username = "bethmarshall2013@hotmail.co.uk";
        public string password = "Shameful-rabbit0";

        
         public string generateUniquePublicMailinatorEmail(IWebDriver driver)
       {          

           Random rand = new Random();

           string emailPrefix = "Beth";
           int emailSuffix = rand.Next(1000, 9999);
           
           string randomMailinatorPublicEmail = emailPrefix + emailSuffix + "@mailinator.com";
           Console.WriteLine("the unique email used for this test is " + randomMailinatorPublicEmail);
           return randomMailinatorPublicEmail;
       }

           public string generateUniquePrivateMailinatorEmailSuffix(IWebDriver driver)
       {          
           
           string randomMailinatorPrivateEmailSuffix = "@bethtest.testinator.com";
           Console.WriteLine("the unique email suffix used for this test is " + randomMailinatorPrivateEmailSuffix);
           return randomMailinatorPrivateEmailSuffix;
       }

        public string generateUniquePrivateMailinatorEmailPrefix(IWebDriver driver)
       {          

           Random rand = new Random();

           string emailPrefix = "Beth";
           int emailNumber = rand.Next(1000, 9999);
           string emailSuffix = "@bethtest.testinator.com";
           
           string randomMailinatorPrivateEmailPrefix = emailPrefix + emailNumber + emailSuffix ;
           Console.WriteLine("the unique email prefix used for this test is " + randomMailinatorPrivateEmailPrefix);
           return randomMailinatorPrivateEmailPrefix;
       }

       public string generateUniquePassword(IWebDriver driver)
       {          
           Random rand = new Random();

           string passwordPrefix = "Beth!%U?";
           int passwordSuffix = rand.Next(1000, 9999);

           string randomPassword = passwordPrefix + passwordSuffix;
           Console.WriteLine("the unique password used for this test is " + randomPassword);
           return randomPassword;
       }

        public string generateUniqueUsername(IWebDriver driver)
       {          
           Random rand = new Random();

           string usernamePrefix = "Beth";
           int usernameSuffix = rand.Next(1, 9999);

           string randomUsername = usernamePrefix + usernameSuffix;
           Console.WriteLine("the unique username used for this test is " + randomUsername);
           return randomUsername;
       }
        
    }
}