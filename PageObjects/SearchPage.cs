using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using NUnit.Framework;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;

namespace POMSample.PageObjects
{
    class SearchPage
    {
        private IWebDriver driver;
        Int32 timeout = 10000; // in milliseconds

        public SearchPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.XPath, Using = "//*[@id='rso']/div[1]/div/div/div[1]/a")]
        private IWebElement firstResult;

        async void AsyncDelay()
        {
            await Task.Delay(50);
        }

        public FinalPage ClickSearchResults()
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromMilliseconds(timeout));

            // Wait for the page to load
            wait.Until(d => ((IJavaScriptExecutor)d).ExecuteScript("return document.readyState").Equals("complete"));

            firstResult.Click();

            AsyncDelay();

            return new FinalPage(driver);
        }
    }
}
