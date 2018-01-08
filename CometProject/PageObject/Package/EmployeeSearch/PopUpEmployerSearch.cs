using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumWebDriver.ExcelOperation;
using System;
using System.Linq;

namespace CometProject.PageObject.Package.EmployeeSearch
{
    class PopUpEmployerSearch
    {
        public IWebDriver driver;
        public PopUpEmployerSearch(IWebDriver _driver)
        {
            this.driver = _driver;
        }
        public void SwitchToFrame()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
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
        public void SearchEmployer()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
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

            driver.FindElement(By.Id("EmployerCodeText")).Clear();
            driver.FindElement(By.Id("EmployerCodeText")).SendKeys(ExcelOperation.GetData[2]);

            // Click on Search button
            var ele = driver.FindElement(By.Id("SearchButton"));
            IJavaScriptExecutor executor = (IJavaScriptExecutor)driver;
            executor.ExecuteScript("var ele=arguments[0];setTimeout(function(){ele.click();},100)", ele);

            // Select the record from the grid
            var ele1 = driver.FindElement(By.XPath(".//*[@id='ResultsGrid']/tbody/tr[2]/td[2]/a"));
            IJavaScriptExecutor executor1 = (IJavaScriptExecutor)driver;
            executor1.ExecuteScript("var ele1=arguments[0];setTimeout(function(){ele1.click();},100)", ele1);

            WebDriverWait waitWindow = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            waitWindow.Until(d => driver.WindowHandles.Count == 1);
            driver.SwitchTo().Window(driver.WindowHandles.Last());
        }
        public static void SwitchToDialogBox(IWebDriver driver, string parent)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            wait.Until(d => d.WindowHandles.Count == 2);

            //Switch to Modal dialog
            if (driver.WindowHandles.Count == 2)
            {
                foreach (string window in driver.WindowHandles)
                {
                    if (!window.Equals(parent))
                    {
                        driver.SwitchTo().Window(window);
                        break;
                    }
                }
            }
        }
    }
}
