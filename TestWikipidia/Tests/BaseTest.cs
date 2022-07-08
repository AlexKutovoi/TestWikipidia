using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;

namespace TestWikipidia.Tests
{
    public class BaseTest : IDisposable
    {
        protected readonly IWebDriver driver;
        private bool disposedValue;

        protected BaseTest()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();

            driver.Navigate().GoToUrl("https://ru.wikipedia.org");

        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            driver?.Dispose();
        }

    }

}
