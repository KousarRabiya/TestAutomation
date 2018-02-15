using MMSG.Automation;
using MMSG.Automation.DataTransferObjects;
using MMSG.Automation.Exceptions;
using OpenQA.Selenium;
using System;

namespace MMSG.Pages.UI_Pages.ROL.Your_Account
{
    public class TransactionsPage : BasePage
    {
        /// <summary>
        /// The static instance of the logger for the class.
        /// </summary>
        private static readonly Logger Logger =
            Logger.GetInstance(typeof(TransactionsPage));

        /// <summary>
        /// Verify that the dropdown and values are present 
        /// </summary>
        /// <param name="dropDownName"></param>
        /// <returns>Returns true if the element present</returns>
        public bool ValidateDropDownAndValue(string dropDownName,string dropDownValue)
        {
            Logger.LogMethodEntry("TransactionsPage", "ValidateDropDownAndValue", base.IsTakeScreenShotDuringEntryExit);
            try
            {
                switch (dropDownName)
                {
                    case "View Account:":
                        return IsElementPresent(By.XPath(TransactionResource.TransactionsPage_ViewAccountLabel_Xpath_Locator))
                            && IsElementPresent(By.XPath(TransactionResource.TransactionsPage_ViewAccountDropDown_Xpath_Locator));
                    case "From:":
                        return IsElementPresent(By.XPath(TransactionResource.TransactionsPage_FromLabel_Xpath_Locator))
                            && IsElementPresent(By.XPath(TransactionResource.TransactionsPage_FromDropDown_Xpath_Locator));
                }
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            return false;
        }

        /// <summary>
        /// Method to verify available balance is not zero
        /// </summary>
        /// <returns></returns>
        public bool ValidateAvailableBalance()
        {
            Logger.LogMethodEntry("TransactionsPage", "ValidateAvailableBalance", base.IsTakeScreenShotDuringEntryExit);
            try
            {
                string valueOnWebPage = base.GetElementInnerTextByXPath(TransactionResource.TransactionsPage_AvailableBalanceValue_Xpath_Locator);
                if (valueOnWebPage != "$0.00")
                {
                    return true;
                }
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            return false;
        }
    }
}
