using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using SeleniumWebDriver.ExcelOperation;
using System;

namespace CometProject.PageObject.Package.EditPackage
{
    class EditPackage
    {
        public IWebDriver driver;
        public EditPackage(IWebDriver _driver)
        {
            this.driver = _driver;
        }

        [FindsBy(How = How.Id, Using = "txtBusinessEmail")]
        public IWebElement EmailId { get; set; }

        [FindsBy(How = How.Id, Using = "wucButtons_cmdNextEnabled")]
        public IWebElement NextButton { get; set; }
        public void EditPackageBusinessEmailId()
        {
            EmailId.Clear();
            EmailId.SendKeys(ExcelOperation.GetData[2]);
        }
        public void ClickOnNext()
        {
            NextButton.Click();
        }
        public bool VerifyEmailIdSavedSuccessfully()
        {
            var text_input = driver.FindElement(By.XPath(".//*[@id='txtBusinessEmail']"));
            if (text_input.GetAttribute("value") == ExcelOperation.GetData[2])
            {
                return true;
            }
            return false;
        }
        public void VerifyLandedOnEmployeeDetailsPage()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));// logic need to change
            wait.Until(ExpectedConditions.ElementExists(By.XPath(".//*[@id='Form1']/table/tbody/tr[2]/td/table/tbody/tr/td[4]")));
        }
    }
}
