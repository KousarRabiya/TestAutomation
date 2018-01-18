using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Linq;

namespace CometProject.PageObject
{
    class ProcessMenuPage
    {
        public IWebDriver driver;
        public ProcessMenuPage(IWebDriver _driver)
        {
            this.driver = _driver;
        }

        [FindsBy(How = How.Id, Using = "PopUpMenu_cmdMenu2")]
        public IWebElement EditButton { get; set; }

        [FindsBy(How = How.Id, Using = "PopUpMenu_cmdMenu10")]
        public IWebElement AdminFeesButton { get; set; }

        [FindsBy(How = How.Id, Using = "PopUpMenu_cmdMenu6")]
        public IWebElement NewBenefitButton { get; set; }
        public void clickOnEdit()
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
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            var ele = driver.FindElement(By.Id("PopUpMenu_cmdMenu2"));

            IJavaScriptExecutor executor = (IJavaScriptExecutor)driver;
            executor.ExecuteScript("var ele=arguments[0];setTimeout(function(){ele.click();},150)", ele);
            WebDriverWait waitWindows = new WebDriverWait(driver, TimeSpan.FromSeconds(30));

            waitWindows.Until(d => driver.WindowHandles.Count == 1);
            driver.SwitchTo().Window(driver.WindowHandles.Last());
        }
        public void ClickOnAdminFee()
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
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            var ele = driver.FindElement(By.Id("PopUpMenu_cmdMenu10"));
            IJavaScriptExecutor executor = (IJavaScriptExecutor)driver;
            executor.ExecuteScript("var ele=arguments[0];setTimeout(function(){ele.click();},150)", ele);

            WebDriverWait waitWindows = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            waitWindows.Until(d => driver.WindowHandles.Count == 1);
            driver.SwitchTo().Window(driver.WindowHandles.Last());
        }
        public void ClickNewBenefitButton()
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
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            var ele = driver.FindElement(By.Id("PopUpMenu_cmdMenu6"));
            IJavaScriptExecutor executor = (IJavaScriptExecutor)driver;
            executor.ExecuteScript("var ele=arguments[0];setTimeout(function(){ele.click();},150)", ele);

            WebDriverWait waitWindows = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            waitWindows.Until(d => driver.WindowHandles.Count == 1);
            driver.SwitchTo().Window(driver.WindowHandles.Last());
        }

        public void ClickReviewActivateButton()
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
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            var ele = driver.FindElement(By.Id("PopUpMenu_cmdMenu5"));
            IJavaScriptExecutor executor = (IJavaScriptExecutor)driver;
            executor.ExecuteScript("var ele=arguments[0];setTimeout(function(){ele.click();},150)", ele);

            WebDriverWait waitWindows = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            waitWindows.Until(d => driver.WindowHandles.Count == 1);
            driver.SwitchTo().Window(driver.WindowHandles.Last());
        }
        public void VerifyLandedOnProcessMenu()
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
            WebDriverWait waitWindow = new WebDriverWait(driver, TimeSpan.FromSeconds(10));// logic need to change
            waitWindow.Until(d => driver.Title == "PROCESSES");
        }
    }
}
