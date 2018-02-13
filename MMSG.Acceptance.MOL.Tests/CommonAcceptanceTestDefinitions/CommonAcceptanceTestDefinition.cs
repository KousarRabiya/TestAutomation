using Microsoft.VisualStudio.TestTools.UnitTesting;
using MMSG.Automation;
using MMSG.Automation.DataTransferObjects;
using MMSG.Pages.UI_Pages;
using System;
using TechTalk.SpecFlow;

namespace MMSG.Acceptance.MOL.Tests.CommonAcceptanceTestDefinitions
{
    [Binding]
    public class CommonAcceptanceTestDefinitions : BasePage
    {
        /// <summary>
        /// The static instance of the logger for the class.
        /// </summary>
        private static readonly Logger Logger =
        Logger.GetInstance(typeof(CommonAcceptanceTestDefinitions));


        /// <summary>
        /// Access the login pagebased on the application URL
        /// </summary>
        /// <param name="applicationURL">This is application under test URL </param>
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
        /// Login as user based on the user type
        /// </summary>
        /// <param name="userType">This is user type enum.</param>

        [When(@"I login as user ""(.*)""")]
        public void LoginAsUser(User.UserTypeEnum userType)
        {
            Logger.LogMethodEntry("CommonAcceptanceTestDefinitions", "LoginAsUser", base.IsTakeScreenShotDuringEntryExit);
            ApplicationLoginPage loginPage = new ApplicationLoginPage();
            loginPage.LoginAsUser(userType);
            Logger.LogMethodExit("CommonAcceptanceTestDefinitions", "LoginAsUser", base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Validate the page name as user
        /// </summary>
        /// <param name="pageTitle"></param>
        [Then(@"I should be on ""(.*)"" page")]
        public void ValidatePageName(string pageTitle)
        {
            Logger.LogMethodEntry("CommonAcceptanceTestDefinitions", "ValidatePageName", base.IsTakeScreenShotDuringEntryExit);
            // Assert the expected value with the actual value
            Logger.LogAssertion("ValidatePageName", ScenarioContext.Current.ScenarioInfo.Title, () =>
            Assert.AreEqual(pageTitle, new ApplicationLoginPage().GetUserHomePageName()));
            Logger.LogMethodExit("CommonAcceptanceTestDefinitions", "ValidatePageName", base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Logout as user
        /// </summary>
        /// <param name="userType">This is user type enum.</param>
        [When(@"I click on Logout link as ""(.*)""")]
        public void LogoutAsUser(User.UserTypeEnum userType)
        {
            Logger.LogMethodEntry("CommonAcceptanceTestDefinitions", "LogoutAsUser", base.IsTakeScreenShotDuringEntryExit);
            ApplicationLoginPage loginPage = new ApplicationLoginPage();
            loginPage.LogoutAsUser(userType);
            Logger.LogMethodExit("CommonAcceptanceTestDefinitions", "LogoutAsUser", base.IsTakeScreenShotDuringEntryExit);
        }

        
    }
}
