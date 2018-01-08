using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebServiceTestProject.Reports
{
    class HTMLReport
    {
        static int Step = 1;
        static int Pass = 0;
        static int Fail = 0;
        public static StreamWriter stream;

        static public void CreateHTML(TestContext TestContext) // recive the parameter and used any where in method
        {
            stream = new StreamWriter(PropertiesReference.Properties.ParentPath + "Test_Summary_Report.html");
            stream.WriteLine(@"<html>");
            stream.WriteLine(@"<br>
 <img src='https://media.glassdoor.com/sqll/657610/maxxia-squarelogo-1446732934492.png' align='left' alt='QuikTrip_Logo' height='90' width='90'> 
 <br>
 <br>");

            stream.WriteLine(@"<H1 valign='middle' align='center'>Test Summary Report</H1>");

            stream.WriteLine(@"<font face='Tahoma' size='2'>");

            stream.Write(@"<table border='1' width='100 % '>
                               <tr>
                              <td width='8 % ' bgcolor='#CCCCFF'align='center'><b><font color='#000000' face='Tahoma' size='2'> 
                               <h5>
                                Sn. No.
                                <td width='57 % ' bgcolor='#CCCCFF'align='center'><b><font color='#000000' face='Tahoma' size='2'> 
                                <h5>
                                Test Case Name
                                <td width='20 % ' bgcolor='#CCCCFF'align='center'><b><font color='#000000' face='Tahoma' size='2'> 
                                <h5>
                                Pass/Fail
                                <td width='15 % ' bgcolor='#CCCCFF'align='center'><b><font color='#000000' face='Tahoma' size='2'> 
                                 <h5>
	                             Exceution Time
                                 </tr>");
            stream.Flush();
        }
        static public void AddTestRow(string TestName, string Status)// recive the parameter and used any where in method
        {

            //TimeSpan ExecTime = PropertiesReference.Properties.TestEndTime - PropertiesReference.Properties.TestBeginTime;
            TimeSpan ExecTime = DateTime.Now - PropertiesReference.Properties.TestBeginTime;

            stream.WriteLine("<tr>" + stream.NewLine + "<td width='13%' bgcolor='#FFFFDC' valign='middle' align='center'>" + Step++ + "</td>");
            stream.WriteLine("<td width='24%' bgcolor='#FFFFDC' valign='middle'>" + TestName + "</td>");

            if (Status == "Pass")
            {
                Pass++;
            }
            else
            {
                Fail++;
            }

            stream.WriteLine("<td width='18%' bgcolor='#FFFFDC' valign='top' align='center'><a href='" + "file:///" + PropertiesReference.Properties.HTMLPath + "'>" + Status + "</a></td>");
            //  stream.WriteLine("<td width='18%' bgcolor='#FFFFDC' valign='top' align='center'>" + Status + "</td>");
            stream.WriteLine("<td width='22%' bgcolor='#FFFFDC' valign='top' align='justify'>" + ExecTime.ToString(@"%m") + ":" + ExecTime.ToString(@"s\.f") + " sec(s)" + "</td>");
            stream.Flush();
        }

        static public void Summary()
        {
            TimeSpan ExecTime = PropertiesReference.Properties.BatchEndTime - PropertiesReference.Properties.BatchBeginTime;
            stream.WriteLine(@"</table>" + stream.NewLine);
            stream.WriteLine("<br><br><br><br>");
            stream.Write(@"<table border = '1' width = '50%'>
                             <tr><td width = '100%' colspan = '2' bgcolor = '#000000'><b><font face = 'Tahoma' size = '2' color = '#FFFFFF'> Summary </font></b></td></tr>
                             <tr><td width = '45%' bgcolor = '#E8FFE8'><b><font face = 'Tahoma' size = '2'> Tests Passed </font></b></td><td width ='55%' bgcolor ='#E8FFE8'>" + Pass + "</td></tr>");
            stream.WriteLine(@"<tr><td width ='45%' bgcolor ='#FFE6FF'><b><font face ='Tahoma' size ='2'> Tests Failed </font></b></td><td width='55%' bgcolor='#FFE6FF'>" + Fail + "</td></tr>");
            stream.WriteLine(@"<tr><td width ='45%'bgcolor='#FFFFDC'><b><font face='Tahoma' size='2'>Executed On</font></b></td><td width='55%' bgcolor='#FFFFDC'>" + PropertiesReference.Properties.BatchEndTime.ToString("yyyy-MM-dd") + " </td></tr>");
            stream.WriteLine(@"<tr><td width ='45%'bgcolor='#FFFFDC'><b><font face='Tahoma' size='2'>Start Time</font></b></td><td width='55%' bgcolor= '#FFFFDC'>" + PropertiesReference.Properties.BatchEndTime.ToString("hh: mm:ss tt") + " </td></tr>");
            stream.WriteLine(@"<tr><td width ='45%'bgcolor='#FFFFDC'><b><font face='Tahoma' size='2'>End Time</font></b></td><td width='55%' bgcolor= '#FFFFDC'>" + PropertiesReference.Properties.BatchEndTime.ToString("hh: mm:ss tt") + " </td></tr>");
            stream.WriteLine(@"<tr><td width ='45%'bgcolor='#FFFFDC'><b><font face='Tahoma' size='2'>Execution Time</font></b></td><td width='55%' bgcolor= '#FFFFDC'>" + ExecTime.ToString(@"%m") + " min(s)  " + ExecTime.ToString(@"s\.fff") + " sec(s)" + "</td></tr>");
            stream.WriteLine(@"</table>");
            stream.WriteLine(@"</body>" + stream.NewLine + @"</html>" + stream.NewLine);

            stream.Flush();
            stream.Close();
            stream = null;
            Step = 1;
            Pass = 0;
            Fail = 0;

        }


    }
}
