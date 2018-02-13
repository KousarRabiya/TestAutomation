using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMSG.Automation.DataTransferObjects
{
   public class User : BaseEntityObject
    {
        /// <summary>
        /// This is the password.
        /// </summary>
        public String Password { get; set; }

        /// <summary>
        /// This is the email of the user.
        /// </summary>
        public String Email { get; set; }

        /// <summary>
        /// This is the othername of the user.
        /// </summary>
        public string OtherName { get; set; }

        /// <summary>
        /// This is the Surname of the user.
        /// </summary>
        public String Surname { get; set; }

        /// <summary>
        /// This is the Phone number of the user.
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        /// This is the first name of the user.
        /// </summary>
        public String FirstName { get; set; }

        /// <summary>
        /// This is the middle name of the user.
        /// </summary>
        public String MiddleName { get; set; }

        /// <summary>
        /// This is the last name of the user.
        /// </summary>
        public String LastName { get; set; }

        /// <summary>
        /// This is the enrolment status of the user.
        /// </summary>
        public bool EnrolementStatus { get; set; }

        /// <summary>
        /// This is Given name of the user.
        /// </summary>
        public string GivenName { get; set; }

        /// <summary>
        /// This is the Users Profile Date and Time.
        /// </summary>
        public DateTime CurrentProfileDateTime { get; set; }

        /// <summary>
        /// This is the email of the user.
        /// </summary>
        public String WorkSpaceName { get; set; }

        /// <summary>
        /// This is the Gender of the user.
        /// </summary>
        public string Gender { get; set;}

        /// <summary>
        /// This is user date of birth
        /// </summary>
        public DateTime DOB { get; set;}

        /// <summary>
        /// This is Employee Number of the user
        /// </summary>
        public string EmployeeNumber{ get; set; }

        /// <summary>
        /// This is Member number
        /// </summary>
        public string MemberNumber { get; set; }

        /// <summary>
        /// This is employer code for user
        /// </summary>
        public string EmployerCode { get; set; }

        /// <summary>
        /// This is the type of the user
        /// </summary>
        public enum UserTypeEnum
        {
            #region User Types
            ROLUser = 1,
            COMETUser=2,
            MOLUser=3,
            NewCOMETUser=4,
            ROLWalletTransactionUser =5,
            ROLNonWalletTransactionUser = 6,
            MOLWalletTransactionUser = 7,
            MOLNonWalletTransactionUser = 8,
            #endregion
        }


        /// <summary>
        /// This is the type of the user.
        /// </summary>
        public UserTypeEnum UserType { get; set; }

        /// <summary>
        /// This is the user Id.
        /// </summary>
        public string UserId { get; set; }

        /// <summary>
        /// This method selects users based on given condition.
        /// </summary>
        /// <param name="predicate">The condition</param>
        /// <returns>A list of users</returns>
        public static List<User> Get(Func<User, bool> predicate)
        {
            return InMemoryDatabaseSingleton.DatabaseInstance.SelectMany(predicate);
        }

        /// <summary>
        /// This method inserts a new user into the system.
        /// </summary>]
        public void StoreUserInMemory()
        {
            InMemoryDatabaseSingleton.DatabaseInstance.Insert(this);
        }

        /// <summary>
        /// This method is used to update the user.
        /// </summary>
        public void UpdateUserInMemory(User user)
        {
            InMemoryDatabaseSingleton.DatabaseInstance.Update(user);
        }

        /// <summary>
        /// This method selects a single user based on the role.
        /// </summary>
        /// <param name="userType">This is the user type.</param>
        /// <returns>A single user.</returns>
        public static User Get(UserTypeEnum userType)
        {
            return InMemoryDatabaseSingleton.DatabaseInstance.SelectMany
                <User>(x => x.UserType == userType && x.IsCreated).OrderByDescending(x => x.CreationDate).First();
        }

        /// <summary>
        /// This method gets the user based on User ID.
        /// </summary>
        /// <param name="userId">This is user ID.</param>
        /// <returns>User based on ID.</returns>
        public static User Get(string userId)
        {
            return InMemoryDatabaseSingleton.DatabaseInstance.SelectMany<User>(x => x.UserId == userId && x.IsCreated)
                .OrderByDescending(x => x.CreationDate).First();
        }

        /// <summary>
        /// This method is used to update the user's password.
        /// </summary>
        /// <param name="password">This is the password of the user.</param>
        public void UpdatePassword(string password)
        {
            User user = InMemoryDatabaseSingleton.DatabaseInstance.SelectTopOne<User>(x => x.Name == Name);
            user.Password = password;
        }

        /// <summary>
        /// This method returns all created users of the given type.
        /// </summary>
        /// <param name="userType">This is the type of the user.</param>
        /// <returns>User List.</returns>
        public static List<User> GetAll(UserTypeEnum userType)
        {
            return InMemoryDatabaseSingleton.DatabaseInstance.SelectMany<User>(
                x => x.UserType == userType).OrderByDescending(
                x => x.CreationDate).ToList();
        }
    }
}
