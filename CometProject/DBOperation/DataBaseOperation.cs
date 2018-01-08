using System;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Xml;

namespace SeleniumWebDriver.DBOperation
{
    public class DataBaseOperation
    {
        static SqlConnection conn = new SqlConnection();
        static string connString = ConfigurationManager.ConnectionStrings["CometDBConnStr"].ConnectionString;

        /// <summary>
        /// Sets DB connection
        /// </summary>
        /// <param name="conn"></param>
        private static void SetupDbConnection(SqlConnection conn)
        {
            conn.ConnectionString = ConfigurationManager.ConnectionStrings["CometDBConnStr"].ConnectionString;
            conn.Open();
        }

        /// <summary>
        /// Set up query and parameters 
        /// </summary>
        /// <param name="conn"></param>
        /// <returns></returns>
        private static SqlCommand SendQueryAndParametersToDb(SqlConnection conn)
        {
            SqlCommand command;
            SetupDbConnection(conn);

            command = new SqlCommand("SELECT CONCAT(iEmployeeExtIDBase , iEmployeeExtIDCheckDigit) as EmployeeNo FROM tbl_Employee where sGivenName = @0", conn);
            command.Parameters.Add(new SqlParameter("0", ExcelOperation.ExcelOperation.FetchGivenNamefromExcel("TC1_CreateAnEmployee")));

            return command;
        }

        /// <summary>
        /// Reads data from database
        /// </summary>
        /// <returns></returns>
        public static string ReadData()
        {
            SqlCommand command;
            string empNo = "";
            using (SqlConnection conn = new SqlConnection())
            {
                command = SendQueryAndParametersToDb(conn);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        empNo = reader[0].ToString();
                    }
                }
            }
            return empNo;
        }

        /// <summary>
        /// Gets data from database
        /// </summary>
        /// <param name="connString"></param>
        /// <param name="selectionQuery"></param>
        /// <param name="columnName"></param>
        /// <returns></returns>
        public static string GetDataFromDb(string connString, string selectionQuery, string columnName)
        {
            try
            {
                SqlDataReader myReader = null;
                string value = null;

                // Creating SQL Connection
                SqlConnection myConnection = new SqlConnection(connString);
                myConnection.Open();

                SqlCommand myCommand = new SqlCommand(selectionQuery, myConnection);
                myReader = myCommand.ExecuteReader();

                while (myReader.Read())
                {
                    value = myReader[columnName].ToString();
                }
                myCommand.Connection.Close();
                myConnection.Close();
                return value;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Gets the search results
        /// </summary>
        /// <param name="searchOption"></param>
        /// <returns></returns>
        public static string GetSearchResults(string searchOption)
        {
            try
            {
                string searchResult = string.Empty;
                XmlDocument xmldoc = new XmlDocument();
                
                xmldoc.Load(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location).Replace("\\bin\\Debug", "") + @"\Input Files\DBQueries.xml");
                XmlNode node = xmldoc["Queries"];

                switch (searchOption)
                {
                    case "EmpNum":
                        searchResult = GetDataFromDb(connString, node.ChildNodes[0].InnerText,"EmployeeNo");
                        break;
                    case "EmpCode":
                        searchResult = GetDataFromDb(connString, node.ChildNodes[1].InnerText,"sCode");
                        break;
                }                
                return searchResult;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
