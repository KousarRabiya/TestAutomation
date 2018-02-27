using MMSG.Automation;
using MMSG.Automation.Exceptions;
using OpenQA.Selenium;
using System;

namespace MMSG.Pages.UI_Pages.Comet.Process_Menu
{
    public class AddBenefitPage : BasePage
    {
        /// <summary>
        /// The static instance of the logger for the class.
        /// </summary>
        private static readonly Logger Logger =
            Logger.GetInstance(typeof(AddBenefitPage));

        /// <summary>
        /// Get Page Header
        /// </summary>
        public string GetPageHeader()
        {
            Logger.LogMethodEntry("AddBenefitPage", "GetPageHeader", base.IsTakeScreenShotDuringEntryExit);
            string pageHeader = "";
            try
            {
                base.SwitchToPopup();
                pageHeader = base.GetPageTitle;
                return pageHeader;
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("AddBenefitPage", "GetPageHeader", base.IsTakeScreenShotDuringEntryExit);
            return pageHeader;
        }

        /// <summary>
        /// Select the drop down
        /// </summary>
        /// <param name="dropDownOption"></param>
        /// <param name="dropDownName"></param>
        public void SelectDropDown(string dropDownOption, string dropDownName)
        {
            Logger.LogMethodEntry("AddBenefitPage", "SelectDropDown", base.IsTakeScreenShotDuringEntryExit);
            try
            {
                switch (dropDownName)
                {
                    case "Benefit":
                        base.WaitForElement(By.Id(AddBenefitResource.AddBenefitPage_BenefitName_Id_Locator));
                        base.SelectDropDownValueThroughTextById(AddBenefitResource.AddBenefitPage_BenefitName_Id_Locator, dropDownOption);
                        break;
                    case "Budget Calculation Method":
                        base.WaitForElement(By.Id(AddBenefitResource.AddBenefitPage_BudgetCalculation_Id_Locator));
                        base.SelectDropDownValueThroughTextById(AddBenefitResource.AddBenefitPage_BudgetCalculation_Id_Locator, dropDownOption);
                        break;
                    default:
                        break;
                }
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodEntry("AddBenefitPage", "SelectDropDown", base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click on Save or Next button
        /// </summary>
        /// <param name="buttonName"></param>        
        public void ClickOnButton(string buttonName)
        {
            Logger.LogMethodEntry("AddBenefitPage", "ClickOnButton", base.IsTakeScreenShotDuringEntryExit);
            try
            {
                switch (buttonName)
                {
                    case "Next":
                        IWebElement nextButtonProperty = base.GetWebElementProperties(By.Id(AddBenefitResource.AddBenefitPage_NextButton_Id_Locator));
                        base.ClickByJavaScriptExecutor(nextButtonProperty);
                        break;

                    case "Save":
                        IWebElement saveButtonProperty = base.GetWebElementProperties(By.Id(AddBenefitResource.AddBenefitPage_SaveButton_Id_Locator));
                        base.ClickByJavaScriptExecutor(saveButtonProperty);
                        break;

                    default:
                        break;
                }

            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodEntry("AddBenefitPage", "ClickOnButton", base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Enter Budget Amount
        /// </summary>
        public void BudgetAmount()
        {
            Logger.LogMethodEntry("AddBenefitPage", "BudgetAmount", base.IsTakeScreenShotDuringEntryExit);
            try
            {
                base.ClearTextById(AddBenefitResource.AddBenefitPage_BudgetAmount_Id_Locator);
                base.FillTextBoxById(AddBenefitResource.AddBenefitPage_BudgetAmount_Id_Locator, "10.00");
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodEntry("AddBenefitPage", "BudgetAmount", base.IsTakeScreenShotDuringEntryExit);
        }
    }
}
