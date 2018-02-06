using Microsoft.VisualStudio.TestTools.UnitTesting;
using MMSG.Automation;
using MMSG.Pages.UI_Pages.MOL.Home.Dashboard;
using System;
using TechTalk.SpecFlow;

namespace MMSG.Acceptance.MOL.Tests.ProductAcceptanceTestDefinition
{
    [Binding]
    public class YourAccountDefinition : BasePage
    {
        /// <summary>
        /// The static instance of the logger for the class.
        /// </summary>
        private static readonly Logger Logger =
            Logger.GetInstance(typeof(YourAccountDefinition));

        [When(@"I click on the link ""(.*)""")]
        public void CLickOnTheLink(string linkName)
        {
            Logger.LogMethodEntry("YourAccountDefinition", "CLickOnTheLink", base.IsTakeScreenShotDuringEntryExit);
            new DashboardPage().ClickOnTheLink(linkName);
            Logger.LogMethodExit("YourAccountDefinition", "CLickOnTheLink", base.IsTakeScreenShotDuringEntryExit);
        }

        [Then(@"I should be display with page name ""(.*)""")]
        public void VerifyPageLandedOnPayrollDeductionsAndTransfers(string pageName)
        {
            Logger.LogMethodEntry("ContactDefinition", "ValidateTheUserDetails", base.IsTakeScreenShotDuringEntryExit);
            Logger.LogAssertion("ValidateTheUserDetails", ScenarioContext.Current.ScenarioInfo.Title, () =>
                Assert.IsTrue(new PayrollDeductionsAndTransfersPage().VerifyThepageLandedOnPayrollDeductionsAndTransfers(pageName)));
            Logger.LogMethodExit("ContactDefinition", "ValidateTheUserDetails", base.IsTakeScreenShotDuringEntryExit);
        }

        [When(@"I click on the tab ""(.*)""")]
        public void CliLOnTheTab(string tabName)
        {
            Logger.LogMethodEntry("YourAccountDefinition", "CLickOnTheLink", base.IsTakeScreenShotDuringEntryExit);
            new PayrollDeductionsAndTransfersPage().ClickOnTheTab(tabName);
             Logger.LogMethodExit("YourAccountDefinition", "CLickOnTheLink", base.IsTakeScreenShotDuringEntryExit);
        }



    }
}
