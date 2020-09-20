using MCserverManager.Util;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Threading;

namespace MCserverManager.Logic
{
    public class Server
    {
        // 参照用
        private Canvas System_CPU_Graph;
        private Boolean isRunning;
        // 処理用
        /// <summary>
        /// システム監視用タイマー,グラフ更新用
        /// </summary>
        private DispatcherTimer SystemTimer;
        /// <summary>
        /// CPU使用履歴保存用
        /// </summary>
        private List<float> CPUlog = new List<float>();

        public Server(Canvas System_CPU_Graph)
        {
            this.System_CPU_Graph = System_CPU_Graph;
            Init();
        }

        /// <summary>
        /// データの初期化用
        /// </summary>
        private void Init()
        {
            isRunning = false;

            // タイマー関係
            SystemTimer = Timer.CreateTimer(1000);
            // タイマーイベントの定義
            SystemTimer.Tick += async (sender, e) =>
            {
                object cpuCount = await Task.Run(new Func<object>(SystemInfo.getCPUCounter));
                CPUlog.Insert(0, (float)cpuCount);
                Glaph.CreateCanvasForGlaph(System_CPU_Graph, CPUlog);
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
            Glaph.clear(System_CPU_Graph);
            return true;
        }

        public Canvas getCPUglaph()
        {
            return System_CPU_Graph;
        }

        public void Show(Grid MainGrid) {
            Canvas System_CPU_Graph =(Canvas) MainGrid.FindName("System_CPU_Graph");
            System_CPU_Graph = this.System_CPU_Graph;
        }
        public Boolean IsRunning()
        {
            return isRunning;
        }

    }
}
