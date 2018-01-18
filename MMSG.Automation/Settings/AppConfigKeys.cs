using OpenQA.Selenium;
using MMSG.Automation.CustomException;
using MMSG.Automation.Settings;
using System.Configuration;

namespace MMSG.Automation.Settings
{
    public class AppConfigKeys
    {
        public const string Browser = "Browser";
        public const string Username = "Username";
        public const string Password = "Password";
        public const string Website = "Website";
        public const string PageLoadTimeout = "PageLoadTimeout";
        public const string ElementLoadTimeout = "ElementLoadTimeout";

      public static void AppSetting()
        {
            string driv = ObjectRepository.DriverName;
            string ScreenShotStatus = ConfigurationManager.AppSettings["ScreenShot"];
            ObjectRepository.ScreenShot = ScreenShotStatus;
            switch (driv)
            {
                case "Chrome" :
                    IWebDriver driver=BaseClass.GetChromeDriver();
                    ObjectRepository.Driver = driver;
                    break;

                case "IE":
                    IWebDriver driverIE = BaseClass.GetIEDriver();
                    ObjectRepository.Driver = driverIE;
                    break;
                default:
                    throw new NoSutiableDriverFound("Driver Not Found: " + ObjectRepository.Config.GetBrowser().ToString());

            }
        }
    }
}
