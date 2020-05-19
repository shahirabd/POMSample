using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;

namespace POMSample.PageObjects
{
    class FinalPage
    {
        private IWebDriver driver;
        Int32 timeout = 10000; // in milliseconds

        public FinalPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.XPath, Using = "//*[@id='header_main']/div/div/span")]
        private IWebElement tbLogo;

        public string GetPageTitle()
        {
            return driver.Title;
        }

        // Checks whether the Testbits Logo is displayed properly or not
        public bool GetTBPageLogo()
        {
            return tbLogo.Displayed;
        }

        public void LoadComplete()
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromMilliseconds(timeout));

            // Wait for the page to load
            wait.Until(d => ((IJavaScriptExecutor)d).ExecuteScript("return document.readyState").Equals("complete"));
        }
    }
}
