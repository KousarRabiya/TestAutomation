using CometProject.Hook;
using CometProject.PageObject;
using CometProject.PageObject.AdminFees;
using CometProject.PageObject.BenefitCreation;
using CometProject.PageObject.CardScreen;
using CometProject.PageObject.Package;
using CometProject.PageObject.Package.EditPackage;
using CometProject.PageObject.ReviewAndActivate;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using SeleniumWebdriver.ComponentHelper;
using SeleniumWebdriver.Settings;
using SeleniumWebDriver.BatchProcess;
using System;
using TechTalk.SpecFlow;

namespace CometProject.StepDefinition
{
    [Binding]
    public class PackageCreationAndAddingBenifitSteps
    {
        public IWebDriver driverIE;
        private readonly CallCenterEnquirySearch callCenterSearch;
        private readonly CallCenter callCenter;
        private readonly EmployeeDetailsPage employeeDetails;

        private readonly ProcessMenuPage processsMenuPage;
        private readonly PackageAdminDetailsPage packageAdminDetails;
        private readonly PayRollDetailsPage payRoll;
        private readonly AdminFeesPage adminFees;
        private readonly EditPackagePage editpackage;

        private readonly EditPackageAdminDetailsPage packAdminDetailEdit;
        private readonly EditPayRollDetailsPage payRollDetailEdit;
        private readonly BenefitPage benefitPage;
        private readonly BenefitDetailsPage benefitDetails;

        private readonly ReviewAndActiveatePage activatePackage;
        private readonly CardPage cardScreen;
        private readonly BatchProcessTest batchProcessTest;
        private readonly AmendmentsScreen amendments;

        PackageCreationAndAddingBenifitSteps()
        {
            driverIE = ObjectRepository.Driver;
            callCenterSearch = new CallCenterEnquirySearch(driverIE);
            callCenter = new CallCenter(driverIE);

            employeeDetails = new EmployeeDetailsPage(driverIE);
            processsMenuPage = new ProcessMenuPage(driverIE);
            packageAdminDetails = new PackageAdminDetailsPage(driverIE);

            payRoll = new PayRollDetailsPage(driverIE);
            adminFees = new AdminFeesPage(driverIE);
            editpackage = new EditPackagePage(driverIE);

            packAdminDetailEdit = new EditPackageAdminDetailsPage(driverIE);
            payRollDetailEdit = new EditPayRollDetailsPage(driverIE);
            benefitPage = new BenefitPage(driverIE);

            benefitDetails = new BenefitDetailsPage(driverIE);
            activatePackage = new ReviewAndActiveatePage(driverIE);
            cardScreen = new CardPage(driverIE);

            batchProcessTest = new BatchProcessTest();
            amendments = new AmendmentsScreen(driverIE);
        }

        [Given(@"User enters the valid Employee number in text box")]
        public void GivenUserEntersTheValidEmployeeNumberInTextBox()
        {
            try
            {
                PageFactory.InitElements(driverIE, callCenterSearch);
                callCenterSearch.SearchEmployee();
                SpecHooks.extentTest.Pass(ScenarioContext.Current.StepContext.StepInfo.Text);
            }
            catch (Exception ex)
            {
                WriteReportAndLog(ex);
            }
        }

        [When(@"User clicks on the search button")]
        public void WhenUserClicksOnTheSearchButton()
        {
            try
            {
                callCenterSearch.ClickOnSearchButton();
                SpecHooks.extentTest.Pass(ScenarioContext.Current.StepContext.StepInfo.Text);
            }
            catch (Exception ex)
            {
                WriteReportAndLog(ex);
            }
        }

        [Then(@"Employee Details are shown")]
        public void ThenEmployeeDetailsAreShown()
        {
            try
            {
                PageFactory.InitElements(driverIE, callCenter);
                callCenter.VerifyTreeViewIsDisplayed();
                SpecHooks.extentTest.Pass(ScenarioContext.Current.StepContext.StepInfo.Text);
            }
            catch (Exception ex)
            {
                WriteReportAndLog(ex);
            }
        }

