using log4net;
using OpenQA.Selenium;

namespace MMSG.Automation.ComponentHelper
{
    public class TextBoxHelper
    {
        private static readonly ILog Logger = Log4NetHelper.GetXmlLogger(typeof(TextBoxHelper));
        private static IWebElement element;
        public static void TypeInTextBox(By locator, string text)
        {
            element = GenericHelper.GetElement(locator);
            element.SendKeys(text);
            Logger.Info($" Type in Textbox @ {locator} : value : {text}");
        }

        public static void ClearTextBox(By locator)
        {
            element = GenericHelper.GetElement(locator);
            element.Clear();
            Logger.Info($" Clear the Textbox @ {locator}");
        }
    }
}
