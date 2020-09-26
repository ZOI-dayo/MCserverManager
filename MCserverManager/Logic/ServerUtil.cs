using MCserverManager.Logic.Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace MCserverManager.Logic
{
    class ServerUtil
    {

        private static Grid Main;
        public static void CreateServerToMainWindow(string serverName)
        {
            Main = DataDictionary.Main_Grid;
            Button serverButton = new Button();
            serverButton.Name = serverName;
            serverButton.VerticalAlignment = VerticalAlignment.Top;
            serverButton.BorderBrush = Brushes.Black;
            serverButton.Background = ((Button) DataDictionary.Main_Grid.FindName("Server_Button_Template")).Background;
            serverButton.Margin = ((Button) DataDictionary.Main_Grid.FindName("Server_Button_Template")).Margin;
            serverButton.Height = 50;
            serverButton.Click += new RoutedEventHandler(Server_Button_Click);

            Label lavel = new Label();
            lavel.Content = serverName;
            lavel.FontWeight = FontWeights.Bold;
            serverButton.Content = lavel;

            ((StackPanel) DataDictionary.Main_Grid.FindName("Server_StackPanel")).Children.Add(serverButton);
        }


        private static void Server_Button_Click(object sender, RoutedEventArgs e)
        {
            string Name = ((Button)sender).Name;
            // string ID = Hash.CreateHashString(Name);
            if (!ServerManager.ContainServer(Name))
            {
                MessageBox.Show("指定された名称のサーバーが見つからなかったため開くことができません。");
                // ServerManager.CreateServer(ID);
            }
            ServerManager.ShowServer(Name, Main);
        }
    }
}
