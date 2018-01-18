using MMSG.Automation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMSG.Pages.UIPages.Exceptions
{
    public static class ExceptionHandler
    {
        /// <summary>
        /// Static logger instance of the class.
        /// </summary>
        private static readonly Logger ExceptionLogger =
            Logger.GetInstance(typeof(ExceptionHandler));

        /// <summary>
        /// This method handels and throws exceptions.
        /// </summary>
        /// <param name="ex">This is the exception.</param>
        public static void HandleException(Exception ex)
        {
            // wrap the exception and not execute the below code in second run
            if (ex is GenericPageException
                || ex is OpenQA.Selenium.WebDriverTimeoutException
                || ex is InvalidOperationException
                || ex is OpenQA.Selenium.WebDriverException)
            {
                ExceptionLogger.LogMessage("ExceptionHandler", "HandleException", ex.Message, true);
                throw ex;
            }
            var genericPageException = new GenericPageException(ex.ToString(), ex);
            ExceptionLogger.LogException("ExceptionHandler", "HandleException", ex, ex.Message, true);
            throw genericPageException;
        }
    }
}
