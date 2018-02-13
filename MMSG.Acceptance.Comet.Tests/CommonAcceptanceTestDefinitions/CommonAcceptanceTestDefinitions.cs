﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using MMSG.Automation;
using MMSG.Automation.DataTransferObjects;
using MMSG.Pages.UI_Pages;
using MMSG.Pages.UI_Pages.Comet;
using TechTalk.SpecFlow;

namespace MMSG.Acceptance.Comet.Tests.CommonAcceptanceTestDefinitions
{
    [Binding]
    public sealed class CommonAcceptanceTestDefinitions :BasePage
    {
        // For additional details on SpecFlow step definitions see http://go.specflow.org/doc-stepdef
        /// <summary>
        /// The static instance of the logger for the class.
        /// </summary>
        private static readonly Logger Logger =
        Logger.GetInstance(typeof(CommonAcceptanceTestDefinitions));


        /// <summary>
        /// Launch application URL
        /// </summary>
        /// <param name="userType">This is user type enum.</param>
        [Given(@"I access application URL as ""(.*)""")]
        public void LaunchApplicationURL(User.UserTypeEnum userType)
        {
            Logger.LogMethodEntry("CommonDefinition", "LaunchApplicationURL", base.IsTakeScreenShotDuringEntryExit);
            ApplicationLoginPage loginPage = new ApplicationLoginPage();
            loginPage.BrowseApplicationUserURL(userType);
            CurrentBrowserName = WebDriverSingleton.GetInstance().Browser;
            Logger.LogMethodExit("CommonDefinition", "LaunchApplicationURL", base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Validate the display of Comet logo
        /// </summary>
        [Then(@"I should be displayed with Comet logo")]
        public void ValidateDisplayCometLogo()
        {
            // Validate the logo existance status
            Logger.LogMethodEntry("CommonDefinition", "ValidateDisplayCometLogo", base.IsTakeScreenShotDuringEntryExit);
            Logger.LogAssertion("ValidateTheUserDetails", ScenarioContext.Current.ScenarioInfo.Title, () =>
            Assert.IsTrue(new CallCentreEnquiryPage().GetApplicationLogoExistance()));
            Logger.LogMethodExit("CommonDefinition", "ValidateDisplayCometLogo", base.IsTakeScreenShotDuringEntryExit);
        }

    }
}