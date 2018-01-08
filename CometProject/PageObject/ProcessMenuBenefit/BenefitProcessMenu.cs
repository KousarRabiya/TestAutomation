using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Linq;

namespace CometProject.PageObject.ProcessMenuBenefit
{
    class BenefitProcessMenu
    {
        private IWebDriver driver;
        public BenefitProcessMenu(IWebDriver _driver)
        {
            this.driver = _driver;
        }

        [FindsBy(How = How.Id, Using = "PopUpMenu_cmdMenu9")]
        public IWebElement EditPaymentInstructionButton { get; set; }
        public void ClickOnEditPaymentInstruction()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            wait.Until(d => driver.WindowHandles.Count == 2);
           
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.SwitchTo().Window(driver.WindowHandles.Last());
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            var ele = driver.FindElement(By.Id("PopUpMenu_cmdMenu9"));
            IJavaScriptExecutor executor = (IJavaScriptExecutor)driver;
            executor.ExecuteScript("var ele=arguments[0];setTimeout(function(){ele.click();},150)", ele);

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            WebDriverWait waitWindow = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            waitWindow.Until(d => driver.WindowHandles.Count == 1);
            driver.SwitchTo().Window(driver.WindowHandles.Last());
        }
        public void VerifyPageLandedOnProcessMenu()
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
            WebDriverWait waitWindow = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            waitWindow.Until(d => driver.Title == "PROCESSES");
        }
    }
}
