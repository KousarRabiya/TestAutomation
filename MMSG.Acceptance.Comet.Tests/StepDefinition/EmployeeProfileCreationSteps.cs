using CometProject.PageObject;
using CometProject.PageObject.ProcessMenuEmployee;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using MMSG.Automation.ComponentHelper;
using MMSG.Automation.Settings;
using System;
using System.Linq;
using TechTalk.SpecFlow;

namespace CometProject.StepDefinition
{
    [Binding]
    public class EmployeeProfileCreationSteps
    {
        public IWebDriver driverIE;
        private readonly PersonalDetails personalDetails;
        private readonly AddressDetails addressDetails;
        private readonly ReimbursementDetails reimbursementDetails;
        private readonly ThirdPartyAccess thirdPartyAccess;

        private readonly CallCenterEnquirySearch callCenterSearch;
        private readonly CallCenter callCenter;
        private readonly EAMSscreen EAMSScreen;
        private readonly EmployeeProcessMenu empProcessMenu;
        private readonly EAMSscreen EAMSProfile;
        EmployeeProfileCreationSteps()
        {
            driverIE = ObjectRepository.Driver;
            personalDetails = new PersonalDetails(driverIE);
            addressDetails = new AddressDetails(driverIE);
            reimbursementDetails = new ReimbursementDetails(driverIE);
            thirdPartyAccess = new ThirdPartyAccess(driverIE);

            callCenterSearch = new CallCenterEnquirySearch(driverIE);
            callCenter = new CallCenter(driverIE);
            EAMSScreen = new EAMSscreen(driverIE);
            empProcessMenu = new EmployeeProcessMenu(driverIE);
            EAMSProfile = new EAMSscreen(driverIE);
        }

        [Given(@"User opens the browser and launch Comet application")]
        public void GivenUserOpensTheBrowserAndLaunchCometApplication()
        {
            try
            {
                driverIE.Navigate().GoToUrl(ObjectRepository.URL);
                driverIE.SwitchTo().Window(driverIE.WindowHandles[driverIE.WindowHandles.Count - 1]);
                driverIE.Manage().Window.Maximize();

                PageFactory.InitElements(driverIE, callCenterSearch);
                callCenterSearch.VerifyLandedOnCallCenterScreen();
                //SpecHooks.extentTest.Pass(ScenarioContext.Current.StepContext.StepInfo.Text);
            }
            catch (Exception ex)
            {
                WriteReportAndLog(ex);
            }
        }

        [When(@"User clicks on new button on Comet search screen")]
        public void GivenUserClicksOnNewButtonOnCometSearchScreen()
        {
            try
            {
                PageFactory.InitElements(driverIE, callCenterSearch);
                callCenterSearch.NewButton();
                //SpecHooks.extentTest.Pass(ScenarioContext.Current.StepContext.StepInfo.Text);
            }
            catch (Exception ex)
            {
                WriteReportAndLog(ex);
            }
        }

        [Then(@"User enters all new employee creation details")]
        public void ThenUserEntersAllNewEmployeeCreationDetails()
        {
            try
            {
                PageFactory.InitElements(driverIE, personalDetails);
                personalDetails.VerifyLandedOnPersonalDetailsPage();

                personalDetails.FillPersonalDetails();
                PageFactory.InitElements(driverIE, addressDetails);
                addressDetails.VerifyLandedOnAddressDetailsPage();

                addressDetails.fillAddress();
                PageFactory.InitElements(driverIE, reimbursementDetails);
                reimbursementDetails.VerifyPageLandedOnReimbursement();

                reimbursementDetails.FillReimbursementDetails();
                PageFactory.InitElements(driverIE, thirdPartyAccess);
                thirdPartyAccess.VerifyPageLandedOnThirdParty();

                thirdPartyAccess.FillDetails();
                //SpecHooks.extentTest.Pass(ScenarioContext.Current.StepContext.StepInfo.Text);
            }
            catch (Exception ex)
            {
                WriteReportAndLog(ex);
            }
        }

        [Then(@"User clicks on Save button and EAMS Profile will appear and User closes the EAMS Profile")]
        public void ThenUserClicksOnSaveButtonAndEAMSProfileWillApperaAndUserClosesTheEAMSProfile()
        {
            try
            {
                PageFactory.InitElements(driverIE, thirdPartyAccess);
                thirdPartyAccess.ClickOnSaveButton();
                PageFactory.InitElements(driverIE, EAMSScreen);
                WebDriverWait wait = new WebDriverWait(driverIE, TimeSpan.FromSeconds(30));
                wait.Until(d => driverIE.WindowHandles.Count == 2);
                driverIE.SwitchTo().Window(driverIE.WindowHandles.Last());
                EAMSScreen.PageLandedOnEAMSProfilePage();                
                GenericHelper.IMPScreenShot(driverIE);
                EAMSScreen.ClickOnClose();
                //SpecHooks.extentTest.Pass(ScenarioContext.Current.StepContext.StepInfo.Text);
            }
            catch (Exception ex)
            {
                WriteReportAndLog(ex);
            }
        }

