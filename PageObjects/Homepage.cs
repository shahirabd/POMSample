using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using System;

namespace POMSample.PageObjects
{
    class Homepage
    {
        string test_url = "https://www.google.com";
        private IWebDriver driver;
        private WebDriverWait wait;

        public Homepage(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.Name, Using = "q")]
        [CacheLookup]
        private IWebElement searchTextInput;

        [FindsBy(How = How.Name, Using = "btnK")]
        [CacheLookup]
        private IWebElement searchButton;

        [FindsBy(How = How.Id, Using = "hplogo")]
        [CacheLookup]
        private IWebElement gLogo;

        // Go to the designated page
        public void GoToPage()
        {
            driver.Navigate().GoToUrl(test_url);
        }

        // Returns the Page Title
        public string GetPageTitle()
        {
            return driver.Title;
        }

        // Returns the search string
        public string GetSearchText()
        {
            return searchTextInput.Text;
        }

        // Checks whether the Logo is displayed properly or not
        public bool GetWebPageLogo()
        {
            return gLogo.Displayed;
        }

        public SearchPage TestSearch(string input_search)
        {
            searchTextInput.SendKeys(input_search);
            searchTextInput.Submit();
            return new SearchPage(driver);
        }
    }
}
