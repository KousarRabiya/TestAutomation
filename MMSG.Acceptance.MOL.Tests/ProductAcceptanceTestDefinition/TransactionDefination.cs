using Microsoft.VisualStudio.TestTools.UnitTesting;
using MMSG.Automation;
using MMSG.Pages.UI_Pages.ROL.Home.Dashboard;
using MMSG.Pages.UI_Pages.MOL.Your_Account;
using TechTalk.SpecFlow;

namespace MMSG.Acceptance.MOL.Tests.ProductAcceptanceTestDefinition
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
        /// Navigate to the tab based on the tab name
        /// </summary>
        /// <param name="tabName">This is tab name.</param>
        [When(@"I navigate to ""(.*)"" tab")]
        public void NavigateToTab(string tabName)
        {
            Logger.LogMethodEntry("TransactionDefination", "NavigateToTab", base.IsTakeScreenShotDuringEntryExit);
            // Navigate to tab based on the tab name
            new DashboardPage().NavigateToTab("Maxxia Online",tabName);
            Logger.LogMethodExit("TransactionDefination", "NavigateToTab", base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Method to Verify drop downs and values are displayed
        /// </summary>
        /// <param name="dropDownName"></param>
        [Then(@"I should be displayed with ""(.*)"" dropdown")]
        public void ValidateDropDownIsPresent(string dropDownName)
        {
            Logger.LogMethodEntry("TransactionDefinition", "ValidateDropDownIsPresent", IsTakeScreenShotDuringEntryExit);
            Logger.LogAssertion("ValidateDropDownIsPresent", ScenarioContext.Current.ScenarioInfo.Title, () =>
             Assert.IsTrue(new TransactionsPage().ValidateDropDownIsPresent(dropDownName)));
            Logger.LogMethodExit("TransactionDefinition", "ValidateDropDownIsPresent", IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Method to select drop down option
        /// </summary>
        /// <param name="dropDownOption"></param>
        /// <param name="dropDownName"></param>
        [When(@"I select ""(.*)"" in the dropdown ""(.*)""")]
        public void SelectingTheDropDown(string dropDownOption, string dropDownName)
        {
            Logger.LogMethodEntry("TransactionDefinition", "SelectingTheDropDown", base.IsTakeScreenShotDuringEntryExit);
            new TransactionsPage().ClickOnDropDown(dropDownOption, dropDownName);
            Logger.LogMethodExit("TransactionDefinition", "SelectingTheDropDown", base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verify Available Balance
        /// </summary>
        [Then(@"I should be displayed with Available Balance")]
        public void ValidateAvailableBalance()
        {
            Logger.LogMethodEntry("TransactionDefinition", "ValidateAvailableBalance", IsTakeScreenShotDuringEntryExit);
            Logger.LogAssertion("ValidateAvailableBalance", ScenarioContext.Current.ScenarioInfo.Title, () =>
             Assert.IsTrue(new TransactionsPage().ValidateAvailableBalance()));
            Logger.LogMethodExit("TransactionDefinition", "ValidateAvailableBalance", IsTakeScreenShotDuringEntryExit);
        }
    }
}
