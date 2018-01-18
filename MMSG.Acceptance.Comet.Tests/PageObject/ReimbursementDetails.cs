using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using MMSG.Automation.ComponentHelper;
using MMSG.Automation.ExcelOperation;
using System;

namespace CometProject.PageObject
{
    class ReimbursementDetails
    {
        public IWebDriver driver;
        public ReimbursementDetails(IWebDriver _driver)
        {
            this.driver = _driver;
        }

        [FindsBy(How = How.Id, Using = "EffectiveDateText")]
        public IWebElement EffectiveDate { get; set; }

        [FindsBy(How = How.XPath, Using = "//select[@id='PaymentMethodCombo']/option[2]")]
        public IWebElement PreferedMethodToContact { get; set; }

        [FindsBy(How = How.XPath, Using = "//select[@id='ChequeAddressTypeCombo']/option[3]")]
        public IWebElement ChequeAddress { get; set; }

        [FindsBy(How = How.XPath, Using = "//select[@id='EFTRemittanceMethodCombo']/option[6]")]
        public IWebElement EFTRemittanceCommunicationDetailsMethod { get; set; }

        [FindsBy(How = How.Id, Using = "IQueueNumberText")]
        public IWebElement IQueueNumberText { get; set; }

        [FindsBy(How = How.Id, Using = "CommandButtons_cmdNextEnabled")]
        public IWebElement NextButton { get; set; }

        [FindsBy(How = How.Id, Using = "CommandButtons_cmdAddEnabled")]
        public IWebElement AddButton { get; set; }
        public void FillReimbursementDetails()
        {
            EffectiveDate.Clear();

            // Select Current business date from screen
            var text_input = driver.FindElement(By.XPath(".//*[@id='Form1']/table/tbody/tr[1]/td/table/tbody/tr[1]/td[2]/font")).Text;
            var result = text_input.Substring(text_input.Length - 11);
            string currentDate = result.Remove(result.Length - 1);

            ExcelOperation.AddData("TestData17", currentDate, "TC1_CreateAnEmployee");
            EffectiveDate.SendKeys(currentDate);

            PreferedMethodToContact.Click();
            ChequeAddress.Click();
            EFTRemittanceCommunicationDetailsMethod.Click();
            IQueueNumberText.Clear();

            IQueueNumberText.SendKeys(ExcelOperation.GetData[18]);
            GenericHelper.AllScreenShot(driver);
            NextButton.Click();            
        }
        public void VerifyPageLandedOnReimbursement()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.TitleContains("Employee"));
            
        }
    }
}
