using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using SeleniumWebDriver.ExcelOperation;
using System;
using System.Linq;
using System.Threading;
using TechTalk.SpecFlow;

namespace CometProject.PageObject.BenefitCreation
{
    class BenefitPage
    {
        private IWebDriver driver;
        public BenefitPage(IWebDriver _driver)
        {
            this.driver = _driver;
        }

        [FindsBy(How = How.Id, Using = "ddlBenefitName")]
        public IWebElement BenefitDropDaownId { get; set; }
        public void SelectBenefit()
        {
            WebDriverWait waitWindow = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            waitWindow.Until(d => driver.WindowHandles.Count == 1);
            driver.SwitchTo().Window(driver.WindowHandles.Last());

            SelectElement oSelect = new SelectElement(BenefitDropDaownId);
            if (ScenarioContext.Current.ScenarioInfo.Title == "TC5-Activating the new Package")
            {
                oSelect.SelectByText(ExcelOperation.GetData[3]);
            }
            else
            {
                oSelect.SelectByText(ExcelOperation.GetData[2]);
            }

        }
        public void ClickOnNextButton()
        {
            Thread.Sleep(3000);
            var ele = driver.FindElement(By.Id("wucButtons_cmdNextEnabled"));
            IJavaScriptExecutor executor = (IJavaScriptExecutor)driver;
            executor.ExecuteScript("var ele=arguments[0];setTimeout(function(){ele.click();},150)", ele);
        }
    }
}
