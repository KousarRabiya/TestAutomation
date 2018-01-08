using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebServiceTestProject.Reports
{
    class LogReport
    {
        public static string path;
        public static void CreateLogFile(TestContext TestContext)

        {
            path = PropertiesReference.Properties.ParentPath  +@"Logfile_"+ DateTime.Now.ToString("yyyy-MM-dd_hh-mm-ss") + ".txt";
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
            sw.WriteLine(DateTime.Now.ToString() + "--INFO : ===" + ps + " ===");
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
