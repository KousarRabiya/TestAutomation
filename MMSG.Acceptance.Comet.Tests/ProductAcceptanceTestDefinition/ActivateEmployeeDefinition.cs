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
    public void VerifyThe(string popUpTitle)
    {
        Logger.LogMethodEntry("ActivateEmployeeDefinition", "VerifyAmendmentPage",
             base.IsTakeScreenShotDuringEntryExit);
        Logger.LogAssertion("ValidateTheUserDetails", ScenarioContext.Current.ScenarioInfo.Title, () =>
        Assert.AreEqual(popUpTitle, new CallCentreEnquiryPage().GetTheTitleOfpopUp()));
        Logger.LogMethodExit("AmendmentsDefinition", "ValidatePageName",
       base.IsTakeScreenShotDuringEntryExit);
    }



    [When(@"I click on ""(.*)"" option in Pop up")]
    public void WhenIClickOnOptionInPopUp(string clickOnOption)
    {
        Logger.LogMethodEntry("AmendmentsDefinition", "VerifyAmendmentPage",
             base.IsTakeScreenShotDuringEntryExit);
        new CallCentreEnquiryPage().ProcessMenuPopUpClickOnElement(clickOnOption);
        Logger.LogMethodExit("AmendmentsDefinition", "ValidatePageName",
      base.IsTakeScreenShotDuringEntryExit);
    }




}
}
