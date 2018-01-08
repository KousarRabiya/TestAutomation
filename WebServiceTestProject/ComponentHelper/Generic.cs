using System.IO;

namespace WebServiceTestProject.ComponentHelper
{
    class Generic
    {
      public static void CreateFolder(string Patb)
        {
            Directory.CreateDirectory(Patb);
        }
    }
}
