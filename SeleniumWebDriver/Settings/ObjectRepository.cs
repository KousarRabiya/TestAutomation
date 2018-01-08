using OpenQA.Selenium;
using SeleniumWebdriver.Interfaces;

namespace SeleniumWebdriver.Settings
{
    public class ObjectRepository
    {
        public static IConfig Config { get; set; }

        public static string ProjectName { get; set;}

        public static string Testcasename { get; set; }

        public static string DriverName { get;  set;}
             
        public static IWebDriver Driver { get; set; }

        public static string ScreenShot { get; set; }

        public static string ParentResultPath { get; set; }

        public static string ResultPath { get; set; }
        public static string Scenario { get; set; }

        public static string TestcasesStep { get; set; }
        public static int TestCasesStepNumber { get; set; }
        public static string URL { get; set; }

        public static string User { get; set; }
        public static string ServerName { get; set; }
        public static string DataBaseName { get; set; }
        
        // page objects

        // public static HomePage hPage;
    }
}
