using MMSG.Automation;
using MMSG.Automation.Database_Support.DBDataTransferObjects;
using MMSG.Automation.DataTransferObjects;
using MMSG.Automation.Exceptions;
using OpenQA.Selenium;
using System;
using System.Threading;

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
            Logger.LogMethodEntry("CallCentreEnquiryPage", "GetApplicationLogoExistance", 
                base.IsTakeScreenShotDuringEntryExit);
            bool getApplicationLogoExistance = false;
            try
            {
                base.WaitUntilPopUpLoads(base.GetPageTitle);
                getApplicationLogoExistance = base.IsElementPresent(By.Id(CallCentreEnquiryResource.
                    CallCentreEnquiry_ApplictionLogo_Id_Locator), 10);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("CallCentreEnquiryPage", "GetApplicationLogoExistance",
                base.IsTakeScreenShotDuringEntryExit);
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


        /// <summary>
        /// Search comet user based on the search option type.
        /// </summary>
        /// <param name="optionName">This is option name.</param>
        /// <param name="employeeNumber">This is employee number.</param>
        /// <param name="surName">This is sur name.</param>
        /// <param name="givenName">This is given name.</param>
        /// <param name="employerCode">This is employer code.</param>
        private void SearchComentUser(string optionName, string employeeNumber, string surName,
            string givenName, string employerCode)
        {
            base.WaitUntilPopUpLoads(base.GetPageTitle);
           // Search based on option
            switch (optionName)
            {
                case "EmployeeNumber":
                    base.WaitForElement(By.Id(CallCentreEnquiryResource.
                        CallCentreEnquiry_EmployeeNumberTextBox_Id_Locator));
                    base.FillTextBoxById("CCEmployeeSearch_txtEmployeeNumber", employeeNumber);
                    break;

                case "EmployerCode":
                    base.WaitForElement(By.Id(CallCentreEnquiryResource.
                        CallCentreEnquiry_EmployerCodeTextBox_Id_Locator));
                    base.FillTextBoxById(CallCentreEnquiryResource.
                        CallCentreEnquiry_EmployerCodeTextBox_Id_Locator, employerCode);
                    break;

                case "Surname":
                    base.WaitForElement(By.Id(CallCentreEnquiryResource.
                        CallCentreEnquiry_SurnametextBox_Id_Locator));
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
                base.WaitForElement(By.Id(CallCentreEnquiryResource.CallCentreEnquiry_SearchButton_Id_Locator));
                // Click button by ID
                IWebElement getSearchButton = base.GetWebElementPropertiesById(CallCentreEnquiryResource.
                    CallCentreEnquiry_SearchButton_Id_Locator);
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
                string getEmployeeNo = base.GetInnerTextAttributeValueById(CallCentreEnquiryResource.
                    CallCentreEnquiry_EmployeeNumber_Id_Locator);
                string getEmployeeName = base.GetInnerTextAttributeValueById(CallCentreEnquiryResource.
                    CallCentreEnquiry_EmployeeName_Id_Locator);
                string getGender = base.GetInnerTextAttributeValueById(CallCentreEnquiryResource.
                    CallCentreEnquiry_EmployeeGender_Id_Locator);
                string getEmail = base.GetInnerTextAttributeValueById(CallCentreEnquiryResource.
                    CallCentreEnquiry_EmployeeEmail_Id_Locator);

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
                    case "Benefit":
                        ClickOnBenefit();
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
                // Wait and click on process link
                Thread.Sleep(1000);
                base.WaitForElement(By.XPath(
                    "//td[@class='LeftMenuTree_1 LeftMenuTree_4']/a[@id='LeftMenuTreet3']"));
                base.ClickLinkByXPath("//td[@class='LeftMenuTree_1 LeftMenuTree_4']/a[@id='LeftMenuTreet3']");
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("CallCentreEnquiryPage", "ClickOnProcessMenu",
               base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click On The Benefit
        /// </summary>
        public void ClickOnBenefit()
        {
            Logger.LogMethodEntry("CallCentreEnquiryPage", "ClickOnBenefit",
              base.IsTakeScreenShotDuringEntryExit);
            try
            {
                base.ClickButtonByLinkText(CallCentreEnquiryResource.
                    CallCentreEnquiry_Benifit_LinkText_Locator);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("CallCentreEnquiryPage", "ClickOnBenefit",
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
                IWebElement getNewButton = base.GetWebElementProperties(By.Id(CallCentreEnquiryResource.
                    CallCentreEnquiry_NewButton_Id_Locator));
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
                // Waiting for the New button and Cliking on the button using the java  script executor                
                base.WaitForElement(By.LinkText(CallCentreEnquiryResource.
                    CallCentreEnquiry_CreatePackage_LinkText_Locator));
                IWebElement getNewButton = base.GetWebElementProperties(By.LinkText(CallCentreEnquiryResource.
                    CallCentreEnquiry_CreatePackage_LinkText_Locator));
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
                base.WaitForElement(By.Id(CallCentreEnquiryResource.
                    CallCentreEnquiry_EmployeeNumber_Id_Locator));
                // Employee Number from screen
                string employeeNo = base.GetElementInnerTextById("wucPackageSummary_tdEmployeeNo");
                this.StoreUserDetails(userType, employeeNo);
                Package package = Package.Get(packageType);
                //Package Name From menery
                string getEmployerCode = package.EmployerCode.ToString();
                string toBeCompared = getEmployerCode + " " + "(" + employeeNo;
                //Package name and employee name 
                string employeeNumebrWithPackage = base.GetElementInnerTextById(CallCentreEnquiryResource.
                    CallCentreEnquiry_PackageNameWithEmployeeNumber_Id_Locator);
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
            Logger.LogMethodEntry("CallCentreEnquiryPage", "ClickOnTheAmendmentOptionInTreeView",
               base.IsTakeScreenShotDuringEntryExit);
         
            try
            {
                base.WaitForElement(By.LinkText("Amendments"));
                IWebElement amendmentProperty = base.GetWebElementProperties(By.LinkText(CallCentreEnquiryResource.
                    CallCentreEnquiry_Amendment_LinkText_Locator));
                base.ClickByJavaScriptExecutor(amendmentProperty);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("CallCentreEnquiryPage", "ClickOnTheAmendmentOptionInTreeView",
                base.IsTakeScreenShotDuringEntryExit);
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
                        IWebElement adminProperties = base.GetWebElementPropertiesById(CallCentreEnquiryResource.
                            CallCentreEnquiry_ProcessMenuPopUp_AdminFrees_Id_Locator);
                        base.ClickByJavaScriptExecutor(adminProperties);
                        break;
                    case "Edit":
                        base.SwitchToPopup();
                        IWebElement editProperties = base.GetWebElementPropertiesById(CallCentreEnquiryResource.
                            CallCentreEnquiry_ProcessMenuPopUp_Edit_Id_Locator);
                        base.ClickByJavaScriptExecutor(editProperties);
                        break;
                    case "Review And Activate":
                        base.SwitchToPopup();
                        IWebElement reviewAndActivateProperties = base.GetWebElementPropertiesById(
                            CallCentreEnquiryResource.CallCentreEnquiry_ProcessMenuPopUp_ReviewAndActivate_Locator1);
                        base.ClickByJavaScriptExecutor(reviewAndActivateProperties);
                        break;
                    case "New Benefit":
                        base.SwitchToPopup();
                        IWebElement newBenefitProperties = base.GetWebElementPropertiesById("PopUpMenu_cmdMenu6");
                        base.ClickByJavaScriptExecutor(newBenefitProperties);
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

        /// <summary>
        /// Getting the title of Popup menu Process Menu
        /// </summary>
        /// <returns></returns>
        public string GetTheTitleOfpopUp()
        {
            Logger.LogMethodEntry("CallCentreEnquiryPage", "GetTheTitleOfpopUp",
                          base.IsTakeScreenShotDuringEntryExit);
            string titleOfPage = "";
            try
            {
                Thread.Sleep(1000);
                base.SwitchToDefaultWindow();
                base.SwitchToLastOpenedWindow();
                // Get page title during runtime
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

        /// <summary>
        /// Enter the Employee Number 
        /// </summary>
        /// <param name="employeeNumner">Employee number</param>
        public void EnterTheEmployeeNumberAndSearch(string employeeNumner)
        {
            Logger.LogMethodEntry("CallCentreEnquiryPage", "EnterTheEmployeeNumberAndSearch",
                         base.IsTakeScreenShotDuringEntryExit);

            try
            {
                base.WaitForElement(By.Id(CallCentreEnquiryResource.
                    CallCentreEnquiry_PackageNameWithEmployeeNumber_Id_Locator));
                base.FillTextBoxById(CallCentreEnquiryResource.
                    CallCentreEnquiry_PackageNameWithEmployeeNumber_Id_Locator, employeeNumner);

                // Click button by Search 
                base.WaitForElement(By.Id(CallCentreEnquiryResource.
                    CallCentreEnquiry_SearchButton_Id_Locator));               
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

        /// <summary>
        /// Verify the package is active
        /// </summary>
        /// <returns></returns>
        public bool VerifyThePackageStatusAsActive()
        {
            Logger.LogMethodEntry("CallCentreEnquiryPage", "VerifyThePackageStatusAsActive",
                         base.IsTakeScreenShotDuringEntryExit);
            try
            {               
                string employeeNumebrWithPackage = base.GetElementInnerTextById(CallCentreEnquiryResource.
                    CallCentreEnquiry_PackageNameWithEmployeeNumber_Id_Locator);
                var result = employeeNumebrWithPackage.Substring(employeeNumebrWithPackage.Length - 3);
                string text = employeeNumebrWithPackage.Remove(employeeNumebrWithPackage.Length - 7);
                // compare the value with screen value is status is active
                if (result == "(A)")
                {
                    return true;
                }
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("CallCentreEnquiryPage", "VerifyThePackageStatusAsActive",
                base.IsTakeScreenShotDuringEntryExit);
            return false;
        }
       
        /// <summary>
        /// Verify the page BenefitGrid has been appeared
        /// </summary>
        /// <returns></returns>
        public bool VerifyTheBenefitGridHasAppeared()
        {
            Logger.LogMethodEntry("CallCentreEnquiryPage", "VerifyThePackageStatusAsActive",
                                    base.IsTakeScreenShotDuringEntryExit);
            try
            {
                IWebElement gridElemnet = base.GetWebElementProperties(By.TagName("iframe"));
                base.SwitchToIFrameByWebElement(gridElemnet);
                return base.IsElementPresent(By.Id("grdBenefits"));
             }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("CallCentreEnquiryPage", "VerifyThePackageStatusAsActive",
              base.IsTakeScreenShotDuringEntryExit);
            return false;
        }

        /// <summary>
        /// Clicking on the Benefit Grid 
        /// </summary>
        public void ClickingOnTheBenefitOfGrid()
        {
            Logger.LogMethodEntry("CallCentreEnquiryPage", "ClickingOnTheBenefitOfGrid",
                                                base.IsTakeScreenShotDuringEntryExit);
            try
            {
                IWebElement benifitType = base.GetWebElementProperties(By.TagName("iframe"));
                base.SwitchToIFrameByWebElement(benifitType);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("CallCentreEnquiryPage", "ClickingOnTheBenefitOfGrid",
              base.IsTakeScreenShotDuringEntryExit);
        } 
    }
    }
