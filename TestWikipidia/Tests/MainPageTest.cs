using NUnit.Framework;
using TestWikipidia.Pages;

namespace TestWikipidia.Tests
{
    public class MainPageTest : BaseTest
    {
        [Test]
        public void CheckOpenPhilosophyPage()
        {
            new MainPage(driver)
                .ClickOnRandomArticle()
                .FindPhilosophyPage();                 
        }
    }
}
