using MMSG.Automation;
using MMSG.Automation.DataTransferObjects;
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
                string url = AutomationConfigurationManager.CourseSpaceUrlRoot;

                //Get Domain name from the URL
                string getDomain = url.Substring(7);
                int indexValue = getDomain.IndexOf('/');
                string getDomainString = getDomain.Substring(0, indexValue);
                base.WaitUntilWindowLoads(getDomainString);
                base.SelectWindow(getDomainString);

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

        /// <summary>
        /// Select benifit from dropdown
        /// </summary>
        /// <param name="benifitType">This is Benefit type.</param>
        public void SelectTheBenefitDropDown(Benefit.BenefitTypeEnum benifitType)
        {
            Logger.LogMethodEntry("Amendment_BenefitPage", "SelectTheBenefitDropDown",
              base.IsTakeScreenShotDuringEntryExit);
            try
            {
                // Get the benefit name from in memory
                Benefit benefit = Benefit.Get(benifitType);
                string benefitName = benefit.Benefit1.ToString();

                // Wait and select benefit type from dropdown
                base.WaitForElement(By.Id("ddlBenefits_0"));               
               base.SelectDropDownValueThroughTextById("ddlBenefits_0", benefitName);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }           
            Logger.LogMethodEntry("Amendment_BenefitPage", "SelectTheBenefitDropDown",
                 base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select effective date
        /// </summary>
        public void EffectiveDate()
        {
            Logger.LogMethodEntry("Amendment_BenefitPage", "SelectTheBenefitDropDown",
              base.IsTakeScreenShotDuringEntryExit);
            try
            {
                // geting the effective from the screen
                string getDateText = base.GetInnerTextAttributeValueByXPath(
                Employee_personaldetailsResource.EmployeepersonaldetailsPage__EffectiveDate_Xpath);
                string getDate = getDateText.Substring(17);
                string effectiveDateText = getDate.Replace(")", "").Trim();
                // waiting for the Element
                base.WaitForElement(By.Id(Amendment_BenefitResource.Amendment_BenefitPage_ActivationDateTextBox_ID_Locator));
                // clearing the text box 
                base.ClearTextById(Amendment_BenefitResource.Amendment_BenefitPage_ActivationDateTextBox_ID_Locator);
                // entering the Effective date in text box
                base.FillTextBoxById(Amendment_BenefitResource.Amendment_BenefitPage_ActivationDateTextBox_ID_Locator, effectiveDateText);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodEntry("Amendment_BenefitPage", "EffectiveDate",
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
                // waiting for the Next date drop 
                base.WaitForElement(By.Id(Amendment_BenefitResource.
                    Amendment_BenefitPage_NextPayDateDropDown_ID_Locator));
                base.SelectDropDownValueThroughIndexById(Amendment_BenefitResource.
                    Amendment_BenefitPage_NextPayDateDropDown_ID_Locator, 2);
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
        /// <param name="benefitType">This is benefit type enum.</param>
        public void BudgetCalculationMethod(Benefit.BenefitTypeEnum benefitType)
        {
            Logger.LogMethodEntry("Amendment_BenefitPage", "BudgetCalculationMethod",
             base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Get the BudgetCalculationMethod type from inmemory
                Benefit benefit = Benefit.Get(benefitType);
                string payDateType = benefit.BudgetCalculationMethod.ToString();
                base.WaitForElement(By.Id(Amendment_BenefitResource.
                    Amendment_BenefitPage_BudgetCalculationMenthodDropDown_ID_Locator));
                base.SelectDropDownValueThroughTextById(Amendment_BenefitResource.
                    Amendment_BenefitPage_BudgetCalculationMenthodDropDown_ID_Locator, payDateType);
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
        public void BudgetAmount(Benefit.BenefitTypeEnum benefitType)
        {
            Logger.LogMethodEntry("Amendment_BenefitPage", "BudgetAmount",
             base.IsTakeScreenShotDuringEntryExit);
            try
            {
                // Get the BudgetAmount from inmemory
                Benefit benefit = Benefit.Get(benefitType);
                string BudgetAmount = benefit.BudgetAmount.ToString();
                // Clear Budget Amount text box an fill the Budget Amount
                base.ClearTextById(Amendment_BenefitResource.
                    Amendment_BenefitPage_BudgetAmountTextBox_ID_Locator);
                base.FillTextBoxById(Amendment_BenefitResource.
                    Amendment_BenefitPage_BudgetAmountTextBox_ID_Locator, BudgetAmount);
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
                base.WaitForElement(By.Id(Amendment_BenefitResource.
                    Amendment_BenefitPage_SaveButton_ID_Locator));
                IWebElement saveButtonProperty = base.GetWebElementProperties(
                    By.Id(Amendment_BenefitResource.Amendment_BenefitPage_SaveButton_ID_Locator));
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
