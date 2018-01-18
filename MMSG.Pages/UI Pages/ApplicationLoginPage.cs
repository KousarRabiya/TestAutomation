using MMSG.Automation;
using MMSG.Automation.DataTransferObjects;
using MMSG.Automation.Exceptions;
using OpenQA.Selenium;
using System;
using System.Configuration;
using System.Diagnostics;

namespace MMSG.Pages.UI_Pages
{
    public class ApplicationLoginPage : BasePage
    {

        /// <summary>
        /// The static instance of the logger for the class.
        /// </summary>
        private static readonly Logger Logger =
            Logger.GetInstance(typeof(ApplicationLoginPage));

        /// <summary>
        /// This is the login retry count.
        /// </summary>
        static readonly int LoginAttemptRetryCount = Convert.ToInt32(ConfigurationManager.
            AppSettings[ApplicationLoginPageResource.Login_Page_AppSetting_RetryCount_Key]);

        /// <summary>
        /// Get Wait Limit Time From Config.
        /// </summary>
        private readonly int _getWaitTimeOut = Convert.ToInt32(
            ConfigurationManager.AppSettings["ElementFindTimeOutInSeconds"]);

        /// <summary>
        /// Initialize base Pegasus login Url.
        /// </summary>
        string _baseLoginUrl = null;

        /// <summary>
        ///  Get Title of the Page.
        /// </summary>
        public new string GetPageTitle()
        {
            //Get Page Title
            { return base.GetPageTitle; }
        }

