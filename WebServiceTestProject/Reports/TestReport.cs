using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebServiceTestProject.Reports
{
    class TestReport
    {
        static int Step = 1;
        static int Pass = 0;
        static int Fail = 0;
        public static StreamWriter stream;
        public static string HTMLReportPath;
        static public void CreateHTML(TestContext TestContext) // recive the parameter and used any where in method
        {
            HTMLReportPath = PropertiesReference.Properties.ResultPath + @"\"+TestContext.TestName + "_HTMLReport.html";
            PropertiesReference.Properties.HTMLPath = HTMLReportPath;
            stream = new StreamWriter(HTMLReportPath);
            stream.WriteLine(@"<html>");

            stream.WriteLine(@"<br>
 <img src='https://media.glassdoor.com/sqll/657610/maxxia-squarelogo-1446732934492.png' align='left' alt='_Logo' height='90' width='90'> 
 <br>
 <br>");

            stream.WriteLine(@"<H1 valign='middle' align='center'>Test Report for " + TestContext.TestName + "</H1>");

            stream.WriteLine(@"<font face='Tahoma' size='2'>");

            stream.Write(@"<table border='0' width='100 % '>
                               <tr>
                              <td width='13 % ' bgcolor='#CCCCFF'align='center'><b><font color='#000000' face='Tahoma' size='2'> 
                               <h5>
                                Step Numbers
                                <td width='24 % ' bgcolor='#CCCCFF'align='center'><b><font color='#000000' face='Tahoma' size='2'> 
                                <h5>
                                Objective
                                <td width='23 % ' bgcolor='#CCCCFF'align='center'><b><font color='#000000' face='Tahoma' size='2'> 
                                <h5>
                                Expected Result
                                <td width='22 % ' bgcolor='#CCCCFF'align='center'><b><font color='#000000' face='Tahoma' size='2'> 
                                 <h5>
                                            Actual Result
                                <td width='18 % ' bgcolor='#CCCCFF'align='center'><b><font color='#000000' face='Tahoma' size='2'> 
                                <h5>
                                    Pass/Fail</font></tr>");
            stream.Flush();



        }
        static public void AddTestStep(string Objective, string ExpectedResult, string Status, string AcutalResult = "")// recive the parameter and used any where in method
        {

            {
                stream.WriteLine("<tr>" + stream.NewLine + "<td width='13%' bgcolor='#FFFFDC' valign='middle' align='center'>" + Step++ + "</td>");
                stream.WriteLine("<td width='24%' bgcolor='#FFFFDC' valign='middle' align='center'>" + Objective + "</td>");
                stream.WriteLine("<td width='23%' bgcolor='#FFFFDC' valign='top' align='justify'>" + ExpectedResult + "</td>");
                stream.WriteLine("<td width='22%' bgcolor='#FFFFDC' valign='top' align='justify'>" + AcutalResult + "</td>");
                if (Status.Equals("Pass", StringComparison.InvariantCultureIgnoreCase))
                {
                    Pass++;
                    stream.WriteLine("<td width='18%' bgcolor='#FFFFDC' valign='top' align='center'><font color='green'>Pass</a></td>");
                }
                else
                {
                    Fail++;
                    stream.WriteLine("<td width='18%' bgcolor='#FFFFDC' valign='top' align='center'><font color='red'>Fail</a></td>");
                }
                stream.Flush();
            }
        }

        public static void AddIterationRow(int IternationNumber)

        {
            stream.WriteLine("</table >");
            stream.WriteLine("<table border = '0' width = '100 % ' >");
            stream.WriteLine("<tr>");
            stream.WriteLine("<td width = '100%' bgcolor = '#E7A480' valign = 'middle' align = 'center' > Iteration # " + IternationNumber + "</td>");
            stream.WriteLine("</table>");
            stream.WriteLine("<table>");

        }
        static public void Summary()
        {
            TimeSpan ExecTime = PropertiesReference.Properties.TestEndTime - PropertiesReference.Properties.TestBeginTime;
            stream.WriteLine(@"</table>" + stream.NewLine);
            stream.WriteLine("<br><br><br><br>");
            stream.Write(@"<table border = '1' width = '50%'>
                             <tr><td width = '100%' colspan = '2' bgcolor = '#000000'><b><font face = 'Tahoma' size = '2' color = '#FFFFFF'> Summary </font></b></td></tr>
                             <tr><td width = '45%' bgcolor = '#E8FFE8'><b><font face = 'Tahoma' size = '2'> Total Steps Passed </font></b></td><td width ='55%' bgcolor ='#E8FFE8'>" + Pass + "</td></tr>");
            stream.WriteLine(@"<tr><td width ='45%' bgcolor ='#FFE6FF'><b><font face ='Tahoma' size ='2'> Total Steps Failed </font></b></td><td width='55%' bgcolor='#FFE6FF'>" + Fail + "</td></tr>");
            stream.WriteLine(@"<tr><td width ='45%'bgcolor='#FFFFDC'><b><font face='Tahoma' size='2'>Executed On</font></b></td><td width='55%' bgcolor='#FFFFDC'>" + PropertiesReference.Properties.TestBeginTime.ToString("yyyy-MM-dd") + " </td></tr>");
            stream.WriteLine(@"<tr><td width ='45%'bgcolor='#FFFFDC'><b><font face='Tahoma' size='2'>Start Time</font></b></td><td width='55%' bgcolor= '#FFFFDC'>" + PropertiesReference.Properties.TestBeginTime.ToString("hh: mm:ss tt") + " </td></tr>");
            stream.WriteLine(@"<tr><td width ='45%'bgcolor='#FFFFDC'><b><font face='Tahoma' size='2'>End Time</font></b></td><td width='55%' bgcolor= '#FFFFDC'>" + PropertiesReference.Properties.TestEndTime.ToString("hh: mm:ss tt") + " </td></tr>");
            stream.WriteLine(@"<tr><td width ='45%'bgcolor='#FFFFDC'><b><font face='Tahoma' size='2'>Execution Time</font></b></td><td width='55%' bgcolor= '#FFFFDC'>" + ExecTime.ToString(@"%m") + " min(s)  " + ExecTime.ToString(@"s\.fff") + " sec(s)" + "</td></tr>");
            stream.WriteLine(@"</table>");
            stream.WriteLine(@" </body>" + stream.NewLine + @"</html>" + stream.NewLine);
            stream.Flush();

            stream = null;
            Step = 1;
            Pass = 0;
            Fail = 0;

        }
    }
}
