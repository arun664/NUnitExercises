using DotnetSelenium.pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace DotnetSelenium
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void GoogleSearch()
        {
            IWebDriver driver = new ChromeDriver();

            driver.Navigate().GoToUrl(@"https://www.google.com/");

            IWebElement googleSearchInputBox = driver.FindElement(By.Name("q"));

            googleSearchInputBox.SendKeys("dotnet selenium");
            googleSearchInputBox.SendKeys(Keys.Return);
        }

        [Test]
        public void EaWebsiteLogin()
        {
            IWebDriver driver = new ChromeDriver();

            driver.Navigate().GoToUrl(@"http://eaapp.somee.com/");

            driver.FindElement(By.Id("loginLink")).Click();
            driver.FindElement(By.Name("UserName")).SendKeys("admin");
            driver.FindElement(By.Name("Password")).SendKeys("password");
            driver.FindElement(By.CssSelector(".btn")).Submit();
        }

        [Test]
        public void AdvancedActions()
        {
            IWebDriver driver = new ChromeDriver();
            Actions actions = new Actions(driver);

            driver.Navigate().GoToUrl(@"https://proleed.academy/exercises/selenium/automation-practice-form-with-radio-button-check-boxes-and-drop-down.php");

            driver.Manage().Window.Maximize();

            SelectElement selectPrefix = new SelectElement(driver.FindElement(By.Id("prefix")));
            selectPrefix.SelectByText("Mr.");

            driver.FindElement(By.Id("firstname")).SendKeys("FirstName");

            driver.FindElement(By.Id("lastname")).SendKeys("LastName");

            var accountType = driver.FindElement(By.Id("current"));
            actions.ScrollToElement(accountType).Perform();
            accountType?.Click();

            driver.FindElement(By.Name("fathername")).SendKeys("FatherName");

            driver.FindElement(By.Name("mothername")).SendKeys("MotherName");

            IWebElement multiIdSelect = driver.FindElement(By.Id("passport"));
            actions.ScrollToElement(multiIdSelect).Perform();
            driver.FindElement(By.Id("passport")).Click();
            driver.FindElement(By.Id("studentid")).Click();

            
            IWebElement submitButton = driver.FindElement(By.XPath("//input[@value='Submit']"));
            actions.MoveToElement(submitButton).Perform();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            submitButton?.Submit();
        }

        [Test]
        public void EaWebsiteLoginWithPOM()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl(@"http://eaapp.somee.com/");
            LoginPage loginPage = new LoginPage(driver);
            loginPage.clickLogin();
            loginPage.loginAdmin("admin", "password");
        }
    
    }
}