using CometProject.PageObject;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using MMSG.Automation.ComponentHelper;
using MMSG.Automation.Settings;
using System;
using TechTalk.SpecFlow;

namespace CometProject
{
    [Binding]
    public class CometSearchFeatureSteps
    {
        public IWebDriver driverIE;
        private readonly CallCenterEnquirySearch callCenterSearch;

        CometSearchFeatureSteps()
        {
            driverIE = ObjectRepository.Driver;
            callCenterSearch = new CallCenterEnquirySearch(driverIE);
        }

        [Given(@"I open the browser and launch Comet application")]
        public void GivenIOpenTheBrowserAndLaunchCometApplication()
        {
            try
            {
                driverIE.Navigate().GoToUrl(ObjectRepository.URL);
                driverIE.SwitchTo().Window(driverIE.WindowHandles[driverIE.WindowHandles.Count - 1]);
                driverIE.Manage().Window.Maximize();

                PageFactory.InitElements(driverIE, callCenterSearch);
                callCenterSearch.VerifyLandedOnCallCenterScreen();

                int lastWindowOpened = driverIE.WindowHandles.Count;
                driverIE.SwitchTo().Window(driverIE.WindowHandles[lastWindowOpened - 1]);
                driverIE.Manage().Window.Maximize();

                driverIE.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            }
            catch (Exception ex)
            {
                WriteLog(ex);
            }
        }       

        [When(@"I enter ""(.*)"" in the employee number field")]
        public void WhenIEnterInTheEmployeeNumberField(string empNum)
        {
            try
            {
                PageFactory.InitElements(driverIE, callCenterSearch);
                callCenterSearch.CallCenterEnqrySearch(empNum);
            }
            catch (Exception ex)
            {
                WriteLog(ex);
            }
        }

        [When(@"I enter ""(.*)"" in the employer code field")]
        public void WhenIEnterInTheEmployerCodeField(string empCode)
        {
            try
            {
                PageFactory.InitElements(driverIE, callCenterSearch);
                callCenterSearch.CallCenterEnqrySearch(empCode);
            }
            catch (Exception ex)
            {
                WriteLog(ex);
            }
        }

        [Then(@"I click on Search button")]
        public void ThenIClickOnSearchButton()
        {
            try
            {
                callCenterSearch.ClickOnSearchButton();
                GenericHelper.IMPScreenShot(driverIE);
            }
            catch (Exception ex)
            {
                WriteLog(ex);
            }
        }

        private void WriteLog(Exception ex)
        {
            GenericHelper.TakeScreenshot("Exception_",driverIE);
            MMSG.Automation.Reports.LogReport.WriteError(ScenarioContext.Current.StepContext.StepInfo.Text + "Exception :" + ex);
            driverIE.Quit();
            Assert.Fail(ScenarioContext.Current.StepContext.StepInfo.Text, ex);
        }
    }
}
