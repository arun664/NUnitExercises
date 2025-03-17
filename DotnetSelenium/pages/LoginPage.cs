using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotnetSelenium.pages
{
    public class LoginPage
    {
        private readonly IWebDriver driver;

        public LoginPage( IWebDriver driver )
        {
            this.driver = driver;            
        }


        IWebElement loginBtn => driver.FindElement(By.Id("loginLink"));
        IWebElement username => driver.FindElement(By.Name("UserName"));
        IWebElement password => driver.FindElement(By.Name("Password"));
        IWebElement btnLogin => driver.FindElement(By.CssSelector(".btn"));


        public void clickLogin()
        {
            loginBtn.Click();
        }

        public void loginAdmin(string _username, string _password)
        {
            username.SendKeys(_username);
            password.SendKeys(_password);
            btnLogin.Submit();
        }


    }
}