        [Then(@"Click on the Create new package")]
        public void ThenClickOnTheCreateNewPackage()
        {
            try
            {
                callCenter.clickCreatePackage();
                PageFactory.InitElements(driverIE, employeeDetails);
                employeeDetails.VerifyLandedOnEmploymentDetailspage();
                SpecHooks.extentTest.Pass(ScenarioContext.Current.StepContext.StepInfo.Text);
            }
            catch (Exception ex)
            {
                WriteReportAndLog(ex);
            }
        }

        [Then(@"Click on Amendments")]
        public void ThenClickOnAmendments()
        {
            try
            {
                callCenter.clickAmendments();
                PageFactory.InitElements(driverIE, amendments);
                amendments.VerifyLandedOnAmendmentsScreen("Amendments");
            }
            catch (Exception ex)
            {
                WriteReportAndLog(ex);
            }
        }

        [Then(@"Click on New button")]
        public void ThenClickOnNewButton()
        {
            try
            {
                PageFactory.InitElements(driverIE, amendments);
                amendments.clickNewButton();
                amendments.VerifyLandedOnAmendmentsScreen("Amendments - New Benefits");
            }
            catch (Exception ex)
            {
                WriteReportAndLog(ex);
            }
        }

        [Then(@"Enter New Benefit details")]
        public void ThenEnterNewBenefitDetails()
        {
            try
            {
                PageFactory.InitElements(driverIE, amendments);
                amendments.SelectBenefit();
                amendments.SelectBudgetCalculationMethod();
                amendments.EnterBudgetAmount();
                amendments.EnterVariableIncome();
            }
            catch (Exception ex)
            {
                WriteReportAndLog(ex);
            }
        }

        [Then(@"Click on Save button")]
        public void ThenClickOnSaveButton()
        {
            try
            {
                PageFactory.InitElements(driverIE, amendments);
                amendments.clickSaveButton();
                amendments.VerifyLandedOnAmendmentsScreen("Amendments");
                // Assert.AreEqual(true, amendments.VerifyWhetherBenefitIsAdded());
            }
            catch (Exception ex)
            {
                WriteReportAndLog(ex);
            }
        }

        [Then(@"Click on Cancel button")]
        public void ThenClickOnCancelButton()
        {
            try
            {
                PageFactory.InitElements(driverIE, amendments);
                amendments.clickCancelButton();
                PageFactory.InitElements(driverIE, callCenter);
                callCenter.VerifyTreeViewIsDisplayed();
            }
            catch (Exception ex)
            {
                WriteReportAndLog(ex);
            }
        }

        [Then(@"User enters all the details for creating the package and Click on the save button")]
        public void ThenUserEntersAllTheDetailsForCreatingThePackageAndClickOnTheSaveButton()
        {
            try
            {
                PageFactory.InitElements(driverIE, employeeDetails);

                employeeDetails.FillInEmploymentDetailsAndClickNext();
                PageFactory.InitElements(driverIE, packageAdminDetails);
                packageAdminDetails.VerifyPageLandedOnPackageadminDetails();

                packageAdminDetails.FillPackageAdminDetails();
                PageFactory.InitElements(driverIE, payRoll);
                payRoll.VerifyPageLandedOnPayRollDetails();
                payRoll.FillPayrollDetails();
                SpecHooks.extentTest.Pass(ScenarioContext.Current.StepContext.StepInfo.Text);
            }
            catch (Exception ex)
            {
                WriteReportAndLog(ex);
            }
        }

