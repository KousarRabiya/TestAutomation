﻿using MMSG.Automation;
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
        /// Verify thepage landedon the Admin Fees For Package pge
        /// </summary>
        /// <returns>returen True if the page title</returns>
        public string VerifyPageLandedOnAdminFeesForPackagePackage()
        {
            Logger.LogMethodEntry("AdminFeesForPackagePage", "VerifyPageLandedOnAdminFeesForPackagePackage", base.IsTakeScreenShotDuringEntryExit);
            string pageHeader = "";
            try
            {
                base.SwitchToPopup();
                pageHeader = base.GetInnerTextAttributeValueByXPath(AdminFeesForPackageResource.AdminFeesForPackage_PageTitle_Xpath_Locator);
                return pageHeader;
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("AdminFeesForPackagePage", "VerifyPageLandedOnAdminFeesForPackagePackage", base.IsTakeScreenShotDuringEntryExit);
            return pageHeader;
        }

        /// <summary>
        /// Enter rthe effective date in the Admin Fees For Package Page
        /// </summary>
        public void EnterTheEffectiveDate()
        {
            Logger.LogMethodEntry("AdminFeesForPackagePage", "enterTheEffectiveDate", base.IsTakeScreenShotDuringEntryExit);
            try
            {
                string getDateText = base.GetInnerTextAttributeValueByXPath(Employee_personaldetailsResource.EmployeepersonaldetailsPage_Title_EffectiveDate_Xpath);
                string getDate = getDateText.Substring(17);
                string EffectiveDateText = getDate.Replace(")", "").Trim();
                base.WaitForElement(By.Name(AdminFeesForPackageResource.AdminFeesForPackage_EffectiveDate_ID_Locator));
                bool a = base.IsElementPresent((By.Name(AdminFeesForPackageResource.AdminFeesForPackage_EffectiveDate_ID_Locator)));
                base.FillTextBoxByName("EffectiveDateText", EffectiveDateText);             

            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("AdminFeesForPackagePage", "enterTheEffectiveDate", base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Clickon the look up image and selelcting the fees
        /// </summary>
        public void ClickOnLookUpImgAndSelelctFeesName()
        {
            Logger.LogMethodEntry("AdminFeesForPackagePage", "ClickOnLookUpImgAndSelelctFeesName", base.IsTakeScreenShotDuringEntryExit);
            try
            {
                base.SwitchToPopup();
                base.WaitForElement(By.Id(AdminFeesForPackageResource.AdminFeesForPackage_LookUpImg_ID_Locator));
                IWebElement lookUpImg = base.GetWebElementProperties(By.Id(AdminFeesForPackageResource.AdminFeesForPackage_LookUpImg_ID_Locator));                
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

        public void SelelctTheFeesTypeFromPopUp()
        {
            Logger.LogMethodEntry("AdminFeesForPackagePage", "SelelctTheFeesTypeFromPopUp", base.IsTakeScreenShotDuringEntryExit);
            try
            {
                base.SwitchToPopup();
               
                IWebElement ifreamElement = base.GetWebElementProperties(By.TagName(AdminFeesForPackageResource.AdminFeesForPackage_PopUpGrid_IframeTagName_Locator));
                base.SwitchToIFrameByWebElement(ifreamElement);
               
                base.WaitForElement(By.XPath(AdminFeesForPackageResource.AdminFeesForPackage_PopUpGrid_Xpath_Locator));
                bool a2 = base.IsElementPresent(By.XPath(AdminFeesForPackageResource.AdminFeesForPackage_PopUpGrid_Xpath_Locator));
                IWebElement feesTypeGrid = base.GetWebElementProperties(By.XPath(AdminFeesForPackageResource.AdminFeesForPackage_PopUpGrid_Xpath_Locator));
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
                bool a = base.IsElementPresent(By.XPath("//table[@id='ResultsGrid']/tbody/tr[2]/td[1]/a"));
                base.WaitForElement(By.XPath("//table[@id='ResultsGrid']/tbody/tr[2]/td[1]/a"));
               
                // Cliockingf on the save button
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