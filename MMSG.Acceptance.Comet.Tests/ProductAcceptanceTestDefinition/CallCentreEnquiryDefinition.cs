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
        [When(@"I enter ""(.*)"" of ""(.*)"" in the search textbox")]
        public void SearchUserDetails(string optionName, User.UserTypeEnum userType)
        {
            Logger.LogMethodEntry("CallCentreEnquiryDefinition", "SearchUserDetails",base.IsTakeScreenShotDuringEntryExit);
            new CallCentreEnquiryPage().UserSearch(optionName,userType);
            Logger.LogMethodExit("CallCentreEnquiryDefinition", "SearchUserDetails", base.IsTakeScreenShotDuringEntryExit);
        }


    }
}
