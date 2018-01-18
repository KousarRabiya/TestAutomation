using log4net;
using MMSG.Automation.Settings;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Threading;


namespace MMSG.Automation.ComponentHelper
{
    public class GenericHelper
    {
        public static int StepNo = ObjectRepository.TestCasesStepNumber;
        private readonly IWebDriver _webDriver = null;
        private static readonly ILog Logger = Log4NetHelper.GetXmlLogger(typeof(GenericHelper));
        private static Func<IWebDriver, bool> WaitForWebElementFunc(By locator)
        {
            return ((x) =>
            {
                if (x.FindElements(locator).Count == 1)
                    return true;
                Logger.Info(" Waiting for Element : " + locator);
                return false;
            });
        }
        private static Func<IWebDriver, IList<IWebElement>> GetAllElements(By locator)
        {
            return ((x) =>
            {
                return x.FindElements(locator);
            });
        }

        private static Func<IWebDriver, IWebElement> WaitForWebElementInPageFunc(By locator)
        {
            return ((x) =>
            {
                if (x.FindElements(locator).Count == 1)
                    return x.FindElement(locator);
                return null;
            });
        }

        public static void SelecFromAutoSuggest(By autoSuggesLocator, string initialStr, string strToSelect,
            By autoSuggestistLocator)
        {
            var autoSuggest = ObjectRepository.Driver.FindElement(autoSuggesLocator);
            autoSuggest.SendKeys(initialStr);
            Thread.Sleep(1000);

            var wait = GenericHelper.GetWebdriverWait(TimeSpan.FromSeconds(40));
            var elements = wait.Until(GetAllElements(autoSuggestistLocator));
            var select = elements.First((x => x.Text.Equals(strToSelect, StringComparison.OrdinalIgnoreCase)));
            select.Click();
            Thread.Sleep(1000);
        }

        public static WebDriverWait GetWebdriverWait(TimeSpan timeout)
        {
            ObjectRepository.Driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(1);
            WebDriverWait wait = new WebDriverWait(ObjectRepository.Driver, timeout)
            {
                PollingInterval = TimeSpan.FromMilliseconds(500),
            };
            wait.IgnoreExceptionTypes(typeof(NoSuchElementException), typeof(ElementNotVisibleException));
            Logger.Info(" Wait Object Created ");
            return wait;
        }
        public static bool IsElemetPresent(By locator)
        {
            try
            {
                Logger.Info(" Checking for the element " + locator);
                return ObjectRepository.Driver.FindElements(locator).Count == 1;
            }
            catch (Exception)
            {
                return false;
            }

        }

        public static IWebElement GetElement(By locator)
        {
            if (IsElemetPresent(locator))
                return ObjectRepository.Driver.FindElement(locator);
            else
                throw new NoSuchElementException("Element Not Found : " + locator.ToString());
        }

        //public static void TakeScreenShot(string filename = "Screen")
        //{
        //    var screen = ObjectRepository.Driver.TakeScreenshot();
        //    if (filename.Equals("Screen"))
        //    {
        //        filename = filename + DateTime.UtcNow.ToString("yyyy-MM-dd-mm-ss") + ".jpeg";
        //        screen.SaveAsFile(filename, ScreenshotImageFormat.Jpeg);
        //        Logger.Info(" ScreenShot Taken : " + filename);
        //        return;
        //    }
        //    screen.SaveAsFile(filename, ScreenshotImageFormat.Jpeg);
        //    Logger.Info(" ScreenShot Taken : " + filename);
        //}

        public static bool WaitForWebElement(By locator, TimeSpan timeout)
        {
            ObjectRepository.Driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(1);
            Logger.Info(" Setting the Explicit wait to 1 sec ");
            var wait = GetWebdriverWait(timeout);
            var flag = wait.Until(WaitForWebElementFunc(locator));
            ObjectRepository.Driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(1);
            Logger.Info(" Setting the Explicit wait Configured value ");
            return flag;
        }

        public static IWebElement WaitForWebElementInPage(By locator, TimeSpan timeout)
        {
            ObjectRepository.Driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(1);
            Logger.Info(" Setting the Explicit wait to 1 sec ");
            var wait = GetWebdriverWait(timeout);
            var flag = wait.Until(WaitForWebElementInPageFunc(locator));
            Logger.Info(" Setting the Explicit wait Configured value ");
            ObjectRepository.Driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(1);
            return flag;
        }

