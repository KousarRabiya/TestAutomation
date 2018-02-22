using MMSG.Automation;
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
                base.WaitForElement(By.XPath(AmendmentResource.AmendmentPage_Title_Value_Xpath_Locator));
                //geting the amendment Page heading
                string amendmentPage = base.GetElementInnerTextByXPath(AmendmentResource.AmendmentPage_Title_Value_Xpath_Locator);
                if (amendmentPage== AmendmentResource.AmendmentPage_Title_Value)
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
                Thread.Sleep(1000);
                switch (optionName)
                {
                    case "New":
                        base.WaitForElement(By.CssSelector("input#btnNew"));
                        IWebElement newButtonProperty = base.GetWebElementProperties(By.CssSelector("input#btnNew"));
                        base.PerformMouseClickAction(newButtonProperty);
                        break;
                    case "Cancel":
                        bool a = base.IsElementPresent(By.CssSelector("input#wucBenefitDetailsCancelNSave_cmdCancelEnabled"),10);
                        base.WaitForElement(By.CssSelector("input#wucBenefitDetailsCancelNSave_cmdCancelEnabled"),10);
                        IWebElement newSaveProperty = base.GetWebElementProperties(By.CssSelector("input#wucBenefitDetailsCancelNSave_cmdCancelEnabled"));                                       
                        base.PerformMouseClickAction(newSaveProperty);
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
