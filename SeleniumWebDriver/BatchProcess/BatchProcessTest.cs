using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Configuration;
using System.IO;
using System.Text;

namespace SeleniumWebDriver.BatchProcess
{
    [TestClass]
    public class BatchProcessTest
    {
        [TestMethod]
        public void ExecuteBatchProcess()
        {
            RunScript(LoadScript(Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDi‌​rectory, "..\\..\\..\\")) + @"\SeleniumWebDriver\BatchProcess\execBatchProcess.ps1"));
        }

        /// <summary>
        /// This method takes your script path, loads up the script
        /// into a variable, and passes the variable to the RunScript method
        /// that will then execute the contents
        /// </summary>
        /// <param name="filename"></param>
        /// <returns></returns>
        private string LoadScript(string filename)
        {
            try
            {
                // Create an instance of StreamReader to read from our file.
                // The using statement also closes the StreamReader.
                using (StreamReader sr = new StreamReader(filename))
                {
                    // use a string builder to get all our lines from the file
                    StringBuilder fileContents = new StringBuilder();

                    // string to hold the current line
                    string curLine;

                    // loop through our file and read each line into our
                    // stringbuilder as we go along
                    while ((curLine = sr.ReadLine()) != null)
                    {
                        // read each line and MAKE SURE YOU ADD BACK THE
                        // LINEFEED THAT IT THE ReadLine() METHOD STRIPS OFF
                        fileContents.Append(curLine + "\n");
                    }

                    // call RunScript and pass in our file contents
                    // converted to a string
                    return fileContents.ToString();
                }
            }
            catch (Exception e)
            {
                // Let the user know what went wrong.
                string errorText = "The file could not be read:";
                errorText += e.Message + "\n";
                return errorText;
            }
        }

        /// <summary>
        /// Takes script text as input and runs it
        /// </summary>
        /// <param name="scriptText"></param>
        private void RunScript(string scriptText)
        {
            using (System.Management.Automation.PowerShell powerShell = System.Management.Automation.PowerShell.Create())
            {
                powerShell.Commands.AddScript(scriptText);
                powerShell.AddParameter("serverName", ConfigurationManager.AppSettings["serverName"]);
                powerShell.AddParameter("batchName", ConfigurationManager.AppSettings["batchName"]);
                powerShell.AddParameter("batchParams", ConfigurationManager.AppSettings["batchParams"]);
                try
                {
                    powerShell.Invoke();
                }
                catch (Exception exp)
                {
                    throw exp;
                }
            }
        }
    }
}
