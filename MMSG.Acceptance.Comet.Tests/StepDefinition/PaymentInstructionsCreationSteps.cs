using CometProject.PageObject;
using CometProject.PageObject.PaymentInstruction;
using CometProject.PageObject.ProcessMenuBenefit;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using MMSG.Automation.ComponentHelper;
using MMSG.Automation.Settings;
using System;
using System.Linq;
using TechTalk.SpecFlow;

namespace CometProject.StepDefinition
{
    [Binding]
    public class PaymentInstructionsCreationSteps
    {
        public IWebDriver driverIE;
        private readonly CallCenterEnquirySearch callCenterSearch;
        private readonly CallCenter callCenter;

        private readonly BenefitProcessMenu BenefitProcessMenu;
        private readonly PaymentInstructionPage paymentInstruction;
        PaymentInstructionsCreationSteps()
        {
            driverIE = ObjectRepository.Driver;
            callCenterSearch = new CallCenterEnquirySearch(driverIE);
            callCenter = new CallCenter(driverIE);
            BenefitProcessMenu = new BenefitProcessMenu(driverIE);
            paymentInstruction = new PaymentInstructionPage(driverIE);
        }
        [Given(@"User opens Browser and Launch Comet Appliction")]
        public void GivenUserOpensBrowserAndLaunchCometAppliction()
        {
            try
            {
                driverIE.Navigate().GoToUrl(ObjectRepository.URL);
                driverIE.SwitchTo().Window(driverIE.WindowHandles.Last());
                driverIE.Manage().Window.Maximize();
                //SpecHooks.extentTest.Pass(ScenarioContext.Current.StepContext.StepInfo.Text);
            }
            catch (Exception ex)
            {
                WriteRaportAndLog(ex);
            }
        }       

        [When(@"User Enters Newly Created Employee ID and Search")]
        public void GivenUserEntersNewlyCreatedEmployeeIDAndSearch()
        {
            try
            {
                PageFactory.InitElements(driverIE, callCenterSearch);
                callCenterSearch.SearchEmployee();
                callCenterSearch.ClickOnSearchButton();
                //SpecHooks.extentTest.Pass(ScenarioContext.Current.StepContext.StepInfo.Text);
            }
            catch (Exception ex)
            {
                WriteRaportAndLog(ex);
            }
        }

        [When(@"User clicks on the benefits")]
        public void WhenUserClicksOnTheBenefits()
        {
            try
            {
                PageFactory.InitElements(driverIE, callCenter);
                callCenter.ClickOnBenefit();
                //SpecHooks.extentTest.Pass(ScenarioContext.Current.StepContext.StepInfo.Text);
            }
            catch (Exception ex)
            {
                WriteRaportAndLog(ex);
            }
        }

        [Then(@"User clicks on the benefit from the Benefit Grid")]
        public void ThenUserClicksOnTheBenefitFromTheBenefitGrid()
        {
            try
            {
                PageFactory.InitElements(driverIE, callCenter);
                callCenter.BenefitNameInGrid();
                //SpecHooks.extentTest.Pass(ScenarioContext.Current.StepContext.StepInfo.Text);
            }
            catch (Exception ex)
            {
                WriteRaportAndLog(ex);
            }

        }

        [Then(@"Click on the Edit Payment Instructions from Process menu")]
        public void ThenClickOnTheEditPaymentInstructionsFromProcessMenu()
        {
            try
            {
                PageFactory.InitElements(driverIE, BenefitProcessMenu);
                BenefitProcessMenu.VerifyPageLandedOnProcessMenu();
                BenefitProcessMenu.ClickOnEditPaymentInstruction();
                //SpecHooks.extentTest.Pass(ScenarioContext.Current.StepContext.StepInfo.Text);
            }
            catch (Exception ex)
            {
                WriteRaportAndLog(ex);
            }
        }

