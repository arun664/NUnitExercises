using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

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
    }
}