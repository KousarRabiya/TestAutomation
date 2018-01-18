using MMSG.Automation;
using MMSG.Automation.DataTransferObjects;
using MMSG.Automation.Exceptions;
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
    }
}
