using Microsoft.VisualStudio.TestTools.UnitTesting;
using MMSG.Automation;
using MMSG.Pages.UI_Pages.Comet;
using TechTalk.SpecFlow;

namespace MMSG.Acceptance.Comet.Tests.ProductAcceptanceTestDefinition
{
    [Binding]
    public sealed class VerifyBudgetAmountTransactionsDefination : BaseTestFixture
    {
        /// <summary>
        /// The static instance of the logger for the class.
        /// </summary>
        private static readonly Logger Logger =
        Logger.GetInstance(typeof(VerifyBudgetAmountTransactionsDefination));

        /// <summary>
        /// Click on Employee Number
        /// </summary>
        [Given(@"I click on employee number")]
        public void ClickOnEmpNumber()
        {
            //Click Employee Number
            Logger.LogMethodEntry("VerifyBudgetAmountTransactionsDefination", "ClickOnEmpNumber", base.IsTakeScreenShotDuringEntryExit);
            new VerifyBudgetAmountTransactionPage().ClickEmployeeNumber();
            Logger.LogMethodExit("VerifyBudgetAmountTransactionsDefination", "ClickOnEmpNumber", base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verify Proces menu and select EAMS option
        /// </summary>
        [When(@"I Select EAMS option")]
        public void SelectEAMS()
        {
            Logger.LogMethodEntry("VerifyBudgetAmountTransactionsDefination", "SelectEAMS", base.IsTakeScreenShotDuringEntryExit);
            Assert.AreEqual("PROCESSES", new VerifyBudgetAmountTransactionPage().SwitchAndGetPageTitle("PROCESSES"));
            new VerifyBudgetAmountTransactionPage().SelectEAMS();
            Logger.LogMethodExit("VerifyBudgetAmountTransactionsDefination", "SelectEAMS", base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verify Landed On EAMS Screen
        /// </summary>
        [Then(@"I will land on EAMS screen")]
        public void VerifyLandedOnEAMSScreen()
        {
            Logger.LogMethodEntry("VerifyBudgetAmountTransactionsDefination", "VerifyLandedOnEAMSScreen", base.IsTakeScreenShotDuringEntryExit);
            Assert.AreEqual("Maxxia Account Snapin", new VerifyBudgetAmountTransactionPage().SwitchAndGetPageTitle("Maxxia Account Snapin"));
            new VerifyBudgetAmountTransactionPage().SaveMOLUserName();
            Logger.LogMethodExit("VerifyBudgetAmountTransactionsDefination", "VerifyLandedOnEAMSScreen", base.IsTakeScreenShotDuringEntryExit);
        }
    }
}
