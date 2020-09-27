using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace MCserverManager.Logic
{
    class ServerFileLinks
    {
        public const string Vanilla_1_2_1 = "https://assets.minecraft.net/1_2/minecraft_server.jar";
        public const string Vanilla_1_2_2 = "https://assets.minecraft.net/1_2/minecraft_server.jar";
        public const string Vanilla_1_2_3 = "https://assets.minecraft.net/1_2/minecraft_server.jar";
        public const string Vanilla_1_2_4 = "https://assets.minecraft.net/1_2_5/minecraft_server.jar";
        public const string Vanilla_1_2_5 = "https://launcher.mojang.com/v1/objects/d8321edc9470e56b8ad5c67bbd16beba25843336/server.jar";
        public const string Vanilla_1_3_1 = "https://launcher.mojang.com/v1/objects/82563ce498bfc1fc8a2cb5bf236f7da86a390646/server.jar";
        public const string Vanilla_1_3_2 = "https://launcher.mojang.com/v1/objects/3de2ae6c488135596e073a9589842800c9f53bfe/server.jar";
        public const string Vanilla_1_4_2 = "https://launcher.mojang.com/v1/objects/5be700523a729bb78ef99206fb480a63dcd09825/server.jar";
        public const string Vanilla_1_4_4 = "https://launcher.mojang.com/v1/objects/4215dcadb706508bf9d6d64209a0080b9cee9e71/server.jar";
        public const string Vanilla_1_4_5 = "https://launcher.mojang.com/v1/objects/c12fd88a8233d2c517dbc8196ba2ae855f4d36ea/server.jar";
        public const string Vanilla_1_4_6 = "https://launcher.mojang.com/v1/objects/a0aeb5709af5f2c3058c1cf0dc6b110a7a61278c/server.jar";
        public const string Vanilla_1_4_7 = "https://launcher.mojang.com/v1/objects/2f0ec8efddd2f2c674c77be9ddb370b727dec676/server.jar";
        public const string Vanilla_1_5_1 = "https://launcher.mojang.com/v1/objects/d07c71ee2767dabb79fb32dad8162e1b854d5324/server.jar";
        public const string Vanilla_1_5_2 = "https://launcher.mojang.com/v1/objects/f9ae3f651319151ce99a0bfad6b34fa16eb6775f/server.jar";
        public const string Vanilla_1_6_1 = "https://launcher.mojang.com/v1/objects/0252918a5f9d47e3c6eb1dfec02134d1374a89b4/server.jar";
        public const string Vanilla_1_6_2 = "https://launcher.mojang.com/v1/objects/01b6ea555c6978e6713e2a2dfd7fe19b1449ca54/server.jar";
        public const string Vanilla_1_6_4 = "https://launcher.mojang.com/v1/objects/050f93c1f3fe9e2052398f7bd6aca10c63d64a87/server.jar";
        public const string Vanilla_1_7_2 = "https://launcher.mojang.com/v1/objects/3716cac82982e7c2eb09f83028b555e9ea606002/server.jar";
        public const string Vanilla_1_7_3 = "https://launcher.mojang.com/v1/objects/707857a7bc7bf54fe60d557cca71004c34aa07bb/server.jar";
        public const string Vanilla_1_7_4 = "https://launcher.mojang.com/v1/objects/61220311cef80aecc4cd8afecd5f18ca6b9461ff/server.jar";
        public const string Vanilla_1_7_5 = "https://launcher.mojang.com/v1/objects/e1d557b2e31ea881404e41b05ec15c810415e060/server.jar";
        public const string Vanilla_1_7_6 = "https://launcher.mojang.com/v1/objects/41ea7757d4d7f74b95fc1ac20f919a8e521e910c/server.jar";
        public const string Vanilla_1_7_7 = "https://launcher.mojang.com/v1/objects/a6ffc1624da980986c6cc12a1ddc79ab1b025c62/server.jar";
        public const string Vanilla_1_7_8 = "https://launcher.mojang.com/v1/objects/c69ebfb84c2577661770371c4accdd5f87b8b21d/server.jar";
        public const string Vanilla_1_7_9 = "https://launcher.mojang.com/v1/objects/4cec86a928ec171fdc0c6b40de2de102f21601b5/server.jar";
        public const string Vanilla_1_7_10 = "https://launcher.mojang.com/v1/objects/952438ac4e01b4d115c5fc38f891710c4941df29/server.jar";
        public const string Vanilla_1_8 = "https://launcher.mojang.com/v1/objects/a028f00e678ee5c6aef0e29656dca091b5df11c7/server.jar";
        public const string Vanilla_1_8_1 = "https://launcher.mojang.com/v1/objects/68bfb524888f7c0ab939025e07e5de08843dac0f/server.jar";
        public const string Vanilla_1_8_2 = "https://launcher.mojang.com/v1/objects/a37bdd5210137354ed1bfe3dac0a5b77fe08fe2e/server.jar";
        public const string Vanilla_1_8_3 = "https://launcher.mojang.com/v1/objects/163ba351cb86f6390450bb2a67fafeb92b6c0f2f/server.jar";
        public const string Vanilla_1_8_4 = "https://launcher.mojang.com/v1/objects/dd4b5eba1c79500390e0b0f45162fa70d38f8a3d/server.jar";
        public const string Vanilla_1_8_5 = "https://launcher.mojang.com/v1/objects/ea6dd23658b167dbc0877015d1072cac21ab6eee/server.jar";
        public const string Vanilla_1_8_6 = "https://launcher.mojang.com/v1/objects/2bd44b53198f143fb278f8bec3a505dad0beacd2/server.jar";
        public const string Vanilla_1_8_7 = "https://launcher.mojang.com/v1/objects/35c59e16d1f3b751cd20b76b9b8a19045de363a9/server.jar";
        public const string Vanilla_1_8_8 = "https://launcher.mojang.com/v1/objects/5fafba3f58c40dc51b5c3ca72a98f62dfdae1db7/server.jar";
        public const string Vanilla_1_8_9 = "https://launcher.mojang.com/v1/objects/b58b2ceb36e01bcd8dbf49c8fb66c55a9f0676cd/server.jar";
        public const string Vanilla_1_9 = "https://launcher.mojang.com/v1/objects/b4d449cf2918e0f3bd8aa18954b916a4d1880f0d/server.jar";
        public const string Vanilla_1_9_1 = "https://launcher.mojang.com/v1/objects/bf95d9118d9b4b827f524c878efd275125b56181/server.jar";
        public const string Vanilla_1_9_2 = "https://launcher.mojang.com/v1/objects/2b95cc7b136017e064c46d04a5825fe4cfa1be30/server.jar";
        public const string Vanilla_1_9_3 = "https://launcher.mojang.com/v1/objects/8e897b6b6d784f745332644f4d104f7a6e737ccf/server.jar";
        public const string Vanilla_1_9_4 = "https://launcher.mojang.com/v1/objects/edbb7b1758af33d365bf835eb9d13de005b1e274/server.jar";
        public const string Vanilla_1_10 = "https://launcher.mojang.com/v1/objects/a96617ffdf5dabbb718ab11a9a68e50545fc5bee/server.jar";
        public const string Vanilla_1_10_1 = "https://launcher.mojang.com/v1/objects/cb4c6f9f51a845b09a8861cdbe0eea3ff6996dee/server.jar";
        public const string Vanilla_1_10_2 = "https://launcher.mojang.com/v1/objects/3d501b23df53c548254f5e3f66492d178a48db63/server.jar";
        public const string Vanilla_1_11 = "https://launcher.mojang.com/v1/objects/48820c84cb1ed502cb5b2fe23b8153d5e4fa61c0/server.jar";
        public const string Vanilla_1_11_1 = "https://launcher.mojang.com/v1/objects/1f97bd101e508d7b52b3d6a7879223b000b5eba0/server.jar";
        public const string Vanilla_1_11_2 = "https://launcher.mojang.com/v1/objects/f00c294a1576e03fddcac777c3cf4c7d404c4ba4/server.jar";
        public const string Vanilla_1_12 = "https://launcher.mojang.com/v1/objects/8494e844e911ea0d63878f64da9dcc21f53a3463/server.jar";
        public const string Vanilla_1_12_1 = "https://launcher.mojang.com/v1/objects/561c7b2d54bae80cc06b05d950633a9ac95da816/server.jar";
        public const string Vanilla_1_12_2 = "https://launcher.mojang.com/v1/objects/886945bfb2b978778c3a0288fd7fab09d315b25f/server.jar";
        public const string Vanilla_1_13 = "https://launcher.mojang.com/v1/objects/d0caafb8438ebd206f99930cfaecfa6c9a13dca0/server.jar";
        public const string Vanilla_1_13_1 = "https://launcher.mojang.com/v1/objects/fe123682e9cb30031eae351764f653500b7396c9/server.jar";
        public const string Vanilla_1_13_2 = "https://launcher.mojang.com/v1/objects/3737db93722a9e39eeada7c27e7aca28b144ffa7/server.jar";
        public const string Vanilla_1_14 = "https://launcher.mojang.com/v1/objects/f1a0073671057f01aa843443fef34330281333ce/server.jar";
        public const string Vanilla_1_14_1 = "https://launcher.mojang.com/v1/objects/ed76d597a44c5266be2a7fcd77a8270f1f0bc118/server.jar";
        public const string Vanilla_1_14_2 = "https://launcher.mojang.com/v1/objects/808be3869e2ca6b62378f9f4b33c946621620019/server.jar";
        public const string Vanilla_1_14_3 = "https://launcher.mojang.com/v1/objects/d0d0fe2b1dc6ab4c65554cb734270872b72dadd6/server.jar";
        public const string Vanilla_1_14_4 = "https://launcher.mojang.com/v1/objects/3dc3d84a581f14691199cf6831b71ed1296a9fdf/server.jar";
        public const string Vanilla_1_15 = "https://launcher.mojang.com/v1/objects/e9f105b3c5c7e85c7b445249a93362a22f62442d/server.jar";
        public const string Vanilla_1_15_1 = "https://launcher.mojang.com/v1/objects/4d1826eebac84847c71a77f9349cc22afd0cf0a1/server.jar";
        public const string Vanilla_1_15_2 = "https://launcher.mojang.com/v1/objects/bb2b6b1aefcd70dfd1892149ac3a215f6c636b07/server.jar";
        public const string Vanilla_1_16 = "https://launcher.mojang.com/v1/objects/a0d03225615ba897619220e256a266cb33a44b6b/server.jar";
        public const string Vanilla_1_16_1 = "https://launcher.mojang.com/v1/objects/a412fd69db1f81db3f511c1463fd304675244077/server.jar";
        public const string Vanilla_1_16_2 = "https://launcher.mojang.com/v1/objects/c5f6fb23c3876461d46ec380421e42b289789530/server.jar";
        public const string Vanilla_1_16_3 = "https://launcher.mojang.com/v1/objects/f02f4473dbf152c23d7d484952121db0b36698cb/server.jar";

        public static string GetLink(string version)
        {
            switch (version)
            {
                case "1.2.1": return Vanilla_1_2_1;
                case "1.2.2": return Vanilla_1_2_2;
                case "1.2.3": return Vanilla_1_2_3;
                case "1.2.4": return Vanilla_1_2_4;
                case "1.2.5": return Vanilla_1_2_5;
                case "1.3.1": return Vanilla_1_3_1;
                case "1.3.2": return Vanilla_1_3_2;
                case "1.4.2": return Vanilla_1_4_2;
                case "1.4.4": return Vanilla_1_4_4;
                case "1.4.6": return Vanilla_1_4_6;
                case "1.4.5": return Vanilla_1_4_5;
                case "1.4.7": return Vanilla_1_4_7;
                case "1.5.1": return Vanilla_1_5_1;
                case "1.5.2": return Vanilla_1_5_2;
                case "1.6.1": return Vanilla_1_6_1;
                case "1.6.2": return Vanilla_1_6_2;
                case "1.6.4": return Vanilla_1_6_4;
                case "1.7.2": return Vanilla_1_7_2;
                case "1.7.3": return Vanilla_1_7_3;
                case "1.7.4": return Vanilla_1_7_4;
                case "1.7.5": return Vanilla_1_7_5;
                case "1.7.6": return Vanilla_1_7_6;
                case "1.7.7": return Vanilla_1_7_7;
                case "1.7.8": return Vanilla_1_7_8;
                case "1.7.9": return Vanilla_1_7_9;
                case "1.7.10": return Vanilla_1_7_10;
                case "1.8": return Vanilla_1_8;
                case "1.8.1": return Vanilla_1_8_1;
                case "1.8.2": return Vanilla_1_8_2;
                case "1.8.3": return Vanilla_1_8_3;
                case "1.8.4": return Vanilla_1_8_4;
                case "1.8.5": return Vanilla_1_8_5;
                case "1.8.6": return Vanilla_1_8_6;
                case "1.8.7": return Vanilla_1_8_7;
                case "1.8.8": return Vanilla_1_8_8;
                case "1.8.9": return Vanilla_1_8_9;
                case "1.9": return Vanilla_1_9;
                case "1.9.1": return Vanilla_1_9_1;
                case "1.9.2": return Vanilla_1_9_2;
                case "1.9.3": return Vanilla_1_9_3;
                case "1.9.4": return Vanilla_1_9_4;
                case "1.10": return Vanilla_1_10;
                case "1.10.1": return Vanilla_1_10_1;
                case "1.10.2": return Vanilla_1_10_2;
                case "1.11": return Vanilla_1_11;
                case "1.11.1": return Vanilla_1_11_1;
                case "1.11.2": return Vanilla_1_11_2;
                case "1.12": return Vanilla_1_12;
                case "1.12.1": return Vanilla_1_12_1;
                case "1.12.2": return Vanilla_1_12_2;
                case "1.13": return Vanilla_1_13;
                case "1.13.1": return Vanilla_1_13_1;
                case "1.13.2": return Vanilla_1_13_2;
                case "1.14": return Vanilla_1_14;
                case "1.14.1": return Vanilla_1_14_1;
                case "1.14.2": return Vanilla_1_14_2;
                case "1.14.3": return Vanilla_1_14_3;
                case "1.14.4": return Vanilla_1_14_4;
                case "1.15": return Vanilla_1_15;
                case "1.15.1": return Vanilla_1_15_1;
                case "1.15.2": return Vanilla_1_15_2;
                case "1.16": return Vanilla_1_16;
                case "1.16.1": return Vanilla_1_16_1;
                case "1.16.2": return Vanilla_1_16_2;
                case "1.16.3": return Vanilla_1_16_3;
                default: return "";
            }
        }

        public static void DownloadServerVannila(string version, string downloadFilePath/*, Func<int, Label, bool> OnPercentChange*/)
        {
            Uri remoteUri = new Uri(GetLink(version));

            Debug.WriteLine("hei version = " + version);

            //Create a new WebClient instance. 
            WebClient webClient = new WebClient();
            // using () {
            //Download the Web resource and save it into the current filesystem folder. 
            webClient.DownloadProgressChanged += new DownloadProgressChangedEventHandler((_sender, _e) =>
            {
                Debug.WriteLine("webClient.DownloadProgressChanged");
                if (_e.TotalBytesToReceive == -1)
                {
                    // OnPercentChange(-1);
                    // percentLabel.Content = "ダウンロード中...";
                    // Print("Download in Progress");
                }
                else
                {
                    // OnPercentChange(_e.ProgressPercentage);

                    // percentLabel.Content = _e.ProgressPercentage + "%...";
                    ((ProgressBar)DataDictionary.ServerAddWindow_Grid.FindName("DownloadBar")).Value = _e.ProgressPercentage;
                    // Print(_e.ProgressPercent);
                }
            });
            webClient.DownloadFileCompleted += new AsyncCompletedEventHandler((_sender, _e) =>
            {
                ((Grid)DataDictionary.ServerAddWindow_Grid.FindName("DownloadingGrid")).Visibility = Visibility.Collapsed;
                Window.GetWindow(DataDictionary.ServerAddWindow_Grid).Close();
            });

            ((Grid)DataDictionary.ServerAddWindow_Grid.FindName("DownloadingGrid")).Visibility = Visibility.Visible;
            webClient.DownloadFileAsync(remoteUri, downloadFilePath);
            // }
        }
    }
}
