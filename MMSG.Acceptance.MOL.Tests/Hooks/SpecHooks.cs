//using AventStack.ExtentReports;
//using AventStack.ExtentReports.Reporter;
//using AventStack.ExtentReports.Reporter.Configuration;
//using NUnit.Framework;
//using MMSG.Automation.ComponentHelper;
//using MMSG.Automation.Settings;
//using System;
//using System.Configuration;
//using TechTalk.SpecFlow;

//namespace MOLProject
//{
//    [Binding]
//    public sealed class SpecHooks
//    {
//        public static ExtentReports extent;
//        public static ExtentHtmlReporter htmlReporter;
//        public static ExtentTest extentTest;

//        [BeforeTestRun]
//        public static void BeforeTestRun()
//        {
//            ObjectRepository.ServerName = ConfigurationManager.AppSettings["ServerName"];
//            ObjectRepository.DataBaseName = ConfigurationManager.AppSettings["DataBaseName"];

//            ObjectRepository.ProjectName = "MOL";
//            string curPath = GenericHelper.CurrentDirectory(); 
//            string currentTime = DateTime.Now.ToString("yyyy-MM-dd_hh-mm-ss");

//            string ResultPath = curPath + "\\Result Folder\\MOL_" + currentTime;
//            ObjectRepository.ParentResultPath = ResultPath;
//            GenericHelper.CreatFolder(ResultPath);

//            htmlReporter = new ExtentHtmlReporter(ResultPath + "\\Report.html");
//            htmlReporter.Configuration().Theme = Theme.Standard;

//            htmlReporter.Configuration().DocumentTitle = "HTML Report";
//            htmlReporter.Configuration().ReportName = "Execution Report";
//            extent = new ExtentReports();
//            extent.AttachReporter(htmlReporter);
            
//            // Creating the Log file
//            MMSG.Automation.Reports.LogReport.CreateLogFile();
//        }

//        [BeforeScenario]
//        public void BeforeScenario()
//        {
//            string TCfolder = ScenarioContext.Current.ScenarioInfo.Title;
//            ObjectRepository.TestCasesStepNumber = 1;
//            ObjectRepository.ResultPath = ObjectRepository.ParentResultPath + "\\" + TCfolder;
//            GenericHelper.CreatFolder(ObjectRepository.ResultPath);

//            ObjectRepository.DriverName = ConfigurationManager.AppSettings["Browser"];
//            ObjectRepository.ScreenShot = ConfigurationManager.AppSettings["ScreenShot"];
//            ObjectRepository.URL = ConfigurationManager.AppSettings["Website"];

//            ObjectRepository.Testcasename=TestContext.CurrentContext.Test.Name;
//            extentTest = extent.CreateTest(ScenarioContext.Current.ScenarioInfo.Title);
//            GenericHelper.KillProcess(ObjectRepository.DriverName);

//            // Getting the data from Excel           
//            MMSG.Automation.ExcelOperation.ExcelOperation.FetchDatafromExcel();
//            AppConfigKeys.AppSetting();
//            MMSG.Automation.Reports.LogReport.WritePass("Scenario :" + ScenarioContext.Current.ScenarioInfo.Title);
//        }

//        [AfterScenario]
//        public void AfterScenario()
//        {
//            ObjectRepository.Driver.Quit();
//            GenericHelper.KillProcess(ObjectRepository.DriverName);
//            extent.Flush();
//            MMSG.Automation.Reports.LogReport.WritePass("****************");           
//        }

//        [AfterStep]
//        public void AfterEachStep()
//        {
//            //Checking the Screen short flag
//            if (ObjectRepository.ScreenShot == "All")
//            {
//                GenericHelper.TakeScreenshot("",ObjectRepository.Driver);
//            }            
//        }

//        [BeforeStep]
//        public void BeforeachStep()
//        {
//            ObjectRepository.TestcasesStep = ScenarioContext.Current.StepContext.StepInfo.Text;
//            MMSG.Automation.Reports.LogReport.WritePass(ScenarioContext.Current.StepContext.StepInfo.Text);
//        }
//    }
//}
