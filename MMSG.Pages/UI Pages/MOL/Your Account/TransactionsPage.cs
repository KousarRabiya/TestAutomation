using MMSG.Automation;
using MMSG.Automation.DataTransferObjects;
using MMSG.Automation.Exceptions;
using OpenQA.Selenium;
using System;

namespace MMSG.Pages.UI_Pages.MOL.Your_Account
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
        public bool ValidateDropDownIsPresent(string dropDownName)
        {
            Logger.LogMethodEntry("TransactionsPage", "ValidateDropDownIsPresent", base.IsTakeScreenShotDuringEntryExit);
            try
            {
                switch (dropDownName)
                {
                    case "Select benefit:":
                        return IsElementPresent(By.XPath(TransactionResource.TransactionsPage_SelectBenefitLabel_Xpath_Locator));
                    case "From:":
                        return IsElementPresent(By.XPath(TransactionResource.TransactionsPage_FromLabel_Xpath_Locator));
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

        /// <summary>
        /// Click on the dropdown  button present on the Transaction page 
        /// </summary>
        /// <param name="dropDownOption"></param>
        /// <param name="dropDownName"></param>
        public void ClickOnDropDown(string dropDownOption, string dropDownName)
        {
            Logger.LogMethodEntry("TransactionPage", "ClickOnDropDown", base.IsTakeScreenShotDuringEntryExit);
            try
            {
                switch (dropDownName)
                {
                    case "Select benefit:":
                        base.ClickButtonByXPath(TransactionResource.TransactionPage_SelectBenefitButton_Xpath_Locator);
                        SelectTheDropDown(dropDownOption);
                        break;

                    case "From:":
                        base.ClickButtonByXPath(TransactionResource.TransactionPage_FromButton_Xpath_Locator);
                        SelectTheDropDown(dropDownOption);
                        break;
                }
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
        }

        /// <summary>
        /// Select the drop down option in the dropdown button 
        /// </summary>
        /// <param name="dropDownOption"></param>
        public void SelectTheDropDown(string dropDownOption)
        {
            Logger.LogMethodEntry("TransactionPage", "SelectTheDropDown", base.IsTakeScreenShotDuringEntryExit);
            base.ClickLinkByPartialLinkText(dropDownOption);
        }
    }
}
