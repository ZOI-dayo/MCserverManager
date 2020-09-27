using System;
using System.Collections.Generic;
using System.IO;
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
using MCserverManager.Logic.Manager;
using MCserverManager.Util;
using Microsoft.WindowsAPICodePack.Dialogs;

namespace MCserverManager.Logic
{
    /// <summary>
    /// ServerAddWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class ServerAddWindow : Window
    {
        // private Grid Main;
        // private StackPanel Server_StackPanel;
        // private Button Server_Button_Template;
        public ServerAddWindow(Grid Main, StackPanel Server_StackPanel, Button Server_Button_Template)
        {
            InitializeComponent();
            DictionaryInit();
        }
        private void DictionaryInit()
        {
            // データ辞書
            DataDictionary.ServerAddWindow_Grid = Main;
        }

        private void Done_Button_Click(object sender, RoutedEventArgs e)
        {
            string serverName = Server_Name.Text;
            string serverPath = Server_Folder_TextBox.Text;
            // string ID = Hash.CreateHashString(serverName);
            if (serverName == "" || serverPath == "")
            {
                MessageBox.Show("空欄があります");
                return;
            }
            if (ServerManager.ContainServer(serverName))
            {
                MessageBox.Show("その名前のサーバーは既に作成されています。");
                return;
            }
            if (!Directory.Exists(serverPath))
            {
                if (MessageBox.Show("そのパスにはフォルダが存在しません", "", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    Directory.CreateDirectory(serverPath);
                }
            }
            if (Directory.EnumerateFileSystemEntries(serverPath).Count() != 0)
            {
                if (MessageBox.Show("すでにファイルが存在しますが、続行しますか", "", MessageBoxButton.YesNo) == MessageBoxResult.No) return;
            }

            /*
            Window downloadingWindow = new DownloadingWindow();
            downloadingWindow.Owner = this;
            downloadingWindow.Show();
            */
            // Task task = Task.Run(() => { downloadingWindow.ShowDialog(); });
            // Close();
            // downloadingWindow.ShowDialog();

            ServerManager.CreateServer(serverName, serverPath);

            ServerUtil.CreateServerToMainWindow(serverName);




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
            // Close();
        }

        private void SetFolder_Button_Click(object sender, RoutedEventArgs e)
        {
            CommonOpenFileDialog fileDialog = new CommonOpenFileDialog("サーバーの保存先フォルダを指定");
            fileDialog.IsFolderPicker = true;
            if (fileDialog.ShowDialog() == CommonFileDialogResult.Ok)
            {
                Server_Folder_TextBox.Text = fileDialog.FileName;
            }
        }
    }
}
