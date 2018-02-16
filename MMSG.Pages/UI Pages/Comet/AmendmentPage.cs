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
   public class AmendmentPage : BasePage
    {
        /// <summary>
        /// The static instance of the logger for the class.
        /// </summary>
        private static readonly Logger Logger =
            Logger.GetInstance(typeof(Employee_personaldetailsPage));

        /// <summary>
        /// Verify the page landed on the Amendment Screen
        /// </summary>
        /// <returns></returns>
       public  bool VerifyThepageLandedOnAmendment()
        {
            Logger.LogMethodEntry("AmendmentPage", "VerifyThepageLndedOnAmendment",
                base.IsTakeScreenShotDuringEntryExit);
            bool pageLandedOnAmendment = false;
            try
            {
                base.WaitForElement(By.XPath("//span[@id='lblPageTitle']"));
                //geting the amendment Page heading
                string amendmentPage = base.GetElementInnerTextByXPath("//span[@id='lblPageTitle']");
                if (amendmentPage== "Amendments")
                {
                    return true;
                }
            }           
             catch (Exception e)
            {
                    ExceptionHandler.HandleException(e);
             }
                Logger.LogMethodEntry("AmendmentPage", "VerifyThepageLandedOnAmendment",
                    base.IsTakeScreenShotDuringEntryExit);
            return pageLandedOnAmendment;
            } 

        public void ClickOnOption(string optionName)
        {

            Logger.LogMethodEntry("AmendmentPage", "ClickOnOption",
                base.IsTakeScreenShotDuringEntryExit);
            try
            {
                switch (optionName)
                {
                    case "New":
                        base.WaitForElement(By.Id(AmendmentResource.AmendmentPage_NewButton_Id_Locator));
                        IWebElement newButtonProperty = base.GetWebElementProperties(By.Id(AmendmentResource.AmendmentPage_NewButton_Id_Locator));
                        base.ClickByJavaScriptExecutor(newButtonProperty);
                        break;
                    case "Cancel":
                        base.WaitForElement(By.Id(AmendmentResource.AmendmentPage_CancelButton_ID_Locator));
                        IWebElement newSaveProperty = base.GetWebElementProperties(By.Id(AmendmentResource.AmendmentPage_CancelButton_ID_Locator));
                        base.ClickByJavaScriptExecutor(newSaveProperty);
                        break;
                }
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodEntry("AmendmentPage", "ClickOnOption",
                    base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Checking the Benefit is been added 
        /// </summary>
        /// <param name="benefitName"></param>
        /// <returns></returns>
        public bool BenefitIsAdded(string benefitName)
        {
            Logger.LogMethodEntry("AmendmentPage", "BenefitIsAdded",
              base.IsTakeScreenShotDuringEntryExit);
            bool benefitIsPresent = false;
            try
            {
                int numberOfBenefit = base.GetElementCountByXPath(AmendmentResource.AmendmentPage_BenefitDetailsTableRow_Xpath_Locator);
                string textFromBenefit = base.GetInnerTextAttributeValueByXPath(AmendmentResource.AmendmentPage_BenefitDetailsTableRow_Xpath_Locator + "[" + numberOfBenefit + "]/td[3]");
                if (benefitName == textFromBenefit)
                {
                    return true;
                }
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodEntry("AmendmentPage", "BenefitIsAdded",
                    base.IsTakeScreenShotDuringEntryExit);
            return benefitIsPresent;
        }
    }
}
