using MMSG.Automation;
using MMSG.Automation.DataTransferObjects;
using MMSG.Automation.Exceptions;
using OpenQA.Selenium;
using System;
using System.Threading;

namespace MMSG.Pages.UI_Pages.Comet
{
    public class Package_basedetailsPage : BasePage
    {
        /// <summary>
        /// The static instance of the logger for the class.
        /// </summary>
        private static readonly Logger Logger =
            Logger.GetInstance(typeof(Package_basedetailsPage));


        /// <summary>
        /// Create a new package
        /// </summary>
        /// <param name="packageType">This is a package type enum.</param>
        public void FillNewPackageDetails(Package.PackageTypeEnum packageType)
        {
            Logger.LogMethodEntry("Package_basedetailsPage", "FillNewPackageDetails",
                base.IsTakeScreenShotDuringEntryExit);
            try
            {
                // First set in new package creation
                this.PackageCreationFirstStep(packageType);

                // Data to be filled in second step
                new Package_packageadmindetailsPage().PackageCreationSecondStep(packageType);

                // Data to be filled in third step
                new Package_payrolldetailsPage().PackageCreationThirdStep();

            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("Package_basedetailsPage", "FillNewPackageDetails",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// First step in package creation
        /// </summary>
        /// <param name="packageType">This is a package type enum.</param>
        private void PackageCreationFirstStep(Package.PackageTypeEnum packageType)
        {
            Logger.LogMethodEntry("Package_basedetailsPage", "PackageCreationFirstStep",
              base.IsTakeScreenShotDuringEntryExit);
            try
            {
                Package package = Package.Get(packageType);
                string getEmail = package.BusinessEmail.ToString();
                string getPhone = package.BusinessPhone.ToString();
                string setUpReason = package.SetUpReason.ToString();
                string getEmployerCode = package.EmployerCode.ToString();
                string getOffering = package.Offering.ToString();
                Thread.Sleep(2000);

                // Fill Business Email text box
                base.WaitForElement(By.Id(Package_basedetailsResource.
                    Package_basedetailsPage_BusinesEmail_ID));
                base.ClearTextById(Package_basedetailsResource.
                    Package_basedetailsPage_BusinesEmail_ID);
                base.FillTextBoxById(Package_basedetailsResource.
                    Package_basedetailsPage_BusinesEmail_ID, getEmail);

                // Fill Business Telephone textbox
                base.WaitForElement(By.Id(Package_basedetailsResource.
                    Package_basedetailsPage_NewPackage_BusinessTelephone_ID), 10);
                base.ClearTextById(Package_basedetailsResource.
                    Package_basedetailsPage_NewPackage_BusinessTelephone_ID);
                base.FillTextBoxById(Package_basedetailsResource.
                    Package_basedetailsPage_NewPackage_BusinessTelephone_ID, getPhone);

                // Select Setup Reason from dropdown
                base.WaitForElement(By.Id(Package_basedetailsResource.
                    Package_basedetailsPage_NewPackage_SetupReason_Dropdown_ID), 10);
                base.SelectDropDownValueThroughIndexById(Package_basedetailsResource.
                    Package_basedetailsPage_NewPackage_SetupReason_Dropdown_ID, 1);

                // Click on Employer lookup icon
                IWebElement getEmployerLookup = base.GetWebElementPropertiesById(
                    Package_basedetailsResource.Package_basedetailsPage_NewPackage_EmployerLookup_ID);
                base.PerformMouseClickAction(getEmployerLookup);

                Thread.Sleep(3000);

                // Search employer record
                this.SearchEmployerRecords(getEmployerCode);
                Thread.Sleep(3000);
                base.SwitchToDefaultWindow();

                // Fill Offering textbox
                bool getDropdownOptionStatus = base.IsElementPresent(By.XPath(".//*[@id='divMenuddmEmployerOfferingID']/table/tbody/tr[2]/td[1]"), 10);
                if (getDropdownOptionStatus == false)
                {
                    base.WaitForElement(By.XPath(".//*[@id='ddmEmployerOfferingID_trMain']/td[2]/img"));
                    IWebElement getDropdownOption = base.GetWebElementPropertiesByCssSelector("tr#ddmEmployerOfferingID_trMain > td > input");
                    base.ClickByJavaScriptExecutor(getDropdownOption);


                    IWebElement clickTheDropDownOption = base.GetWebElementPropertiesByXPath
                        (".//*[@id='divMenuddmEmployerOfferingID']/table/tbody/tr[2]/td[1]");
                    base.ClickByJavaScriptExecutor(clickTheDropDownOption);
                }
                else
                {
                    IWebElement clickOnTheDropDownOption = base.GetWebElementPropertiesByXPath
                    (".//*[@id='divMenuddmEmployerOfferingID']/table/tbody/tr[2]/td[1]");
                    base.ClickByJavaScriptExecutor(clickOnTheDropDownOption);
                }

                // Click next button
                base.WaitForElement(By.XPath("//tr[@class='BodyColor']/td[3]/input[3]"));
                IWebElement getNextButton = base.GetWebElementPropertiesByXPath("//tr[@class='BodyColor']/td[3]/input[3]");
                base.ClickByJavaScriptExecutor(getNextButton);

            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("Package_basedetailsPage", "PackageCreationFirstStep",
           base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Search employer records based on the employer code
        /// </summary>
        /// <param name="getEmployerCode">This is Employer code.</param>
        private void SearchEmployerRecords(string getEmployerCode)
        {
            Logger.LogMethodEntry("Package_basedetailsPage", "SearchEmployerRecords",
             base.IsTakeScreenShotDuringEntryExit);
            try
            {
                // Switch to Default window
                base.SwitchToDefaultWindow();
                base.SwitchToWindow(Package_basedetailsResource.
                    Package_basedetailsPage_NewPackage_SearchEmployer_Title);

                // Switch to iframe
                base.SwitchToIFrameByIndex(0);

                // Fill employer code in search employer textbox
                base.WaitForElement(By.Id(Package_basedetailsResource.
                    Package_basedetailsPage_NewPackage_SearchEmployer_Textbox_ID));
                base.ClearTextById(Package_basedetailsResource.
                    Package_basedetailsPage_NewPackage_SearchEmployer_Textbox_ID);
                base.FillTextBoxById(Package_basedetailsResource.
                    Package_basedetailsPage_NewPackage_SearchEmployer_Textbox_ID, getEmployerCode);

                //Click Search button
                base.WaitForElement(By.Id(Package_basedetailsResource.Package_basedetailsPage_NewPackage_SearchEmployer_SearchButton_ID));
                IWebElement getSubmitButton = base.GetWebElementPropertiesById(Package_basedetailsResource.Package_basedetailsPage_NewPackage_SearchEmployer_SearchButton_ID);
                base.ClickByJavaScriptExecutor(getSubmitButton);

                //ClickIng on the Employeer Link 
                base.WaitForElement(By.XPath(Package_basedetailsResource.Package_basedetailsPage_NewPackage_SearchEmployer_EmployeerLink_Xpath));
                IWebElement getEmployerLink = base.GetWebElementPropertiesByXPath((Package_basedetailsResource.Package_basedetailsPage_NewPackage_SearchEmployer_EmployeerLink_Xpath));
                base.ClickByJavaScriptExecutor(getEmployerLink);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("Package_basedetailsPage", "SearchEmployerRecords",
          base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verifythe page landed in the Edit page
        /// </summary>
        /// <param name="pageName">Page name</param>
        /// <returns></returns>
       public string VerifyPageLandedOnEditPage(string pageName)
        {
            Logger.LogMethodEntry("Package_basedetailsPage", "VerifyPageLandedOnEdietPage",
                       base.IsTakeScreenShotDuringEntryExit);
            string pageNameFromScreen = "";
            try
            {
                base.SwitchToPopup();
                switch (pageName)
                {
                    case "Edit Package":                      
                        base.WaitForElement(By.XPath(Package_basedetailsResource.
                            Package_basedetailsPage_EditPackage_PageHeading_Xpath));
                        return base.GetInnerTextAttributeValueByXPath(Package_basedetailsResource.
                            Package_basedetailsPage_EditPackage_PageHeading_Xpath);
                    case "Package Admin Details":
                        string url = AutomationConfigurationManager.CourseSpaceUrlRoot;
                        string getDomain = url.Substring(7);
                        int indexValue = getDomain.IndexOf('/');
                        string getDomainString = getDomain.Substring(0, indexValue);
                        string expectedPageTitle = getDomainString + " " + pageName;
                        if (expectedPageTitle=="")
                        {

                        }
                        break;
                }
                    
               
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("Package_basedetailsPage", "VerifyPageLandedOnEdietPage",
          base.IsTakeScreenShotDuringEntryExit);
            return pageNameFromScreen;
        }

        /// <summary>
        /// changeing the value in edit package page
        /// </summary>
        /// <param name="changeType">change in the type</param>
        /// <param name="changeValue">change value</param>
        public void ChangetheOption(string changeType, string changeValue)
        {
            Logger.LogMethodEntry("Package_basedetailsPage", "ChangetheOption",
            base.IsTakeScreenShotDuringEntryExit);
            try
            {
                base.SwitchToPopup();
                switch (changeType)
                {
                    case "Email":
                        base.WaitForElement(By.Id("txtBusinessEmail"));
                        base.ClearTextById("txtBusinessEmail");
                        base.FillTextBoxById("txtBusinessEmail", changeValue);
                        break;

                }
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("Package_basedetailsPage", "ChangetheOption",
          base.IsTakeScreenShotDuringEntryExit);

        }

        /// <summary>
        /// Clicking on the next button 
        /// </summary>
        public void ClickOnNext()
        {
            Logger.LogMethodEntry("Package_basedetailsPage", "ChangetheOption",
           base.IsTakeScreenShotDuringEntryExit);
            try
            {
                base.SwitchToPopup();
                base.WaitForElement(By.Id(Package_basedetailsResource.Package_basedetailsPage_EditPackage_NextButton_Id));
                IWebElement nextButton = base.GetWebElementProperties(By.Id(Package_basedetailsResource.Package_basedetailsPage_EditPackage_NextButton_Id));
                base.PerformClickAction(nextButton);
              //  base.ClickButtonById("wucButtons_cmdNextEnabled");
                
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("Package_basedetailsPage", "ChangetheOption",
          base.IsTakeScreenShotDuringEntryExit);
        }
    }
}

