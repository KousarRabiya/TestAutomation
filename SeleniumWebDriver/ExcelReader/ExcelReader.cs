using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excel;

namespace SeleniumWebdriver.ExcelReader
{
    public class ExcelReaderHelper
    {
        private static IDictionary<string, IExcelDataReader> cache;
        private static FileStream stream;
        private static IExcelDataReader reader;

        static ExcelReaderHelper()
        {
            cache = new Dictionary<string, IExcelDataReader>();
        }

        private static IExcelDataReader GetExcelReader(string xlPath, string sheetName)
        {
            if (cache.ContainsKey(sheetName))
            {
                reader = cache[sheetName];
            }
            else
            {
                stream = new FileStream(xlPath, FileMode.Open, FileAccess.Read);
                reader = ExcelReaderFactory.CreateOpenXmlReader(stream);
                cache.Add(sheetName, reader);
            }
            return reader;
        }

        public static int GetTotalRows(string xlPath, string sheetName)
        {
            IExcelDataReader reader = GetExcelReader(xlPath, sheetName);
            return reader.AsDataSet().Tables[sheetName].Rows.Count;
        }

        public static object GetCellData(string xlPath, string sheetName, int row, int column)
        {

            IExcelDataReader reader = GetExcelReader(xlPath, sheetName);
            DataTable table = reader.AsDataSet().Tables[sheetName];
            return table.Rows[row][column];
        }

        private static object GetData(Type type, object data)
        {
            switch (type.Name)
            {
                case "String":
                    return data.ToString();
                case "Double":
                    return Convert.ToDouble(data);
                case "DateTime":
                    return Convert.ToDateTime(data);
                default:
                    return data.ToString();
            }
        }
    }
}
