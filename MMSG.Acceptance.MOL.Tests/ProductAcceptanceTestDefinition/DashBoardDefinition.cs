using Microsoft.VisualStudio.TestTools.UnitTesting;
using MMSG.Automation;
using System;
using TechTalk.SpecFlow;
using MMSG.Pages.UI_Pages.MOL.Home.Dashboard;

namespace MMSG.Acceptance.MOL.Tests.ProductAcceptanceTestDefinition
{
    [Binding]
    public class DashBoardDefinition: BasePage
    {

        /// <summary>
        /// The static instance of the logger for the class.
        /// </summary>
        private static readonly Logger Logger =
            Logger.GetInstance(typeof(DashBoardDefinition));      

        [Then(@"I should be display with the benefit ""(.*)""")]
        public void VerifyTheBenefitIsPresent(string benefitName)
        {
            Logger.LogMethodEntry("DashBoardDefinition", "VerifyTheBenefitIsPresent", base.IsTakeScreenShotDuringEntryExit);
            Logger.LogAssertion("ValidateTheUserDetails", ScenarioContext.Current.ScenarioInfo.Title, () =>
             Assert.IsTrue(new DashboardPage().VerifyTheBenefitIsPresent(benefitName)));
            Logger.LogMethodExit("DashBoardDefinition", "VerifyTheBenefitIsPresent", base.IsTakeScreenShotDuringEntryExit);
        } 
             

    }
}
