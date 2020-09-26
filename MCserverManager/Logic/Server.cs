using MCserverManager.Util;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO.Packaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        private Boolean isRunning;

        public string Name;
        private string saveDirectryPath;
        private string serverFileName;
        private string startFileName;
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
        }

        public Boolean run()
        {
            if (isRunning) return false;
            SystemTimer.Start();
            return true;
        }
        public Boolean stop()
        {
            if (!isRunning) return false;

            SystemTimer.Stop();
            Glaph.clear(CPU_Graph_inner);
            return true;
        }

        public Canvas getCPUglaph()
        {
            return CPU_Graph_inner;
        }

        public void Show() {
            Grid MainGrid = DataDictionary.Main_Grid;
            ((Grid) MainGrid.FindName("ServerHide")).Visibility = System.Windows.Visibility.Collapsed;

            Grid System_CPU_Graph = (Grid) MainGrid.FindName("System_CPU_Graph");
            System_CPU_Graph.Children.Clear();
            System_CPU_Graph.Children.Add(CPU_Graph_inner);
            Debug.WriteLine(CPU_Graph_inner.Name);
            
        }
        public Boolean IsRunning()
        {
            return isRunning;
        }

    }
}
