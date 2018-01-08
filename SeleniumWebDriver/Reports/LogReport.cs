using SeleniumWebdriver.Settings;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumWebDriver.Reports
{
   public class LogReport
    {
        public static string path;
        public static void CreateLogFile()
        {
            path = ObjectRepository.ParentResultPath + "//Logfile.txt";
            LogReport.WritePass("******"+ObjectRepository.Testcasename+"*********");
        }

        public static void WritePass(string ps)
        {
            StreamWriter sw = null;
            if (System.IO.File.Exists(path))
            {
                sw = File.AppendText(path);
            }
            else
            {
                sw = File.CreateText(path);
            }
            sw.WriteLine(DateTime.Now.ToString()+ "  "+ps );
            sw.Close();
        }

        public static void WriteError(string ps)
        {
            StreamWriter sw = null;
            if (System.IO.File.Exists(path))
            {
                sw = File.AppendText(path);
            }
            else
            {
                sw = File.CreateText(path);
            }
            sw.WriteLine(DateTime.Now.ToString() + "--ERROR : ===" + ps + " ===");
            sw.Close();
        }
    }
}
