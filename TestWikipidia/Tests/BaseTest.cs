using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

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
