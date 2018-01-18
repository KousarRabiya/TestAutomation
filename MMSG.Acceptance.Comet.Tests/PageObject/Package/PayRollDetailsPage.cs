using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using MMSG.Automation.ComponentHelper;
using MMSG.Automation.ExcelOperation;
using System;
using System.Threading;

namespace CometProject.PageObject.Package
{
    class PayRollDetailsPage
    {
        public IWebDriver driver;
        public PayRollDetailsPage(IWebDriver _driver)
        {
            this.driver = _driver;
        }
        [FindsBy(How = How.Id, Using = "txtPayrollID")]
        public IWebElement PayRollID { get; set; }
        
        public void FillPayrollDetails()
        {
            string payrollId = GenericHelper.RandomPayRollNo();
            ExcelOperation.AddData("TestData4", payrollId, "TC4_AddingThePackageToTheEmployee");
            PayRollID.SendKeys(payrollId);

            var eleImg = driver.FindElement(By.XPath(".//*[@id='ddmPayCycleID_trMain']/td[2]/img"));
            IJavaScriptExecutor executor = (IJavaScriptExecutor)driver;
            executor.ExecuteScript("var eleImg=arguments[0];setTimeout(function(){eleImg.click();},100)", eleImg);

            // Selects first item fromn Pay Cycle Description drop down
            var eleDropDown = driver.FindElement(By.XPath(".//*[@id='divMenuddmPayCycleID']/table/tbody/tr[2]/td[1]"));
            IJavaScriptExecutor executor1 = (IJavaScriptExecutor)driver;
            executor1.ExecuteScript("var eleDropDown=arguments[0];setTimeout(function(){eleDropDown.click();},100)", eleDropDown);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            Thread.Sleep(2000);

            //Click on the AddButton
            var eleAddButton = driver.FindElement(By.XPath(".//*[@id='wucButtons_cmdAddEnabled']"));
            IJavaScriptExecutor executorAddButton = (IJavaScriptExecutor)driver;
            executorAddButton.ExecuteScript("var eleAddButton=arguments[0];setTimeout(function(){eleAddButton.click();},100)", eleAddButton);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            Thread.Sleep(2000);

            // Clicks on Save button
            GenericHelper.AllScreenShot(driver);
            var eleSaveButton = driver.FindElement(By.Id("wucButtons_cmdSaveEnabled"));
            IJavaScriptExecutor executorSaveButton = (IJavaScriptExecutor)driver;
            executorSaveButton.ExecuteScript("var eleSaveButton=arguments[0];setTimeout(function(){eleSaveButton.click();},100)", eleSaveButton);
        }
        public void VerifyPageLandedOnPayRollDetails()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));// logic need to change
            wait.Until(ExpectedConditions.ElementExists(By.XPath(".//*[@id='Form1']/table/tbody/tr[2]/td/table/tbody/tr/td[5]")));
        }
    }
}
