using System;
using System.Configuration;
using SeleniumWebdriver.Interfaces;
using SeleniumWebDriver.Configuration;
using SeleniumWebDriver.Settings;
using SeleniumWebDriver;
using System.IO;

namespace SeleniumWebdriver
{
    public class AppConfigReader : IConfig
    {
        public BrowserType? GetBrowser()
        {
            string browser = ConfigurationManager.AppSettings.Get(AppConfigKeys.Browser);
            try
            {
                return (BrowserType)Enum.Parse(typeof(BrowserType), browser);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public int GetElementLoadTimeOut()
        {
            string timeout = ConfigurationManager.AppSettings.Get(AppConfigKeys.ElementLoadTimeout);
            if (timeout == null)
                return 30;
            return Convert.ToInt32(timeout);
        }

        public int GetPageLoadTimeOut()
        {
            string timeout = ConfigurationManager.AppSettings.Get(AppConfigKeys.PageLoadTimeout);
            if (timeout == null)
                return 30;
            return Convert.ToInt32(timeout);
        }

        public string GetPassword()
        {
            return ConfigurationManager.AppSettings.Get(AppConfigKeys.Password);
        }

        public string GetUsername()
        {
            return ConfigurationManager.AppSettings.Get(AppConfigKeys.Username);
        }

        public string GetWebsite()
        {
            return ConfigurationManager.AppSettings.Get(AppConfigKeys.Website);
        }

        /// <summary>
        /// Property course space url root.
        /// </summary>
        public static string CourseSpaceUrlRoot
        {
            get { return GetCourseSpaceUrlRoot(); }
        }

        /// <summary>
        /// Find course space url root based on application environment.
        /// </summary> 
        /// <returns>Application cs url.</returns>
        public static string GetCourseSpaceUrlRoot()
        {
            string applicationUrl;
            switch (Environment.GetEnvironmentVariable(AppConfigReaderResource.AUTOMATION_TEST_ENVIRONMENT_KEY.ToUpper())
                ?? ConfigurationManager.AppSettings[AppConfigReaderResource.TestEnvironment_Key].ToUpper())
            {
                case "COMETDEV":
                    applicationUrl = ConfigurationManager.AppSettings[AppConfigReaderResource.URLRootCometDev_Key];
                    break;
                case "COMETUAT":
                    applicationUrl = ConfigurationManager.AppSettings[AppConfigReaderResource.URLRootCometUAT_Key];
                    break;
                case "MOLUAT":
                    applicationUrl = ConfigurationManager.AppSettings[AppConfigReaderResource.URLRootMOLUAT_Key];
                    break;
                case "ROLCERT":
                    applicationUrl = ConfigurationManager.AppSettings[AppConfigReaderResource.URLRootROLCert_Key];
                    break;

                default: throw new ArgumentException("The suggested application environment was not found");
            }
            return applicationUrl;
        }



        /// <summary>
        /// Property application environment.
        /// </summary>
        public static string ApplicationTestEnvironment
        {
            get { return GetApplicationTestEnvironment(); }
        }

        /// <summary>
        /// Find application environment.
        /// </summary> 
        /// <returns>Application environment.</returns>
        public static string GetApplicationTestEnvironment()
        {
            return Environment.GetEnvironmentVariable(
                AppConfigReaderResource.AUTOMATION_TEST_ENVIRONMENT_KEY.ToUpper())
                   ?? ConfigurationManager.AppSettings[AppConfigReaderResource.TestEnvironment_Key].ToUpper();
        }

        /// <summary>
        /// Property browser instance.
        /// </summary>
        public static string BrowserExecutionInstance
        {
            get { return GetExecutionBrowser(); }
        }

        /// <summary>
        /// Property application download file path.
        /// </summary>
        public static string DownloadFilePath
        {
            get
            {
                return Environment.GetEnvironmentVariable(AppConfigReaderResource.DOWNLOAD_PATH_Key)
                       ?? Path.GetDirectoryName(Path.GetDirectoryName(Path.GetDirectoryName(Path.GetDirectoryName
                           (System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase))))
                       + "\\SeleniumWebdriver\\ApplicationDownloadedFiles";
            }
        }

        /// <summary>
        /// Find execution browser.
        /// </summary> 
        /// <returns>Browser instance.</returns>
        private static string GetExecutionBrowser()
        {
            return Environment.GetEnvironmentVariable(
                AppConfigReaderResource.AUTOMATION_BROWSER_KEY)
                   ?? ConfigurationManager.AppSettings[AppConfigReaderResource.BrowserName_Key];
        }

    }
}