        [Then(@"User fills all the details and selecting Payment type as Adhoc")]
        public void ThenUserFillsAllTheDetails()
        {
            try
            {
                PageFactory.InitElements(driverIE, paymentInstruction);
                paymentInstruction.VerifyPageLandedOnPaymentInstructionPage();
                paymentInstruction.SelectPaymentType();

                paymentInstruction.PaymentDescriptionTextBox();
                paymentInstruction.PaymentReference();
                paymentInstruction.PaymentAmountTextBox();
                paymentInstruction.PartPaymentSelect();

                paymentInstruction.PaymentDueDateBox();
                paymentInstruction.PaymentTerminationDateBox();
                paymentInstruction.PaymentFrequencySelect();
                paymentInstruction.SearchPayee();

                paymentInstruction.AddButtonClick();
                //SpecHooks.extentTest.Pass(ScenarioContext.Current.StepContext.StepInfo.Text);
            }
            catch (Exception ex)
            {
                WriteRaportAndLog(ex);
            }
        }

        [Then(@"User save the Payment Instruction")]
        public void ThenUserSaveThePaymentInstruction()
        {
            try
            {
                PageFactory.InitElements(driverIE, paymentInstruction);
                paymentInstruction.ClickOnSaveButton();
                //SpecHooks.extentTest.Pass(ScenarioContext.Current.StepContext.StepInfo.Text);
            }
            catch (Exception ex)
            {
                WriteRaportAndLog(ex);
            }
        }

        [Then(@"User fills all the details and selecting Payment type as Regular")]
        public void ThenUserFillsAllTheDetailsAndSelectingPaymentTypeAsRegular()
        {
            try
            {
                PageFactory.InitElements(driverIE, paymentInstruction);
                paymentInstruction.VerifyPageLandedOnPaymentInstructionPage();
                paymentInstruction.SelectPaymentType();

                paymentInstruction.PaymentDescriptionTextBox();
                paymentInstruction.PaymentReference();
                paymentInstruction.PaymentAmountTextBox();

                paymentInstruction.PartPaymentSelect();
                paymentInstruction.PaymentDueDateBox();
                paymentInstruction.PaymentFrequencySelect();

                paymentInstruction.SearchPayee();
                paymentInstruction.AddButtonClick();
                //SpecHooks.extentTest.Pass(ScenarioContext.Current.StepContext.StepInfo.Text);
            }
            catch (Exception ex)
            {
                WriteRaportAndLog(ex);
            }
        }

        [Then(@"Verify Payment Instruction is been Created")]
        public void ThenVerifyPaymentInstructionIsBeenCreated()
        {
            try
            {
                PageFactory.InitElements(driverIE, callCenter);
                callCenter.VerifyTreeViewIsDisplayed();
                bool paymentDescrtion = callCenter.VerifyPaymentInstructionIsCreated();
                if (paymentDescrtion)
                {
                    GenericHelper.IMPScreenShot(driverIE);
                    //SpecHooks.extentTest.Pass(ScenarioContext.Current.StepContext.StepInfo.Text);
                }

            }
            catch (Exception ex)
            {
                WriteRaportAndLog(ex);
            }
        }
        [Then(@"Close browser")]
        public void ThenCloseBrowser()
        {
            try
            {
                driverIE.Close();
                //SpecHooks.extentTest.Pass(ScenarioContext.Current.StepContext.StepInfo.Text);
            }
            catch (Exception ex)
            {
                WriteRaportAndLog(ex);
            }
        }

        private void WriteRaportAndLog(Exception ex)
        {
            //SpecHooks.extentTest.Fail(ScenarioContext.Current.StepContext.StepInfo.Text);
            GenericHelper.TakeScreenshot("Exception_",driverIE);
            MMSG.Automation.Reports.LogReport.WriteError(ScenarioContext.Current.StepContext.StepInfo.Text + "Exception :" + ex);
            driverIE.Quit();
            Assert.Fail(ScenarioContext.Current.StepContext.StepInfo.Text, ex);
        }
    }
}
