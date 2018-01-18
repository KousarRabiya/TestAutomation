using log4net;
using OpenQA.Selenium;

namespace MMSG.Automation.ComponentHelper
{
    public class ButtonHelper
    {
        private static readonly ILog Logger = Log4NetHelper.GetXmlLogger(typeof(ButtonHelper));
        private static IWebElement _element;

        public static void ClickButton(By locator)
        {
            _element = GenericHelper.GetElement(locator);
            _element.Click();
            Logger.Info(" Button Click @ " + locator);
        }

        public static bool IsButtonEnabled(By locator)
        {
            _element = GenericHelper.GetElement(locator);
            Logger.Info(" Checking Is Button Enabled ");
            return _element.Enabled;
        }

        public static string GetButtonText(By locator)
        {
            _element = GenericHelper.GetElement(locator);
            if (_element.GetAttribute("value") == null)
                return string.Empty;
            return _element.GetAttribute("value");
        }
    }
}
