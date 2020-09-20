using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using MCserverManager.Logic.Manager;

namespace MCserverManager.Logic
{
    /// <summary>
    /// ServerAddWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class ServerAddWindow : Window
    {
        private Grid Main;
        private StackPanel Server_StackPanel;
        private Button Server_Button_Template;
        public ServerAddWindow(Grid Main, StackPanel Server_StackPanel, Button Server_Button_Template)
        {
            InitializeComponent();
            this.Main = Main;
            this.Server_StackPanel = Server_StackPanel;
            this.Server_Button_Template = Server_Button_Template;
        }

        private void Done_Button_Click(object sender, RoutedEventArgs e)
        {
            string serverName = Server_Name.Text;
            ServerManager.CreateServer(serverName);

            Button serverButton = new Button();
            serverButton.Name = serverName;
            serverButton.VerticalAlignment = VerticalAlignment.Top;
            serverButton.BorderBrush = Brushes.Black;
            serverButton.Background = Server_Button_Template.Background;
            serverButton.Margin = Server_Button_Template.Margin;
            serverButton.Height = 50;
            serverButton.Click += new RoutedEventHandler(Server_Button_Click);

            Label lavel = new Label();
            lavel.Content = serverName;
            lavel.FontWeight = FontWeights.Bold;
            serverButton.Content = lavel;

            /*
            string serverButtonSTR = "<Button x:Name=\""+serverName+"\" VerticalAlignment=\"Top\" BorderBrush=\"Black\" Background=\"#FFF4F4F5\" Margin=\"5,10,5,0\" Height=\"50\" Click=\"Server_Button_Click\"><Label Content=\"" + serverName + "\" FontWeight=\"Bold\" /></Button>";
            DependencyProperty dependencyProperty = new DependencyProperty();
            serverButton.SetValue(DependencyProperty.RegisterReadOnly("Click",typeof(string),);
            */
            /*
             <Button VerticalAlignment="Top" BorderBrush="Black" Background="#FFF4F4F5" Margin="5,10,5,0" Height="50" Click="Server_Button_Click">
                        <Label Content="TEST SERVER" FontWeight="Bold"/>
                    </Button>
             */
            Server_StackPanel.Children.Add(serverButton);
            Close();
        }
        private void Server_Button_Click(object sender, RoutedEventArgs e)
        {
            string ID = ((Button)sender).Name;
            if (!ServerManager.ContainServer(ID))
            {
                ServerManager.CreateServer(ID);
            }
            ServerManager.ShowServer(ID, Main);
        }
    }
}
