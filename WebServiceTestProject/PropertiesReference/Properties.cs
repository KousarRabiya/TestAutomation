using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebServiceTestProject.PropertiesReference
{
   public class Properties
    {
        public static string ParentPath {get; set;}
        public static string ResultPath { get; set; }

        public static  DateTime TestBeginTime { get; set; }
        public static DateTime TestEndTime { get; set; }
        public static DateTime BatchBeginTime { get; set; }
        public static DateTime BatchEndTime { get; set; }
        public static  string CurrentDirectory { get; set; }
        public static string HTMLPath { get; set; }

        
    }
}
