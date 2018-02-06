using MMSG.Automation;
using MMSG.Automation.DataTransferObjects;
using MMSG.Automation.Exceptions;
using OpenQA.Selenium;
using System;
using System.Threading;

namespace MMSG.Pages.UI_Pages.Comet
{

    public class Employee_personaldetailsPage : BasePage
    {
        /// <summary>
        /// The static instance of the logger for the class.
        /// </summary>
        private static readonly Logger Logger =
            Logger.GetInstance(typeof(Employee_personaldetailsPage));

        /// <summary>
        /// Get the page title from commet application
        /// </summary>
        /// <returns>This will return page title.</returns>
        public string GetCommetNewEmoplyeePageTitle()
        {
            Logger.LogMethodEntry("Employee_personaldetailsPage", "GetCommetNewEmoplyeePageTitle",
                base.IsTakeScreenShotDuringEntryExit);
            string popupTitle = null;
            try
            {
                base.SwitchToDefaultWindow();
                // Get page title 
                popupTitle = base.GetPageTitle;
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodEntry("Employee_personaldetailsPage", "GetCommetNewEmoplyeePageTitle",
                base.IsTakeScreenShotDuringEntryExit);
            return popupTitle;
        }

        /// <summary>
        /// Get popup title.
        /// </summary>
        /// <returns>Return the popup title.</returns>
        public string GetpopupTitle()
        {
            Logger.LogMethodEntry("Employee_personaldetailsPage", "GetpopupTitle",
                base.IsTakeScreenShotDuringEntryExit);
            string returnPopupTitle = null;
            try
            {
                // Get page title 
                base.SwitchToDefaultWindow();
                base.SwitchToLastOpenedWindow();
                base.WaitUntilPopUpLoads(base.GetPageTitle);
                returnPopupTitle = base.GetPageTitle;
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("Employee_personaldetailsPage", "GetpopupTitle",
                 base.IsTakeScreenShotDuringEntryExit);
            return returnPopupTitle;
        }

        /// <summary>
        /// Fill the textbox using customized GUID and store the data inmemory
        /// </summary>
        /// <param name="userType">This is user type enum.</param>
        public void FillEmployeeDetails(User.UserTypeEnum userType)
        {
            base.SwitchToDefaultWindow();
            base.MaximizeWindow();
            //Step one form fill for new employee 
            this.NewEmployeeCreationFirstStep(userType);

            // Click next button
            base.WaitForElement(By.Id(Employee_personaldetailsResource.
                EmployeepersonaldetailsPage_NextButton_ID_Locator));
            IWebElement getNextButton = base.GetWebElementPropertiesById(Employee_personaldetailsResource.
                EmployeepersonaldetailsPage_NextButton_ID_Locator);
            base.ClickByJavaScriptExecutor(getNextButton);
            User user = User.Get(userType);
            string sName = user.Surname.ToString();
            Thread.Sleep(2000);

            //Step two form fill for new employee 
            this.NewEmployeeCreationSecondStep(userType);

            // Click next button
            IWebElement getButtonXpath = base.GetWebElementPropertiesByXPath("//tr[@class='BodyColor']/td[3]/input[4]");
            base.ClickByJavaScriptExecutor(getButtonXpath);
            Thread.Sleep(2000);

            //Step three form fill for new employee 
            this.NewEmployeeCreationThirdStep(userType);

            // Click next button
            getButtonXpath = base.GetWebElementPropertiesByXPath("//tr[@class='BodyColor']/td[3]/input[4]");
            base.ClickByJavaScriptExecutor(getButtonXpath);
            Thread.Sleep(2000);

            getButtonXpath = base.GetWebElementPropertiesByXPath("//tr[@class='BodyColor']/td[3]/input[2]");
            base.ClickByJavaScriptExecutor(getButtonXpath);
            Thread.Sleep(2000);

        }

        /// <summary>
        /// Step one form fill for new employee 
        /// </summary>
        /// <param name="userType">This is user type enum.</param>
        private void NewEmployeeCreationFirstStep(User.UserTypeEnum userType)
        {
            // Generate Customized GUID for text fill    
            string givenNameGUID = this.GenerateGivenNameGUID();
            string surnameGUID = this.GenerateSurnameGUID();
            string otherNameGUID = this.GenerateOtherNameGUID();
            string preferredName = this.GeneratePreferredNameGUID();
            string dOB = "09-05-1974";
            string tenDigitMobileRandomNumbers = GetTenDigitMobileRandomNumbers();
            string preferredEmail = "ppcustomer@maxxia.com.au";
            string homeTelephone = "03 99730006";
            string gESBMenberNumber = "190902";

            // Wait for Title dropdown and select the value
            base.WaitForElement(By.Id(Employee_personaldetailsResource.
                EmployeepersonaldetailsPage_Title_Dropdown_ID_Locator));
            base.SelectDropDownValueThroughIndexById(Employee_personaldetailsResource.
                EmployeepersonaldetailsPage_Title_Dropdown_ID_Locator, 6);

            // Fill Given Name textbox
            base.WaitForElement(By.Id(Employee_personaldetailsResource.
                EmployeepersonaldetailsPage_GivenName_Textbox_ID_Locator));
            base.ClearTextById(Employee_personaldetailsResource.
                EmployeepersonaldetailsPage_GivenName_Textbox_ID_Locator);
            base.FillTextBoxById(Employee_personaldetailsResource.
                EmployeepersonaldetailsPage_GivenName_Textbox_ID_Locator, givenNameGUID);

            // Fill Home Telephone textbox
            base.WaitForElement(By.Id(Employee_personaldetailsResource.
                EmployeepersonaldetailsPage_PhoneNumberHomeText_Textbox_ID_Locator));
            base.ClearTextById(Employee_personaldetailsResource.
                EmployeepersonaldetailsPage_PhoneNumberHomeText_Textbox_ID_Locator);
            base.FillTextBoxById(Employee_personaldetailsResource.
                EmployeepersonaldetailsPage_PhoneNumberHomeText_Textbox_ID_Locator, homeTelephone);

            // Fill OtherNames Textbox
            base.WaitForElement(By.Id(Employee_personaldetailsResource.
                EmployeepersonaldetailsPage_OtherNamesText_Textbox_ID_Locator));
            base.ClearTextById(Employee_personaldetailsResource.
                EmployeepersonaldetailsPage_OtherNamesText_Textbox_ID_Locator);
            base.FillTextBoxById(Employee_personaldetailsResource.
                EmployeepersonaldetailsPage_OtherNamesText_Textbox_ID_Locator, otherNameGUID);

            // Fill Surname textbox
            base.WaitForElement(By.Id(Employee_personaldetailsResource.
                EmployeepersonaldetailsPage_SurnameText_Textbox_ID_Locator));
            base.ClearTextById(Employee_personaldetailsResource.
                EmployeepersonaldetailsPage_SurnameText_Textbox_ID_Locator);
            base.FillTextBoxById(Employee_personaldetailsResource.
                EmployeepersonaldetailsPage_SurnameText_Textbox_ID_Locator, surnameGUID);

            // Fill data of birth text box
            base.WaitForElement(By.Id(Employee_personaldetailsResource.
                EmployeepersonaldetailsPage_DateOfBirthText_Textbox_ID_Locator));
            base.ClearTextById(Employee_personaldetailsResource.
                EmployeepersonaldetailsPage_DateOfBirthText_Textbox_ID_Locator);
            base.FillTextBoxById(Employee_personaldetailsResource.
                EmployeepersonaldetailsPage_DateOfBirthText_Textbox_ID_Locator, dOB);

            // Select Gender option from the dropdown
            base.WaitForElement(By.Id(Employee_personaldetailsResource.
                EmployeepersonaldetailsPage_Gender_Dropdown_ID_Locator));
            base.SelectDropDownValueThroughIndexById(Employee_personaldetailsResource.
                EmployeepersonaldetailsPage_Gender_Dropdown_ID_Locator, 2);

            // Fill Preferred Name text box 
            base.WaitForElement(By.Id(Employee_personaldetailsResource.
                EmployeepersonaldetailsPage_PreferredNameText_Textbox_ID_Locator));
            base.ClearTextById(Employee_personaldetailsResource.
                EmployeepersonaldetailsPage_PreferredNameText_Textbox_ID_Locator);
            base.FillTextBoxById(Employee_personaldetailsResource.
                EmployeepersonaldetailsPage_PreferredNameText_Textbox_ID_Locator, preferredName);

            // Fill textbox by email id
            base.WaitForElement(By.Id(Employee_personaldetailsResource.
                EmployeepersonaldetailsPage_EmailAddressText_Textbox_ID_Locator));
            base.ClearTextById(Employee_personaldetailsResource.
                EmployeepersonaldetailsPage_EmailAddressText_Textbox_ID_Locator);
            base.FillTextBoxById(Employee_personaldetailsResource.
                EmployeepersonaldetailsPage_EmailAddressText_Textbox_ID_Locator, preferredEmail);

            // Fill GESB Member Number Text
            base.WaitForElement(By.Id(Employee_personaldetailsResource.
                EmployeepersonaldetailsPage_GESBMemberNumberText_Textbox_ID_Locator));
            base.ClearTextById(Employee_personaldetailsResource.
                EmployeepersonaldetailsPage_GESBMemberNumberText_Textbox_ID_Locator);
            base.FillTextBoxById(Employee_personaldetailsResource.
                EmployeepersonaldetailsPage_GESBMemberNumberText_Textbox_ID_Locator, gESBMenberNumber);

            // Select Employee Asked Marketing No Radio
            base.SelectRadioButtonById(Employee_personaldetailsResource.
                EmployeepersonaldetailsPage_EmployeeAskedMarketingNoRadio_RadioButton_ID);

            // Select Receive Marketing Info Yes Radio
            base.SelectRadioButtonById(Employee_personaldetailsResource.
                EmployeepersonaldetailsPage_ReceiveMarketingInfoYesRadio_RadioButton_ID);

            // Select Employee Asked Green Statement Yes Radio
            base.SelectRadioButtonById(Employee_personaldetailsResource.
                EmployeepersonaldetailsPage_EmployeeAskedGreenStatementYesRadio_RadioButton_ID);

            // Select Receive Substantiation Reminders Yes Radio
            base.SelectRadioButtonById(Employee_personaldetailsResource.
                EmployeepersonaldetailsPage_ReceiveSubstantiationRemindersYesRadio_RadioButton_ID);

            // Select Receive Payment Notifications Yes Radio
            base.SelectRadioButtonById(Employee_personaldetailsResource.
                EmployeepersonaldetailsPage_ReceivePaymentNotificationsYesRadio_RadioButton_ID);

            // Select Online Claims Approval Required No Radio
            base.SelectRadioButtonById(Employee_personaldetailsResource.
                EmployeepersonaldetailsPage_OnlineClaimsApprovalRequiredNo_RadioButton_ID);

            // Store the data in memory
            this.StoreUserDetails(userType, givenNameGUID,
                surnameGUID, otherNameGUID, tenDigitMobileRandomNumbers,
                preferredEmail, gESBMenberNumber);

        }

        /// <summary>
        /// Step two form fill new employee
        /// </summary>
        /// <param name="userType">This is user type enum.</param>
        private void NewEmployeeCreationSecondStep(User.UserTypeEnum userType)
        {
            try
            {
                // Fill Home adress in adress text box
                base.WaitForElement(By.Id(Employee_personaldetailsResource.
                    EmployeepersonaldetailsPage_HomeAddressLine1Text_Textbox_ID_Locator));
                base.ClearTextById(Employee_personaldetailsResource.
                    EmployeepersonaldetailsPage_HomeAddressLine1Text_Textbox_ID_Locator);
                base.FillTextBoxById(Employee_personaldetailsResource.
                    EmployeepersonaldetailsPage_HomeAddressLine1Text_Textbox_ID_Locator,
                    Employee_personaldetailsResource.
                    EmployeepersonaldetailsPage_HomeAddressLine1Text_Textbox_Text);

                // Fill Home Suburb text box
                base.WaitForElement(By.Id(Employee_personaldetailsResource.
                EmployeepersonaldetailsPage_HomeSuburbText_Textbox_ID_Locator));
                base.ClearTextById(Employee_personaldetailsResource.
                EmployeepersonaldetailsPage_HomeSuburbText_Textbox_ID_Locator);
                base.FillTextBoxById(Employee_personaldetailsResource.
                EmployeepersonaldetailsPage_HomeSuburbText_Textbox_ID_Locator,
                Employee_personaldetailsResource.
                EmployeepersonaldetailsPage_HomeSuburbText_Textbox_Text);

                // Select state from Home state dropdown
                base.WaitForElement(By.Id(Employee_personaldetailsResource.
                EmployeepersonaldetailsPage_HomeStateCombo_Dropdown_ID_Locator));
                base.SelectDropDownValueThroughIndexById(Employee_personaldetailsResource.
                EmployeepersonaldetailsPage_HomeStateCombo_Dropdown_ID_Locator, 7);

                // Fill Postcode in the home Postcode textbox
                base.WaitForElement(By.Id(Employee_personaldetailsResource.
                EmployeepersonaldetailsPage_HomePostCodeText_Textbox_ID_Locator));
                base.ClearTextById(Employee_personaldetailsResource.
                EmployeepersonaldetailsPage_HomePostCodeText_Textbox_ID_Locator);
                base.FillTextBoxById(Employee_personaldetailsResource.
                EmployeepersonaldetailsPage_HomePostCodeText_Textbox_ID_Locator,
                Employee_personaldetailsResource.
                EmployeepersonaldetailsPage_HomePostCodeText_Textbox_Text);

                // Fill Postal Address
                base.WaitForElement(By.Id(Employee_personaldetailsResource.
                EmployeepersonaldetailsPage_PostalAddressLine1Text_Textbox_ID_Locator));
                base.ClearTextById(Employee_personaldetailsResource.
                 EmployeepersonaldetailsPage_PostalAddressLine1Text_Textbox_ID_Locator);
                base.FillTextBoxById(Employee_personaldetailsResource.
                    EmployeepersonaldetailsPage_PostalAddressLine1Text_Textbox_ID_Locator,
                    Employee_personaldetailsResource.
                    EmployeepersonaldetailsPage_HomeAddressLine1Text_Textbox_Text);

                //Fill Postal Suburb Text
                base.WaitForElement(By.Id(Employee_personaldetailsResource.
                EmployeepersonaldetailsPage_PostalSuburbText_Textbox_ID_Locator));
                base.ClearTextById(Employee_personaldetailsResource.
                EmployeepersonaldetailsPage_PostalSuburbText_Textbox_ID_Locator);
                base.FillTextBoxById(Employee_personaldetailsResource.
                EmployeepersonaldetailsPage_PostalSuburbText_Textbox_ID_Locator,
                Employee_personaldetailsResource.
                EmployeepersonaldetailsPage_HomeSuburbText_Textbox_Text);

                // Select state from Postal state dropdown
                base.WaitForElement(By.Id(Employee_personaldetailsResource.
                EmployeepersonaldetailsPage_PostalStateCombo_Dropdown_ID_Locator));
                base.SelectDropDownValueThroughIndexById(Employee_personaldetailsResource.
                EmployeepersonaldetailsPage_PostalStateCombo_Dropdown_ID_Locator, 7);

                // Select Postal Post Code Text
                base.WaitForElement(By.Id(Employee_personaldetailsResource.
                EmployeepersonaldetailsPage_PostalPostCodeText_Textbox_ID_Locator));
                base.ClearTextById(Employee_personaldetailsResource.
                EmployeepersonaldetailsPage_PostalPostCodeText_Textbox_ID_Locator);
                base.FillTextBoxById(Employee_personaldetailsResource.
                EmployeepersonaldetailsPage_PostalPostCodeText_Textbox_ID_Locator,
                Employee_personaldetailsResource.
                EmployeepersonaldetailsPage_HomePostCodeText_Textbox_Text);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
        }

        /// <summary>
        /// Step three form fill new employee
        /// </summary>
        /// <param name="userType">This is user type enum.</param>
        private void NewEmployeeCreationThirdStep(User.UserTypeEnum userType)
        {
            try
            {
                string getDateText = base.GetInnerTextAttributeValueByXPath("html/body/form/table/tbody/tr[1]/td/table/tbody/tr[1]/td[2]/font");
                string getDate = getDateText.Substring(17);
                string effectiveDateText = getDate.Replace(")", "").Trim();

                // Fill Effective Date Text
                base.WaitForElement(By.Id(Employee_personaldetailsResource.
                    EmployeepersonaldetailsPage_EffectiveDateText_Textbox_ID_Locator));
                base.ClearTextById(Employee_personaldetailsResource.
                    EmployeepersonaldetailsPage_EffectiveDateText_Textbox_ID_Locator);
                base.FillTextBoxById(Employee_personaldetailsResource.
                    EmployeepersonaldetailsPage_EffectiveDateText_Textbox_ID_Locator, effectiveDateText);

                base.WaitForElement(By.Id(Employee_personaldetailsResource.
                    EmployeepersonaldetailsPage_PaymentMethodCombo_Dropdown_ID_Locator));
                base.SelectDropDownValueThroughIndexById(Employee_personaldetailsResource.
                    EmployeepersonaldetailsPage_PaymentMethodCombo_Dropdown_ID_Locator, 1);


                base.WaitForElement(By.Id(Employee_personaldetailsResource.
                    EmployeepersonaldetailsPage_BankAccountNumberText_Textbox_ID_Locator));
                base.ClearTextById(Employee_personaldetailsResource.
                    EmployeepersonaldetailsPage_BankAccountNumberText_Textbox_ID_Locator);
                base.FillTextBoxById(Employee_personaldetailsResource.
                    EmployeepersonaldetailsPage_BankAccountNumberText_Textbox_ID_Locator,
                    Employee_personaldetailsResource.
                    EmployeepersonaldetailsPage_BankAccountNumberText_Textbox_Text);


                base.WaitForElement(By.Id(Employee_personaldetailsResource.
                    EmployeepersonaldetailsPage_BSBNumberText_Textbox_ID_Locator));
                base.ClearTextById(Employee_personaldetailsResource.
                    EmployeepersonaldetailsPage_BSBNumberText_Textbox_ID_Locator);
                base.FillTextBoxById(Employee_personaldetailsResource.
                    EmployeepersonaldetailsPage_BSBNumberText_Textbox_ID_Locator,
                    Employee_personaldetailsResource.
                    EmployeepersonaldetailsPage_BSBNumberText_Textbox_Text);

                base.WaitForElement(By.Id("EFTRemittanceMethodCombo"));
                base.SelectDropDownValueThroughIndexById("EFTRemittanceMethodCombo", 5);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
        }

        /// <summary>
        /// Stores User Details in Memory.
        /// </summary>
        /// <param name="userTypeEnum">This is User by Type.</param>
        /// <param name="userInformation">This is User Information Guid.</param>        
        public void StoreUserDetails(User.UserTypeEnum userTypeEnum, string givenNameGUID,
                string surnameGUID, string otherNameGUID, string tenDigitMobileRandomNumbers,
                string preferredEmail, string gESBMenberNumber)
        {
            //Stores User Details in Memory

            Logger.LogMethodEntry("AddUserPage", "StoreUserDetails"
                , base.IsTakeScreenShotDuringEntryExit);
            //Store User Details in Memory
            this.StoreUserDetailsInMemory(userTypeEnum, givenNameGUID,
                surnameGUID, otherNameGUID, tenDigitMobileRandomNumbers,
                preferredEmail, gESBMenberNumber);
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
        private void StoreUserDetailsInMemory(User.UserTypeEnum userTypeEnum,
            string givenNameGUID, string surnameGUID, string otherNameGUID, string tenDigitMobileRandomNumbers,
               string preferredEmail, string gESBMenberNumber)
        {
            //Save user in Memory
            Logger.LogMethodEntry("AddUserPage", "StoreUserDetailsInMemory",
                base.IsTakeScreenShotDuringEntryExit);
            //Save User Properties in Memory
            //Save user Details
            this.SaveUserInMemory
             (userTypeEnum, givenNameGUID,
                surnameGUID, otherNameGUID, tenDigitMobileRandomNumbers,
                preferredEmail, gESBMenberNumber);

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
        private void SaveUserInMemory(User.UserTypeEnum userTypeEnum, string givenNameGUID,
               string surnameGUID, string otherNameGUID, string tenDigitMobileRandomNumbers,
               string preferredEmail, string gESBMenberNumber)
        {
            //Save The User In Memory
            Logger.LogMethodEntry("AddUserPage", "SaveUserInMemory",
              base.IsTakeScreenShotDuringEntryExit);
            User newUser = new User
            {
                Email = preferredEmail,
                OtherName = otherNameGUID,
                Surname = surnameGUID.ToString(),
                GivenName = givenNameGUID,
                MemberNumber = gESBMenberNumber,
                UserType = userTypeEnum,
                IsCreated = true,
            };
            
            //Save The User In Memory
            newUser.StoreUserInMemory();
            string sn = User.Get(userTypeEnum).Surname.ToString();
            Logger.LogMethodExit("AddUserPage", "SaveUserInMemory",
              base.IsTakeScreenShotDuringEntryExit);
        }

        public static string GetTenDigitMobileRandomNumbers()
        {
            Random generator = new Random();
            return generator.Next(0, 1000000).ToString("D10");
        }

        /// <summary>
        /// This methord is to generate the GUID for course name
        /// </summary>
        /// <param name="courseType">This is course choosen to create.</param>
        private string GenerateGivenNameGUID()
        {
            Logger.LogMethodEntry("HEDGlobalHomePage", "GenerateGivenNameGUID"
        , base.IsTakeScreenShotDuringEntryExit);
            // Generate GUID for course
            Guid UserGUID = Guid.NewGuid();
            //Get the system date
            String date = DateTime.Now.ToString("yyyy/MM/dd");
            //Fetch the random value
            string randomValue = UserGUID.ToString().Split('-')[0];
            //Store empty value to courseNameGUID variable
            string givenNameGUID = string.Empty;
            //Append the data and New Course string
            givenNameGUID = "Auto-" + date + "-" + randomValue + "-GivenName" + "-CometUser";
            //Store the course name to inmemory
            // this.StoreCourseGUID(givenNameGUID, usetType);
            Logger.LogMethodExit("HEDGlobalHomePage", "GenerateCourseGUID"
            , base.IsTakeScreenShotDuringEntryExit);
            //Return the course name
            return givenNameGUID;
        }

        /// <summary>
        /// This methord is to generate the GUID for course name
        /// </summary>
        /// <param name="courseType">This is course choosen to create.</param>
        private string GeneratePreferredNameGUID()
        {
            Logger.LogMethodEntry("HEDGlobalHomePage", "GenerateGivenNameGUID"
        , base.IsTakeScreenShotDuringEntryExit);
            // Generate GUID for course
            Guid UserGUID = Guid.NewGuid();
            //Get the system date
            String date = DateTime.Now.ToString("yyyy/MM/dd");
            //Fetch the random value
            string randomValue = UserGUID.ToString().Split('-')[0];
            string preferredNameGUID = string.Empty;
            //Append the data and New Course string
            preferredNameGUID = "Auto-" + date + "-" + randomValue + "-PreferredName" + "-CometUser";
            //Store the course name to inmemory
            // this.StoreCourseGUID(givenNameGUID, usetType);
            Logger.LogMethodExit("HEDGlobalHomePage", "GenerateCourseGUID"
            , base.IsTakeScreenShotDuringEntryExit);
            //Return the course name
            return preferredNameGUID;
        }


        /// <summary>
        /// This methord is to generate the GUID for course name
        /// </summary>
        /// <param name="courseType">This is course choosen to create.</param>
        private string GenerateSurnameGUID()
        {
            Logger.LogMethodEntry("HEDGlobalHomePage", "GenerateGivenNameGUID"
        , base.IsTakeScreenShotDuringEntryExit);
            // Generate GUID for course
            Guid UserGUID = Guid.NewGuid();
            //Get the system date
            String date = DateTime.Now.ToString("yyyy/MM/dd");
            //Fetch the random value
            string randomValue = UserGUID.ToString().Split('-')[0];
            //Store empty value to courseNameGUID variable
            string surnameGUID = string.Empty;
            //Append the data and New Course string
            surnameGUID = "Auto-" + date + "-" + randomValue + "-Surname" + "-CometUser";
            //Store the course name to inmemory
            // this.StoreCourseGUID(givenNameGUID, usetType);
            Logger.LogMethodExit("HEDGlobalHomePage", "GenerateCourseGUID"
            , base.IsTakeScreenShotDuringEntryExit);
            //Return the course name
            return surnameGUID;
        }


        /// <summary>
        /// This methord is to generate the GUID for course name
        /// </summary>
        /// <param name="courseType">This is course choosen to create.</param>
        private string GenerateOtherNameGUID()
        {
            Logger.LogMethodEntry("HEDGlobalHomePage", "GenerateGivenNameGUID"
        , base.IsTakeScreenShotDuringEntryExit);
            // Generate GUID for course
            Guid UserGUID = Guid.NewGuid();
            //Get the system date
            String date = DateTime.Now.ToString("yyyy/MM/dd");
            //Fetch the random value
            string randomValue = UserGUID.ToString().Split('-')[0];
            //Store empty value to courseNameGUID variable
            string otherNameGUID = string.Empty;
            //Append the data and New Course string
            otherNameGUID = "Auto-" + date + "-" + randomValue + "-OtherName" + "-CometUser";
            //Store the course name to inmemory
            // this.StoreCourseGUID(givenNameGUID, usetType);
            Logger.LogMethodExit("HEDGlobalHomePage", "GenerateCourseGUID"
            , base.IsTakeScreenShotDuringEntryExit);
            //Return the course name
            return otherNameGUID;
        }

        /// <summary>
        /// Click on option name in popup
        /// </summary>
        /// <param name="optionName">This is option name.</param>
        /// <param name="popupName">This is popup name.</param>
        public void ClickOnButtonInPopup(string optionName, string popupName)
        {
            Logger.LogMethodEntry("Employee_personaldetailsPage", "ClickOnButtonInPopup",
                base.IsTakeScreenShotDuringEntryExit);
            try
            {
                base.WaitUntilPopUpLoads(popupName);
                base.SwitchToIFrameByName("frmMain");
                base.WaitForElement(By.Name("cancel"));
                IWebElement getCancelButton = base.GetWebElementProperties(By.Name("cancel"));
                base.ClickByJavaScriptExecutor(getCancelButton);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("Employee_personaldetailsPage", "ClickOnButtonInPopup",
                base.IsTakeScreenShotDuringEntryExit);
        }

    }
}