using Microsoft.VisualStudio.TestTools.UnitTesting;
using MMSG.Automation;
using MMSG.Automation.DataTransferObjects;
using MMSG.Pages.UI_Pages.Comet;
using TechTalk.SpecFlow;

namespace MMSG.Acceptance.Comet.Tests.ProductAcceptanceTestDefinition
{
    [Binding]
    public sealed class Employee_personaldetailsDefinition : BasePage
    {
        /// <summary>
        /// The static instance of the logger for the class.
        /// </summary>
        private static readonly Logger Logger =
        Logger.GetInstance(typeof(Employee_personaldetailsDefinition));

        /// <summary>
        /// Validate the display of page name.
        /// </summary>
        /// <param name="pageName">This is Page name.</param>
        [Then(@"I should be on ""(.*)"" page")]
        public void ValidatePageName(string pageName)
        {
            Logger.LogMethodEntry("Employee_personaldetailsDefinition", "ValidatePageName",
                base.IsTakeScreenShotDuringEntryExit);
            string url = AutomationConfigurationManager.CourseSpaceUrlRoot;

            //Get Domain name from the URL
            string getDomain = url.Substring(7);
            int indexValue = getDomain.IndexOf('/');
            string getDomainString = getDomain.Substring(0, indexValue);
            string expectedPageTitle = getDomainString + " " + pageName;

            Logger.LogAssertion("ValidateTheUserDetails", ScenarioContext.Current.ScenarioInfo.Title, () =>
            Assert.AreEqual(expectedPageTitle, new Employee_personaldetailsPage().GetCommetNewEmoplyeePageTitle()));
            Logger.LogMethodExit("Employee_personaldetailsDefinition", "ValidatePageName",
                base.IsTakeScreenShotDuringEntryExit);
        }


        /// <summary>
        /// Validate popup name.
        /// </summary>
        /// <param name="expectedPopupTitle">This is popup name.</param>
        [Then(@"I should be on ""(.*)"" popup")]
        public void ValidatePopupName(string expectedPopupTitle)
        {
            Logger.LogAssertion("ValidateTheUserDetails", ScenarioContext.Current.ScenarioInfo.Title, () =>
                Assert.AreEqual(expectedPopupTitle, new Employee_personaldetailsPage().GetpopupTitle()));
            Logger.LogMethodExit("Employee_personaldetailsDefinition", "ValidatePageName",
                base.IsTakeScreenShotDuringEntryExit);
        }


        /// <summary>
        /// Enter new user details
        /// </summary>
        /// <param name="userType">This is user type enum.</param>
        [When(@"I enter new ""(.*)"" employee details")]
        public void EnterNewEmployeeDetails(User.UserTypeEnum userType)
        {
            Logger.LogMethodEntry("Employee_personaldetailsDefinition", "EnterNewEmployeeDetails",
                base.IsTakeScreenShotDuringEntryExit);
            new Employee_personaldetailsPage().FillEmployeeDetails(userType);
            Logger.LogMethodExit("Employee_personaldetailsDefinition", "EnterNewEmployeeDetails",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click on close buton
        /// </summary>
        /// <param name="buttonName">This is button name.</param>
        [When(@"I click on ""(.*)"" button in ""(.*)"" popup")]
        public void ClickOnButtonByName(string buttonName, string popupName)
        {
            Logger.LogMethodEntry("Employee_personaldetailsDefinition", "ClickOnButtonByName",
                base.IsTakeScreenShotDuringEntryExit);
            new Employee_personaldetailsPage().ClickOnButtonInPopup(buttonName, popupName);

            Logger.LogMethodExit("Employee_personaldetailsDefinition", "ClickOnButtonByName",
                base.IsTakeScreenShotDuringEntryExit);
        }

    }
}