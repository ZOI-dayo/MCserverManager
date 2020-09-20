using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using System.Diagnostics;
// using System.Windows.Forms.DataVisualization.Charting;
using System.Drawing;
using MCserverManager.Util;
using MCserverManager.Logic;
using MCserverManager.Logic.Manager;

namespace MCserverManager
{
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            // 初期化
            InitializeComponent();
        }

        /*
        private void Server_Button_Click(object sender, RoutedEventArgs e)
        {
            Server server = new Server(System_CPU_Graph);
            ServerManager.ShowServer(((Button)sender).Name, Main, server);
        }
        */

        private void Server_Add_Button_Click(object sender, RoutedEventArgs e)
        {
            Window serverAddWindow = new ServerAddWindow(Main, System_CPU_Graph, Server_StackPanel, Server_Button_Template);
            serverAddWindow.Show();
        }
    }
}
