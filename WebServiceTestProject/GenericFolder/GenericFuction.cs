using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using TechTalk.SpecFlow;

namespace WebServiceTestProject.GenericFolder
{

    public partial class  ValidateCometWebservice
    {

        public static void TakeScreenShot(string exception)
        {
            System.Drawing.Bitmap bitmap = new System.Drawing.Bitmap(2000, 1000);
            System.Drawing.Graphics graphics = System.Drawing.Graphics.FromImage(bitmap as System.Drawing.Image);
            graphics.CopyFromScreen(0, 0, 0, 0, bitmap.Size);
            bitmap.Save(PropertiesReference.Properties.ResultPath + @"\TC_Test.jpeg", System.Drawing.Imaging.ImageFormat.Jpeg);
           
        }
       public static void BeforeClass()
        {
            DirectoryInfo currentDir = new DirectoryInfo(Directory.GetCurrentDirectory());
            string parentResultpath = currentDir.FullName + @"\Result Folder\API_" + DateTime.Now.ToString("yyyy-MM-dd_hh-mm-ss") + @"\";
            string curdir = currentDir.FullName;
            PropertiesReference.Properties.CurrentDirectory = curdir;
            PropertiesReference.Properties.ParentPath = parentResultpath;
            ComponentHelper.Generic.CreateFolder(parentResultpath);
        }
        public static void BeforeTest()
        {
            PropertiesReference.Properties.TestBeginTime = DateTime.Now;
            string parentPath = PropertiesReference.Properties.ParentPath;

            string resultPath = parentPath + @"\TC_" + ScenarioContext.Current.ScenarioInfo.Title;
            PropertiesReference.Properties.ResultPath = resultPath;
            ComponentHelper.Generic.CreateFolder(resultPath);
        }


    }
}
