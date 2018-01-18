using CometProject.PageObject.PaymentInstruction.PayeeSearch;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using MMSG.Automation.ComponentHelper;
using MMSG.Automation.ExcelOperation;
using System;
using System.Linq;
using System.Threading;
using TechTalk.SpecFlow;

namespace CometProject.PageObject.PaymentInstruction
{
    class PaymentInstructionPage
    {
        private IWebDriver driver;
        public PaymentInstructionPage(IWebDriver _driver)
        {
            this.driver = _driver;
        }
        [FindsBy(How = How.Id, Using = "PaymentTypeCombo")]
        public IWebElement PaymentType { get; set; }

        [FindsBy(How = How.Id, Using = "PaymentDescriptionText")]
        public IWebElement PaymentDescription { get; set; }

        [FindsBy(How = How.Id, Using = "PaymentReferenceText")]
        public IWebElement PaymentRefrerences { get; set; }

        [FindsBy(How = How.Id, Using = "PartPaymentRuleCombo")]
        public IWebElement PartPaymentDropDown { get; set; }

        [FindsBy(How = How.Id, Using = "PaymentFrequencyCombo")]
        public IWebElement PaymentFrequencyDropDown { get; set; }

        [FindsBy(How = How.Id, Using = "imgpayeeLookup")]
        public IWebElement LookUpImg { get; set; }

        [FindsBy(How = How.Id, Using = "PaymentDueDateText")]
        public IWebElement PaymentDueDate { get; set; }

        [FindsBy(How = How.Id, Using = "TerminateDateText")]
        public IWebElement PaymentTerminationDate { get; set; }

        [FindsBy(How = How.Id, Using = "PaymentAmountText")]
        public IWebElement PaymentAmount { get; set; }

        [FindsBy(How = How.Id, Using = "CommandButtons_cmdSaveEnabled")]
        public IWebElement SaveButton { get; set; }

        public void SelectPaymentType()
        {
            SelectElement drop = new SelectElement(PaymentType);
            drop.SelectByText(ExcelOperation.GetData[2]);
        }
        public void PaymentDescriptionTextBox()
        {
            string randomString = GenericHelper.RandomString(6);
            PropertiesFile.Properties.PaymentDescription = randomString;
            if (ScenarioContext.Current.ScenarioInfo.Title == "TC7-Adding Adhoc Payment Instruction")
            {
                ExcelOperation.AddData("TestData3", randomString, "TC7_AddingAdhocPaymentInstruction");
            }
            else
            {
                ExcelOperation.AddData("TestData3", randomString, "TC8_AddingRegularPaymentInstruction");
            }
            PaymentDescription.SendKeys(randomString);
        }
        public void PaymentReference()
        {
            string paymentReference = GenericHelper.RandomString(6);
            if (ScenarioContext.Current.ScenarioInfo.Title == "TC7-Adding Adhoc Payment Instruction")
            {
                ExcelOperation.AddData("TestData4", paymentReference, "TC7_AddingAdhocPaymentInstruction");
            }
            else
            {
                ExcelOperation.AddData("TestData4", paymentReference, "TC8_AddingRegularPaymentInstruction");
            }
            PaymentRefrerences.SendKeys(paymentReference);
        }
        public void PartPaymentSelect()
        {
            SelectElement drop = new SelectElement(PartPaymentDropDown);
            drop.SelectByText(ExcelOperation.GetData[5]);
        }
        public void PaymentFrequencySelect()
        {
            SelectElement drop = new SelectElement(PaymentFrequencyDropDown);
            drop.SelectByText(ExcelOperation.GetData[6]);
        }
        public void SearchPayee()
        {
            var ele = driver.FindElement(By.Id("imgpayeeLookup"));
            IJavaScriptExecutor executor = (IJavaScriptExecutor)driver;
            executor.ExecuteScript("var ele=arguments[0];setTimeout(function(){ele.click();},150)", ele);

            PayeeSearchPage payeePage = new PayeeSearchPage(driver);
            payeePage.SearchPayee();
        }
        public void PaymentDueDateBox()
        {
            var text_input = driver.FindElement(By.XPath(".//*[@id='Form1']/table/tbody/tr[1]/td/table/tbody/tr[1]/td[2]/font")).Text;
            var result = text_input.Substring(text_input.Length - 11);
            string currentDate = result.Remove(result.Length - 2);
            PaymentDueDate.SendKeys(currentDate + "8");
        }
        public void PaymentTerminationDateBox()
        {
            var text_input = driver.FindElement(By.XPath(".//*[@id='Form1']/table/tbody/tr[1]/td/table/tbody/tr[1]/td[2]/font")).Text;
            var result = text_input.Substring(text_input.Length - 11);
            string currentDate = result.Remove(result.Length - 2);
            PaymentTerminationDate.SendKeys(currentDate + "8");
        }
        public void AddButtonClick()
        {
            var ele = driver.FindElement(By.Id("CommandButtons_cmdAddEnabled"));
            IJavaScriptExecutor executor = (IJavaScriptExecutor)driver;
            executor.ExecuteScript("var ele=arguments[0];setTimeout(function(){ele.click();},150)", ele);
        }
        public void PaymentAmountTextBox()
        {
            PaymentAmount.Clear();
            PaymentAmount.SendKeys(ExcelOperation.GetData[7]);
        }
        public void ClickOnSaveButton()
        {
            WebDriverWait waitWindow = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            waitWindow.Until(ExpectedConditions.ElementExists(By.Id("CommandButtons_cmdSaveEnabled")));
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            Thread.Sleep(2000);
            var ele = driver.FindElement(By.Id("CommandButtons_cmdSaveEnabled"));
            IJavaScriptExecutor executor = (IJavaScriptExecutor)driver;
            executor.ExecuteScript("var ele=arguments[0];setTimeout(function(){ele.click();},150)", ele);
        }
        public void VerifyPageLandedOnPaymentInstructionPage()
        {
            driver.SwitchTo().Window(driver.WindowHandles.Last());
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementExists(By.Id("CommandButtons_cmdSaveEnabled")));
        }
    }
}
