using System;
using System.Collections.Generic;
using System.Windows.Controls;
using MCserverManager.Logic;

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
        /// サーバーを一覧に追加します
        /// </summary>
        /// <param name="ID">管理用ID</param>
        /// <param name="server">サーバーのオブジェクト</param>
        /// <returns>サーバーの保存に成功したかどうか</returns>
        public static Boolean SetServer(string ID, Server server) {
            if (servers.ContainsKey(ID)) return false;
            servers.Add(ID, server);
            return true;
        }
        /// <summary>
        /// IDからサーバーを取得します
        /// </summary>
        /// <param name="ID">求めるサーバーのID</param>
        /// <returns>取得したサーバー</returns>
        public static Server GetServer(string ID) {
            return servers[ID];
        }

        /// <summary>
        /// サーバーを制作、リストに追加します
        /// </summary>
        /// <param name="ID">管理用ID</param>
        /// <param name="System_CPU_Graph">サーバーのグラフ描画用オブジェクト</param>
        /// <returns>サーバーの保存に成功したかどうか</returns>
        public static Boolean CreateServer(string ID) {
            Server server = new Server();
            return SetServer(ID, server);
        }
        public static void ShowServer(string ID, Grid MainGrid)
        {
            Server server = GetServer(ID);
            // あとで消す
            if (!server.IsRunning()) {
                server.run();
            }
            server.Show(MainGrid);
        }

        public static Boolean ContainServer(String ID)
        {
            return servers.ContainsKey(ID);
        }
    }
}
