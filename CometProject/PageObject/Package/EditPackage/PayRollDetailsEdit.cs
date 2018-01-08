using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;

namespace CometProject.PageObject.Package.EditPackage
{
    class PayRollDetailsEdit
    {
        public IWebDriver driver;
        public PayRollDetailsEdit(IWebDriver _driver)
        {
            this.driver = _driver;
        }
        [FindsBy(How = How.Id, Using = "wucButtons_cmdSaveEnabled")]
        public IWebElement SaveButton { get; set; }
        public void ClickOnSaveButton()
        {
            SaveButton.Click();
        }
        public void VerifyPageLandedOnPayRollDetails()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));// logic need to change
            wait.Until(ExpectedConditions.ElementExists(By.XPath(".//*[@id='Form1']/table/tbody/tr[2]/td/table/tbody/tr/td[5]")));
        }
    }
}
