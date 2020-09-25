using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.IO.Pipes;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using MCserverManager.Logic;

namespace MCserverManager.Util
{
    class DataUtil
    {
        private static string localPath = Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location);
        /*
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
        */
        public static void SaveServerList(List<Server> servers) {
            string filePath = localPath + "\\Data\\serverList.bin";
            // Debug.WriteLine(filePath);
            if (!Directory.Exists(Path.GetDirectoryName(filePath))) Directory.CreateDirectory(Path.GetDirectoryName(filePath));

            Stream stream = new FileStream(filePath, FileMode.Create, FileAccess.Write, FileShare.None);
            IFormatter formatter = new BinaryFormatter();
            formatter.Serialize(stream, servers);
            stream.Close();
        }

        public static List<Server> LoadServerList()
        {
            string filePath = localPath + "\\Data\\serverList.bin";
            Debug.WriteLine(filePath);
            if (!File.Exists(filePath)) return new List<Server>();

            Stream stream = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read);
            IFormatter formatter = new BinaryFormatter();
            List<Server> servers = (List<Server>) formatter.Deserialize(stream);
            stream.Close();

            Debug.WriteLine("Sever Count = "+servers.Count);

            return servers;
        }
    }
}
