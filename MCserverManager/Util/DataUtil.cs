using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MCserverManager.Logic;

namespace MCserverManager.Util
{
    class DataUtil
    {
        public static void SaveServer(Server data, string serverName)
        {
            // string localPath = System.Reflection.Assembly.GetEntryAssembly().Location; // C:\Users\ZOI\Desktop\書類\.NET Framework\MCserverManager\MCserverManager\bin\Debug\MCserverManager.exe
            // string localPath = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().CodeBase); // file:\C:\Users\ZOI\Desktop\書類\.NET Framework\MCserverManager\MCserverManager\bin\Debug
            // string localPath = System.Reflection.Assembly.GetExecutingAssembly().CodeBase; //file:///C:/Users/ZOI/Desktop/書類/.NET Framework/MCserverManager/MCserverManager/bin/Debug/MCserverManager.exe
            string localPath = Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location); // C:\Users\ZOI\Desktop\書類\.NET Framework\MCserverManager\MCserverManager\bin\Debug
            Debug.WriteLine(localPath);
            // string filePath = localPath + "";
            // Stream stream = new FileStream();
        }
    }
}
