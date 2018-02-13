using MMSG.Automation;
using MMSG.Automation.DataTransferObjects;
using MMSG.Automation.Exceptions;
using OpenQA.Selenium;
using System;

namespace MMSG.Pages.UI_Pages.ROL.Home.Dashboard
{
    public class ContactPage : BasePage
    {
        /// <summary>
        /// The static instance of the logger for the class.
        /// </summary>
        private static readonly Logger Logger =
            Logger.GetInstance(typeof(ContactPage));


        public bool ValidateUserDetailsinYourDetails(User.UserTypeEnum userType)
        {
            Logger.LogMethodEntry("ContactPage", "ValidateUserDetailsinYourDetails",base.IsTakeScreenShotDuringEntryExit);
            bool getUserDetailsExistance = false;
            try
            {
                User user = User.Get(userType);
                string getUserFirstName = user.LastName.ToString();
                string getSurname = user.Surname.ToString();
                string getPhoneName = user.Phone.ToString();
                string getEmail = user.Email.ToString();


                bool getFirstNameExistance = this.getFirstNameExistanceStatus(getUserFirstName);
                bool getSurnameExistance = this.getSurnameExistanceStatus(getSurname);
                bool getPhoneExistance = this.getPhoneNumberExistanceStatus(getPhoneName);
                bool getEmailExistance = this.getEmailExistanceStatus(getEmail);
                
                if(getFirstNameExistance == true && getSurnameExistance == true && getPhoneExistance == true && getEmailExistance == true)
                {
                    getUserDetailsExistance = true;
                }
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodEntry("ContactPage", "ValidateUserDetailsinYourDetails", base.IsTakeScreenShotDuringEntryExit);
            return getUserDetailsExistance;
        }

        public bool getFirstNameExistanceStatus(string getUserFirstName)
        {
            bool getFirstNameExistance = false;
            string getFirstName = base.GetInnerTextAttributeValueById("Firstname");

            if(getFirstName.Equals(getUserFirstName))
            {
                getFirstNameExistance = true;
            }
            return getFirstNameExistance;
        }


        public bool getSurnameExistanceStatus(string getUserSurname)
        {
            bool getSurnameExistance = false;
            string getFirstName = base.GetInnerTextAttributeValueById("Surname");

            if (getFirstName.Equals(getUserSurname))
            {
                getSurnameExistance = true;
            }
            return getSurnameExistance;
        }

        public bool getPhoneNumberExistanceStatus(string getUserPhoneNumber)
        {
            bool getPhoneExistance = false;
            string getPhoneNumber = base.GetValueAttributeById("Phone");

            if (getPhoneNumber.Equals(getUserPhoneNumber))
            {
                getPhoneExistance = true;
            }
            return getPhoneExistance;
        }

        public bool getEmailExistanceStatus(string getUserEmail)
        {
            bool getEmailExistance = false;
            string getEmail = base.GetValueAttributeById("Email");

            if (getEmail.Equals(getUserEmail))
            {
                getEmailExistance = true;
            }
            return getEmailExistance;

        }

        /// <summary>
        /// Method Verify that the dropdown is present 
        /// </summary>
        /// <param name="dropDownName"></param>
        /// <returns>Returns true idf the element present</returns>
        public bool ValidateDropDownIsPresent(string dropDownName)
        {
            Logger.LogMethodEntry("ContactPage", "ValidateUserDetailsinYourDetails", base.IsTakeScreenShotDuringEntryExit);
            try
            {
                switch (dropDownName)
                {
                    case "I want to":
                        return base.IsElementPresent(By.XPath(ContactResource.ContactPage_IWantToButton_Xpath_Locator));
                    case "Change":
                        return base.IsElementPresent(By.XPath(ContactResource.ContactPage_ChangeButton_Xpath_Locator));
                    case "Add benefit":
                        return base.IsElementPresent(By.XPath(ContactResource.ContactPage_AddBenefitButton_Xpath_Locator));
                    case "Deduction per pay":
                        return base.IsElementPresent(By.XPath(ContactResource.ContactPage_PayDeductionTextBox_Xpath_Locator));
                    case "Pay date for change":
                        return base.IsElementPresent(By.XPath(ContactResource.ContactPage_PayDeductionTextBox_Xpath_Locator));

                }
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            return false;
           
        }

        /// <summary>
        /// Click on the dropdown  button presnt on the contact us page 
        /// </summary>
        /// <param name="dropDownOption"></param>
        /// <param name="dropDownName"></param>
        public void ClickOnDropDown(string dropDownOption, string dropDownName)
        {
            Logger.LogMethodEntry("ContactPage", "ValidateUserDetailsinYourDetails", base.IsTakeScreenShotDuringEntryExit);
            try
            {
                switch (dropDownName)
                {
                    case "I want to":
                        base.ClickButtonByXPath(ContactResource.ContactPage_IWantToButton_Xpath_Locator);
                        SelectTheDropDown(dropDownOption);
                        break;
                    case "Change":
                        base.ClickButtonByXPath(ContactResource.ContactPage_ChangeButton_Xpath_Locator);
                        SelectTheDropDown(dropDownOption);
                        break;
                    case "Add benefit":
                        base.ClickButtonByXPath(ContactResource.ContactPage_AddBenefitButton_Xpath_Locator);
                        SelectTheDropDown(dropDownOption);
                        break;
                    case "Pay date for change":
                        base.ClickButtonByXPath(ContactResource.ContactPage_PayDateForChangesDropDown_Xpath_Locator);
                        SelectTheDropDown(dropDownOption);
                        break;
                }
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
        }
        
        /// <summary>
        /// Select the drop down option in the dropdown button 
        /// </summary>
        /// <param name="dropDownOption"></param>
        public void SelectTheDropDown(string dropDownOption)
        {
            Logger.LogMethodEntry("ContactPage", "SelectTheDropDown", base.IsTakeScreenShotDuringEntryExit);
            base.ClickLinkByPartialLinkText(dropDownOption);
        }

        /// <summary>
        /// Enters value to the text box
        /// </summary>
        public void EnterValueToTextBox(string textBoxName)
        {
            Logger.LogMethodEntry("ContactPage", "ValidateUserDetailsinYourDetails", base.IsTakeScreenShotDuringEntryExit);
            try
            {
                switch (textBoxName)
                {
                    case "Amount":
                        base.ClearTextByXPath(ContactResource.ContactPage_PayDeductionTextBox_Xpath_Locator);
                        base.FillTextBoxByXPath(ContactResource.ContactPage_PayDeductionTextBox_Xpath_Locator, ContactResource.ContactPage_PayDeductionTextBox_Amount_Value);
                        break;
                    case "Phone":
                        base.ClearTextById(ContactResource.ContactPage_PhoneNumberTextBox_ID_Locator);
                        base.FillTextBoxById(ContactResource.ContactPage_PhoneNumberTextBox_ID_Locator, ContactResource.ContactPage_PhoneNumberTextBox_PhoneNumber_Value);
                        break;
                    case "Email":
                        base.ClearTextById(ContactResource.ContactPage_EmailIdTextBox_ID_Locator);
                        base.FillTextBoxById(ContactResource.ContactPage_EmailIdTextBox_ID_Locator, ContactResource.ContactPage_EmailId_Email_Value);
                        break;
                    case "Message":
                        base.ClearTextById(ContactResource.ContactPage_Messagel_ID_Locator);
                        base.FillTextBoxById(ContactResource.ContactPage_Messagel_ID_Locator, ContactResource.ContactPage_Messagel_Message_Value);
                        break;
                }
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }

        }

        /// <summary>
        /// Selelct the radio button 
        /// </summary>
        /// <param name="deductionOption"></param>
        public void SelectRadioButton(string radioButtonNmae)
        {
            Logger.LogMethodEntry("ContactPage", "ValidateUserDetailsinYourDetails", base.IsTakeScreenShotDuringEntryExit);
            try
            {
                switch (radioButtonNmae)
                {
                    case "Once off deduction":
                        base.ClickButtonById(ContactResource.ContactPage_PayDeductionRadioButtonOncesOffDeduction_ID_Locator);
                        break;
                    case "Ongoing deduction":
                        base.ClickButtonById(ContactResource.ContactPage_PayDeductionRadioButtonOnGoingDeduction_ID_Locator);
                        break;
                    case "Select a pay date":
                        base.ClickButtonById(ContactResource.ContactPage_PayDateChangeSelectPayDate_ID_Locator);
                        break;
                    case "Next pay date for change":
                        base.ClickButtonById(ContactResource.ContactPage_NextPayDateForChange_ID_Locator);
                        break;
                    case "Phone":
                        base.ClickButtonById(ContactResource.ContactPage_PreferredPhone_ID_Locator);
                        break;
                    case "Email":
                        base.ClickButtonById(ContactResource.ContactPage_PreferredEmail_ID_Locator);
                        break;
                }
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }

        }

        /// <summary>
        /// Clicking on the Button
        /// </summary>
        /// <param name="buttonName"></param>
        public void ClickOnButton(string buttonName)
        {
            Logger.LogMethodEntry("ContactPage", "ValidateUserDetailsinYourDetails", base.IsTakeScreenShotDuringEntryExit);
            try
            {
                switch (buttonName)
                {
                    case "Submit":
                        base.ClickButtonById(ContactResource.ContactPage_SubmitButtonl_ID_Locator);
                        break;
                }
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
        }

        /// <summary>
        /// Verify the Message is present or not. If present it returns true.
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>

        public bool VerifyTheMessage(string message)
        {
            Logger.LogMethodEntry("ContactPage", "ValidateUserDetailsinYourDetails", base.IsTakeScreenShotDuringEntryExit);
            try
            {
                string messageOnWebPage = base.GetElementInnerTextByXPath(ContactResource.ContactPage_SuccessMessage_Xpath_Locator);
                if (messageOnWebPage == message)
                {
                    return true;
                }
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            return false;
        }

    }
}
