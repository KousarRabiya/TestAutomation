using Microsoft.VisualStudio.TestTools.UnitTesting;
using MMSG.Automation;
using MMSG.Automation.DataTransferObjects;
using MMSG.Pages.UI_Pages.Comet;
using System;
using TechTalk.SpecFlow;

namespace MMSG.Acceptance.Comet.Tests.ProductAcceptanceTestDefinition
{
    [Binding]
    public class AmendmentsDefinition : BasePage
    {
        /// <summary>
        /// The static instance of the logger for the class.
        /// </summary>
        private static readonly Logger Logger =
        Logger.GetInstance(typeof(AmendmentsDefinition));

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
        /// <param name="clickOption">Button Name</param>
        [When(@"I click on ""(.*)"" in Amendment page")]
        public void ClickingOnTheAmendmentOption(string clickOption)
        {
            Logger.LogMethodEntry("AmendmentsDefinition", "ClickingOnTheAmendmentOption",
               base.IsTakeScreenShotDuringEntryExit);
            new AmendmentPage().ClickOnOption(clickOption);
            Logger.LogMethodExit("AmendmentsDefinition", "ClickingOnTheAmendmentOption",
              base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verify the apge landed on the Amendment Benefit page
        /// </summary>
        /// <param name="pageName"> Page Name</param>
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
        /// <param name="benefitType">Benenfit type</param>
        [When(@"I select Benefit for ""(.*)""")]
        public void SelctingTheBenefitDropdown(Benefit.BenefitTypeEnum benifitType)
        {
            Logger.LogMethodEntry("AmendmentsDefinition", "SelctingTheBenefitDropdown",
                base.IsTakeScreenShotDuringEntryExit);
            new Amendment_BenefitPage().SelectTheBenefitDropDown(benifitType);
            Logger.LogMethodExit("AmendmentsDefinition", "SelctingTheBenefitDropdown",
            base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Entering the Effective date 
        /// </summary>
        [When(@"I enter Effective date in Amendments_NewBenefits Page")]
        public void EnteringTheEffectiveDate()
        {
            Logger.LogMethodEntry("AmendmentsDefinition", "EnteringTheEffectiveDate",
                 base.IsTakeScreenShotDuringEntryExit);
            new Amendment_BenefitPage().EffectiveDate();
            Logger.LogMethodExit("AmendmentsDefinition", "EnteringTheEffectiveDate",
           base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Selcying the Pay date in the drop down
        /// </summary>
        [When(@"I selelct Next Paydate for change")]
        public void SelelctingTheNextPayDate()
        {
            Logger.LogMethodEntry("AmendmentsDefinition", "SelelctingTheNextPayDate",
                base.IsTakeScreenShotDuringEntryExit);
            new Amendment_BenefitPage().NextPayDate();
            Logger.LogMethodExit("AmendmentsDefinition", "SelelctingTheNextPayDate",
           base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Selecting the Budget calcution method type
        /// </summary>
        /// <param name="calculationMethodType">Budget Method type</param>
        [When(@"I select Budget Calculation Method of ""(.*)""")]
        public void SelelctingTheCalculationMethodType(Benefit.BenefitTypeEnum benefitType)
        {
            Logger.LogMethodEntry("AmendmentsDefinition", "SelelctingTheCalculationMethodType",
                base.IsTakeScreenShotDuringEntryExit);
            new Amendment_BenefitPage().BudgetCalculationMethod(benefitType);
            Logger.LogMethodExit("AmendmentsDefinition", "SelelctingTheCalculationMethodType",
           base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Entering the amount to the Txt box budget ammount
        /// </summary>
        /// <param name="budgetAmount">Budget Amount</param>

        [When(@"I enter the Budget Amount of ""(.*)""")]
        public void EnteringTheBudgetAmount(Benefit.BenefitTypeEnum benefitType)
        {
            Logger.LogMethodEntry("AmendmentsDefinition", "EnteringTheBudgetAmount",
                base.IsTakeScreenShotDuringEntryExit);
            new Amendment_BenefitPage().BudgetAmount(benefitType);
            Logger.LogMethodExit("AmendmentsDefinition", "EnteringTheBudgetAmount",
           base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Clicking on the save button in the amendmentBenefit page
        /// </summary>

        [When(@"I enter save Button in Amendments_NewBenefits Page")]
        public void ClickingOnTheaSaveButton()
        {
            Logger.LogMethodEntry("AmendmentsDefinition", "ClickingOnTheaSaveButton",
                base.IsTakeScreenShotDuringEntryExit);
            new Amendment_BenefitPage().ClickOnSaveButton();
            Logger.LogMethodExit("AmendmentsDefinition", "ClickingOnTheaSaveButton",
           base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Checking the Benefit is added and displayed in the amendment Page
        /// </summary>
        /// <param name="benefitname">Benefit Name which needto be added </param>
        [Then(@"I should see the New benefit Name of ""(.*)""")]
        public void VerifyingTheBenefitIsBeenAdded(Benefit.BenefitTypeEnum benefitType)
        {
            Logger.LogMethodEntry("AmendmentsDefinition", "VerifyingTheBenefitIsBeenAdded",
                 base.IsTakeScreenShotDuringEntryExit);
            Logger.LogAssertion("ValidateTheUserDetails", ScenarioContext.Current.ScenarioInfo.Title, () =>
            Assert.IsTrue(new AmendmentPage().BenefitIsAdded(benefitType)));
            Logger.LogMethodExit("AmendmentsDefinition", "VerifyingTheBenefitIsBeenAdded",
           base.IsTakeScreenShotDuringEntryExit);
        }

    }
}
