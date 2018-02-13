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

        public void NextPayDate(string payDate)
        {
            Logger.LogMethodEntry("Amendment_BenefitPage", "NextPayDate",
             base.IsTakeScreenShotDuringEntryExit);
            try
            {
                base.WaitForElement(By.Id("ddlBenefits_0"));
                base.SelectDropDownValueThroughTextById("ddlBenefits_0", payDate);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodEntry("Amendment_BenefitPage", "NextPayDate",
                 base.IsTakeScreenShotDuringEntryExit);
        }

    }
}
