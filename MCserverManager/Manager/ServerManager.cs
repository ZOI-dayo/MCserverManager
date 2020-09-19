using System;
using System.Collections.Generic;
using System.Windows.Controls;

namespace MCserverManager.Manager
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
        private static Dictionary<string, Server.Server> servers = new Dictionary<string, Server.Server>();

        /// <summary>
        /// サーバーを一覧に追加します
        /// </summary>
        /// <param name="ID">管理用ID</param>
        /// <param name="server">サーバーのオブジェクト</param>
        /// <returns>サーバーの保存に成功したかどうか</returns>
        public static Boolean setServer(string ID, Server.Server server) {
            if (servers.ContainsKey(ID)) return false;
            servers.Add(ID, server);
            return true;
        }
        /// <summary>
        /// IDからサーバーを取得します
        /// </summary>
        /// <param name="ID">求めるサーバーのID</param>
        /// <returns>取得したサーバー</returns>
        public static Server.Server getServer(string ID) {
            return servers[ID];
        }

        /// <summary>
        /// サーバーを制作、リストに追加します
        /// </summary>
        /// <param name="ID">管理用ID</param>
        /// <param name="System_CPU_Graph">サーバーのグラフ描画用オブジェクト</param>
        /// <returns>サーバーの保存に成功したかどうか</returns>
        public static Boolean createServer(string ID, Canvas System_CPU_Graph) {
            Server.Server server = new Server.Server(System_CPU_Graph);
            return setServer(ID, server);
        }
    }
}
