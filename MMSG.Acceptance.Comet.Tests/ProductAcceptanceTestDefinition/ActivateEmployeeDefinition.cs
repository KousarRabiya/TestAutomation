using Microsoft.VisualStudio.TestTools.UnitTesting;
using MMSG.Automation;
using MMSG.Pages.UI_Pages.Comet;
using TechTalk.SpecFlow;

namespace MMSG.Acceptance.Comet.Tests.ProductAcceptanceTestDefinition
{
    [Binding]
    public sealed class ActivateEmployeeDefinition : BasePage
    {
        /// <summary>
        /// The static instance of the logger for the class.
        /// </summary>
        private static readonly Logger Logger =
        Logger.GetInstance(typeof(ActivateEmployeeDefinition));

    /// <summary>
    /// Verify the Pop has appeared
    /// </summary>
    /// <param name="popUpTitle"> pop up title</param>     

    [Then(@"I should be display with ""(.*)"" Pop up in Call Centre Enqiury screen")]
    public void VerifyAmendmentPage(string popUpTitle)
    {
        Logger.LogMethodEntry("ActivateEmployeeDefinition", "VerifyAmendmentPage",
             base.IsTakeScreenShotDuringEntryExit);
        Logger.LogAssertion("ValidateTheUserDetails", ScenarioContext.Current.ScenarioInfo.Title, () =>
        Assert.AreEqual(popUpTitle, new CallCentreEnquiryPage().GetTheTitleOfpopUp()));
        Logger.LogMethodExit("AmendmentsDefinition", "ValidatePageName",
       base.IsTakeScreenShotDuringEntryExit);
    }

        /// <summary>
        /// Clicking on the element in Pop Up
        /// </summary>
        /// <param name="clickOnOption">option need to clicked</param>
        [When(@"I click on ""(.*)"" option in Pop up")]
    public void SelelctAdminFeesInPopUp(string clickOnOption)
    {
        Logger.LogMethodEntry("AmendmentsDefinition", "VerifyAmendmentPage",
             base.IsTakeScreenShotDuringEntryExit);
        new CallCentreEnquiryPage().ProcessMenuPopUpClickOnElement(clickOnOption);
        Logger.LogMethodExit("AmendmentsDefinition", "ValidatePageName",
      base.IsTakeScreenShotDuringEntryExit);
    }

        /// <summary>
        /// Verify the page landed on the Admin Fees for Package
        /// </summary>
        /// <param name="pageTitle">Title of the apge</param>

        [Then(@"I should be display with  ""(.*)"" in title")]
        public void VerifyThePageHeader(string pageTitle)
        {
            Logger.LogMethodEntry("ActivateEmployeeDefinition", "VerifyThePageHeader",
             base.IsTakeScreenShotDuringEntryExit);
            Logger.LogAssertion("ValidateTheUserDetails", ScenarioContext.Current.ScenarioInfo.Title, () =>
            Assert.AreEqual(pageTitle, new AdminFeesForPackagePage().VerifyPageLandedOnAdminFeesForPackagePackage()));
            Logger.LogMethodExit("AmendmentsDefinition", "VerifyThePageHeader",
           base.IsTakeScreenShotDuringEntryExit);
        }
        /// <summary>
        /// 
        /// </summary>
        [When(@"I enter Effective Date in Admin Fees for Package")]
        public void EnteringTheEffectiveDate()
        {

            Logger.LogMethodEntry("ActivateEmployeeDefinition", "EnteringTheEffectiveDate",
             base.IsTakeScreenShotDuringEntryExit);
            new AdminFeesForPackagePage().EnterTheEffectiveDate();
            Logger.LogMethodExit("AmendmentsDefinition", "EnteringTheEffectiveDate",
          base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// User click on the look up image and selelct the fees name from the pop up
        /// </summary>
        [When(@"I should Click on the lookup button and select Fees Name from PopUp")]
        public void ClickingOnLookupImgAndsectingTheFees()
        {
            Logger.LogMethodEntry("ActivateEmployeeDefinition", "ClickingOnLookupImgAndsectingTheFees",
              base.IsTakeScreenShotDuringEntryExit);
           new AdminFeesForPackagePage().ClickOnLookUpImgAndSelelctFeesName();
            Logger.LogMethodExit("AmendmentsDefinition", "ClickingOnLookupImgAndsectingTheFees",
        base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click on the Add button and save the fees 
        /// </summary>
        [When(@"I click on Add button and Save the Fees")]
        public void ClickOnTheAddButtonAndSaveTheAdminFees()
        {

            Logger.LogMethodEntry("ActivateEmployeeDefinition", "ClickingOnLookupImgAndsectingTheFees",
              base.IsTakeScreenShotDuringEntryExit);
            new AdminFeesForPackagePage().ClickOnAddAndSaveTheFees();
            Logger.LogMethodExit("AmendmentsDefinition", "ClickingOnLookupImgAndsectingTheFees",
        base.IsTakeScreenShotDuringEntryExit);
        }


    }
}
