using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using ROLProject.Page_Object;
using ROLProject.PropertiesFiles;
using SeleniumWebdriver.ComponentHelper;
using SeleniumWebdriver.Settings;
using SeleniumWebDriver.ExcelOperation;
using System;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace ROLProject.StepDefinition
{
    [Binding]
    public class ROLNavigateToContactPageSteps
    {
        public IWebDriver driver;
        private readonly LoginPage loginPage;
        private readonly DashboardPage rolDashBoard;
        private readonly ContactPage rolContactPage;

        ROLNavigateToContactPageSteps()
        {
            driver = SeleniumWebdriver.Settings.ObjectRepository.Driver;

            loginPage = new LoginPage(driver);
            rolDashBoard = new DashboardPage(driver);
            rolContactPage = new ContactPage(driver);
        }
        [Given(@"User able to launch the ROL application")]
        public void GivenUserAbleToLaunchTheROLApplication_()
        {
            try
            {
                driver.Navigate().GoToUrl(ObjectRepository.URL);
                driver.Manage().Window.Maximize();
                Hook.SpecFlowHook.test.Pass(ScenarioContext.Current.StepContext.StepInfo.Text);
            }
            catch (Exception ex)
            {
                WriteLogAndReport(ex);
            }
        }       

        [When(@"User Login to the  ROL application using valid credentials")]
        public void WhenUserLoginToTheROLApplicationUsingValidCredentials(Table table)
        {
            try
            {
                var Credencials = table.CreateInstance<Properties>();
                // Getting the Data from excel and and passing to the Username field
                PageFactory.InitElements(driver, loginPage);
                loginPage.EnterUsername(ExcelOperation.GetData[1]);

                // Getting the Data from excel and and passing to the Password field 
                loginPage.EnterPassword(ExcelOperation.GetData[2]);
                loginPage.ClickLoginButton();
                PageFactory.InitElements(driver, rolDashBoard);

                rolDashBoard.VerifyLandedOnContactPage();
                Hook.SpecFlowHook.test.Pass(ScenarioContext.Current.StepContext.StepInfo.Text);
            }
            catch (Exception ex)
            {
                rolDashBoard.IfErrorScrollDown();
                WriteLogAndReport(ex);
            }
        }

        [Then(@"User clicks on the Contact present right side of the appliction")]
        public void ThenUserClicksOnTheContactPresentRightSideOfTheAppliction()
        {
            try
            {
                // Clicking on th contact link in dashboard
                PageFactory.InitElements(driver, rolDashBoard);
                rolDashBoard.ClickOnTheContact();
                Hook.SpecFlowHook.test.Pass(ScenarioContext.Current.StepContext.StepInfo.Text);
            }
            catch (Exception ex)
            {
                WriteLogAndReport(ex);
            }
        }

        [Then(@"Application should land in Contact Page")]
        public void ThenApplicationShouldLandInContactPage()
        {
            try
            {
                // Verifying the system landed on the Contact Page
                PageFactory.InitElements(driver, rolContactPage);
                rolContactPage.VerifyLandedInContactPage();
                GenericHelper.IMPScreenShot(driver);
                Hook.SpecFlowHook.test.Pass(ScenarioContext.Current.StepContext.StepInfo.Text);
            }
            catch(Exception ex)
            {
                WriteLogAndReport(ex);
            }
        }

        [Then(@"User fills the details of the request")]
        public void ThenUserFillsTheDetailsOfTheRequest()
        {
            try
            {
                // Filling the feilds present Contact page
                rolContactPage.FillTheDetails();
                Hook.SpecFlowHook.test.Pass(ScenarioContext.Current.StepContext.StepInfo.Text);
            }
            catch (Exception ex)
            {
                WriteLogAndReport(ex);
            }
        }

        [Then(@"User Clicks on the Submit Button")]
        public void ThenUserClicksOnTheSubmitButton()
        {
            try
            {
                // clicking on the submit button
                rolContactPage.ClickSubmitButton();
                GenericHelper.IMPScreenShot(driver);
                // rolContactPage.VerifySubmitSuccessFull();
                Hook.SpecFlowHook.test.Pass(ScenarioContext.Current.StepContext.StepInfo.Text);
            }
            catch (Exception ex)
            {
                WriteLogAndReport(ex);
            }
        }

        [Then(@"Close Browser")]
        public void ThenCloseBrowser()
        {
            try
            {
                driver.Close();
                Hook.SpecFlowHook.test.Pass(ScenarioContext.Current.StepContext.StepInfo.Text);
            }
            catch (Exception ex)
            {
                WriteLogAndReport(ex);
            }
        }

        private void WriteLogAndReport(Exception ex)
        {
            Hook.SpecFlowHook.test.Fail(ScenarioContext.Current.StepContext.StepInfo.Text);
            GenericHelper.TakeScreenshot("Exception_",driver);
            SeleniumWebDriver.Reports.LogReport.WriteError(ScenarioContext.Current.StepContext.StepInfo.Text + "Exception :" + ex);
            driver.Quit();
            Assert.Fail(ScenarioContext.Current.StepContext.StepInfo.Text, ex);
        }
    }
}
