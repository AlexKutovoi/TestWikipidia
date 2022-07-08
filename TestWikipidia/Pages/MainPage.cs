using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System.Text;

namespace TestWikipidia.Pages
{
    public class MainPage
    {        
        private IWebDriver driver;
        public MainPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        private By tapOnUrl = By.Id("n-randompage");
        private By titleName = By.Id("firstHeading");
        private By titleMainUrl = By.XPath("//div[@class='mw-parser-output']/p[1]/a[contains(@href,'wiki/%D0%')]");


        public MainPage ClickOnRandomArticle()
        {                
                var wait = new WebDriverWait(driver, new TimeSpan(0, 0, 30));
                wait.Until(ExpectedConditions.ElementToBeClickable(tapOnUrl));
                driver.FindElement(tapOnUrl).Click();              
           
            return this;
        }
        public MainPage FindPhilosophyPage() 
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            int step = 1;
            while (!driver.FindElement(titleName).Text.Equals("Философия"))
            {
                WriteLogsSteps(step.ToString());
                var link = driver.FindElements(titleMainUrl);
                for (int i = 0; i < link.Count; i++)
                {
                    bool wrongLink = link[i].Text.Contains(".") || link[i].Text.Contains("-");

                    if (!wrongLink)
                    {
                        link[i].Click();
                        break;
                    }
                    else if (driver.FindElements(By.CssSelector("[title='Философия']")).Count > 0)
                    {
                        driver.FindElement(By.CssSelector("[title='Философия']")).Click();
                        break;
                    }
                    else if (link.Count == 0)
                    {
                        driver.FindElement(tapOnUrl).Click(); 
                        break;
                    }                     
                }
                step++;
            }
            WriteLogsSteps(step.ToString());
            return this;
        }

        public void WriteLogsSteps(string step)
        {
            string title = driver.FindElement(titleName).Text;
            string url = driver.Url;
            string filePath = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName+@"/";
            StringBuilder s = new StringBuilder();
            s.AppendLine("Шаг " + step + " - " + title + " - " + url);
            File.AppendAllText(filePath + "log.txt", s.ToString());           
        }
    }
}
