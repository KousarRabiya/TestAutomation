using Microsoft.VisualStudio.TestTools.UnitTesting;
using MMSG.Automation;
using MMSG.Automation.DataTransferObjects;
using MMSG.Pages.UI_Pages.Comet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace MMSG.Acceptance.Comet.Tests.ProductAcceptanceTestDefinition
{
    [Binding]
    public sealed class CallCentreEnquiryDefinition : BaseTestFixture
    {
        /// <summary>
        /// The static instance of the logger for the class.
        /// </summary>
        private static readonly Logger Logger =
        Logger.GetInstance(typeof(CallCentreEnquiryDefinition));


        /// <summary>
        /// Search the user based on the user information search criteria
        /// </summary>
        /// <param name="userType">This is user type enum.</param>
        [When(@"I enter ""(.*)"" of ""(.*)"" in the search textbox from ""(.*)""")]
        public void SearchUserDetails(string optionName, User.UserTypeEnum userType, string dataFetchType)
        {
            Logger.LogMethodEntry("CallCentreEnquiryDefinition", "SearchUserDetails", base.IsTakeScreenShotDuringEntryExit);
            new CallCentreEnquiryPage().UserSearch(optionName, userType, dataFetchType);
            Logger.LogMethodExit("CallCentreEnquiryDefinition", "SearchUserDetails", base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click on search button.
        /// </summary>
        [When(@"I click on Search button")]
        public void ClickSearchButton()
        {
            //Click search button
            Logger.LogMethodEntry("CallCentreEnquiryDefinition", "ClickSearchButton", base.IsTakeScreenShotDuringEntryExit);
            new CallCentreEnquiryPage().ClickSearchButton();
            Logger.LogMethodExit("CallCentreEnquiryDefinition", "ClickSearchButton", base.IsTakeScreenShotDuringEntryExit);
        }


        /// <summary>
        /// Validate the display of searched employee.
        /// </summary>
        /// <param name="userType">This is user type enum.</param>
        [Then(@"I should be displayed with employee information of ""(.*)""")]
        public void ValidateDisplayOfEmployeeInformationOf(User.UserTypeEnum userType)
        {
            Logger.LogMethodEntry("CallCentreEnquiryDefinition", "ValidateDisplayOfEmployeeInformationOf",
                base.IsTakeScreenShotDuringEntryExit);
            Logger.LogAssertion("ValidateTheUserDetails", ScenarioContext.Current.ScenarioInfo.Title, () =>
            Assert.IsTrue(new CallCentreEnquiryPage().GetEmployeeDetailsDisplayStatus(userType)));
            Logger.LogMethodEntry("CallCentreEnquiryDefinition", "ValidateDisplayOfEmployeeInformationOf",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Validate page Landed 
        /// </summary>
        /// <param name="pageName">Page Name</param>
        [Then(@"I should be on the ""(.*)"" page")]
        public void ValidatePageName(string pageName)
        {
            Logger.LogMethodEntry("CallCentreEnquiryDefinition", "ValidatePageName", base.IsTakeScreenShotDuringEntryExit);
            string url = AutomationConfigurationManager.CourseSpaceUrlRoot;

            //Get Domain name from the URL
            string getDomain = url.Substring(7);
            int indexValue = getDomain.IndexOf('/');
            string getDomainString = getDomain.Substring(0, indexValue);
            string expectedPageTitle = getDomainString + " " + pageName;

            Logger.LogAssertion("ValidateTheUserDetails", ScenarioContext.Current.ScenarioInfo.Title, () =>
            Assert.AreEqual(expectedPageTitle, new Employee_personaldetailsPage().GetCommetNewEmoplyeePageTitle()));
            Logger.LogMethodExit("CallCentreEnquiryDefinition", "ValidatePageName", base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click on the option
        /// </summary>
        /// <param name="optionName">Option Name</param>
        /// <param name="pageName">Page Name</param>
        [When(@"I click on ""(.*)"" in ""(.*)"" page")]
        public void ClickOption(string optionName, string pageName)
        {
            Logger.LogMethodEntry("CallCentreEnquiryDefinition", "ClickOption", base.IsTakeScreenShotDuringEntryExit);
            string url = AutomationConfigurationManager.CourseSpaceUrlRoot;

            //Get Domain name from the URL
            string getDomain = url.Substring(7);
            int indexValue = getDomain.IndexOf('/');
            string getDomainString = getDomain.Substring(0, indexValue);
            string PageTitle = getDomainString + " " + pageName;

            new CallCentreEnquiryPage().ClickOptionOnCCEnquiryPage(optionName, PageTitle);

            Logger.LogMethodExit("CallCentreEnquiryDefinition", "ClickOption", base.IsTakeScreenShotDuringEntryExit);
        }


        /// <summary>
        /// Verify the Package is  created successfully
        /// </summary>
        /// <param name="packageTypeEnum">This is package type enum.</param>
        [Then(@"I should be displayed with ""(.*)"" for ""(.*)""")]
        public void ValidateDisplayOfPackage(Package.PackageTypeEnum packageTypeEnum, User.UserTypeEnum userType)
        {
            Logger.LogMethodEntry("CallCentreEnquiryDefinition", "ValidateDisplayOfPackage", base.IsTakeScreenShotDuringEntryExit);
            Logger.LogAssertion("ValidateTheUserDetails", ScenarioContext.Current.ScenarioInfo.Title, () =>
           Assert.IsTrue(new CallCentreEnquiryPage().VeriFyPackageName(packageTypeEnum, userType)));
            Logger.LogMethodExit("CallCentreEnquiryDefinition", "ValidateDisplayOfPackage", base.IsTakeScreenShotDuringEntryExit);

        }

        /// <summary>
        /// Enter the Employee nuber and search
        /// </summary>
        /// <param name="employeeNo"> Employee numner is been send</param>
        [When(@"I enter Employee number as ""(.*)"" and search in Call centre Enquiry")]
        public void EnterIngTheEmployeeValueAndSearchtheEmployee(string employeeNo)
        {
            Logger.LogMethodEntry("CallCentreEnquiryDefinition", "EnterIngTheEmployeeValueAndSearchtheEmployee", base.IsTakeScreenShotDuringEntryExit);
            new CallCentreEnquiryPage().EnterTheEmployeeNumberAndSearch(employeeNo);
            Logger.LogMethodExit("CallCentreEnquiryDefinition", "EnterIngTheEmployeeValueAndSearchtheEmployee", base.IsTakeScreenShotDuringEntryExit);
        }


    }
}