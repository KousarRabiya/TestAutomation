using MMSG.Automation;
using MMSG.Automation.Exceptions;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMSG.Pages.UI_Pages.Comet
{
   public class Amendment_BenefitPage : BasePage
    {
        /// <summary>
        /// The static instance of the logger for the class.
        /// </summary>
        private static readonly Logger Logger =
            Logger.GetInstance(typeof(Employee_personaldetailsPage));

        /// <summary>
        /// Verify the apge landedOn the Amendment Benefit page
        /// </summary>
        /// <returns></returns>
        public bool VerifyPageLandedOnAmendmentBenefitPage(string pageName)
        {
            Logger.LogMethodEntry("Amendment_BenefitPage", "VerifyPageLandedOnAmendmentBenefitPage",
               base.IsTakeScreenShotDuringEntryExit);
            bool statusofPage = false;
            try
            {
                //geting the page name and compereing 
                base.WaitForElement(By.Id("lblPageTitle"));
                string AmendmentPageBenefitPage = base.GetInnerTextAttributeValueById("lblPageTitle");
                if (AmendmentPageBenefitPage== "Amendments - New Benefits")
                {
                    return true;
                }
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodEntry("Amendment_BenefitPage", "VerifyPageLandedOnAmendmentBenefitPage",
                  base.IsTakeScreenShotDuringEntryExit);
            return statusofPage;
        }
        public void SelectTheBenefitDropDown(string benefitName)
        {
            Logger.LogMethodEntry("Amendment_BenefitPage", "SelectTheBenefitDropDown",
              base.IsTakeScreenShotDuringEntryExit);
            try
            {
                base.WaitForElement(By.Id("ddlBenefits_0"));               
               base.SelectDropDownValueThroughTextById("ddlBenefits_0", benefitName);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }           
            Logger.LogMethodEntry("Amendment_BenefitPage", "VerifyPageLandedOnAmendmentBenefitPage",
                 base.IsTakeScreenShotDuringEntryExit);
        }
        public void EffectiveDate()
        {
            Logger.LogMethodEntry("Amendment_BenefitPage", "SelectTheBenefitDropDown",
              base.IsTakeScreenShotDuringEntryExit);
            try
            {
                string getDateText = base.GetInnerTextAttributeValueByXPath(Employee_personaldetailsResource.EmployeepersonaldetailsPage_Title_EffectiveDate_Xpath);
                string getDate = getDateText.Substring(17);
                string effectiveDateText = getDate.Replace(")", "").Trim();
                base.WaitForElement(By.Id("txtActivationDate_0"));
                base.ClearTextById("txtActivationDate_0");
                base.FillTextBoxById("txtActivationDate_0", effectiveDateText);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodEntry("Amendment_BenefitPage", "VerifyPageLandedOnAmendmentBenefitPage",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Selecting the next Pay in the drop down
        /// </summary>
        public void NextPayDate()
        {
            Logger.LogMethodEntry("Amendment_BenefitPage", "NextPayDate",
             base.IsTakeScreenShotDuringEntryExit);
            try
            {
                base.WaitForElement(By.Id(Amendment_BenefitResource.Amendment_BenefitPage_NextPayDateDropDown_ID_Locator));
                base.SelectDropDownValueThroughIndexById(Amendment_BenefitResource.Amendment_BenefitPage_NextPayDateDropDown_ID_Locator, 2);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodEntry("Amendment_BenefitPage", "NextPayDate",
                 base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Selecting the Budget caluction menthod 
        /// </summary>
        /// <param name="payDateType"></param>

        public void BudgetCalculationMethod(string payDateType)
        {
            Logger.LogMethodEntry("Amendment_BenefitPage", "BudgetCalculationMethod",
             base.IsTakeScreenShotDuringEntryExit);
            try
            {
                base.WaitForElement(By.Id(Amendment_BenefitResource.Amendment_BenefitPage_BudgetCalculationMenthodDropDown_ID_Locator));
                base.SelectDropDownValueThroughTextById(Amendment_BenefitResource.Amendment_BenefitPage_BudgetCalculationMenthodDropDown_ID_Locator, payDateType);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodEntry("Amendment_BenefitPage", "BudgetCalculationMethod",
                 base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Entering the budget amount in the text box
        /// </summary>
        /// <param name="BudgetAmount">Budget Amount</param>

        public void BudgetAmount(string BudgetAmount)
        {
            Logger.LogMethodEntry("Amendment_BenefitPage", "BudgetAmount",
             base.IsTakeScreenShotDuringEntryExit);
            try
            {
                base.ClearTextById(Amendment_BenefitResource.Amendment_BenefitPage_BudgetAmountTextBox_ID_Locator);
                base.FillTextBoxById(Amendment_BenefitResource.Amendment_BenefitPage_BudgetAmountTextBox_ID_Locator, BudgetAmount);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodEntry("Amendment_BenefitPage", "BudgetAmount",
                 base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Clicking on the Save Button 
        /// </summary>

        public void ClickOnSaveButton()
        {
            Logger.LogMethodEntry("Amendment_BenefitPage", "ClickOnSaveButton",
             base.IsTakeScreenShotDuringEntryExit);
            try
            {
                base.WaitForElement(By.Id(Amendment_BenefitResource.Amendment_BenefitPage_SaveButton_ID_Locator));
                IWebElement saveButtonProperty = base.GetWebElementProperties(By.Id(Amendment_BenefitResource.Amendment_BenefitPage_SaveButton_ID_Locator));
                base.ClickByJavaScriptExecutor(saveButtonProperty);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodEntry("Amendment_BenefitPage", "ClickOnSaveButton",
                 base.IsTakeScreenShotDuringEntryExit);
        }
    }
}
