using Microsoft.VisualStudio.TestTools.UnitTesting;
using MMSG.Automation;
using MMSG.Pages.UI_Pages.Comet.Process_Menu;
using TechTalk.SpecFlow;

namespace MMSG.Acceptance.Comet.Tests.ProductAcceptanceTestDefinition
{
    [Binding]
    public sealed class AddBenefitDefination : BaseTestFixture
    {
        /// <summary>
        /// The static instance of the logger for the class.
        /// </summary>
        private static readonly Logger Logger =
        Logger.GetInstance(typeof(AddBenefitDefination));

        /// <summary>
        /// Verify application landed on Benefit Screen
        /// </summary>
        [Then(@"I will land on New Benefit page")]
        public void VerifyLandedOnNewBenefitScreen()
        {
            Logger.LogMethodEntry("AddBenefitDefination", "VerifyLandedOnNewBenefitScreen", base.IsTakeScreenShotDuringEntryExit);
            Assert.AreEqual("mslmcoppiapp01 Package Benefit", new AddBenefitPage().GetPageHeader());
            Logger.LogMethodExit("AddBenefitDefination", "VerifyLandedOnNewBenefitScreen", base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Benefit
        /// </summary>
        [Then(@"I select ""(.*)"" in ""(.*)""")]
        public void SelectBenefit(string dropDownOption, string dropDownName)
        {
            Logger.LogMethodEntry("AddBenefitDefination", "SelectBenefit", base.IsTakeScreenShotDuringEntryExit);
            new AddBenefitPage().SelectDropDown(dropDownOption, dropDownName);
            Logger.LogMethodExit("AddBenefitDefination", "SelectBenefit", base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click on Button
        /// </summary>
        [Then(@"I click on ""(.*)"" Button")]
        public void ClickOnButton(string buttonName)
        {
            Logger.LogMethodEntry("AddBenefitDefination", "ClickOnButton", base.IsTakeScreenShotDuringEntryExit);
            new AddBenefitPage().ClickOnButton(buttonName);
            Logger.LogMethodExit("AddBenefitDefination", "ClickOnButton", base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Enter Budget Amount
        /// </summary>
        [Then(@"I enter Budget Amount")]
        public void BudgetAmount()
        {
            Logger.LogMethodEntry("AddBenefitDefination", "BudgetAmount", base.IsTakeScreenShotDuringEntryExit);
            new AddBenefitPage().BudgetAmount();
            Logger.LogMethodExit("AddBenefitDefination", "BudgetAmount", base.IsTakeScreenShotDuringEntryExit);
        }
    }
}
