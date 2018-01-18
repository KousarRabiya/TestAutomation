using Microsoft.VisualStudio.TestTools.UnitTesting;
using MMSG.Automation;
using MMSG.Automation.DataTransferObjects;
using MMSG.Pages.UI_Pages.ROL.Home.Dashboard;
using TechTalk.SpecFlow;

namespace MMSG.Acceptance.ROL.Tests.ProductAcceptanceTestDefinition
{
    [Binding]
    public class ContactDefinition : BasePage
    {
        /// <summary>
        /// The static instance of the logger for the class.
        /// </summary>
        private static readonly Logger Logger =
            Logger.GetInstance(typeof(ContactDefinition));

        /// <summary>
        /// Navigate to the tab based on the tab name
        /// </summary>
        /// <param name="tabName">This is tab name.</param>
        [When(@"I navigate to ""(.*)"" tab")]
        public void NavigateToTab(string tabName)
        {
            Logger.LogMethodEntry("ContactDefinition", "NavigateToTab",base.IsTakeScreenShotDuringEntryExit);
            // Navigate to tab based on the tab name
            new DashboardPage().NavigateToTab(tabName);
            Logger.LogMethodExit("ContactDefinition", "NavigateToTab", base.IsTakeScreenShotDuringEntryExit);
        }


        [Then(@"I should be displayed with ""(.*)"" details")]
        public void ValidateTheUserDetails(User.UserTypeEnum userType)
        {
            Logger.LogMethodEntry("ContactDefinition", "ValidateTheUserDetails", base.IsTakeScreenShotDuringEntryExit);
            Logger.LogAssertion("ValidateTheUserDetails", ScenarioContext.Current.ScenarioInfo.Title, () =>
                Assert.IsTrue(new ContactPage().ValidateUserDetailsinYourDetails(userType)));
            Logger.LogMethodExit("ContactDefinition", "ValidateTheUserDetails", base.IsTakeScreenShotDuringEntryExit);
        }

    }
}
