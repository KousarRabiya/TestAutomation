using Microsoft.VisualStudio.TestTools.UnitTesting;
using MMSG.Automation;
using MMSG.Pages.UI_Pages.Comet;
using System;
using TechTalk.SpecFlow;

namespace MMSG.Acceptance.Comet.Tests.ProductAcceptanceTestDefinition
{
    [Binding]
    public class AmendmentsDefinition: BasePage
    {
        /// <summary>
        /// The static instance of the logger for the class.
        /// </summary>
        private static readonly Logger Logger =
        Logger.GetInstance(typeof(Employee_personaldetailsDefinition));

        [Then(@"I should be on the Amendment page")]
        public void VerifyAmendmentPage()
        {
            Logger.LogMethodEntry("AmendmentsDefinition", "VerifyAmendmentPage",
               base.IsTakeScreenShotDuringEntryExit);
            Logger.LogAssertion("ValidateTheUserDetails", ScenarioContext.Current.ScenarioInfo.Title, () =>
           Assert.IsTrue(new AmendmentPage().VerifyThepageLandedOnAmendment()));
            Logger.LogMethodExit("Employee_personaldetailsDefinition", "ValidatePageName",
               base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Clicking on the New Button in Amendment Screen
        /// </summary>
        /// <param name="p0"></param>
        [When(@"I click on ""(.*)"" in Amendment page")]
        public void WhenIClickOnInAmendmentPage(string clickOption)
        {
            Logger.LogMethodEntry("AmendmentsDefinition", "VerifyAmendmentPage",
               base.IsTakeScreenShotDuringEntryExit);
            new AmendmentPage().ClickOnOption(clickOption);
            Logger.LogMethodExit("AmendmentsDefinition", "ValidatePageName",
              base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verify the apge landed on the Amendment Benefit page
        /// </summary>
        /// <param name="p0"></param>
        [Then(@"I should be display ""(.*)"" in Amendments_NewBenefits Page")]
        public void VerifyThePageLandedOnAmendmentBenefit(string pageName)
        {
            Logger.LogMethodEntry("AmendmentsDefinition", "VerifyThePageLandedOnAmendmentBenefit",
                base.IsTakeScreenShotDuringEntryExit);
            Logger.LogAssertion("ValidateTheUserDetails", ScenarioContext.Current.ScenarioInfo.Title, () =>
            Assert.IsTrue(new Amendment_BenefitPage().VerifyPageLandedOnAmendmentBenefitPage(pageName)));
            Logger.LogMethodExit("AmendmentsDefinition", "VerifyThePageLandedOnAmendmentBenefit",
             base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Selecting the benefit from the dropdown 
        /// </summary>
        /// <param name="p0">Benenfit type</param>
        [When(@"I select ""(.*)"" Benefit in Amendments_NewBenefits Page")]
        public void WhenISelectInAmendments_NewBenefits(string benefitType)
        {
            Logger.LogMethodEntry("AmendmentsDefinition", "VerifyAmendmentPage",
                base.IsTakeScreenShotDuringEntryExit);
            new Amendment_BenefitPage().SelectTheBenefitDropDown(benefitType);
            Logger.LogMethodExit("AmendmentsDefinition", "ValidatePageName",
            base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Entering the Effective date 
        /// </summary>
        [When(@"I enter Effective date in Amendments_NewBenefits Page")]
        public void WhenIEnterEffectiveDateInAmendments_NewBenefits()
        {
            Logger.LogMethodEntry("AmendmentsDefinition", "VerifyAmendmentPage",
                 base.IsTakeScreenShotDuringEntryExit);
            new Amendment_BenefitPage().EffectiveDate();
            Logger.LogMethodExit("AmendmentsDefinition", "ValidatePageName",
           base.IsTakeScreenShotDuringEntryExit);
        }

        [When(@"I selelct Next Paydate for change is ""(.*)""")]
        public void WhenISelelctNextPaydateForChangeIs(string paydate)
        {
            Logger.LogMethodEntry("AmendmentsDefinition", "VerifyAmendmentPage",
                base.IsTakeScreenShotDuringEntryExit);
            new Amendment_BenefitPage().NextPayDate(paydate);
            Logger.LogMethodExit("AmendmentsDefinition", "ValidatePageName",
           base.IsTakeScreenShotDuringEntryExit);
        }

        [When(@"I select Budget Calculation Method As ""(.*)""")]
        public void WhenISelectBudgetCalculationMethodAs(string p0)
        {
           
        }







    }
}