        [Then(@"User lands in the Call Centre Enquiry page and created Employee Num will be shown")]
        public void ThenUserLandsInTheCallCentreEnquiryPageAndCreatedEmployeeNumWillBeShown()
        {
            try
            {
                PageFactory.InitElements(driverIE, callCenter);
                driverIE.SwitchTo().Window(driverIE.WindowHandles.Last());
                callCenter.GetEmployeeIdAndUpdateInExcel();
                GenericHelper.IMPScreenShot(driverIE);
                callCenter.VerifyTreeViewIsDisplayed();
                //SpecHooks.extentTest.Pass(ScenarioContext.Current.StepContext.StepInfo.Text);
            }
            catch (Exception ex)
            {
                WriteReportAndLog(ex);
            }
        }

        [When(@"User enters the valid Employee number and clicks on Search button")]
        public void GivenUserEntersTheValidEmployeeNumberAndClicksOnSearchButton()
        {
            try
            {
                int lastWindowOpened = driverIE.WindowHandles.Count;
                driverIE.SwitchTo().Window(driverIE.WindowHandles[lastWindowOpened - 1]);
                driverIE.Manage().Window.Maximize();

                driverIE.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
                PageFactory.InitElements(driverIE, callCenterSearch);
                //callCenterSearch.SearchEmployee();

                callCenterSearch.ClickOnSearchButton();
                //SpecHooks.extentTest.Pass(ScenarioContext.Current.StepContext.StepInfo.Text);
            }
            catch (Exception ex)
            {
                WriteReportAndLog(ex);
            }
        }

        [Then(@"Verify Employee Details are shown")]
        public void ThenVerifyEmployeeDetailsAreShown()
        {
            try
            {
                PageFactory.InitElements(driverIE, callCenter);
                callCenter.VerifyTreeViewIsDisplayed();
                callCenter.GetEmployeeIdAndUpdateInExcel();
                //SpecHooks.extentTest.Pass(ScenarioContext.Current.StepContext.StepInfo.Text);
            }
            catch (Exception ex)
            {
                WriteReportAndLog(ex);
            }
        }

        [Then(@"Close the Browser")]
        public void ThenCloseTheBrowser()
        {
            try
            {
                driverIE.Close();
                //SpecHooks.extentTest.Pass(ScenarioContext.Current.StepContext.StepInfo.Text);
            }
            catch (Exception ex)
            {
                WriteReportAndLog(ex);
            }
        }

        [Then(@"User clicks on employee number")]
        public void ThenUserClicksOnEmployeeNumber()
        {
            try
            {
                PageFactory.InitElements(driverIE, callCenter);
                callCenter.VerifyTreeViewIsDisplayed();
                callCenter.ClickOnEmployeeNumber();
                //SpecHooks.extentTest.Pass(ScenarioContext.Current.StepContext.StepInfo.Text);
            }
            catch (Exception ex)
            {
                WriteReportAndLog(ex);
            }
        }

        [Then(@"User selects EAMS option")]
        public void ThenUserSelectsEAMSOption()
        {
            try
            {
                PageFactory.InitElements(driverIE, empProcessMenu);                
                if (empProcessMenu.VerifyLandedOnProcessMenu())
                {
                    empProcessMenu.ClickEAMSButton();
                    //SpecHooks.extentTest.Pass(ScenarioContext.Current.StepContext.StepInfo.Text);
                }
                else
                {
                    //SpecHooks.extentTest.Pass(ScenarioContext.Current.StepContext.StepInfo.Text);
                }
               
            }
            catch (Exception ex)
            {
                WriteReportAndLog(ex);
            }
        }

       

        [Then(@"Verify MOL Username is displayed")]
        public void ThenVerifyMOLUsernameIsDisplayed()
        {
            try
            {
                PageFactory.InitElements(driverIE, EAMSProfile);                
                EAMSProfile.PageLandedOnEAMSProfilePage();
                if (EAMSProfile.CheckEAMSIsCreated())
                {
                    //SpecHooks.extentTest.Pass(ScenarioContext.Current.StepContext.StepInfo.Text);
                }
                else
                {
                    //SpecHooks.extentTest.Fail(ScenarioContext.Current.StepContext.StepInfo.Text);
                    MMSG.Automation.Reports.LogReport.WriteError(ScenarioContext.Current.StepContext.StepInfo.Text + "Exception :EAms Profile Is not created");
                }
            }
            catch (Exception ex)
            {
                WriteReportAndLog(ex);
            }
        }

        [Then(@"Close complete Browser")]
        public void ThenCloseCompleteBrowser()
        {
            try
            {
                driverIE.Quit();
                //SpecHooks.extentTest.Pass(ScenarioContext.Current.StepContext.StepInfo.Text);
            }
            catch (Exception ex)
            {
                WriteReportAndLog(ex);
            }
        }
        private void WriteReportAndLog(Exception ex)
        {
            //SpecHooks.extentTest.Fail(ScenarioContext.Current.StepContext.StepInfo.Text);
            GenericHelper.TakeScreenshot("Exception_",driverIE);
            MMSG.Automation.Reports.LogReport.WriteError(ScenarioContext.Current.StepContext.StepInfo.Text + "Exception :" + ex);
            driverIE.Quit();
            Assert.Fail(ScenarioContext.Current.StepContext.StepInfo.Text, ex);
        }
    }
}