        /// <summary>
        /// Gets the base login Url from configuration.
        /// </summary>
        /// <param name="userTypeEnum">This is User by Type Enum.</param>
        public void BrowseApplicationUserURL(User.UserTypeEnum userTypeEnum)
        {
            Logger.LogMethodEntry("LoginPage", "BrowseApplicationUserURL",
                base.IsTakeScreenShotDuringEntryExit);
            try
            {
                switch (userTypeEnum)
                {
                    // Get URL of workspace admin
                    case User.UserTypeEnum.ROLUser:
                    case User.UserTypeEnum.COMETUser:
                        _baseLoginUrl = (AutomationConfigurationManager.GetCourseSpaceUrlRoot()).ToString();
                        base.DeleteAllBrowserCookies();
                        break;
                }
                this.GoToLoginUrl(_baseLoginUrl, userTypeEnum);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("Login", "BrowseApplicationUserURL", base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        ///  Navigates from base Url in browser through WebDriver.
        /// </summary>
        public void GoToLoginUrl(string baseLoginUrl,User.UserTypeEnum userTypeEnum)
        {
            Logger.LogMethodEntry("LoginPage", "GoToLoginUrl",
                base.IsTakeScreenShotDuringEntryExit);
            try
            {
                // Switch based on the user type
              switch(userTypeEnum)
                {
                    case User.UserTypeEnum.ROLUser:
                        GotoNavigationURl(baseLoginUrl);
                        break;
                    // Execute Comet URL
                    case User.UserTypeEnum.COMETUser:
                        GotoNavigationURlComet(baseLoginUrl);
                        break;
                }
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("LoginPage", "GoToLoginUrl",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Navigate to Comet URL
        /// </summary>
        /// <param name="baseLoginUrl">This is login URL</param>
        private void GotoNavigationURlComet(string baseLoginUrl)
        {
            try
            {
                //Get Url Successfully Browsed
                if (IsUrlBrowsedSuccessful())
                {
                    //Open Url in Browser
                    base.NavigateToBrowseUrl(baseLoginUrl);
                    base.SwitchToPopup();
                }
                else
                {
                    throw new Exception("Browser cannot display the webpage");
                }
            }
            catch(Exception e)
            {
                ExceptionHandler.HandleException(e);

            }
        }

        /// <summary>
        /// Navigate to URL
        /// </summary>
        /// <param name="baseLoginUrl">This is login URL.</param>
        private void GotoNavigationURl(string baseLoginUrl)
        {
            try
            {
                //Get Url Successfully Browsed
                if (IsUrlBrowsedSuccessful())
                {
                    //Open Url in Browser
                    base.NavigateToBrowseUrl(baseLoginUrl);
                    string title = base.GetPageTitle;
                    if (title == "Certificate Error: Navigation Blocked")
                    {
                        base.NavigateToBrowseUrl("javascript:document.getElementById('overridelink').click()");
                    }
                }
                else
                {
                    throw new Exception("Browser cannot display the webpage");
                }
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
        }

        /// <summary>
        /// Check thr Url Browsed Successfully.
        /// </summary>
        /// <returns>True if Url browsed successfully else false.</returns>
        /// <remarks>Slow web page loading or page not found then this 
        /// method open the Url in the address bar and wait till specified time
        ///  to page get successfully browse.</remarks>
        public Boolean IsUrlBrowsedSuccessful()
        {
            //Start Stop Watch
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            //Get Image Present On The Page
            String getCurrentPageTitle = base.GetPageTitle;
            if (getCurrentPageTitle.Equals(ApplicationLoginPageResource.LoginPage_NoConnect_Window_Title
                ) || getCurrentPageTitle.Equals
                (ApplicationLoginPageResource.Login_Page_404Error_Window_Title))
            {
                while (stopWatch.Elapsed.TotalSeconds < _getWaitTimeOut)
                {
                    //Navigate Base Url
                    base.NavigateToBrowseUrl(this._baseLoginUrl);
                    getCurrentPageTitle = base.GetPageTitle;
                    if (!getCurrentPageTitle.Equals(ApplicationLoginPageResource.
                        LoginPage_NoConnect_Window_Title) && !getCurrentPageTitle.Equals
                (ApplicationLoginPageResource.Login_Page_404Error_Window_Title))
                    {
                        stopWatch.Stop();
                        return true;
                    }
                }
                stopWatch.Stop();
                return false;
            }
            stopWatch.Stop();
            return true;
        }

        /// <summary>
        /// Login as user based on the user type
        /// </summary>
        /// <param name="userType">This is user type enum.</param>
        public void LoginAsUser(User.UserTypeEnum userType)
        {
            try
            {
                // Get the username and password based on the user type
                User user = User.Get(userType);
                string userName = user.Name.ToString();
                string password = user.Password.ToString();

                // Execute based on the user type
                switch (userType)
                {

                    case User.UserTypeEnum.ROLUser:
                        // Enter user name and password
                        this.ROLUserLogin(userName, password);
                        break;
                }

                UserName = user.Name;
                Password = user.Password;
                UserType = userType.ToString();
            }
            catch (Exception e)
            {
                LoginSpace = "";
                UserName = "";
                UserType = "";
                Password = "";
                ExceptionHandler.HandleException(e);
                throw;
            }

        }

        /// <summary>
        /// User login as ROL user 
        /// </summary>
        /// <param name="userName">This is the user name.</param>
        /// <param name="password">This is password.</param>
        public void ROLUserLogin(string userName, string password)
        {
            try
            {
                this.WaitandSelectROLWindow();

                // Enter username
                base.WaitForElement(By.Id(ApplicationLoginPageResource.ApplicationLoginPage_ROL_UserNameTextBox_Id_Locator));
                base.ClearTextById(ApplicationLoginPageResource.ApplicationLoginPage_ROL_UserNameTextBox_Id_Locator);
                base.FillTextBoxById(ApplicationLoginPageResource.ApplicationLoginPage_ROL_UserNameTextBox_Id_Locator, userName);

                // Enter Password
                base.WaitForElement(By.Id(ApplicationLoginPageResource.ApplicationLoginPage_ROL_PasswordTextBox_Id_Locator));
                base.ClearTextById(ApplicationLoginPageResource.ApplicationLoginPage_ROL_PasswordTextBox_Id_Locator);
                base.FillTextBoxById(ApplicationLoginPageResource.ApplicationLoginPage_ROL_PasswordTextBox_Id_Locator, password);

                // Click 
                base.WaitForElement(By.XPath(ApplicationLoginPageResource.ApplicationLoginPage_ROL_LoginButton_Click_XPath_Locator));
                base.ClickButtonByXPath(ApplicationLoginPageResource.ApplicationLoginPage_ROL_LoginButton_Click_XPath_Locator);

            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }

        }

        /// <summary>
        /// Get the home page title from the application.
        /// </summary>
        /// <returns>This will return the page title.</returns>
        public string GetUserHomePageName()
        {
            Logger.LogMethodEntry("ApplicationLoginPage", "GetUserHomePageName", base.IsTakeScreenShotDuringEntryExit);
            // Initialize the page name veriable to null
            string getPageName = null;

            try
            {
                //Wait untill the page loads
                base.WaitUntilWindowLoads(base.GetPageTitle);
                base.SelectWindow(base.GetPageTitle);
                // Get the page name
                getPageName = base.GetWindowTitleByJavaScriptExecutor();
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("ApplicationLoginPage", "GetUserHomePageName", base.IsTakeScreenShotDuringEntryExit);
            return getPageName;
        }

        /// <summary>
        /// Logout as user from application
        /// </summary>
        /// <param name="userType">This is user type enum.</param>
        public void LogoutAsUser(User.UserTypeEnum userType)
        {
            Logger.LogMethodEntry("ApplicationLoginPage", "ClickLogoutLink", base.IsTakeScreenShotDuringEntryExit);
            try
            {
                WaitandSelectROLWindow();

                //Wait for logout option t
                switch(userType)
                {
                    case User.UserTypeEnum.ROLUser:
                        //Wait untill window loads and select window
                        WaitandSelectROLWindow();

                        // Hover the mouse on the username option
                        base.WaitForElement(By.ClassName(ApplicationLoginPageResource.
                            ApplicationLoginPage_ROL_loginuser_ClassName_Locator));
                        IWebElement getUserNameOption = base.GetWebElementPropertiesByClassName("username");
                        base.PerformMouseHoverAction(getUserNameOption);

                        // Click on logout option link
                        base.WaitForElement(By.XPath((ApplicationLoginPageResource.
                            ApplicationLoginPage_ROL_Logout_XPath_Locator)));
                        IWebElement getLogoutLink = base.GetWebElementPropertiesByXPath(ApplicationLoginPageResource.
                            ApplicationLoginPage_ROL_Logout_XPath_Locator);
                        base.PerformMouseClickAction(getLogoutLink);
                        break;
                }
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("ApplicationLoginPage", "ClickLogoutLink", base.IsTakeScreenShotDuringEntryExit);
        }


        /// <summary>
        ///Wait untill window loads and select the window.
        /// </summary>
        protected void WaitandSelectROLWindow()
        {
            try
            {
                // Wait untill window loads
                base.WaitUntilWindowLoads(ApplicationLoginPageResource.ApplicationLoginPage_ROL_PageTitle_Title);
                // Select window
                base.SelectWindow(ApplicationLoginPageResource.ApplicationLoginPage_ROL_PageTitle_Title);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
        }
    }
}