        [Then(@"Verify the Package is created")]
        public void ThenVerifyThePackageIsCreated()
        {
            try
            {
                PageFactory.InitElements(driverIE, callCenter);
                callCenter.VerifyTreeViewIsDisplayed();
                if (callCenter.VerifyPackageStatus() == "(P)")
                {
                    SpecHooks.extentTest.Pass(ScenarioContext.Current.StepContext.StepInfo.Text);
                }
                else
                {
                    SpecHooks.extentTest.Fail(ScenarioContext.Current.StepContext.StepInfo.Text);
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
                driverIE.Close();
                SpecHooks.extentTest.Pass(ScenarioContext.Current.StepContext.StepInfo.Text);
            }
            catch (Exception ex)
            {
                WriteReportAndLog(ex);
            }
        }

        [Then(@"Click on Process Menu")]
        public void ThenClickOnProcessMenu()
        {
            try
            {
                callCenter.clickOnProcessMenu();
                SpecHooks.extentTest.Pass(ScenarioContext.Current.StepContext.StepInfo.Text);
            }
            catch (Exception ex)
            {
                WriteReportAndLog(ex);
            }
        }

        [Then(@"User Clicks on the Edit option")]
        public void ThenUserClicksOnTheEditOption()
        {
            try
            {
                PageFactory.InitElements(driverIE, processsMenuPage);
                processsMenuPage.VerifyLandedOnProcessMenu();
                processsMenuPage.clickOnEdit();
                SpecHooks.extentTest.Pass(ScenarioContext.Current.StepContext.StepInfo.Text);
            }
            catch (Exception ex)
            {
                WriteReportAndLog(ex);
            }

        }
        [Then(@"User Clicks on the Admin Fees option")]
        public void ThenUserClicksOnTheAdminFeesOption()
        {
            try
            {
                PageFactory.InitElements(driverIE, processsMenuPage);
                processsMenuPage.VerifyLandedOnProcessMenu();
                processsMenuPage.ClickOnAdminFee();
                SpecHooks.extentTest.Pass(ScenarioContext.Current.StepContext.StepInfo.Text);
            }
            catch (Exception ex)
            {
                WriteReportAndLog(ex);
            }
        }

        [Then(@"User Add the AdminFees")]
        public void ThenUserAddTheAdminFrees()
        {
            try
            {
                PageFactory.InitElements(driverIE, adminFees);
                adminFees.AddAdminFees();
                SpecHooks.extentTest.Pass(ScenarioContext.Current.StepContext.StepInfo.Text);
            }
            catch (Exception ex)
            {
                WriteReportAndLog(ex);
            }
        }

        [Then(@"User Clicks on the New Benefit option")]
        public void ThenUserClicksOnTheNewBenefitOption()
        {
            try
            {
                PageFactory.InitElements(driverIE, processsMenuPage);
                processsMenuPage.VerifyLandedOnProcessMenu();
                processsMenuPage.ClickNewBenefitButton();
                SpecHooks.extentTest.Pass(ScenarioContext.Current.StepContext.StepInfo.Text);
            }
            catch (Exception ex)
            {
                WriteReportAndLog(ex);
            }
        }
        [Then(@"User Add Benefits")]
        public void ThenUserAddBenifits()
        {
            try
            {
                PageFactory.InitElements(driverIE, benefitPage);
                benefitPage.SelectBenefit();
                benefitPage.ClickOnNextButton();
                PageFactory.InitElements(driverIE, benefitDetails);
                benefitDetails.SelectBudgetCalculationMethod();
                benefitDetails.BudgetAmount();
                benefitDetails.ClickOnSaveButton();
                benefitDetails.PopUpToSaveAndClickOnNo();
                SpecHooks.extentTest.Pass(ScenarioContext.Current.StepContext.StepInfo.Text);
            }
            catch (Exception ex)
            {
                WriteReportAndLog(ex);
            }
        }

        [Then(@"User able to change Email Id And Click on the save button")]
        public void ThenUserAbleToChangeEmailIdAndClickOnTheSaveButton()
        {
            try
            {
                PageFactory.InitElements(driverIE, editpackage);
                editpackage.VerifyLandedOnEmployeeDetailsPage();
                editpackage.EditPackageBusinessEmailId();
                editpackage.ClickOnNext();

                PageFactory.InitElements(driverIE, packAdminDetailEdit);
                packAdminDetailEdit.VerifyPageLandedOnPackageadminDetails();
                packAdminDetailEdit.ClickOnNextButton();
                PageFactory.InitElements(driverIE, payRollDetailEdit);

                payRollDetailEdit.VerifyPageLandedOnPayRollDetails();
                payRollDetailEdit.ClickOnSaveButton();
                SpecHooks.extentTest.Pass(ScenarioContext.Current.StepContext.StepInfo.Text);
            }
            catch (Exception ex)
            {
                WriteReportAndLog(ex);
            }

        }
        [Then(@"Verify Email is Updated")]
        public void ThenVerifyEmailIsUpdated()
        {
            try
            {
                PageFactory.InitElements(driverIE, editpackage);
                if (editpackage.VerifyEmailIdSavedSuccessfully())
                {
                    GenericHelper.IMPScreenShot(driverIE);
                    SpecHooks.extentTest.Pass(ScenarioContext.Current.StepContext.StepInfo.Text);
                }
                else
                {
                    SpecHooks.extentTest.Fail(ScenarioContext.Current.StepContext.StepInfo.Text);
                }
            }
            catch (Exception ex)
            {
                WriteReportAndLog(ex);
            }
        }

        [Then(@"Click on Review and Activate")]
        public void ThenClickOnReviewAndActivate()
        {
            try
            {
                PageFactory.InitElements(driverIE, callCenter);
                callCenter.VerifyTreeViewIsDisplayed();
                callCenter.clickOnProcessMenu();
                PageFactory.InitElements(driverIE, processsMenuPage);
                processsMenuPage.VerifyLandedOnProcessMenu();
                processsMenuPage.ClickReviewActivateButton();
                SpecHooks.extentTest.Pass(ScenarioContext.Current.StepContext.StepInfo.Text);
            }
            catch (Exception ex)
            {
                WriteReportAndLog(ex);
            }
        }

        [Then(@"Activate the Package")]
        public void ThenActivateThePackage()
        {
            try
            {
                PageFactory.InitElements(driverIE, activatePackage);
                activatePackage.ClickOnSaveButton();
                SpecHooks.extentTest.Pass(ScenarioContext.Current.StepContext.StepInfo.Text);
            }
            catch (Exception ex)
            {
                WriteReportAndLog(ex);
            }
        }

        [Then(@"Verify the Package is activated")]
        public void ThenVerifyThePackageIsActivatedOrNot()
        {
            try
            {
                PageFactory.InitElements(driverIE, callCenter);
                if (callCenter.VerifyPackageStatus() == "(A)")
                {
                    GenericHelper.IMPScreenShot(driverIE);
                    SpecHooks.extentTest.Pass(ScenarioContext.Current.StepContext.StepInfo.Text);
                }
                else
                {
                    SpecHooks.extentTest.Fail(ScenarioContext.Current.StepContext.StepInfo.Text);
                }
            }
            catch (Exception ex)
            {
                WriteReportAndLog(ex);
            }

        }
        [Then(@"Verify Card symbol appeared on call center page")]
        public void ThenVerifyCardSymbolAppearedOnCallCenterPage()
        {
            PageFactory.InitElements(driverIE, callCenter);
            callCenter.VerifyCardIsCreatedSuccessufully();
        }

        [Then(@"User click on the card symbol and check the card status is order pending")]
        public void ThenUserClickOnTheCardSymbolAndCheckTheCardStatusIsOrderPending()
        {
            PageFactory.InitElements(driverIE, callCenter);
            callCenter.ClickOnTheCard();
            PageFactory.InitElements(driverIE, cardScreen);
            cardScreen.VerifyCardStatuesIsOrderPending();
        }

        [Then(@"User run batch file in remote machine")]
        public void ThenUserRunBatchFileInRemoteMachine()
        {
            batchProcessTest.ExecuteBatchProcess();
        }

        [Then(@"User Verify card status is incative")]
        public void ThenUserVerifyCardStatusIsIncative()
        {
            driverIE.Navigate().Refresh();
        }
        private void WriteReportAndLog(Exception ex)
        {
            SpecHooks.extentTest.Fail(ScenarioContext.Current.StepContext.StepInfo.Text);
            GenericHelper.TakeScreenshot("Exception_", driverIE);
            SeleniumWebDriver.Reports.LogReport.WriteError(ScenarioContext.Current.StepContext.StepInfo.Text + "Exception :" + ex);
            driverIE.Quit();
            Assert.Fail(ScenarioContext.Current.StepContext.StepInfo.Text, ex);
        }
    }
}
