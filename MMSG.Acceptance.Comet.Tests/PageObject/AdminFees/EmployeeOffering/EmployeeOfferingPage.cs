using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Linq;

namespace CometProject.PageObject.AdminFees.EmployeeOffering
{
    class EmployeeOfferingPage
    {
        private IWebDriver driver;
        public EmployeeOfferingPage(IWebDriver _driver)
        {
            this.driver = _driver;
        }       
        
        public void ClickOnSearchResult()
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
            driver.SwitchTo().Window(driver.WindowHandles.Last());

            SwitchToFrame();

            WebDriverWait waitWindow = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            waitWindow.Until(ExpectedConditions.ElementExists(By.XPath(".//*[@id='ResultsGrid']/tbody/tr[2]/td[1]/a")));

            // Select data from grid
            var ele = driver.FindElement(By.XPath(".//*[@id='ResultsGrid']/tbody/tr[2]/td[1]/a"));
            IJavaScriptExecutor executor = (IJavaScriptExecutor)driver;
            executor.ExecuteScript("var ele=arguments[0];setTimeout(function(){ele.click();},150)", ele);

            WebDriverWait waitWindows = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            waitWindows.Until(d => driver.WindowHandles.Count == 1);
            driver.SwitchTo().Window(driver.WindowHandles.Last());
        }
        public void SwitchToFrame()
        {
            //WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            Func<IWebDriver, bool> waitForElement = new Func<IWebDriver, bool>((IWebDriver Web) =>
            {
                int element = driver.FindElements(By.TagName("iframe")).Count;
                if (element!=0)
                {
                    return true;
                }
                return false;
            });
            wait.Until(waitForElement);
            // wait.Until(ExpectedConditions.ElementExists(By.TagName("iframe")));
            driver.SwitchTo().Frame(driver.FindElement(By.TagName("iframe")));
        }
    }
}
