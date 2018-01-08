using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using SeleniumWebdriver.ComponentHelper;
using System;
using System.Threading;

namespace CometProject.PageObject.Package
{
    class PackageAdminDetails
    {
        public IWebDriver driver;
        public PackageAdminDetails(IWebDriver _driver)
        {
            this.driver = _driver;
        }

        [FindsBy(How = How.XPath, Using = ".//*[@id='ddmFinancialAdvisor_trMain']/td[2]/img")]
        public IWebElement FinancialAdviserImg { get; set; }
        public void FillPackageAdminDetails()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            wait.Until(ExpectedConditions.ElementExists(By.XPath(".//*[@id='wucButtons_cmdNextEnabled']")));
            Thread.Sleep(5000);

            GenericHelper.AllScreenShot(driver);
            var ele = driver.FindElement(By.XPath(".//*[@id='wucButtons_cmdNextEnabled']"));
            IJavaScriptExecutor executor = (IJavaScriptExecutor)driver;
            executor.ExecuteScript("var ele=arguments[0];setTimeout(function(){ele.click();},100)", ele);
        }
        public void VerifyPageLandedOnPackageadminDetails()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementExists(By.XPath(".//*[@id='Form1']/table/tbody/tr[2]/td/table/tbody/tr")));
        }
    }
}
