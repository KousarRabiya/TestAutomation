using CometProject.PageObject.AdminFees.EmployeeOffering;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using SeleniumWebDriver.ExcelOperation;
using System;

namespace CometProject.PageObject.AdminFees
{
    class AdminFeesPage
    {
        private IWebDriver driver;
        public AdminFeesPage(IWebDriver _driver)
        {
            this.driver = _driver;
        }

        [FindsBy(How = How.XPath, Using = ".//*[@id='imgItemLookup']")]
        public IWebElement SearchImg { get; set; }

        [FindsBy(How = How.Id, Using = "EffectiveDateText")]
        public IWebElement EffectiveDtae { get; set; }

        [FindsBy(How = How.Id, Using = "CommandButtons_cmdSaveEnabled")]
        public IWebElement SaveButton { get; set; }

        public void AddAdminFees()
        {
            SearchImg.Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);

            // Click to open admin search pop up
            EmployeeOfferingPage EmpOff = new EmployeeOfferingPage(driver);
            EmpOff.ClickOnSearchResult();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);

            // Select current business date from screen
            var text_input = driver.FindElement(By.XPath(".//*[@id='Form1']/table/tbody/tr[1]/td/table/tbody/tr[1]/td[2]/font")).Text;
            var result = text_input.Substring(text_input.Length - 11);
            string currentDate = result.Remove(result.Length - 1);

            ExcelOperation.AddData("TestData2", currentDate, "TC5_ActivatingTheNewPackage");
            EffectiveDtae.SendKeys(currentDate);
            SaveButton.Click();
        }
    }
}
