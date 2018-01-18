using System.Globalization;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using OpenQA.Selenium;
using log4net;
using System.Collections;

namespace MMSG.Automation
{
    public class Logger
        {
        private readonly ILog _log4NetLogger;

        private static ICollection _configLogs = log4net.Config.XmlConfigurator.Configure();
       

        /// <summary>
        /// Returns an instance of logger.
        /// </summary>
        /// <returns>An instance of logger.</returns>
        public static Logger GetInstance(Type T)
        {
            var logger = new Logger(T);


            return logger;
        }

        /// <summary>
        /// Logger.
        /// </summary>
        private Logger(Type T)
        {
            _log4NetLogger = LogManager.GetLogger("MMSG.Automation");

        }

        /// <summary>
        /// This method takes a screenshot and puts it in the directory.
        /// </summary>
        /// <param name="fileName">This is the name of the file.</param>
        private void TakeScreenShot(string fileName)
        {
            Screenshot screenShot = ((ITakesScreenshot)WebDriverSingleton.GetInstance().WebDriver).GetScreenshot();
            string executingPath = new FileInfo(System.Reflection.Assembly.GetExecutingAssembly().Location).DirectoryName;
            if (executingPath != null)
            {
                screenShot.SaveAsFile(Path.Combine(executingPath, "Log", fileName + ".jpeg"), ScreenshotImageFormat.Jpeg);
                Console.WriteLine(executingPath + fileName);
            }
        }

        /// <summary>
        /// This method logs a message.
        /// </summary>
        /// <param name="message">This is the message.</param>
        private void Log(string message)
        {

            string messageToLog = string.Format(" UserName = {0} ~ Password = {1} ~UserType=  {2}  ~ TransactionTimings = {3} ~ BrowserName = {4}"
                , BaseTestScript.UserName
                , BaseTestScript.Password
                , BaseTestScript.UserType
                , BaseTestScript.TransactionTimings
                , BaseTestScript.CurrentBrowserName
                );
            //Log at info level the message
            _log4NetLogger.Info(messageToLog + " ~ " + message);
        }

        /// <summary>
        /// This method logs a message.
        /// </summary>
        /// <param name="className">The name of the class.</param>
        /// <param name="methodName">The name of the method.</param>
        /// <param name="message">The message.</param>
        /// <param name="isTakeScreenShot">If a screen shot should be taken.</param>
        public void LogMessage(string className, string methodName, string message, bool isTakeScreenShot = false)
        {
            const string logMessageTemplate = "~ClassName = {0} ~ MethodName = {1} ~ Message = {2} ~ ScreenShot File = {3}";
            // Date time stamp to generate the screen shot file name
            String screenShotFileName = DateTime.Now.Year
                + DateTime.Now.Month.ToString(CultureInfo.InvariantCulture)
                + DateTime.Now.Day
                + DateTime.Now.Hour
                + DateTime.Now.Minute
                + DateTime.Now.Second;

            String logMessage = String.Format(logMessageTemplate, className, methodName, message, isTakeScreenShot ? screenShotFileName : "Not Applicable");

            Log(logMessage);

            if (isTakeScreenShot) TakeScreenShot(screenShotFileName);
        }

        /// <summary>
        /// This logs a metho entry.
        /// </summary>
        /// <param name="className">This is the name of the class.</param>
        /// <param name="methodName">This is the name of the method.</param>
        /// <param name="isTakeScreenShot">This tells if a screen shot should be taken default to false.</param>
        public void LogMethodEntry(string className, string methodName, bool isTakeScreenShot = false)
        {
            LogMessage(className, methodName, "Entry", isTakeScreenShot);
        }

        /// <summary>
        /// This logs a metho exit
        /// </summary>
        /// <param name="className">This is the name of the class</param>
        /// <param name="methodName">This is the name of the method</param>
        /// <param name="isTakeScreenShot">This tells if a screen shot should be taken default to false</param>
        public void LogMethodExit(string className, string methodName, bool isTakeScreenShot = false)
        {
            LogMessage(className, methodName, "Exit", isTakeScreenShot);
        }

        /// <summary>
        /// This logs an exception.
        /// </summary>
        /// <param name="className">This is the name of the class.</param>
        /// <param name="methodName">This is the name of the method.</param>
        /// <param name="exception">This is the exception to be logged.</param>
        /// <param name="isTakeScreenShot">This tells if a screen shot should be taken default to false.</param>
        public void LogException(string className, string methodName, Exception exception, bool isTakeScreenShot = false)
        {
            LogMessage(className, methodName, "~ Exception Message = " + exception.Message + " ~ Inner Exception = " + exception.InnerException + " ~ Stack Trace =" + exception.StackTrace, isTakeScreenShot);
        }

