using Microsoft.VisualStudio.TestTools.UnitTesting;
using MMSG.Automation;
//using MMSG.Pages.UI_Pages.ROL.Your_Account;
using TechTalk.SpecFlow;

namespace MMSG.Acceptance.ROL.Tests.ProductAcceptanceTestDefinition
{
    [Binding]
    public class TransactionDefination:BasePage
    {
        /// <summary>
        /// The static instance of the logger for the class.
        /// </summary>
        private static readonly Logger Logger =
            Logger.GetInstance(typeof(TransactionDefination));

        /// <summary>
        /// Method to Verify drop downs and values are displayed
        /// </summary>
        /// <param name="dropDownName"></param>
        /// <param name="dropDownValue"></param>
        [Then(@"I should be displayed with ""(.*)"" dropdown and contains ""(.*)"" value")]
        public void ValidateDropDownAndValue(string dropDownName, string dropDownValue)
        {
            Logger.LogMethodEntry("TransactionsDefinition", "ValidateDropDownAndValue", IsTakeScreenShotDuringEntryExit);
            //Logger.LogAssertion("VerifyDropDownAppeared", ScenarioContext.Current.ScenarioInfo.Title, () =>
            // Assert.IsTrue(new TransactionPage().ValidateDropDownAndValue(dropDownName, dropDownValue)));
            Logger.LogMethodExit("TransactionsDefinition", "ValidateDropDownAndValue", IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verify Available Balance
        /// </summary>
        [Then(@"I should be displayed with Available Balance")]
        public void ValidateAvailableBalance()
        {
            Logger.LogMethodEntry("TransactionsDefinition", "ValidateAvailableBalance", IsTakeScreenShotDuringEntryExit);
            //Logger.LogAssertion("ValidateAvailableBalance", ScenarioContext.Current.ScenarioInfo.Title, () =>
            // Assert.IsTrue(new TransactionsPage().ValidateAvailableBalance()));
            Logger.LogMethodExit("TransactionsDefinition", "ValidateAvailableBalance", IsTakeScreenShotDuringEntryExit);
        }
    }
}
