using MMSG.Automation;
using MMSG.Automation.Database_Support.DBDataTransferObjects;
using MMSG.Automation.DataTransferObjects;
using MMSG.Automation.Exceptions;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MMSG.Pages.UI_Pages.Comet
{
    public class CallCentreEnquiryPage : BasePage
    {
        /// <summary>
        /// The static instance of the logger for the class.
        /// </summary>
        private static readonly Logger Logger =
            Logger.GetInstance(typeof(CallCentreEnquiryPage));

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
        public void UserSearch(string optionName, User.UserTypeEnum userType, string dataFetchType)
        {
            Logger.LogMethodEntry("CallCentreEnquiryPage", "UserSearch", base.IsTakeScreenShotDuringEntryExit);
            try
            {
                string employeeNumber = string.Empty;
                string surName = string.Empty;
                string givenName = string.Empty;
                string employerCode = string.Empty;
                User user = User.Get(userType);

                switch (dataFetchType)
                {
                    case "DB":
                        employeeNumber = new DBUserQueries().GetEmployeeNumberBySurName(userType);
                        break;

                    case "XML":
                        //Get user details from XML
                        employeeNumber = user.EmployeeNumber.ToString();
                        surName = user.Name.ToString();
                        givenName = user.GivenName.ToString();
                        employerCode = user.EmployerCode.ToString();
                        break;
                }
                // Enter the data into the search text box based on the data fetch criteria
                SearchComentUser(optionName, employeeNumber, surName, givenName, employerCode);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("CallCentreEnquiryPage", "UserSearch", base.IsTakeScreenShotDuringEntryExit);
        }


        private void SearchComentUser(string optionName, string employeeNumber, string surName,
            string givenName, string employerCode)
        {
            base.WaitUntilPopUpLoads(base.GetPageTitle);
            switch (optionName)
            {
                case "EmployeeNumber":
                    base.WaitForElement(By.Id("CCEmployeeSearch_txtEmployeeNumber"));
                    base.FillTextBoxByXPath("CCEmployeeSearch_txtEmployeeNumber", employeeNumber);
                    break;

                case "EmployerCode":
                    base.WaitForElement(By.Id("CCEmployeeSearch_txtEmployerCode"));
                    base.FillTextBoxByXPath("CCEmployeeSearch_txtEmployerCode", employerCode);
                    break;

                case "Surname":
                    base.WaitForElement(By.Id("CCEmployeeSearch_txtSurname"));
                    break;
            }
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
            Logger.LogMethodEntry("CallCentreEnquiryPage", "ClickOptionOnCCEnquiryPage",
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
                    case "Amendment":
                        ClickOnTheAmendmentOptionInTreeView();
                        break;
                    case "Process Menu":
                        ClickOnProcessMenu();
                        break;
                }
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("CallCentreEnquiryPage", "ClickOptionOnCCEnquiryPage",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Clickon the processmenu of the Call cenetre Enquiry Screen
        /// </summary>
        public void ClickOnProcessMenu()
        {
            Logger.LogMethodEntry("CallCentreEnquiryPage", "ClickOnProcessMenu",
               base.IsTakeScreenShotDuringEntryExit);
            try
            {
                IWebElement processMenuProp = base.GetWebElementProperties(By.Id("LeftMenuTreet3"));
                base.ClickButtonById("LeftMenuTreet3");
                base.SwitchToPopup();

            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("CallCentreEnquiryPage", "ClickOnProcessMenu",
               base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click new button in Call Centre Enquiry page
        /// </summary>
        public void ClickNewButton(string pageName)
        {
            Logger.LogMethodEntry("CallCentreEnquiryPage", "ClickNewButton", base.IsTakeScreenShotDuringEntryExit);
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
            Logger.LogMethodExit("CallCentreEnquiryPage", "ClickNewButton", base.IsTakeScreenShotDuringEntryExit);
        }


        /// <summary>
        /// Click new button in Call Centre Enquiry page
        /// </summary>
        public void ClickCreateNewPackageLink(string pageName)
        {
            Logger.LogMethodEntry("CallCentreEnquiryPage", "ClickCreateNewPackageLink",
                base.IsTakeScreenShotDuringEntryExit);
            try
            {
                base.SwitchToDefaultWindow();
                base.WaitUntilPopUpLoads(pageName);
                base.SelectWindow(pageName);
                bool ewe = base.IsElementPresent(By.LinkText("Create New Package"), 10);
                base.WaitForElement(By.LinkText("Create New Package"));
                IWebElement getNewButton = base.GetWebElementProperties(By.LinkText("Create New Package"));
                base.ClickByJavaScriptExecutor(getNewButton);
                Thread.Sleep(1000);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("CallCentreEnquiryPage", "ClickCreateNewPackageLink",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verify the created package display in call center enquiry screen
        /// </summary>
        /// <param name="packageType">This is package type enum.</param>
        /// <param name="userType">This is user type enum.</param>
        /// <returns>Return package existance status.</returns>
        public bool VeriFyPackageName(Package.PackageTypeEnum packageType, User.UserTypeEnum userType)
        {
            Logger.LogMethodEntry("CallCentreEnquiryPage", "VeriFyPackageName",
                base.IsTakeScreenShotDuringEntryExit);
            bool packageIsPresent = false;
            try
            {
                base.WaitForElement(By.Id("wucPackageSummary_tdEmployeeNo"));
                // Employee Nuber from screen
                string employeeNo = base.GetElementInnerTextById("wucPackageSummary_tdEmployeeNo");
                this.StoreUserDetails(userType, employeeNo);
                Package package = Package.Get(packageType);
                //Package Name From menery
                string getEmployerCode = package.EmployerCode.ToString();
                string toBeCompared = getEmployerCode + " " + "(" + employeeNo;
                //Package name and employee name 
                string employeeNumebrWithPackage = base.GetElementInnerTextById("LeftMenuTreet2");
                string text= employeeNumebrWithPackage.Remove(employeeNumebrWithPackage.Length - 7);
                // compare the value with trhye screen value
                if (text== toBeCompared)
                {
                    return true;
                }
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("CallCentreEnquiryPage", "VeriFyPackageName",
                base.IsTakeScreenShotDuringEntryExit);
            return packageIsPresent;
        }

        /// <summary>
        /// Click new button in Call Amendment page
        /// </summary>
        public void ClickOnTheAmendmentOptionInTreeView()
        {           
            base.WaitForElement(By.LinkText("Amendments"));
            IWebElement amendmentProperty = base.GetWebElementProperties(By.LinkText("Amendments"));
            base.ClickByJavaScriptExecutor(amendmentProperty);
        }


        /// <summary>
        /// Stores User Details in Memory.
        /// </summary>
        /// <param name="userTypeEnum">This is User by Type.</param>
        /// <param name="userInformation">This is User Information Guid.</param>        
        public void StoreUserDetails(User.UserTypeEnum userTypeEnum, string employeeNumber)
        {
            //Stores User Details in Memory

            Logger.LogMethodEntry("AddUserPage", "StoreUserDetails"
                , base.IsTakeScreenShotDuringEntryExit);
            //Store User Details in Memory
            this.StoreUserDetailsInMemory(userTypeEnum, employeeNumber);
            string sname = User.Get(userTypeEnum).Surname.ToString();
            Logger.LogMethodExit("AddUserPage", "StoreUserDetails"
                , base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Saving the User Details in Memory
        /// </summary>
        /// <param name="userTypeEnum">This is User Type Enum</param>
        /// <param name="userName">This is Username guid</param>
        /// <param name="userPassword">This is Password</param>
        /// <param name="firstName">This Is First Name</param>
        /// <param name="lastName">This Is Last Name</param>
        private void StoreUserDetailsInMemory(User.UserTypeEnum userTypeEnum, string employeeNumber)
        {
            //Save user in Memory
            Logger.LogMethodEntry("AddUserPage", "StoreUserDetailsInMemory",
                base.IsTakeScreenShotDuringEntryExit);
            //Save User Properties in Memory
            //Save user Details
            this.SaveUserInMemory
             (userTypeEnum, employeeNumber);

            Logger.LogMethodExit("AddUserPage", "StoreUserDetailsInMemory",
                base.IsTakeScreenShotDuringEntryExit);
        }


        /// <summary>
        /// Save User In Memory
        /// </summary>
        /// <param name="userTypeEnum">This is User Type Enum</param>
        /// <param name="userName">This is UserName Guid</param>
        /// <param name="userPassword">This is Password</param>
        /// <param name="firstName">This is First Name</param>
        /// <param name="lastName">This is Last Name</param> 
        private void SaveUserInMemory(User.UserTypeEnum userTypeEnum, string employeeNumber)
        {
            //Save The User In Memory
            Logger.LogMethodEntry("AddUserPage", "SaveUserInMemory",
              base.IsTakeScreenShotDuringEntryExit);
            User newUser = new User
            {
                EmployeeNumber = employeeNumber,
            };
        }


        /// <summary>
        /// Clicking on the elelment in the process menu
        /// </summary>
        public void ProcessMenuPopUpClickOnElement(string optionName)
        {
            Logger.LogMethodEntry("CallCentreEnquiryPage", "ProcessMenuPopUpClickOnElemet",
               base.IsTakeScreenShotDuringEntryExit);
            try
            {
                switch (optionName)
                {
                    case "Admin Fees":
                        base.SwitchToPopup();
                        string a1 = base.GetPageTitle;
                        bool a = base.IsElementPresent(By.Id("PopUpMenu_cmdMenu10"));
                        IWebElement adminProperties = base.GetWebElementPropertiesById("PopUpMenu_cmdMenu10");
                        base.ClickByJavaScriptExecutor(adminProperties);
                        break;

                    case "Edit":
                        base.SwitchToPopup();
                        string a2 = base.GetPageTitle;
                        bool a3 = base.IsElementPresent(By.Id("PopUpMenu_cmdMenu2"));
                        IWebElement editProperties = base.GetWebElementPropertiesById("PopUpMenu_cmdMenu2");
                        base.ClickByJavaScriptExecutor(editProperties);
                        break;

                }
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("CallCentreEnquiryPage", "ProcessMenuPopUpClickOnElemet",
                base.IsTakeScreenShotDuringEntryExit);
        }

        public string GetTheTitleOfpopUp()
        {
            Logger.LogMethodEntry("CallCentreEnquiryPage", "GetTheTitleOfpopUp",
                          base.IsTakeScreenShotDuringEntryExit);
            string titleOfPage = "";
            try
            {
                Thread.Sleep(2000);               
                base.SwitchToPopup();
                titleOfPage = base.GetPageTitle;
                Thread.Sleep(1000);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("CallCentreEnquiryPage", "GetTheTitleOfpopUp",
                base.IsTakeScreenShotDuringEntryExit);
            return titleOfPage;
        }

        public void EnterTheEmployeeNumberAndSearch(string employeeNumner)
        {
            Logger.LogMethodEntry("CallCentreEnquiryPage", "EnterTheEmployeeNumberAndSearch",
                         base.IsTakeScreenShotDuringEntryExit);

            try
            {
                base.WaitForElement(By.Id("CCEmployeeSearch_txtEmployeeNumber"));
                base.FillTextBoxByXPath("CCEmployeeSearch_txtEmployeeNumber", employeeNumner);
                base.WaitForElement(By.Id("CCEmployeeSearch_cmdSearch"));
                // Click button by ID
                IWebElement getSearchButton = base.GetWebElementPropertiesById("CCEmployeeSearch_cmdSearch");
                base.ClickByJavaScriptExecutor(getSearchButton);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("CallCentreEnquiryPage", "EnterTheEmployeeNumberAndSearch",
                base.IsTakeScreenShotDuringEntryExit);
        }
    }
}