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

        [When(@"I select ""(.*)"" in the dropdown ""(.*)""")]
        public void SelelctingTheDropDownInContactPage(string dropDownOption, string dropDownName)
        {
            Logger.LogMethodEntry("ContactDefinition", "SelelctingTheDropDownInContactPage", base.IsTakeScreenShotDuringEntryExit);
            new ContactPage().ClickOnDropDown(dropDownOption, dropDownName);
            Logger.LogMethodExit("ContactDefinition", "SelelctingTheDropDownInContactPage", base.IsTakeScreenShotDuringEntryExit);
        }

        [Then(@"I should be display ""(.*)"" dropdown")]
        public void VerifyDropDownAppeared(string DropDownName)
        {
            Logger.LogMethodEntry("ContactDefinition", "VerifyDropDownAppeared", base.IsTakeScreenShotDuringEntryExit);
            Logger.LogAssertion("ValidateTheUserDetails", ScenarioContext.Current.ScenarioInfo.Title, () =>
                 Assert.IsTrue(new ContactPage().ValidateDropDownIsPresent(DropDownName)));
            Logger.LogMethodExit("ContactDefinition", "VerifyDropDownAppeared", base.IsTakeScreenShotDuringEntryExit);
        }       

        [When(@"I Enter the ""(.*)""")]
        public void EnterTheValeInTextBox(string textBoxName)
        {
            Logger.LogMethodEntry("ContactDefinition", "EnterTheValeInTextBox", base.IsTakeScreenShotDuringEntryExit);
            new ContactPage().EnterValueToTextBox(textBoxName);
            Logger.LogMethodExit("ContactDefinition", "EnterTheValeInTextBox", base.IsTakeScreenShotDuringEntryExit);
        }       

        [When(@"I select the Radio Button ""(.*)""")]
        public void SelelctingTheRadioButton(string radioButtonName)
        {
            Logger.LogMethodEntry("ContactDefinition", "SelelctingTheRadioButton", base.IsTakeScreenShotDuringEntryExit);
            new ContactPage().SelectRadioButton(radioButtonName);
            Logger.LogMethodExit("ContactDefinition", "SelelctingTheRadioButton", base.IsTakeScreenShotDuringEntryExit);
        }

        [When(@"I click on ""(.*)"" Button")]
        public void ClickingOnButton(string buttonName)
        {
            Logger.LogMethodEntry("ContactDefinition", "ClickingOnButton", base.IsTakeScreenShotDuringEntryExit);
            new ContactPage().ClickOnButton(buttonName);
            Logger.LogMethodExit("ContactDefinition", "ClickingOnButton", base.IsTakeScreenShotDuringEntryExit);
        }

        [Then(@"I should be displayed with ""(.*)"" message")]
        public void VerifyTheMessage(string message)
        {
            Logger.LogMethodEntry("ContactDefinition", "VerifyTheMessage", base.IsTakeScreenShotDuringEntryExit);
            Logger.LogAssertion("ValidateTheUserDetails", ScenarioContext.Current.ScenarioInfo.Title, () =>
                 Assert.IsTrue(new ContactPage().VerifyTheMessage(message)));
            Logger.LogMethodExit("ContactDefinition", "VerifyTheMessage", base.IsTakeScreenShotDuringEntryExit);
        }

    }
}
