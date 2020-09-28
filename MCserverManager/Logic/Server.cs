using MCserverManager.Logic.Manager;
using MCserverManager.Util;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.IO.Packaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Threading;

namespace MCserverManager.Logic
{
    [Serializable]
    public class Server
    {
        // 参照用
        [NonSerialized]
        private Canvas CPU_Graph_inner;
        [NonSerialized]
        private bool isRunning;

        public string Name;
        private string saveDirectryPath;
        private string serverFileName = "server.jar";
        // private string startFileName = "start.bat";
        private string startOption;

        [NonSerialized]
        private Process serverProcess;
        private StreamReader serverLogReader;
        // 処理用
        /// <summary>
        /// システム監視用タイマー,グラフ更新用
        /// </summary>
        [NonSerialized]
        private DispatcherTimer SystemTimer;
        /// <summary>
        /// CPU使用履歴保存用
        /// </summary>
        [NonSerialized]
        private List<float> CPUlog;

        public Server(string Name, string saveDirectryPath)
        {
            this.Name = Name;
            this.saveDirectryPath = saveDirectryPath;
            Init();
        }

        /// <summary>
        /// データの初期化用
        /// </summary>
        public void Init()
        {
            CPU_Graph_inner = new Canvas();
            isRunning = false;
            CPUlog = new List<float>();
            startOption = "-Xms2048M -Xmx8192M -jar " + serverFileName + " nogui";

            serverProcess = new Process();
            serverProcess.StartInfo.FileName = "java";
            serverProcess.StartInfo.Arguments = startOption; // "-a -b -c"のように
            serverProcess.StartInfo.WorkingDirectory = saveDirectryPath;
            serverProcess.StartInfo.CreateNoWindow = true;
            serverProcess.StartInfo.RedirectStandardError = true;
            serverProcess.StartInfo.RedirectStandardOutput = true;
            serverProcess.StartInfo.UseShellExecute = false;
            serverProcess.EnableRaisingEvents = true;


            serverProcess.OutputDataReceived += (sender, ev) =>
            {
                if (isRunning && ServerManager.ShowingServerName == Name) {
                    DataDictionary.Main_Grid.Dispatcher.Invoke(() =>
                    {
                        ((TextBlock)DataDictionary.Main_Grid.FindName("Console_Log_Test")).Text += ev.Data + "\n";
                    });
                }
            };
            serverProcess.ErrorDataReceived += (sender, ev) =>
            {
                if (isRunning && ServerManager.ShowingServerName == Name)
                {
                    DataDictionary.Main_Grid.Dispatcher.Invoke(() =>
                    {
                        ((TextBlock)DataDictionary.Main_Grid.FindName("Console_Log_Test")).Text += ev.Data + "\n";
                    });
                }

            };
            serverProcess.Exited += (sender, ev) =>
            {
                Console.WriteLine($"exited");
                serverProcess.WaitForExit();
            };
            
            // serverLogReader = serverProcess.StandardOutput;

            CPU_Graph_inner.Name = "System_CPU_Graph_inner";
            CPU_Graph_inner.Background = Brushes.White;

            // タイマー関係
            SystemTimer = Timer.CreateTimer(1000);
            // タイマーイベントの定義
            SystemTimer.Tick += async (sender, e) =>
            {
                object cpuCount = await Task.Run(new Func<object>(SystemInfo.getCPUCounter));
                CPUlog.Insert(0, (float)cpuCount);
                Glaph.CreateCanvasForGlaph(CPU_Graph_inner, CPUlog);
            };





            CreateServer();
        }

        public Boolean run()
        {
            if (isRunning) return false;
            isRunning = true;
            SystemTimer.Start();
            
            serverProcess.Start();
            
            serverProcess.BeginOutputReadLine();
            serverProcess.BeginErrorReadLine();
            
            
            return true;
        }
        public Boolean stop()
        {
            if (!isRunning) return false;
            isRunning = false;

            SystemTimer.Stop();
            Glaph.clear(CPU_Graph_inner);
            return true;
        }

        public Canvas getCPUglaph()
        {
            return CPU_Graph_inner;
        }

        public void Show()
        {
            Grid MainGrid = DataDictionary.Main_Grid;
            ((Grid)MainGrid.FindName("ServerHide")).Visibility = System.Windows.Visibility.Collapsed;

            Grid System_CPU_Graph = (Grid)MainGrid.FindName("System_CPU_Graph");
            System_CPU_Graph.Children.Clear();
            System_CPU_Graph.Children.Add(CPU_Graph_inner);
            Debug.WriteLine(CPU_Graph_inner.Name);

        }
        public Boolean IsRunning()
        {
            return isRunning;
        }
        public void CreateServer()
        {
            if (!Directory.Exists(saveDirectryPath)) Directory.CreateDirectory(saveDirectryPath);
            /*
            if (!File.Exists(saveDirectryPath + startFileName))
            {
                File.Create(saveDirectryPath + "\\" + startFileName);
                File.WriteAllText(saveDirectryPath + "\\" + startFileName, startCommand);

            }
            */
            Debug.WriteLine("CreateServer()");
            Task serverDownload = Task.Run(() =>
            Application.Current.Dispatcher.Invoke(() =>
            {
                ServerFileLinks.DownloadServerVannila(
                    "1.8.4",
                    saveDirectryPath + "\\" + serverFileName/*,
                    /*(Label)DataDictionary.ServerAddWindow_Grid.FindName("Downoading_Percent")/*, OnDownloadPercentChange*/);
            }));
        }
        private bool OnDownloadPercentChange(int percent, Label percentLabel)
        {
            // Label percentLabel = (Label)DataDictionary.ServerAddWindow_Grid.FindName("Downoading_Percent");
            if (percent < 0)
            {
                percentLabel.Content = "ダウンロード中...";
                return false;
            }
            percentLabel.Content = percent + "%...";
            Debug.WriteLine(percent);
            return true;
        }

    }
}
