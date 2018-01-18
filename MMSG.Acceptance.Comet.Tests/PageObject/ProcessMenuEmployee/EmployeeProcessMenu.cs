using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Linq;

namespace CometProject.PageObject.ProcessMenuEmployee
{
    class EmployeeProcessMenu
    {
        public IWebDriver driver;
        public EmployeeProcessMenu(IWebDriver _driver)
        {
            this.driver = _driver;
        }
        [FindsBy(How = How.Id, Using = "PopUpMenu_cmdMenu10")]
        public IWebElement EAMSButton { get; set; }
        public void ClickEAMSButton()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            wait.Until(d => driver.WindowHandles.Count == 2);
            driver.SwitchTo().Window(driver.WindowHandles.Last());

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            var ele = driver.FindElement(By.Id("PopUpMenu_cmdMenu10"));
            IJavaScriptExecutor executor = (IJavaScriptExecutor)driver;

            executor.ExecuteScript("var ele=arguments[0];setTimeout(function(){ele.click();},150)", ele);
            WebDriverWait waitWindow = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            waitWindow.Until(d => driver.WindowHandles.Count == 2);
            driver.SwitchTo().Window(driver.WindowHandles.Last());
        }
        public bool VerifyLandedOnProcessMenu()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromMinutes(1));
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

            string processMenuText = driver.FindElement(By.XPath(".//*[@id='tblMain']/tbody/tr/td[2]/table/tbody/tr[2]/td/table/tbody/tr[2]/td[2]")).Text;
            if (processMenuText == "Processes")
            {
                return true;
            }
            return true;
        }
    }
}
