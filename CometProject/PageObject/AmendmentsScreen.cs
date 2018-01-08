using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using SeleniumWebDriver.ExcelOperation;
using System;

namespace CometProject.PageObject
{
    class AmendmentsScreen
    {
        public IWebDriver driver;
        public AmendmentsScreen(IWebDriver _driver)
        {
            this.driver = _driver;
        }

        [FindsBy(How = How.Id, Using = "lblPageTitle")]
        public IWebElement PageTitle { get; set; }

        [FindsBy(How = How.Id, Using = "ddlBenefits_0")]
        public IWebElement BenefitDropDown { get; set; }


        [FindsBy(How = How.Id, Using = "ddlBudgetCalcMethod_0")]
        public IWebElement BudgetCalcMethodDropDown { get; set; }

        [FindsBy(How = How.Id, Using = "txtBudgetAmount_0")]
        public IWebElement BudgetAmount { get; set; }

        [FindsBy(How = How.Id, Using = "txtVariableIncome_0")]
        public IWebElement VariableIncome { get; set; }

        [FindsBy(How = How.Id, Using = "html/body/form/table/tbody/tr[14]/td/div/table/tbody/tr/td/table/tbody/tr[2]/td[3]")]
        public IWebElement BenefitName { get; set; }

        public void VerifyLandedOnAmendmentsScreen(string pageTitle)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.TextToBePresentInElement(PageTitle, pageTitle));
        }

        public void clickNewButton()
        {
            var ele = driver.FindElement(By.XPath(".//*[@id='btnNew']"));
            IJavaScriptExecutor executor = (IJavaScriptExecutor)driver;
            executor.ExecuteScript("var ele=arguments[0];setTimeout(function(){ele.click();},150)", ele);
        }

        public void SelectBenefit()
        {
            SelectElement oSelect = new SelectElement(BenefitDropDown);
            oSelect.SelectByText(ExcelOperation.GetData[2]);
        }

        public void SelectBudgetCalculationMethod()
        {
            SelectElement oSelect = new SelectElement(BudgetCalcMethodDropDown);
            oSelect.SelectByText(ExcelOperation.GetData[3]);
        }

        public void EnterBudgetAmount()
        {
            BudgetAmount.SendKeys(ExcelOperation.GetData[4]);
        }

        public void EnterVariableIncome()
        {
            VariableIncome.SendKeys(ExcelOperation.GetData[5]);
        }
        public void clickSaveButton()
        {
            var ele = driver.FindElement(By.XPath(".//*[@id='btnSave']"));
            IJavaScriptExecutor executor = (IJavaScriptExecutor)driver;
            executor.ExecuteScript("var ele=arguments[0];setTimeout(function(){ele.click();},150)", ele);
        }

        public bool VerifyWhetherBenefitIsAdded()
        {
            bool blnAdded;
            string benefit = BenefitName.Text;
            blnAdded = blnAdded = true ? ExcelOperation.GetData[2] == benefit : false;
            return blnAdded;
        }

        public void clickCancelButton()
        {
            var ele = driver.FindElement(By.XPath(".//*[@id='wucBenefitDetailsCancelNSave_cmdCancelEnabled']"));
            IJavaScriptExecutor executor = (IJavaScriptExecutor)driver;
            executor.ExecuteScript("var ele=arguments[0];setTimeout(function(){ele.click();},150)", ele);
        }
    }
}
