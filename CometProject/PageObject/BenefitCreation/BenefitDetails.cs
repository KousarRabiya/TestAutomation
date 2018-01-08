using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using SeleniumWebDriver.ExcelOperation;
using System;
using TechTalk.SpecFlow;

namespace CometProject.PageObject.BenefitCreation
{
    class BenefitDetails
    {
        private IWebDriver driver;
        public BenefitDetails(IWebDriver _driver)
        {
            this.driver = _driver;
        }

        [FindsBy(How = How.Id, Using = "txtBudgetAmount")]
        public IWebElement EditButton { get; set; }

        [FindsBy(How = How.Id, Using = "ddlBudgetCalcMethod")]
        public IWebElement BudgetCalculation { get; set; }

        public void SelectBudgetCalculationMethod()
        {
            SelectElement oSelect = new SelectElement(BudgetCalculation);
            if (ScenarioContext.Current.ScenarioInfo.Title == "TC5-Activating the new Package")
            {
                oSelect.SelectByText(ExcelOperation.GetData[4]);
            }
            else
            {
                oSelect.SelectByText(ExcelOperation.GetData[3]);
            }
        }

        public void BudgetAmount()
        {
            if (ScenarioContext.Current.ScenarioInfo.Title == "TC5-Activating the new Package")
            {
                EditButton.SendKeys(ExcelOperation.GetData[5]);
            }
            else
            {
                EditButton.SendKeys(ExcelOperation.GetData[4]);
            }
        }
        public void ClickOnSaveButton()
        {
            var ele = driver.FindElement(By.Id("wucButtons_cmdSaveEnabled"));
            IJavaScriptExecutor executor = (IJavaScriptExecutor)driver;
            executor.ExecuteScript("var ele=arguments[0];setTimeout(function(){ele.click();},150)", ele);
        }
        public void PopUpToSaveAndClickOnNo()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementExists(By.XPath(".//*[@id='divMain']/table")));
            var ele = driver.FindElement(By.Id("wucPopUpDialogOtherBenToProcess_cmdNo"));

            IJavaScriptExecutor executor = (IJavaScriptExecutor)driver;
            executor.ExecuteScript("var ele=arguments[0];setTimeout(function(){ele.click();},150)", ele);
        }
    }
}
