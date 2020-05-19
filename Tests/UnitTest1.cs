using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using POMSample.Constants;
using POMSample.PageObjects;

namespace POMSample
{
    public class Tests
    {
        public string searchText = "Testbits";
        public string pageTitle = "Google";
        private IWebDriver driver;

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
        }

        [Test]
        public void SearchTB()
        {
            //string expectedTitle = "Software Testing Solution | Testbits | Top Application & Software Testing";
            string actualTitle;
            Homepage homePage = new Homepage(driver);
            homePage.GoToPage();
            homePage.TestSearch(searchText);

            SearchPage searchPage = new SearchPage(driver);
            FinalPage finalPage = searchPage.ClickSearchResults();
            finalPage.LoadComplete();
            actualTitle = finalPage.GetPageTitle();

            //Assert.AreEqual(expectedTitle, actualTitle, "Page title not matched.");
            Assert.AreEqual(TextConstant.tbHomePageTitle, actualTitle, "Page title not matched.");
        }

        [TearDown]
        public void Teardown()
        {
            driver.Close();
        }
    }
}