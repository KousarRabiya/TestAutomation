using MMSG.Automation.Settings;
using System.Collections.Generic;
using System.IO;

namespace MMSG.Automation.ExcelOperation
{
    public class ExcelOperation
    {
        public static Dictionary<int, string> GetData;
        public static Dictionary<int, string> GetGivenName;
        public static string path;
        public static void FetchDatafromExcel()
        {
            DirectoryInfo currentDir = new DirectoryInfo(Directory.GetCurrentDirectory());

            path = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location).Replace("\\bin\\Debug", "") + "\\Input Files\\TestData.xlsx";

            System.Data.OleDb.OleDbConnection MyConnection;

            string sqlTest = null;
            MyConnection = new System.Data.OleDb.OleDbConnection("provider=Microsoft.ACE.OLEDB.12.0;Data Source='" + path + "'; Extended Properties='Excel 12.0; HDR = YES'");
            MyConnection.Open();
            sqlTest = "select * from  [" + ObjectRepository.ProjectName + "$] where TestCasesName =\"" + ObjectRepository.Testcasename + "\"";
            System.Data.OleDb.OleDbCommand TestCommand = new System.Data.OleDb.OleDbCommand(sqlTest, MyConnection);
            System.Data.OleDb.OleDbDataReader TestReader = TestCommand.ExecuteReader();

            GetData = new Dictionary<int, string>();
            while (TestReader.Read())
            {
                int i = 1;
                for (int Row = 1; Row < TestReader.FieldCount; Row++)
                {
                    GetData.Add(i, TestReader.GetValue(Row).ToString().Trim());
                    i++;
                }

            }

            TestReader.Close();

        }
        public static void AddData(string Key, string Value, string TestCasesName)
        {
            string sql = null;
            path = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location).Replace("\\bin\\Debug", "") + "\\Input Files\\TestData.xlsx";

            System.Data.OleDb.OleDbConnection MyConnection;

            System.Data.OleDb.OleDbCommand myCommand = new System.Data.OleDb.OleDbCommand();
            MyConnection = new System.Data.OleDb.OleDbConnection("provider=Microsoft.ACE.OLEDB.12.0;Data Source='" + path + "'; Extended Properties='Excel 12.0; HDR = YES'");
            MyConnection.Open();
            myCommand.Connection = MyConnection;

            sql = "update [COMET$] set " + Key + "=\"" + Value + "\" where  TestCasesName =\"" + TestCasesName + "\"";

            myCommand.CommandText = sql;
            myCommand.ExecuteNonQuery();
            MyConnection.Close();
        }
        public static string FetchGivenNamefromExcel(string TestName)
        {
            DirectoryInfo currentDir = new DirectoryInfo(Directory.GetCurrentDirectory());
            path = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location).Replace("\\bin\\Debug", "") + "\\Input Files\\TestData.xlsx";

            System.Data.OleDb.OleDbConnection MyConnection;

            string sqlTest = null;
            MyConnection = new System.Data.OleDb.OleDbConnection("provider=Microsoft.ACE.OLEDB.12.0;Data Source='" + path + "'; Extended Properties='Excel 12.0; HDR = YES'");
            MyConnection.Open();

            sqlTest = "select * from  [" + ObjectRepository.ProjectName + "$] where TestCasesName =\"" + TestName + "\"";
            System.Data.OleDb.OleDbCommand TestCommand = new System.Data.OleDb.OleDbCommand(sqlTest, MyConnection);
            System.Data.OleDb.OleDbDataReader TestReader = TestCommand.ExecuteReader();

            GetGivenName = new Dictionary<int, string>();
            while (TestReader.Read())
            {
                int i = 1;
                for (int Row = 1; Row < TestReader.FieldCount; Row++)
                {
                    GetGivenName.Add(i, TestReader.GetValue(Row).ToString().Trim());
                    i++;
                }
            }
            TestReader.Close();
            return GetGivenName[2].ToString();            
        }
    }
}
