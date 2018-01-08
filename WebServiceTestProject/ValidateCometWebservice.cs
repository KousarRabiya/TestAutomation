using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using System.Linq;
using System.Xml;
using WebServiceTestProject.Reports;

namespace WebServiceTestProject
{
    [TestClass]
    public partial class ValidateCometWebservice
    {
        mslmcopreprod01.CometService webService = new mslmcopreprod01.CometService();
        public static string XMLPath;
        private static Random random = new Random();

        [TestMethod]
        public void ValidateCreateEmployee()
        {
            try
            {
                XmlDocument xmldoc = new XmlDocument();
                xmldoc.Load(PropertiesReference.Properties.CurrentDirectory + @"\XML Test Data\CreateEmployee.xml");
                XmlNode hierarchyNode = xmldoc["Request"]["CometCreateEmployee"]["Employee"];

                hierarchyNode.ChildNodes[0].ChildNodes[1].InnerText = RandomString(8);
                xmldoc.Save(PropertiesReference.Properties.CurrentDirectory + @"\XML Test Data\CreateEmployee.xml");
                XmlNode node = webService.CreateEmployee(xmldoc.OuterXml.ToString());

                Assert.AreEqual("Success", node.FirstChild.Name);

                if (node.FirstChild.Name == "Success")
                {
                    TestReport.AddTestStep("Verify the response of the Create Employee to be successfull", 
                        "Response of the Create Employee to be successfull", "Pass", "Employee ID: " 
                        + node.ChildNodes[0].ChildNodes[0].ChildNodes[0].InnerText + " and Employee Number: "
                        + node.ChildNodes[0].ChildNodes[0].ChildNodes[1].InnerText + " created successfully");

                    XmlDocument xmlPackageDoc = new XmlDocument();
                    xmlPackageDoc.Load(PropertiesReference.Properties.CurrentDirectory + @"\XML Test Data\CreatePackage.xml");

                    XmlNode hierarchyPackageNode = xmlPackageDoc["Request"]["CometCreatePackage"];

                    //Update EmployeeID and PackagePayroll from the response received from Create Employee method
                    hierarchyPackageNode.ChildNodes[0].InnerText = node.ChildNodes[0].ChildNodes[0].ChildNodes[0].InnerText; //Employee ID
                    hierarchyPackageNode.ChildNodes[1].ChildNodes[2].ChildNodes[0].InnerText = node.ChildNodes[0].ChildNodes[0].ChildNodes[1].InnerText; //Employee Number

                    xmlPackageDoc.Save(PropertiesReference.Properties.CurrentDirectory + @"\XML Test Data\CreatePackage.xml");
                    HTMLReport.AddTestRow(TestContext.TestName, "Pass");
                }
            }
            catch (Exception e)
            {
                TestReport.AddTestStep("Verify the response of the Create Employee to be successfull", "Response of the Create Employee to be successfull", "Fail", "Response received is not Success. Exception: " + e);
                HTMLReport.AddTestRow(TestContext.TestName, "Fail");
            }
        }

        [TestMethod]
        public void ValidateNewPackage()
        {
            try
            {
                XmlDocument xmldoc = new XmlDocument();
                xmldoc.Load(PropertiesReference.Properties.CurrentDirectory + @"\XML Test Data\CreatePackage.xml");
                XmlNode node = webService.CreatePackage(xmldoc.OuterXml.ToString());

                Assert.AreEqual("Success", node.FirstChild.Name);
                if (node.FirstChild.Name == "Success")
                {
                    TestReport.AddTestStep("Verify the response of the Create Package to be successful",
                        "Response of the Create Package to be successfull", "Pass", 
                        "Package ID: " + node.ChildNodes[0].ChildNodes[0].ChildNodes[0].InnerText +
                        " and Package Number: "+ node.ChildNodes[0].ChildNodes[0].ChildNodes[1].InnerText + " generated successfully");
                    HTMLReport.AddTestRow(TestContext.TestName, "Pass");
                }
                else
                {
                    TestReport.AddTestStep("Verify the response of the Create Package to be successful", "Response of the Create Package to be successfull", "Fail", "Responses received is not Success as Child node has " + node.FirstChild.Name);
                    HTMLReport.AddTestRow(TestContext.TestName, "Fail");
                    throw new Exception();
                }
            }
            catch (Exception e)
            {
                TestReport.AddTestStep("Verify the response of the Create Package to be successful", "Response of the Create Package to be successfulls", "Fail", "Responses received is not Success. Exception:" + e);
                HTMLReport.AddTestRow(TestContext.TestName, "Fail");
            }
        }

        [ClassInitialize]
        public static void BeforeBeginTests(TestContext TestContext)
        {

            DirectoryInfo currentDir = new DirectoryInfo(Directory.GetCurrentDirectory());
            string parentResultpath = currentDir.Parent.Parent.Parent.FullName + @"\Result Folder\API_" + DateTime.Now.ToString("yyyy-MM-dd_hh-mm-ss") + @"\";
            string curdir = currentDir.Parent.Parent.Parent.FullName;

            PropertiesReference.Properties.CurrentDirectory = curdir;
            PropertiesReference.Properties.ParentPath = parentResultpath;
            ComponentHelper.Generic.CreateFolder(parentResultpath);

            PropertiesReference.Properties.BatchBeginTime = DateTime.Now;
            HTMLReport.CreateHTML(TestContext);
            LogReport.CreateLogFile(TestContext);
        }

        [TestInitialize()]
        public void BeforeTestBegin()
        {
            PropertiesReference.Properties.TestBeginTime = DateTime.Now;
            string parentPath = PropertiesReference.Properties.ParentPath;

            string resultPath = parentPath + @"\TC_" + TestContext.TestName;
            PropertiesReference.Properties.ResultPath = resultPath;
            ComponentHelper.Generic.CreateFolder(resultPath);
            TestReport.CreateHTML(TestContext);
        }

        [TestCleanup]
        public void AfterTest()
        {
            PropertiesReference.Properties.TestEndTime = DateTime.Now;
            TestReport.Summary();
        }

        [ClassCleanup]
        public static void AfterClass()
        {
            PropertiesReference.Properties.BatchEndTime = DateTime.Now;
            HTMLReport.Summary();
        }

        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        private TestContext testContextInstance;

        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}
