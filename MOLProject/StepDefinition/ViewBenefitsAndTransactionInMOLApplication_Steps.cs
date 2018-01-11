using MOLProject.Page_Object;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using SeleniumWebdriver.ComponentHelper;
using SeleniumWebdriver.Settings;
using SeleniumWebDriver.ExcelOperation;
using System;
using TechTalk.SpecFlow;

namespace MOLProject.StepDefinition
{
    [Binding]
    public class ViewBenefitsAndTransactionInMOLApplication_Steps
    {
        public IWebDriver driver;
        private readonly LoginPage molLogin;
        private readonly DashBoardPage molDashBoard;
        private readonly TranscationPage molAccount;
        ViewBenefitsAndTransactionInMOLApplication_Steps()
        {
            // Getting the driver from the Object repositary  
            driver = ObjectRepository.Driver;

            // Passing the driver to constructor of the different page
            molLogin = new LoginPage(driver);
            molDashBoard = new DashBoardPage(driver);
            molAccount = new TranscationPage(driver);
        }
        [Given(@"User able to launch the MOL application")]
        public void GivenUserAbleToLaunchTheMOLApplication()
        {
            try
            {
                driver.Navigate().GoToUrl(ObjectRepository.URL);
                driver.Manage().Window.Maximize();

                // Sending the data to Extent reports
                SpecHooks.extentTest.Pass(ScenarioContext.Current.StepContext.StepInfo.Text);
            }
            catch (Exception ex)
            {
                WriteReportAndLog(ex);
            }
        }

        [When(@"User Login to the application using valid credentials")]
        public void WhenUserLoginToTheApplicationUsingValidCredentials()
        {
            try
            {
                PageFactory.InitElements(driver, molLogin);

                // Getting the data from excel and passing to the Username and Password fields
                molLogin.EnterUsername(ExcelOperation.GetData[1]);
                molLogin.EnterPassword(ExcelOperation.GetData[2]);

                molLogin.ClickLoginButton();
                PageFactory.InitElements(driver, molDashBoard);

                // Verifying Dashboard screen is visible by checking the heading
                molDashBoard.VerifySystemLandedOnDashboard();
                SpecHooks.extentTest.Pass(ScenarioContext.Current.StepContext.StepInfo.Text);
            }
            catch (Exception ex)
            {
                molDashBoard.IfErrorScrollDown();
                WriteReportAndLog(ex);
            }
        }

        [Then(@"User able to view benefits")]
        public void ThenUserAbleToViewBenefits()
        {
            try
            {
                // Capturing the list of benefits           
                molDashBoard.ListOfBenefits();
                GenericHelper.IMPScreenShot(driver);
                SpecHooks.extentTest.Pass(ScenarioContext.Current.StepContext.StepInfo.Text);
            }
            catch (Exception ex)
            {
                WriteReportAndLog(ex);
            }
        }

        [Then(@"Close Browser\.")]
        public void ThenCloseBrowser_()
        {
            try
            {
                driver.Close();
                SpecHooks.extentTest.Pass(ScenarioContext.Current.StepContext.StepInfo.Text);
            }
            catch (Exception ex)
            {
                WriteReportAndLog(ex);
            }
        }

        [Then(@"User Clicks on View payroll and deduction\.")]
        public void ThenUserClicksOnViewPayrollAndDeduction_()
        {
            try
            {
                PageFactory.InitElements(driver, molDashBoard);
                molDashBoard.ClickOnViewPayroll();
                SpecHooks.extentTest.Pass(ScenarioContext.Current.StepContext.StepInfo.Text);
            }
            catch (Exception ex)
            {
                WriteReportAndLog(ex);
            }
        }

        [Then(@"User Clicks on the Advance filter and set Date Picker")]
        public void ThenUserClicksOnTheAdvanceFilterAndSetDatePicker()
        {
            try
            {
                PageFactory.InitElements(driver, molAccount);

                // Setting the date duration for 18 months using the date picker and clicking on the Submit Button
                molAccount.ClickOnAdvanceFilter();
                molAccount.DatePickerFrom();
                molAccount.DatePickerTo();
                molAccount.ClickSubmit();
                SpecHooks.extentTest.Pass(ScenarioContext.Current.StepContext.StepInfo.Text);
            }
            catch (Exception ex)
            {
                WriteReportAndLog(ex);
            }
        }

        [Then(@"User able to view  transaction")]
        public void ThenUserAbleToViewTransaction()
        {
            // Checking the transaction exist in the table 
            PageFactory.InitElements(driver, molAccount);
            int transactionExist = molAccount.IsTransactionExist();
            try
            {
                // If transaction exist in the table capture the transaction 
                if (transactionExist != 0)
                {
                    //molAccount.CaptureScreenTransaction();
                    GenericHelper.IMPScreenShot(driver);
                    SpecHooks.extentTest.Pass(ScenarioContext.Current.StepContext.StepInfo.Text);
                }
            }
            catch (Exception ex)
            {
                WriteReportAndLog(ex);
            }
        }

        [Then(@"Close Browser")]
        public void ThenCloseBrowser()
        {
            try
            {
                driver.Close();
                SpecHooks.extentTest.Pass(ScenarioContext.Current.StepContext.StepInfo.Text);
            }
            catch (Exception ex)
            {
                WriteReportAndLog(ex);
            }
        }

        private void WriteReportAndLog(Exception ex)
        {
            SpecHooks.extentTest.Fail(ScenarioContext.Current.StepContext.StepInfo.Text);
            GenericHelper.TakeScreenshot("Exception_",driver);
            SeleniumWebDriver.Reports.LogReport.WriteError(ScenarioContext.Current.StepContext.StepInfo.Text + "Exception :" + ex);
            driver.Quit();
            Assert.Fail(ScenarioContext.Current.StepContext.StepInfo.Text, ex);
        }
    }
}