        /// <summary>
        /// This logs an exception
        /// </summary>
        /// <param name="className">This is the name of the class</param>
        /// <param name="methodName">This is the name of the method</param>
        /// <param name="exception">This is the exception to be logged</param>
        /// <param name="message"> This is the user Message</param>
        /// <param name="isTakeScreenShot">This tells if a screen shot should be taken default to false</param>
        public void LogException(string className, string methodName, Exception exception, string message, bool isTakeScreenShot = false)
        {
            LogMessage(className, methodName, "~ Exception Message = " + exception.Message + " ~ Inner Exception = " + exception.InnerException + " ~ Stack Trace =" + exception.StackTrace, isTakeScreenShot);
        }

        /// <summary>
        /// This method asserts an expression and logs result.
        /// </summary>
        /// <param name="testCaseName">The name of test case.</param>
        /// <param name="scenarioName">The name of the scenario.</param>
        /// <param name="message">Any user message</param>
        /// <param name="assertExpression">This is the assert expression
        /// This expression is expected to be of format ()=> Assert.Fail(),Assert.AreEqual()...
        /// The method is executed and based on result the logging is done.
        /// </param>
        /// <param name="isTakeScreenShotOnPass">This tells if a screen shot should be taken
        /// if execution passes.</param>
        private void LogAssertion(string testCaseName, string scenarioName, string message, Action assertExpression, bool isTakeScreenShotOnPass = false)
        {
            const string logMessageTemplate = "~TestCaseName  = {0} ~ ScenarioName ={1} ~ Result = {2} ~ Message= {3} ~ ScreenShot File = {4}";
            //  string logMessage = null;

            // Date time stamp to convert the Screen shot file name
            String screenShotFileName = DateTime.Now.Year.ToString(CultureInfo.InvariantCulture)
                + DateTime.Now.Month
                + DateTime.Now.Day
                + DateTime.Now.Hour
                + DateTime.Now.Minute
                + DateTime.Now.Second;
            try
            {
                assertExpression.Invoke();
                message = String.Format(logMessageTemplate, testCaseName, scenarioName, "Assert Passed",
                    message, isTakeScreenShotOnPass ? screenShotFileName : "Not Applicable");
                Log(message);
                if (isTakeScreenShotOnPass) TakeScreenShot(screenShotFileName);
            }
            catch (AssertFailedException afe)
            {
                message = String.Format(logMessageTemplate, testCaseName, scenarioName, "~Assert Failed~", " | UserMessage = " + message + "~ Reason = " + afe, screenShotFileName);
                TakeScreenShot(screenShotFileName);
                Log(message);
                // Close webdriver and browser instances if Assert Fails
                WebDriverSingleton.GetInstance().Dispose();
                throw;
            }
        }

        /// <summary>
        /// This method asserts an expression and logs result.
        /// </summary>
        /// <param name="testCaseName">The name of test case.</param>
        /// <param name="scenarioName">The name of the scenario.</param>
        /// <param name="assertExpression">This is the assert expression
        /// This expression is expected to be of format ()=> Assert.Fail(),Assert.AreEqual()...
        /// The method is executed and based on result the logging is done.
        /// </param>
        /// <param name="isTakeScreenShotOnPass">This tells if a screen shot should be taken
        /// if execution passe.s</param>
        public void LogAssertion(string testCaseName, string scenarioName, Action assertExpression, bool isTakeScreenShotOnPass = false)
        {
            LogAssertion(testCaseName, scenarioName, "", assertExpression, isTakeScreenShotOnPass);
        }

        /// <summary>
        /// This method asserts an expression and logs result.
        /// </summary>
        /// <param name="testCaseName">The name of test case.</param>
        /// <param name="scenarioName">The name of the scenario.</param>
        /// <param name="message">Any user message.</param>
        /// <param name="exception">This is th exception being used.</param>
        /// <param name="assertExpression">This is the assert expression
        /// This expression is expected to be of format ()=> Assert.Fail(),Assert.AreEqual()...
        /// The method is executed and based on result the logging is done.
        /// </param>
        public void LogAssertion(string testCaseName, string scenarioName, string message, Exception exception, Action assertExpression)
        {
            LogAssertion(testCaseName, scenarioName, "~Message = " + message + "~ Exception = " + exception + " ~ StackTrace = " + exception.StackTrace
                , assertExpression, true);
        }
    }
}