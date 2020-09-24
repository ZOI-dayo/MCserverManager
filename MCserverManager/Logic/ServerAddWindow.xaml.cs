﻿using System;
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
using MCserverManager.Util;
using Microsoft.WindowsAPICodePack.Dialogs;

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
            // string ID = Hash.CreateHashString(serverName);
            if (ServerManager.ContainServer(serverName)) {
                MessageBox.Show("その名前のサーバーは既に作成されています。");
                return;
            }
            ServerManager.CreateServer(serverName, Server_Folder_TextBox.Text);

            ServerUtil.CreateServerToMainWindow(Main,serverName, Server_Button_Template, Server_StackPanel);


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
            Close();
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
