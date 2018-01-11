using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using SeleniumWebDriver.ExcelOperation;
using System;
using System.Linq;
using System.Threading;

namespace CometProject.PageObject.PaymentInstruction.PayeeSearch
{
    public  class PayeeSearchPage
    {
        private IWebDriver driver;
        public PayeeSearchPage(IWebDriver _driver)
        {
            this.driver = _driver;
        }
        
        public void SwitchToFrame()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            Func<IWebDriver, bool> waitForElement = new Func<IWebDriver, bool>((IWebDriver Web) =>
            {
                int element = driver.FindElements(By.TagName("iframe")).Count;
                if (element != 0)
                {
                    return true;
                }
                return false;
            });
            wait.Until(waitForElement);
            driver.SwitchTo().Frame(driver.FindElement(By.TagName("iframe")));
        }
        public void SearchPayee()
        {            
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            Func<IWebDriver, bool> waitForElement = new Func<IWebDriver, bool>((IWebDriver Web) =>
            {
                if (driver.WindowHandles.Count == 2)
                {
                    return true;
                }
                return false;
            });

            wait.Until(waitForElement);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
           
            driver.SwitchTo().Window(driver.WindowHandles.Last());
            SwitchToFrame();

            driver.FindElement(By.Id("PayeeNameText")).SendKeys(ExcelOperation.GetData[8]);
            driver.FindElement(By.Id("SearchButton")).Click();
            var ele = driver.FindElement(By.Id("SearchButton"));

            IJavaScriptExecutor executor = (IJavaScriptExecutor)driver;
             executor.ExecuteScript("var ele=arguments[0];setTimeout(function(){ele.click();},150)", ele);
                       
            WebDriverWait waitWindow = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            waitWindow.Until(ExpectedConditions.ElementExists(By.XPath(".//*[@id='ResultsGrid']/tbody/tr[2]/td[2]/a")));
            Thread.Sleep(2000);

            var ele1 = driver.FindElement(By.XPath(".//*[@id='ResultsGrid']/tbody/tr[2]/td[2]/a"));
            IJavaScriptExecutor executor1 = (IJavaScriptExecutor)driver;
            executor1.ExecuteScript("var ele1=arguments[0];setTimeout(function(){ele1.click();},150)", ele1);
           
            WebDriverWait waitWindows = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            waitWindows.Until(d => driver.WindowHandles.Count == 1);
            driver.SwitchTo().Window(driver.WindowHandles.Last());
        }
    }
}
