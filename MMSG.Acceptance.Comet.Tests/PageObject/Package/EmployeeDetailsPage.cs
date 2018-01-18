using CometProject.PageObject.Package.EmployeeSearch;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using MMSG.Automation.ComponentHelper;
using MMSG.Automation.ExcelOperation;
using System;

namespace CometProject.PageObject.Package
{
    class EmployeeDetailsPage
    {
        public IWebDriver driver;
        public EmployeeDetailsPage(IWebDriver _driver)
        {
            this.driver = _driver;
        }

        [FindsBy(How = How.Id, Using = "imgEmployerLookup")]
        public IWebElement EmployerShortName { get; set; }        

        [FindsBy(How = How.Id, Using = "cboSetUpReason")]
        public IWebElement SetupReason { get; set; }
        
        public void FillInEmploymentDetailsAndClickNext()
        {
            EmployerShortName.Click();          
            EmployerSearchPopupPage EmpPop = new EmployerSearchPopupPage(driver);
            EmpPop.SearchEmployer();
            
            // Click on Offering drop down
            var ele = driver.FindElement(By.XPath(".//*[@id='ddmEmployerOfferingID_trMain']/td[2]/img"));
            IJavaScriptExecutor executor = (IJavaScriptExecutor)driver;
            executor.ExecuteScript("var ele=arguments[0];setTimeout(function(){ele.click();},100)", ele);

            // Selects Offering value 
            var ele1 = driver.FindElement(By.XPath(".//*[@id='divMenuddmEmployerOfferingID']/table/tbody/tr[2]/td[1]"));
            IJavaScriptExecutor executor1 = (IJavaScriptExecutor)driver;
            executor.ExecuteScript("var ele1=arguments[0];setTimeout(function(){ele1.click();},100)", ele1);

            // Select Setup Reason
            SelectElement drop = new SelectElement(SetupReason);
            drop.SelectByText(ExcelOperation.GetData[3]);

            GenericHelper.AllScreenShot(driver);

            // Click on Next button
            var nextButton = driver.FindElement(By.XPath(".//*[@id='wucButtons_cmdNextEnabled']"));
            IJavaScriptExecutor executor12 = (IJavaScriptExecutor)driver;
            executor12.ExecuteScript("var nextButton=arguments[0];setTimeout(function(){nextButton.click();},100)", nextButton);
        }

        public void VerifyLandedOnEmploymentDetailspage()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));// logic need to change
            wait.Until(ExpectedConditions.ElementExists(By.XPath(".//*[@id='Form1']/table/tbody/tr[2]/td/table/tbody/tr/td[4]")));
        }
    }
}
