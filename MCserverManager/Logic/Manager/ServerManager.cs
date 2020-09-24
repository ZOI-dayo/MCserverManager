using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Windows.Controls;
using MCserverManager.Logic;
using MCserverManager.Util;

namespace MCserverManager.Logic.Manager
{
    /// <summary>
    /// サーバーの一覧を管理します
    /// </summary>
    class ServerManager
    {
        /// <summary>
        /// 管理しているサーバーの一覧
        /// ID:string, server:Server.ServerのDictionary
        /// </summary>
        private static Dictionary<string, Server> servers = new Dictionary<string, Server>();

        /// <summary>
        /// 名前からサーバーを取得します
        /// </summary>
        /// <param name="Name">取得するサーバーの名前</param>
        /// <returns>取得したサーバー</returns>
        public static Server GetServer(string Name)
        {
            return servers[Name];
        }

        /// <summary>
        /// サーバーを一覧に追加します
        /// </summary>
        /// <param name="Name">管理用の名前</param>
        /// <param name="server">サーバーのオブジェクト</param>
        /// <returns>サーバーの保存に成功したかどうか</returns>
        public static Boolean SetServer(string Name, Server server)
        {
            if (servers.ContainsKey(Name)) return false;
            servers.Add(Name, server);
            return true;
        }

        public static List<Server> GetServers()
        {
            return servers.Values.ToList();
        }


        /// <summary>
        /// サーバーを制作、リストに追加します
        /// </summary>
        /// <param name="Name">管理用の名前</param>
        /// <param name="System_CPU_Graph">サーバーのグラフ描画用オブジェクト</param>
        /// <returns>サーバーの保存に成功したかどうか</returns>
        public static Boolean CreateServer(string Name, string saveDirectryPath)
        {
            Server server = new Server(Name, saveDirectryPath);
            return SetServer(Name, server);
        }
        public static void ShowServer(string Name, Grid MainGrid)
        {
            Server server = GetServer(Name);
            // あとで消す
            if (!server.IsRunning())
            {
                server.run();
            }
            server.Show(MainGrid);
        }

        public static Boolean ContainServer(String Name)
        {
            return servers.ContainsKey(Name);
        }

        public static void SaveServers()
        {
            DataUtil.SaveServerList(servers.Values.ToList());
            /*
            foreach(KeyValuePair<string, Server> serverData in servers) {
                string name = serverData.Key;
                Server server = serverData.Value;
                // DataUtil.SaveServer(server, name);
                Debug.WriteLine(name);
            }
            */
        }
        public static void LoadServers()
        {
            List<Server> servers = DataUtil.LoadServerList();
            Debug.WriteLine("Hay");
            Debug.WriteLine(servers);
            foreach (Server server in servers)
            {
                SetServer(server.Name, server);
                Debug.WriteLine("Hey");
            }
        }
    }
}
