﻿using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports.Reporter.Configuration;
using NUnit.Framework;
using SeleniumWebdriver.ComponentHelper;
using SeleniumWebdriver.Settings;
using SeleniumWebDriver.Settings;
using System;
using System.Configuration;
using TechTalk.SpecFlow;

namespace ROLProject.Hook
{
    [Binding]
    public sealed class SpecFlowHook
    {
        public static ExtentReports extent;
        public static ExtentHtmlReporter htmlReporter;
        public static ExtentTest test;

        [BeforeTestRun]
        public static void BeforeTestRun()
        {
            ObjectRepository.ServerName = ConfigurationManager.AppSettings["ServerName"];
            ObjectRepository.DataBaseName = ConfigurationManager.AppSettings["DataBaseName"];

            ObjectRepository.ProjectName = "ROL";
            string curPath = GenericHelper.CurrentDirectory();
            string currentTime = DateTime.Now.ToString("yyyy-MM-dd_hh-mm-ss");

            string ResultPath = curPath + "\\Result Folder\\ROL_" + currentTime;
            ObjectRepository.ParentResultPath = ResultPath;
            GenericHelper.CreatFolder(ResultPath);

            htmlReporter = new ExtentHtmlReporter(ResultPath + "\\Report.html");
            htmlReporter.Configuration().Theme = Theme.Standard;
            htmlReporter.Configuration().DocumentTitle = "HTML Report";

            htmlReporter.Configuration().ReportName = "Execution Report";
            extent = new ExtentReports();
            extent.AttachReporter(htmlReporter);
            // Creating the Log file
            SeleniumWebDriver.Reports.LogReport.CreateLogFile();
        }
        
        [BeforeScenario]
        public void BeforeScenario()
        {
            string TCfolder = ScenarioContext.Current.ScenarioInfo.Title;
            ObjectRepository.TestCasesStepNumber = 1;
            ObjectRepository.ResultPath = ObjectRepository.ParentResultPath + "\\" + TCfolder;
            SeleniumWebdriver.ComponentHelper.GenericHelper.CreatFolder(ObjectRepository.ResultPath);

            ObjectRepository.DriverName = ConfigurationManager.AppSettings["Browser"];
            ObjectRepository.ScreenShot = ConfigurationManager.AppSettings["ScreenShot"];
            ObjectRepository.URL = ConfigurationManager.AppSettings["Website"];
            ObjectRepository.Testcasename = TestContext.CurrentContext.Test.Name;

            GenericHelper.KillProcess(ObjectRepository.DriverName);
            test = extent.CreateTest(ScenarioContext.Current.ScenarioInfo.Title);
            GenericHelper.KillProcess(ObjectRepository.DriverName);

            // Getting the data from Excel 
            SeleniumWebDriver.ExcelOperation.ExcelOperation.FetchDatafromExcel();
            AppConfigKeys.AppSetting();
            SeleniumWebDriver.Reports.LogReport.WritePass("Senario :"+ScenarioContext.Current.ScenarioInfo.Title);
        }

        [AfterScenario]
        public void AfterScenario()
        {
            ObjectRepository.Driver.Quit();
            GenericHelper.KillProcess(ObjectRepository.DriverName);
            // Writes into the HTML page
            extent.Flush();
            SeleniumWebDriver.Reports.LogReport.WritePass("****************");
            SeleniumWebDriver.Reports.LogReport.WritePass("****************");
        }
        [AfterStep]
        public void AfterEachStep()
        {
            //checking the Screeen shor flag
            if (ObjectRepository.ScreenShot == "All")
            {
                GenericHelper.TakeScreenshot("",ObjectRepository.Driver);
            }           
        }

        [BeforeStep]
        public void BeforeachStep()
        {
            ObjectRepository.TestcasesStep = ScenarioContext.Current.StepContext.StepInfo.Text;
            SeleniumWebDriver.Reports.LogReport.WritePass(ScenarioContext.Current.StepContext.StepInfo.Text);
        }
    }
}
