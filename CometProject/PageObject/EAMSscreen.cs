using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Linq;

namespace CometProject.PageObject
{
    class EAMSscreen
    {
        public IWebDriver driver;
        public EAMSscreen(IWebDriver _driver)
        {
            this.driver = _driver;
        }
        public void ClickOnClose()
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            if (driver.Title != "Maxxia Account Snapin")
            {
                driver.SwitchTo().Window(driver.WindowHandles.Last());
            }
            driver.Close();
        }
        public void PageLandedOnEAMSProfilePage()
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
            driver.SwitchTo().Window(driver.WindowHandles.Last());
            WebDriverWait waitWindow = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            waitWindow.Until(ExpectedConditions.ElementIsVisible(By.Name("frmMain")));

           // driver.SwitchTo().Frame(driver.FindElement(By.Name("frmMain")));
            WebDriverWait waitWindows = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            waitWindows.Until(d => driver.Title != "Maxxia Account Snapin");
        }
        public bool CheckEAMSIsCreated()
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.SwitchTo().Window(driver.WindowHandles.Last());
            driver.SwitchTo().Frame(driver.FindElement(By.Name("frmMain")));

            var text_input = driver.FindElement(By.XPath(".//*[@id='frmMain']/table[1]/tbody/tr[2]/td[2]/table[2]/tbody/tr[2]/td[3]/input"));
            if (!string.IsNullOrEmpty(text_input.GetAttribute("value")))
            {
                return true;
            }
            return false;
        }
    }
}
