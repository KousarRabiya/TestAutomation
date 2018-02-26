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
    public class ReviewActivatePage : BasePage
    {      /// <summary>
           /// The static instance of the logger for the class.
           /// </summary>
        private static readonly Logger Logger =
            Logger.GetInstance(typeof(ReviewActivatePage));

        /// <summary>
        /// Verify the page landed on the Review and Activate page 
        /// </summary>
        /// <returns>Returns the status as true for is page is landed</returns>
        public bool VerifyThePageLandedOnReviewAndActivatePage()
        {
            Logger.LogMethodEntry("ReviewAndActivatePage", "VerifyThePageLandedOnReviewAndActivatePage",
                base.IsTakeScreenShotDuringEntryExit);
            bool getTheReviewAndActivatePageStatus = false;
            try
            {
                base.SwitchToPopup();
                String pagetittle = base.GetInnerTextAttributeValueByXPath(ReviewActivateResource.
                    ReviewActivatePage_Title_Xpath_Locator);
                if (pagetittle == "Review And Activate Package")
                {
                    getTheReviewAndActivatePageStatus = true;
                    return getTheReviewAndActivatePageStatus;
                }
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("ReviewAndActivatePage", "VerifyThePageLandedOnReviewAndActivatePage",
                base.IsTakeScreenShotDuringEntryExit);
            return getTheReviewAndActivatePageStatus;
        }

        /// <summary>
        /// Clicking on the save button in Review and activate page
        /// </summary>
        public void ClickOnSaveButtonOnReviwAndActivatePage()
        {
            Logger.LogMethodEntry("ReviewAndActivatePage", "ClickOnSaveButtonOnReviwAndActivatePage",
                base.IsTakeScreenShotDuringEntryExit);
            try
            {
                base.WaitForElement(By.Id(ReviewActivateResource.
                    ReviewActivatePage_SaveButton_Id_Locator));
                base.ClickButtonById(ReviewActivateResource.
                    ReviewActivatePage_SaveButton_Id_Locator);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("ReviewAndActivatePage", "ClickOnSaveButtonOnReviwAndActivatePage",
                base.IsTakeScreenShotDuringEntryExit);
        }
    }
}