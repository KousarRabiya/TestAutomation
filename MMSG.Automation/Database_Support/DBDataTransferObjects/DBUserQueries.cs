using MMSG.Automation.DataTransferObjects;
using Pegasus_DataAccess.Database_Support;
using System;
using System.Collections.Generic;

namespace MMSG.Automation.Database_Support.DBDataTransferObjects
{
    public class DBUserQueries : DatabaseTools
    {
        /// <summary>
        /// Get employer number based on the surname
        /// </summary>
        /// <param name="role">This is usertype enum.</param>
        /// <returns>Return employee number.</returns>
        public string GetEmployeeNumberBySurName(User.UserTypeEnum role)
        {
            string employeeNumber = string.Empty;

            try
            {

               User user = User.Get(role);
                string surName = user.Surname.ToString();
                switch (role)
                {
                    // Purpose: Query To Retrieve Username for Ws Admin
                    case User.UserTypeEnum.COMETUser:
                    case User.UserTypeEnum.NewCOMETUser:
                        employeeNumber = GetdataDb(strConnection,
                                             "SELECT Top 1 CONCAT(iEmployeeExtIDBase , iEmployeeExtIDCheckDigit) as iEmployeeID FROM tbl_Employee WHERE sSurname ='" + surName + "'",
                                             "iEmployeeID");
                        break;

                }
                return employeeNumber;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
