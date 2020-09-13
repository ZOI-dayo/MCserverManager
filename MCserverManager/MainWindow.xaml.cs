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

namespace MCserverManager
{
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// システム監視用タイマー
        /// </summary>
        private DispatcherTimer SystemTimer;
        private List<double> CPUlog = new List<double>();

        /*
        public void MakeLineData()
        {
            var points1 = new List<DataPoint>();
            for (int i = 0; i < dataNumber; i++)
            {
                points1.Add(new DataPoint((double)i, amplitude
                   * Math.Sin(2.0 * Math.PI * i / frequency)));
            }
            CPU_dataPoints = points1;
        }
        private List<DataPoint> CPU_dataPoints;
        public List<DataPoint> CPU_DataPoints
        {
            get { return CPU_dataPoints; }
            set { SetProperty(ref CPU_dataPoints, value); }
        }
        */

        public MainWindow()
        {
            // 初期化
            InitializeComponent();

            /*
            //グラフ関係 https://qiita.com/nocd5/items/064a783240c1e8590169
            System_CPU_Graph_Chart.ChartAreas.Add("ChartArea1");
            */
            Console.WriteLine(System_CPU_Graph.Width);
            for (int i = 0; i < System_CPU_Graph.Width; i++){
                createCanvasForGlaph(System_CPU_Graph, i);
            }

            // タイマー関係
            SystemTimer = CreateTimer(1000);
            // タイマーイベントの定義
            SystemTimer.Tick += (sender, e) => {
                CPUlog.Add(double.Parse(getCPUCounter().ToString()));
                // System_CPU_Text.Text = getCPUCounter().ToString();
                /*
                System_CPU_Graph_Chart.Series.Clear();

                // Seriesの作成と値の追加
                Series seriesCPU = new Series();
                seriesCPU.ChartType = SeriesChartType.Line;
                seriesCPU.MarkerStyle = MarkerStyle.Circle;
                for (int i = 0; i < System_CPU_Graph.Width; i++) {
                    seriesCPU.Points.AddXY(i, CPUlog[CPUlog.Count - i]);
                }
                System_CPU_Graph_Chart.Series.Add(seriesCPU);
                */
                
                
            };
            SystemTimer.Start();
        }
        
        /// <summary>
        /// 1秒間隔のタイマー生成処理
        /// </summary>
        /// <returns>生成したタイマー</returns>
        private DispatcherTimer CreateTimer(int Span)
        {
            // タイマー生成（優先度はアイドル時に設定）
            var t = new DispatcherTimer(DispatcherPriority.SystemIdle);

            // タイマーイベントの発生間隔を(int Span)ミリ秒に設定
            t.Interval = TimeSpan.FromMilliseconds(Span);

            /*
            // タイマーイベントの定義
            t.Tick += (sender, e) => {
                // タイマーイベント発生時の処理をここに書く

                // 現在の時分秒をテキストに設定
                // textBlock.Text = DateTime.Now.ToString("HH:mm:ss");
            };
            */

            // 生成したタイマーを返す
            return t;
        }
        /// <summary>
        /// CPU使用率を取得します
        /// </summary>
        /// <returns>CPU使用率(int型,%)</returns>
        public object getCPUCounter()
        {
            PerformanceCounter cpuCounter = new PerformanceCounter();
            cpuCounter.CategoryName = "Processor";
            cpuCounter.CounterName = "% Processor Time";
            cpuCounter.InstanceName = "_Total";

            // will always start at 0
            dynamic firstValue = cpuCounter.NextValue();
            System.Threading.Thread.Sleep(100);
            // now matches task manager reading
            dynamic secondValue = cpuCounter.NextValue();

            return secondValue;
        }

        /// <summary>
        /// グラフ用に四角形を出力します
        /// </summary>
        /// <param name="parent">親となるCanvasオブジェクトです</param>
        /// <param name="index">「左から何番目か」を表す数字です</param>
        public void createCanvasForGlaph(Canvas parent, int index) {
            Canvas canvas = new Canvas();
            canvas.Background = System.Windows.Media.Brushes.Black;
            canvas.Height = index;
            canvas.Width = 1;
            Canvas.SetTop(canvas, parent.Height - index);
            Canvas.SetLeft(canvas, parent.Width - index);
            parent.Children.Add(canvas);
            Console.WriteLine("aaa");
        }
    }
}