        public static void Wait(IWebDriver driver, By locator, int timeout)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeout));
            wait.Until(ExpectedConditions.ElementExists(locator));
        }

        public static string CurrentDirectory()
        {
            DirectoryInfo currentDir = new DirectoryInfo(Directory.GetCurrentDirectory());
            return currentDir.FullName;
        }

        public static void CreatFolder(String Resultpath)
        {
            Directory.CreateDirectory(Resultpath);
        }

        public static void TakeScreenShot(string exception)
        {
            System.Drawing.Bitmap bitmap = new System.Drawing.Bitmap(2000, 1000);
            System.Drawing.Graphics graphics = System.Drawing.Graphics.FromImage(bitmap as System.Drawing.Image);
            graphics.CopyFromScreen(0, 0, 0, 0, bitmap.Size);
            bitmap.Save(ObjectRepository.ResultPath + @"\" + exception + "_" + ObjectRepository.Testcasename + "_StepNo_" + StepNo + ".jpeg", ImageFormat.Jpeg);
            StepNo++;
        }
        public static void TakeScreenshot(string Exception,IWebDriver driver)
        {
            var cantakescreenshot = (driver as ITakesScreenshot) != null;
            if (!cantakescreenshot)
                return;
            var filename = string.Empty + DateTime.Now.Hour + DateTime.Now.Minute + DateTime.Now.Second + DateTime.Now.Millisecond;
            filename = ObjectRepository.ResultPath + @"\" + Exception + ObjectRepository.Testcasename + "_StepNo_" + StepNo + ".jpeg";
            var ss = ((ITakesScreenshot)driver).GetScreenshot();
            var screenshot = ss.AsBase64EncodedString;
            byte[] screenshotAsByteArray = ss.AsByteArray;
           // if (!Directory.Exists(path))
             //   Directory.CreateDirectory(path);
            ss.SaveAsFile(filename,ScreenshotImageFormat.Jpeg);
            StepNo++;
        }


        public static void IMPScreenShot(IWebDriver driver)
        {
            if (ObjectRepository.ScreenShot == "IMP")
            {
                GenericHelper.TakeScreenshot("", driver);
            }
        }

        public static void IMPScreenShot()
        {
            if (ObjectRepository.ScreenShot == "IMP")
            {
                GenericHelper.TakeScreenShot("");
            }
        }
        public static void AllScreenShot()
        {
            if (ObjectRepository.ScreenShot == "All")
            {
                GenericHelper.TakeScreenShot("");
            }
        }
        public static void AllScreenShot(IWebDriver driver)
        {
            if (ObjectRepository.ScreenShot == "All")
            {
                GenericHelper.TakeScreenShot("");
            }
        }
        private static Random random = new Random();
        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
        public static string RandomPayRollNo()
        {
            var random = new Random();
            int randomNumber = random.Next(100000, 999999);
            return randomNumber.ToString();
        }
        public static string RandomDate()
        {
            Random gen = new Random();
            DateTime start = new DateTime(1995, 1, 1);
            int range = (DateTime.Today - start).Days;
            return start.AddDays(gen.Next(range)).ToString();
        }
        public static void KillProcess(String processToBeKilled)
        {           
            String ProcessHastoBeKilled = "";
            if (processToBeKilled == "Chrome")
            {
                ProcessHastoBeKilled = "chromedriver";
            }
            else if (processToBeKilled == "IE")
            {
                ProcessHastoBeKilled = "iedriverserver";
            }
            Process[] ps = Process.GetProcessesByName(ProcessHastoBeKilled);
            foreach (Process p in ps)
            {
                p.Kill();
            }           

        }

        /// <summary>
        /// Cleans up the web driver and related processess.
        /// </summary>
        public static void Cleanup(String processToBeKilled)
        {
            try
            {

                if (ObjectRepository.Driver != null) ObjectRepository.Driver.Quit();

                Process[] processesToKill = Process.GetProcessesByName(processToBeKilled);
                foreach (Process processToKill in processesToKill)
                {
                    try
                    {
                        // kill and clean all processess
                        processToKill.Kill();
                    }
                    catch
                    {
                        //This exception is being consumed so that if a process is not killed the testing will not stop
                    }
                }
            }
            catch
            {
                //This exception is being consumed so that if a process is not killed the testing will not stop
            }
        }

    }
}
