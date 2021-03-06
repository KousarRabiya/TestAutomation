﻿using CometProject.PageObject.Package.EmployeeSearch;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using SeleniumWebdriver.ComponentHelper;
using SeleniumWebDriver.ExcelOperation;
using System;

namespace CometProject.PageObject.Package
{
    class EmployeeDetails
    {
        public IWebDriver driver;
        public EmployeeDetails(IWebDriver _driver)
        {
            this.driver = _driver;
        }

        [FindsBy(How = How.Id, Using = "imgEmployerLookup")]
        public IWebElement EmployerShortName { get; set; }

        [FindsBy(How = How.Id, Using = "ddmEmployerOfferingID_txtDisplay")]
        public IWebElement Offering { get; set; }

        [FindsBy(How = How.Id, Using = "EmployerCodeText")]
        public IWebElement EmployerCodeText { get; set; }

        [FindsBy(How = How.Id, Using = "SearchButton")]
        public IWebElement SearchButton { get; set; }

        [FindsBy(How = How.XPath, Using = ".//*[@id='ResultsGrid']/tbody/tr[2]/td[1]/a")]
        public IWebElement EmployeeResult { get; set; }

        [FindsBy(How = How.Id, Using = "txtEmployerShortName")]
        public IWebElement EmployerShortNameTextBox { get; set; }

        [FindsBy(How = How.Id, Using = "ddmEmployerOfferingID_txtDisplay")]
        public IWebElement EmployerOfferring { get; set; }

        [FindsBy(How = How.Id, Using = "cboSetUpReason")]
        public IWebElement SetupReason { get; set; }
        [FindsBy(How = How.XPath, Using = ".//*[@id='wucButtons_cmdNextEnabled']")]
        public IWebElement NextButton { get; set; }
        public void FillInEmploymentDetailsAndClickNext()
        {
            EmployerShortName.Click();          
            PopUpEmployerSearch EmpPop = new PopUpEmployerSearch(driver);
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
