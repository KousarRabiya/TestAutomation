using System.Configuration;
using System.Data.SqlClient;
using System;
using MMSG.Automation.DataTransferObjects;
using MMSG.Automation;

namespace Pegasus_DataAccess.Database_Support
{
    public class DatabaseTools
    {
        // Purpose: Fetch Connection String
        static SqlConnection conn = new SqlConnection();
        static string DBConnString = AutomationConfigurationManager.ApplicationTestEnvironment.ToUpper() + "DBConnStr";
        public static readonly string strConnection = ConfigurationManager.ConnectionStrings[DBConnString].ConnectionString;

        
        //COMETUATDBConnStr

        //Purpose: Method To Get Last Single Column Data
        public static string GetdataDb(string connString, 
            string selecTionQuery, string columnName)
        {
            try
            {
                // Purpose: Creating SQL Connection
                SqlConnection myConnection = new SqlConnection(connString);
                myConnection.Open();
                SqlDataReader myReader = null;
                SqlCommand myCommand = new SqlCommand(selecTionQuery, myConnection);
                myReader = myCommand.ExecuteReader();
                string value1 = null;
                while (myReader.Read())
                {
                    value1 = myReader[columnName].ToString();
                }
                myCommand.Connection.Close();
                myConnection.Close();
                return value1;
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        //Purpose: Method To Execute query To Connecting DB
        public static void ExecuteQueryDb(string connString, string insertQuery)
        {
            try
            {
                // Purpose: Creating SQL Connection
                SqlConnection myConnection = new SqlConnection(connString);
                myConnection.Open();
                SqlCommand myCommand = new SqlCommand(insertQuery, myConnection);
                myCommand.ExecuteNonQuery();
                myCommand.Connection.Close();
                myConnection.Close();
            }
            catch (Exception e)
            {
                throw e;
            }
        }


        //Purpose: Method to Fetch SQLConnection DB
        public static SqlConnection GetSqlConnection()
        {
            try
            {
                // Purpose: Creating SQL Connection
                string connectionString = DatabaseTools.strConnection;
                var sqlConnection = new SqlConnection(connectionString);
                return sqlConnection;
            }
            catch (SqlException e)
            {
                throw new Exception(e.ToString());
            }
        }
    }
}