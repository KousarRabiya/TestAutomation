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
                /*
                EmployeeNumber
EmployerCode
Surname
GivenName
DateOfBirth*/
                //Get user details
                User user = User.Get(userType);
                string employeeNumber = user.EmployeeNumber.ToString();
                string surName = user.Name.ToString();
                string givenName = user.GivenName.ToString();
                string date = user.DOB.ToString();
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
    }
}
