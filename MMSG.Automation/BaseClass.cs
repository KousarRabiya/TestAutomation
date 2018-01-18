using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using MMSG.Automation;
using MMSG.Automation.CustomException;
using MMSG.Automation.Settings;
using MMSG.Automation.Configuration;
using System.IO;

namespace MMSG.Automation
{
    public class BaseClass
    {
        public static DirectoryInfo currentDir = new DirectoryInfo(Directory.GetCurrentDirectory());
        public static IWebDriver GetFirefoxDriver()
        {
            IWebDriver driver = new FirefoxDriver();
            return driver;
        }
        public static IWebDriver GetChromeDriver()
        {

            // IWebDriver driver = new ChromeDriver(@"\\msa.com.au\UserData\VDIFolderRedir\DevavratKs\Documents\Visual Studio 2015\Projects\ROLProject\MMSG.Automation\Driver\");
            // IWebDriver driver = new ChromeDriver(currentDir + @"\MMSG.Automation\Driver\");
            IWebDriver driver = new ChromeDriver(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location));
            return driver;
        }
        public static IWebDriver GetIEDriver()
        {
            // TODO: Remove the below two lines once iE settings are done
            var options = new InternetExplorerOptions();
            options.IntroduceInstabilityByIgnoringProtectedModeSettings = true;

            //IWebDriver driver = new InternetExplorerDriver(currentDir + @"\MMSG.Automation\Driver\", options);
            IWebDriver driver = new InternetExplorerDriver(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location), options);
            return driver;
        }
        public static void InitWebDriver(TestContext tc)
        {
            ObjectRepository.Config = new AutomationConfigurationManager();
            switch (ObjectRepository.Config.GetBrowser())
            {
                case BrowserType.Firefox:
                    ObjectRepository.Driver = GetFirefoxDriver();
                    break;
                case BrowserType.Chrome:
                    ObjectRepository.Driver = GetChromeDriver();
                    break;
                case BrowserType.IExplorer:
                    ObjectRepository.Driver = GetIEDriver();
                    break;
                default:
                    throw new NoSutiableDriverFound("Driver Not Found: " + ObjectRepository.Config.GetBrowser().ToString());
            }


        }
    }
}
