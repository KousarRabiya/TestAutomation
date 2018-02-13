using MMSG.Automation;
using MMSG.Automation.DataTransferObjects;
using MMSG.Automation.Exceptions;
using OpenQA.Selenium;
using System;
using System.Threading;

namespace MMSG.Pages.UI_Pages.Comet
{
    public class Package_packageadmindetailsPage : BasePage
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
        public void PackageCreationSecondStep(Package.PackageTypeEnum packageType)
        {
            Logger.LogMethodEntry("Package_basedetailsPage", "PackageCreationSecondStep",
                base.IsTakeScreenShotDuringEntryExit);
            try
            {
                Package package = Package.Get(packageType);
                string getEntertainmentCap = package.EntertainmentCap.ToString();
                string getLivingExpenseCap = package.LivingExpenseCap.ToString();

                // Fill Living Expense Cap textbox
                base.WaitForElement(By.Id(Package_packageadmindetailsResource.
                    Package_packageadmindetailsPage_NewPackage_LivingExpenseCap_Textbox_ID));
                base.ClearTextById(Package_packageadmindetailsResource.
                    Package_packageadmindetailsPage_NewPackage_LivingExpenseCap_Textbox_ID);
                base.FillTextBoxById(Package_packageadmindetailsResource.
                    Package_packageadmindetailsPage_NewPackage_LivingExpenseCap_Textbox_ID, getLivingExpenseCap);

                // Fill Living EntertainmentCap textbox               
                base.WaitForElement(By.Id(Package_packageadmindetailsResource.
                    Package_packageadmindetailsPage_NewPackage_EntertainmentCap_Textbox_ID));
                base.ClearTextById(Package_packageadmindetailsResource.
                    Package_packageadmindetailsPage_NewPackage_EntertainmentCap_Textbox_ID);
                base.FillTextBoxById(Package_packageadmindetailsResource.
                    Package_packageadmindetailsPage_NewPackage_EntertainmentCap_Textbox_ID, getEntertainmentCap);


                // Clicking on the FinancialAdvisor Tex Box
                base.WaitForElement(By.CssSelector("tr#ddmFinancialAdvisor_trMain > td > input"));
                IWebElement getFinancialAdvisor = base.GetWebElementPropertiesByCssSelector("tr#ddmFinancialAdvisor_trMain > td > input");
                base.ClickByJavaScriptExecutor(getFinancialAdvisor);

                // Clicking on the DropDown of FinancialAdvisor
                IWebElement getFinancialAdvisioOption = base.GetWebElementPropertiesByXPath
                    (".//*[@id='divMenuddmFinancialAdvisor']/table/tbody/tr[3]/td[1]");
                base.ClickByJavaScriptExecutor(getFinancialAdvisioOption);
                Thread.Sleep(3000);

                // Click next button               
                base.WaitForElement(By.XPath(Package_packageadmindetailsResource.Package_packageadmindetailsPage_NewPackage_NextButton_Textbox_Xpath));
                IWebElement getNextButton = base.GetWebElementPropertiesByXPath(Package_packageadmindetailsResource.Package_packageadmindetailsPage_NewPackage_NextButton_Textbox_Xpath);
                base.ClickByJavaScriptExecutor(getNextButton);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("Package_basedetailsPage", "PackageCreationSecondStep",
                base.IsTakeScreenShotDuringEntryExit);
        }
    }
}
