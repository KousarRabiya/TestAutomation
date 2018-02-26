using MMSG.Automation;
using MMSG.Automation.DataTransferObjects;
using MMSG.Automation.Exceptions;
using OpenQA.Selenium;
using System;
using System.Threading;

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
        public bool VerifyThepageLandedOnAmendment()
        {
            Logger.LogMethodEntry("AmendmentPage", "VerifyThepageLndedOnAmendment",
                base.IsTakeScreenShotDuringEntryExit);
            bool pageLandedOnAmendment = false;
            try
            {
                base.SwitchToPopup();
                base.WaitForElement(By.XPath(AmendmentResource.AmendmentPage_Title_Value_Xpath_Locator));
                //geting the amendment Page heading
                string amendmentPage = base.GetElementInnerTextByXPath(AmendmentResource.
                    AmendmentPage_Title_Value_Xpath_Locator);
                if (amendmentPage == AmendmentResource.AmendmentPage_Title_Value)
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

        /// <summary>
        /// Clicking on the button in Amendment screen 
        /// </summary>
        /// <param name="optionName">option name which we need to be clicked </param>
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
                        base.WaitForElement(By.CssSelector(AmendmentResource.AmendmentPage_NewButton_CsSelelctor_Locator));
                        IWebElement newButtonProperty = base.GetWebElementProperties(By.CssSelector(AmendmentResource.
                            AmendmentPage_NewButton_CsSelelctor_Locator));
                        base.PerformMouseClickAction(newButtonProperty);
                        break;
                    case "Cancel":
                        base.WaitForElement(By.CssSelector(AmendmentResource.AmendmentPage_CancelButton_CssSelelctor_Locator), 10);
                        IWebElement newSaveProperty = base.GetWebElementProperties(By.CssSelector(AmendmentResource.AmendmentPage_CancelButton_CssSelelctor_Locator));
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
        /// <param name="benefitType">sending the benefit type to the method</param>
        /// <returns></returns>
        public bool BenefitIsAdded(Benefit.BenefitTypeEnum benefitType)
        {
            Logger.LogMethodEntry("AmendmentPage", "BenefitIsAdded",
              base.IsTakeScreenShotDuringEntryExit);
            bool benefitIsPresent = false;
            try
            {
                //geting the benefit from the memory
                Benefit benefit = Benefit.Get(benefitType);
                string benefitName = benefit.Benefit1.ToString();
                int numberOfBenefit = base.GetElementCountByXPath(AmendmentResource.
                    AmendmentPage_BenefitDetailsTableRow_Xpath_Locator);
                string textFromBenefit = base.GetInnerTextAttributeValueByXPath(AmendmentResource.
                    AmendmentPage_BenefitDetailsTableRow_Xpath_Locator + "[" + numberOfBenefit + "]/td[3]");
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
