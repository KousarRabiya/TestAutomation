using MMSG.Automation;
using MMSG.Automation.Exceptions;
using OpenQA.Selenium;
using System;

namespace MMSG.Pages.UI_Pages.ROL.Home.Dashboard
{
    public class DashboardPage : BasePage
    {
        /// <summary>
        /// The static instance of the logger for the class.
        /// </summary>
        private static readonly Logger Logger =
            Logger.GetInstance(typeof(DashboardPage));

        /// <summary>
        /// Navigate to tab
        /// </summary>
        /// <param name="tabName">This is tab name.</param>
        public void NavigateToTab(string tabName)
        {
            // Navigate to tab
            Logger.LogMethodEntry("DashboardPage", "NavigateToTab",base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Wait forwindowload and select the window
                WaitandSelectROLWindow();
                bool getTabExistance = base.IsElementPresent(By.LinkText(tabName), 10);
                int getItemCount = base.GetElementCountByLinkText(tabName);
                if (getItemCount == Convert.ToInt32(1) && getTabExistance == true)
                {
                    IWebElement getTab = base.GetWebElementPropertiesByLinkText(tabName);
                    base.PerformMouseClickAction(getTab);
                }
                else
                {
                    // Click the tab name based on tab name provided
                    ClickTabName(tabName);
                }
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("DashboardPage", "NavigateToTab", base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click tab name based on the title
        /// </summary>
        /// <param name="tabName">This is tab name.</param>
        private void ClickTabName(string tabName)
        {
            int getTabNameCount = Convert.ToInt32(0);
            try
            {
                // Get the total number of tabs
                getTabNameCount = base.GetElementCountByXPath(DashboardResource.
                    DashboardPage_GetTabCount_Xpath_Locator);

                for(int i = Convert.ToInt32(1); i<=getTabNameCount; i++)
                {
                    // Get tab name
                    string getTabName = base.GetElementInnerTextByXPath(string.Format(DashboardResource.
                        DashboardPage_GetTabName_Xpath_Locator, i));
                    if(getTabName.Equals(tabName))
                    {
                        // Click on the tab name based on the title comparision
                        IWebElement getTab = base.GetWebElementPropertiesByXPath(string.Format(DashboardResource.
                        DashboardPage_GetTabName_Xpath_Locator, i));
                        base.PerformMouseClickAction(getTab);
                        break;
                    }
                }
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }

        }


        /// <summary>
        ///Wait untill window loads and select the window.
        /// </summary>
        private void WaitandSelectROLWindow()
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
