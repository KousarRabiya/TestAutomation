using log4net;
using SeleniumWebdriver.Settings;
using SeleniumWebDriver.Settings;

namespace SeleniumWebdriver.ComponentHelper
{
    public class NavigationHelper
    {
        private static readonly ILog Logger = Log4NetHelper.GetXmlLogger(typeof(NavigationHelper));
        public static void NavigateToUrl(string Url)
        {
            ObjectRepository.Driver.Navigate().GoToUrl(Url);
            Logger.Info(" Navigate To Page " + Url);
        }
    }
}
