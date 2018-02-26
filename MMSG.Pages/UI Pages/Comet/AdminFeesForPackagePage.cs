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
   public class AdminFeesForPackagePage : BasePage
    {
        /// <summary>
        /// The static instance of the logger for the class.
        /// </summary>
        private static readonly Logger Logger =
            Logger.GetInstance(typeof(AdminFeesForPackagePage));

        /// <summary>
        /// Verify the page landed on the Admin Fees For Package pge
        /// </summary>
        /// <returns>Return page title</returns>
        public string VerifyPageLandedOnAdminFees()
        {
            Logger.LogMethodEntry("AdminFeesForPackagePage", "VerifyPageLandedOnAdminFeesForPackagePackage",
                base.IsTakeScreenShotDuringEntryExit);
            string pageHeader = "";
            try
            {
                // Switch to popup
                base.SwitchToPopup();
                // Get the popup title
                pageHeader = base.GetInnerTextAttributeValueByXPath(AdminFeesForPackageResource.
                    AdminFeesForPackage_PageTitle_Xpath_Locator);
                return pageHeader;
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("AdminFeesForPackagePage", "VerifyPageLandedOnAdminFeesForPackagePackage",
                base.IsTakeScreenShotDuringEntryExit);
            return pageHeader;
        }

        /// <summary>
        /// Enter the effective date in the Admin fees for Package
        /// </summary>
        public void EnterTheEffectiveDate()
        {
            Logger.LogMethodEntry("AdminFeesForPackagePage", "EnterTheEffectiveDate", 
                base.IsTakeScreenShotDuringEntryExit);
            try
            {
                // Get effective date from the application
                string getDateText = base.GetInnerTextAttributeValueByXPath(
                    Employee_personaldetailsResource.EmployeepersonaldetailsPage__EffectiveDate_Xpath);
                string getDate = getDateText.Substring(17);
                string EffectiveDateText = getDate.Replace(")", "").Trim();
                // Fill the Effective date in Admin fee page
                base.WaitForElement(By.Name(AdminFeesForPackageResource.AdminFeesForPackage_EffectiveDate_ID_Locator));
                base.FillTextBoxByName(AdminFeesForPackageResource.AdminFeesForPackage_EffectiveDate_Name_Locator, 
                    EffectiveDateText);            
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("AdminFeesForPackagePage", "enterTheEffectiveDate", 
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click on look up image and selelcting the fees
        /// </summary>
        public void ClickOnLookUpImgAndSelelctFeesName()
        {
            Logger.LogMethodEntry("AdminFeesForPackagePage", "ClickOnLookUpImgAndSelelctFeesName", base.IsTakeScreenShotDuringEntryExit);
            try
            {
                // switching on the pop up
                base.SwitchToPopup();
                // waiting for the admin look up image 
                base.WaitForElement(By.Id(AdminFeesForPackageResource.AdminFeesForPackage_LookUpImg_ID_Locator));
                IWebElement lookUpImg = base.GetWebElementProperties(By.Id(AdminFeesForPackageResource.
                    AdminFeesForPackage_LookUpImg_ID_Locator));                
                base.ClickButtonById(AdminFeesForPackageResource.AdminFeesForPackage_LookUpImg_ID_Locator);
                base.SwitchToPopup();
                //Selelcting the fees from Pop Up
                SelelctTheFeesTypeFromPopUp();
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("AdminFeesForPackagePage", "ClickOnLookUpImgAndSelelctFeesName", base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Selelcting the fees type from the pop up
        /// </summary>
        public void SelelctTheFeesTypeFromPopUp()
        {
            Logger.LogMethodEntry("AdminFeesForPackagePage", "SelelctTheFeesTypeFromPopUp", base.IsTakeScreenShotDuringEntryExit);
            try
            {
                // switch to pop up window
                base.SwitchToPopup();
                base.WaitUntilPopUpLoads("Search");
                base.SelectWindow("Search");

               //switch to iframe
                IWebElement ifreamElement = base.GetWebElementProperties(By.TagName(AdminFeesForPackageResource.
                    AdminFeesForPackage_PopUpGrid_IframeTagName_Locator));
                base.SwitchToIFrameByWebElement(ifreamElement);

                //wait for the git to appeare
                base.WaitForElement(By.XPath(AdminFeesForPackageResource.AdminFeesForPackage_PopUpGrid_Xpath_Locator)); 

                // click on the Git option              
                IWebElement feesTypeGrid = base.GetWebElementProperties(By.XPath(AdminFeesForPackageResource.
                    AdminFeesForPackage_PopUpGrid_Xpath_Locator));
                base.ClickByJavaScriptExecutor(feesTypeGrid);
                base.SwitchToPopup();
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("AdminFeesForPackagePage", "SelelctTheFeesTypeFromPopUp", base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click on the Add and save the Admin fees
        /// </summary>
        public void ClickOnAddAndSaveTheFees()
        {
            Logger.LogMethodEntry("AdminFeesForPackagePage", "ClickOnAddAndSaveTheFees", base.IsTakeScreenShotDuringEntryExit);
            try
            {
                base.SwitchToPopup();
                // cliking on the Add button
                base.WaitForElement(By.Id(AdminFeesForPackageResource.AdminFeesForPackage_AddButton_ID_Locator));
                IWebElement addButton = base.GetWebElementProperties(By.Id(AdminFeesForPackageResource.AdminFeesForPackage_AddButton_ID_Locator));
                base.ClickByJavaScriptExecutor(addButton);

                // Wait for grid to load
                base.WaitForElement(By.XPath(AdminFeesForPackageResource.AdminFeesForPackage_Grid_Xpath_Locator));
               
                // Clickingf on the save button
                base.WaitForElement(By.Id(AdminFeesForPackageResource.AdminFeesForPackage_SaveButton_ID_Locator));
                IWebElement SaveButton = base.GetWebElementProperties(By.Id(AdminFeesForPackageResource.AdminFeesForPackage_SaveButton_ID_Locator));
                base.ClickByJavaScriptExecutor(SaveButton);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("AdminFeesForPackagePage", "ClickOnAddAndSaveTheFees", base.IsTakeScreenShotDuringEntryExit);
        }
    }
}
