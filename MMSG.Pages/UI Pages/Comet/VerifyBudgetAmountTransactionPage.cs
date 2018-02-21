using MMSG.Automation;
using MMSG.Automation.Database_Support.DBDataTransferObjects;
using MMSG.Automation.DataTransferObjects;
using MMSG.Automation.Exceptions;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MMSG.Pages.UI_Pages.Comet
{
   public class VerifyBudgetAmountTransactionPage : BasePage
    {
        /// <summary>
        /// The static instance of the logger for the class.
        /// </summary>
        private static readonly Logger Logger =
            Logger.GetInstance(typeof(VerifyBudgetAmountTransactionPage));

        /// <summary>
        /// Click Employee Number
        /// </summary>
        public void ClickEmployeeNumber()
        {
            try
            {              
                IWebElement getEmployeeNum = base.GetWebElementPropertiesByXPath(VerifyBudgetAmountTransactionResource.VerifyBudgetAmountTransactionPage_EmployeeNum_XPath_Locator);
                base.PerformMouseClickAction(getEmployeeNum);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
        }

        /// <summary>
        /// Switch and Get the Page Title
        /// </summary>
        /// <returns></returns>
        public string SwitchAndGetPageTitle(string pageTitle)
        {
            Logger.LogMethodEntry("VerifyBudgetAmountTransactionPage", "GetPageTitle",
                base.IsTakeScreenShotDuringEntryExit);
            string popupTitle = null;
            try
            {
                base.SwitchToDefaultWindow();
                base.SwitchToLastOpenedWindow();
                popupTitle = base.GetPageTitle;
                base.WaitUntilPopUpLoads(pageTitle);               
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodEntry("VerifyBudgetAmountTransactionPage", "GetPageTitle",
                base.IsTakeScreenShotDuringEntryExit);
            return popupTitle;
        }

        /// <summary>
        /// Select EAMS
        /// </summary>
        public void SelectEAMS()
        {
            try
            {
                IWebElement getEAMSOption = base.GetWebElementPropertiesById(VerifyBudgetAmountTransactionResource.VerifyBudgetAmountTransactionPage_EAMS_Id_Locator);
                base.PerformMouseClickAction(getEAMSOption);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
        }

        /// <summary>
        /// Save MOL User Name
        /// </summary>
        public void SaveMOLUserName()
        {
            try
            {
                IWebElement getMOLUserName = base.GetWebElementPropertiesById(VerifyBudgetAmountTransactionResource.VerifyBudgetAmountTransactionPage_MOLUserName_XPath_Locator);

            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
        }
    }
}
