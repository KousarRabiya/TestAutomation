using MMSG.Automation;
using MMSG.Automation.DataTransferObjects;
using MMSG.Automation.Exceptions;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMSG.Pages.UI_Pages.Comet
{
    public class CallCentreEnquiryPage : BasePage
    {
        /// <summary>
        /// The static instance of the logger for the class.
        /// </summary>
        private static readonly Logger Logger =
            Logger.GetInstance(typeof(ApplicationLoginPage));

        /// <summary>
        /// Get the application logo existance status
        /// </summary>
        /// <returns>Return logo existance status.</returns>
        public bool GetApplicationLogoExistance()
        {
            Logger.LogMethodEntry("CallCentreEnquiryPage", "GetApplicationLogoExistance", base.IsTakeScreenShotDuringEntryExit);
            bool getApplicationLogoExistance = false;
            try
            {
                base.WaitUntilPopUpLoads(base.GetPageTitle);
                getApplicationLogoExistance = base.IsElementPresent(By.Id("imgBanner"), 10);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("CallCentreEnquiryPage", "GetApplicationLogoExistance", base.IsTakeScreenShotDuringEntryExit);
            return getApplicationLogoExistance;
        }

        /// <summary>
        /// Search user based on the input search criteria
        /// </summary>
        /// <param name="userType">This is user type enum.</param>
        public void UserSearch(string optionName, User.UserTypeEnum userType)
        {
            Logger.LogMethodEntry("CallCentreEnquiryPage", "UserSearch", base.IsTakeScreenShotDuringEntryExit);
            try
            {

                //Get user details
                User user = User.Get(userType);
                string employeeNumber = user.EmployeeNumber.ToString();
                string surName = user.Name.ToString();
                string givenName = user.GivenName.ToString();
                string employerCode = user.EmployerCode.ToString();

                base.WaitUntilPopUpLoads(base.GetPageTitle);
                switch (optionName)
                {
                    case "EmployeeNumber":
                        base.WaitForElement(By.Id("CCEmployeeSearch_txtEmployeeNumber"));
                        base.FillTextBoxById("CCEmployeeSearch_txtEmployeeNumber", employeeNumber);
                        break;

                    case "EmployerCode":
                        base.WaitForElement(By.Id("CCEmployeeSearch_txtEmployerCode"));
                        base.FillTextBoxById("CCEmployeeSearch_txtEmployerCode", employerCode);
                        break;

                    case "Surname":
                        base.WaitForElement(By.Id("CCEmployeeSearch_txtSurname"));
                        break;
                }
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("CallCentreEnquiryPage", "UserSearch", base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click search button
        /// </summary>
        public void ClickSearchButton()
        {
            try
            {
                // Wait untill popup loads
                base.WaitUntilPopUpLoads(base.GetPageTitle);
                // Wait for search button to load
                base.WaitForElement(By.Id("CCEmployeeSearch_cmdSearch"));
                // Click button by ID
                IWebElement getSearchButton = base.GetWebElementPropertiesById("CCEmployeeSearch_cmdSearch");
                base.ClickByJavaScriptExecutor(getSearchButton);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
        }

        /// <summary>
        /// Get element existance details from application
        /// </summary>
        /// <param name="userType">This is user type enum.</param>
        /// <returns>This will return employee existance status.</returns>
        public bool GetEmployeeDetailsDisplayStatus(User.UserTypeEnum userType)
        {
            Logger.LogMethodEntry("CallCentreEnquiryPage", "GetEmployeeDetailsDisplayStatus", base.IsTakeScreenShotDuringEntryExit);
            bool getEmployeeDetailsStatus = false;
            try
            {
                // Get user details from inmemory
                User user = User.Get(userType);
                string employeeNo = user.EmployeeNumber.ToString();
                string employeeName = user.Name.ToString();
                string gender = user.Gender.ToString();
                string email = user.Email.ToString();

                // Get user details from application
                string getEmployeeNo = base.GetInnerTextAttributeValueById("wucPackageSummary_tdEmployeeNo");
                string getEmployeeName = base.GetInnerTextAttributeValueById("wucPackageSummary_tdEmployeeName");
                string getGender = base.GetInnerTextAttributeValueById("wucPackageSummary_tdGender");
                string getEmail = base.GetInnerTextAttributeValueById("wucPackageSummary_tdEmail");

                if (getEmployeeNo.Equals(employeeNo) &&
                    getEmployeeName.Contains(employeeName) && getGender.Equals(gender) && getEmail.Equals(email))
                {
                    getEmployeeDetailsStatus = true;
                }

            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("CallCentreEnquiryPage", "GetEmployeeDetailsDisplayStatus", base.IsTakeScreenShotDuringEntryExit);
            return getEmployeeDetailsStatus;
        }

        /// <summary>
        /// Click new button in Call Centre Enquiry page
        /// </summary>
        public void ClickOptionOnCCEnquiryPage(string optionName, string pageName)
        {
            Logger.LogMethodEntry("Employee_personaldetailsPage", "ClickNewButton",
                base.IsTakeScreenShotDuringEntryExit);
            try
            {
                switch (optionName)
                {
                    case "New":
                        ClickNewButton(pageName);
                        break;

                    case "Create New Package":
                        ClickCreateNewPackageLink(pageName);
                        break;
                }
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("Employee_personaldetailsPage", "ClickNewButton",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click new button in Call Centre Enquiry page
        /// </summary>
        public void ClickNewButton(string pageName)
        {
            Logger.LogMethodEntry("Employee_personaldetailsPage", "ClickNewButton", base.IsTakeScreenShotDuringEntryExit);
            try
            {
                base.WaitUntilPopUpLoads(pageName);
                base.WaitForElement(By.Id("CCEmployeeSearch_cmdNew"));
                IWebElement getNewButton = base.GetWebElementProperties(By.Id("CCEmployeeSearch_cmdNew"));
                base.ClickByJavaScriptExecutor(getNewButton);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("Employee_personaldetailsPage", "ClickNewButton", base.IsTakeScreenShotDuringEntryExit);
        }


        /// <summary>
        /// Click new button in Call Centre Enquiry page
        /// </summary>
        public void ClickCreateNewPackageLink(string pageName)
        {
            Logger.LogMethodEntry("Employee_personaldetailsPage", "ClickCreateNewPackageLink",
                base.IsTakeScreenShotDuringEntryExit);
            try
            {
                base.WaitUntilPopUpLoads(pageName);
                bool ewe = base.IsElementPresent(By.LinkText("Create New Package"), 10);
                base.WaitForElement(By.LinkText("Create New Package"));
                IWebElement getNewButton = base.GetWebElementProperties(By.Id("CCEmployeeSearch_cmdNew"));
                base.ClickByJavaScriptExecutor(getNewButton);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("Employee_personaldetailsPage", "ClickCreateNewPackageLink",
                base.IsTakeScreenShotDuringEntryExit);
        }
    }
}