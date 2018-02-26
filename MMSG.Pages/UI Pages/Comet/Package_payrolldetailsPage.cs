using MMSG.Automation;
using MMSG.Automation.DataTransferObjects;
using MMSG.Automation.Exceptions;
using OpenQA.Selenium;
using System;
using System.Threading;

namespace MMSG.Pages.UI_Pages.Comet
{
    public class Package_payrolldetailsPage : BasePage
    {
        /// <summary>
        /// The static instance of the logger for the class.
        /// </summary>
        private static readonly Logger Logger =
            Logger.GetInstance(typeof(Package_packageadmindetailsPage));

        /// <summary>
        /// Data to be filled in second step of Create package 
        /// </summary>
        /// <param name="packageType">This is package type enum.</param>
        public void PackageCreationThirdStep()
        {
            Logger.LogMethodEntry("Package_payrolldetailsPage", "PackageCreationThirdStep",
            base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Generate 6 digit random number
                Random r = new Random();
                int randNum = r.Next(1000000);
                string sixDigitNumber = randNum.ToString("D6");

                // Enter payroll details
                base.WaitForElement(By.Id(Package_payrolldetailsResource.
                    Package_payrolldetailsPage_Payroll_Textbox_ID));
                base.ClearTextById(Package_payrolldetailsResource.
                    Package_payrolldetailsPage_Payroll_Textbox_ID);
                base.FillTextBoxById(Package_payrolldetailsResource.
                    Package_payrolldetailsPage_Payroll_Textbox_ID, sixDigitNumber);

                bool getDropdownOptionStatus = base.IsElementPresent(By.XPath(Package_payrolldetailsResource.
                    Package_payrolldetailsPage_PayCycleTable_Textbox_Xpath),10);
                if(getDropdownOptionStatus==false)
                {
                    base.WaitForElement(By.XPath(Package_payrolldetailsResource.
                        Package_payrolldetailsPage_PayCycle_Textbox_Xpath));
                    IWebElement getDropdown = base.GetWebElementPropertiesByXPath(Package_payrolldetailsResource.
                        Package_payrolldetailsPage_PayCycle_Textbox_Xpath);
                    base.ClickByJavaScriptExecutor(getDropdown);

                    IWebElement getPayCycleOption = base.GetWebElementPropertiesByXPath(Package_payrolldetailsResource.
                    Package_payrolldetailsPage_PayCycleTable_Textbox_Xpath);
                    base.ClickByJavaScriptExecutor(getPayCycleOption);
                }
                else
                {
                    IWebElement getPayCycleOption = base.GetWebElementPropertiesByXPath(Package_payrolldetailsResource.
                    Package_payrolldetailsPage_PayCycleTable_Textbox_Xpath);
                    base.ClickByJavaScriptExecutor(getPayCycleOption);
                }

                // Click Add button
                bool df = base.IsElementPresent(By.Id(Package_payrolldetailsResource.
                    Package_payrolldetailsPage__AddButton_ID),10);
                base.WaitForElement(By.Id((Package_payrolldetailsResource.
                    Package_payrolldetailsPage__AddButton_ID)));
                IWebElement getAddButton = base.GetWebElementPropertiesById((Package_payrolldetailsResource.
                    Package_payrolldetailsPage__AddButton_ID));
                base.ClickByJavaScriptExecutor(getAddButton);
                Thread.Sleep(3000);

                // Click Save Button
                base.WaitForElement(By.XPath(Package_payrolldetailsResource.
                    Package_payrolldetailsPage_SaveButton_Xpath));
                IWebElement getSaveButton = base.GetWebElementPropertiesByXPath(Package_payrolldetailsResource.
                    Package_payrolldetailsPage_SaveButton_Xpath);
                base.PerformMouseClickAction(getSaveButton);

            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("Package_payrolldetailsPage", "PackageCreationThirdStep",
            base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Clicking on he save button in Edit package in Package Enroll ment Details
        /// </summary>
        public void ClikingOnSaveInEdit()
        {
            Logger.LogMethodEntry("Package_payrolldetailsPage", "ClikingOnSaveInEdit",
          base.IsTakeScreenShotDuringEntryExit);
            Thread.Sleep(2000);
            try
            {
                base.WaitForElement(By.Id(Package_payrolldetailsResource.
                    Package_payrolldetailsPage_Edit_SaveButton_ID));
                IWebElement getSaveButton = base.GetWebElementPropertiesById(Package_payrolldetailsResource.
                    Package_payrolldetailsPage_Edit_SaveButton_ID);
                base.PerformMouseClickAction(getSaveButton);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("Package_payrolldetailsPage", "ClikingOnSaveInEdit",
            base.IsTakeScreenShotDuringEntryExit);
        }
    }
}
