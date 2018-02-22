using Microsoft.VisualStudio.TestTools.UnitTesting;
using MMSG.Automation;
using MMSG.Pages.UI_Pages.Comet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace MMSG.Acceptance.Comet.Tests.ProductAcceptanceTestDefinition
{
    [Binding]
    public sealed class PaymentInstructionDefinition :  BaseTestFixture
    {
        /// <summary>
        /// The static instance of the logger for the class.
        /// </summary>
        private static readonly Logger Logger =
        Logger.GetInstance(typeof(CallCentreEnquiryDefinition));

        /// <summary>
        /// Verify the benefit grid is dispalyed
        /// </summary>
        [Then(@"I should be display with the Benefit Grid")]
        public void VerifyTheBenefitGridHasAppeare()
        {
            Logger.LogMethodEntry("CallCentreEnquiryPage", "VerifyTheBenefitGridHasAppeare",
                base.IsTakeScreenShotDuringEntryExit);
            Logger.LogAssertion("ValidateTheUserDetails", ScenarioContext.Current.ScenarioInfo.Title, () =>
          Assert.IsTrue(new CallCentreEnquiryPage().VerifyTheBenefitGridHasAppeared()));
            Logger.LogMethodExit("CallCentreEnquiryPage", "VerifyTheBenefitGridHasAppeare", 
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click on The Benefit in the grid
        /// </summary>
        [When(@"I click on the Benefit in benefit grid")]
        public void ClickingOnThebenefitofGrid()
        {
            Logger.LogMethodEntry("CallCentreEnquiryPage", "VerifyTheBenefitGridHasAppeare",
                base.IsTakeScreenShotDuringEntryExit);
            new CallCentreEnquiryPage().ClickingOnTheBenefitOfGrid();
            Logger.LogMethodExit("CallCentreEnquiryPage", "VerifyTheBenefitGridHasAppeare",
                base.IsTakeScreenShotDuringEntryExit);
        }
    }
}
