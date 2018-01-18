using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;

namespace CometProject.PageObject.Package.EditPackage
{
    class EditPackageAdminDetailsPage
    {
        public IWebDriver driver;
        public EditPackageAdminDetailsPage(IWebDriver _driver)
        {
            this.driver = _driver;
        }
        
        [FindsBy(How = How.Id, Using = "wucButtons_cmdNextEnabled")]
        public IWebElement NextButton { get; set; }
        public void ClickOnNextButton()
        {
            NextButton.Click();
        }
        public void VerifyPageLandedOnPackageadminDetails()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementExists(By.XPath(".//*[@id='Form1']/table/tbody/tr[2]/td/table/tbody/tr")));
        }
    }
}
