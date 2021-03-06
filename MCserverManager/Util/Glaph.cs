﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;

namespace MCserverManager.Util
{
    class Glaph
    {
        /// <summary>
        /// グラフ用に四角形を出力します
        /// </summary>
        /// <param name="parent">親となるCanvasオブジェクトです</param>
        /// <param name="list">データが入っているリストです(float型、百分率)</param>
        public static void CreateCanvasForGlaph(Canvas parent, List<float> list)
        {
            parent.Children.Clear();
            for (int index = 0; index < parent.ActualWidth; index++)
            {
                // createCanvasForGlaph(System_CPU_Graph, i, CPUlog);
                double Content = 0;
                Canvas canvas = new Canvas();
                canvas.Background = Brushes.Black;
                if (index < list.Count)
                {
                    // Content = canvas.Height * (list[list.Count - index - 1] / 100); // 高さ
                    Content = parent.ActualHeight * (list[index] / 100); // 高さ
                }
                canvas.Height = Content;
                canvas.Width = 1;
                Canvas.SetTop(canvas, parent.ActualHeight - Content);
                Canvas.SetLeft(canvas, parent.ActualWidth - index - 1);
                parent.Children.Add(canvas);
            }
            for(int i =Convert.ToInt32(Math.Ceiling(parent.ActualWidth)); i < list.Count; i++) {
                list.RemoveAt(i);
            }
        }
        public static void clear(Canvas parent)
        {
            parent.Children.Clear();
        }
    }
}
