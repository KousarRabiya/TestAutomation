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
                base.ClearTextByXpath(Package_payrolldetailsResource.
                    Package_payrolldetailsPage_Payroll_Textbox_ID);
                base.FillTextBoxByXpath(Package_payrolldetailsResource.
                    Package_payrolldetailsPage_Payroll_Textbox_ID, sixDigitNumber);

                bool getDropdownOptionStatus = base.IsElementPresent(By.XPath("//div[@id='divMenuddmPayCycleID']/table/tbody/tr[2]/td[1]"),10);
                if(getDropdownOptionStatus==false)
                {
                    base.WaitForElement(By.XPath("//tr[@id='ddmPayCycleID_trMain']/td/input"));
                    IWebElement getDropdown = base.GetWebElementPropertiesByXPath("//tr[@id='ddmPayCycleID_trMain']/td/input");
                    base.ClickByJavaScriptExecutor(getDropdown);

                    IWebElement getPayCycleOption = base.GetWebElementPropertiesByXPath("//div[@id='divMenuddmPayCycleID']/table/tbody/tr[2]/td[1]");
                    base.ClickByJavaScriptExecutor(getPayCycleOption);
                }
                else
                {
                    IWebElement getPayCycleOption = base.GetWebElementPropertiesByXPath("//div[@id='divMenuddmPayCycleID']/table/tbody/tr[2]/td[1]");
                    base.ClickByJavaScriptExecutor(getPayCycleOption);
                }

                // Click Add button
                bool df = base.IsElementPresent(By.Id("wucButtons_cmdAddEnabled"),10);
                base.WaitForElement(By.Id("wucButtons_cmdAddEnabled"));
                IWebElement getAddButton = base.GetWebElementPropertiesById("wucButtons_cmdAddEnabled");
                base.ClickByJavaScriptExecutor(getAddButton);
                Thread.Sleep(3000);

                // Click Save Button
                base.WaitForElement(By.XPath("//tr[@class='BodyColor']/td[3]/input[2]"));
                IWebElement getSaveButton = base.GetWebElementPropertiesByXPath("//tr[@class='BodyColor']/td[3]/input[2]");
                base.PerformMouseClickAction(getSaveButton);

            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("Package_payrolldetailsPage", "PackageCreationThirdStep",
            base.IsTakeScreenShotDuringEntryExit);
        }
    }
}
