using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace MCserverManager.Util
{
    class Timer
    {
        /// <summary>
        /// 指定した間隔で実行されるタイマーを生成します
        /// </summary>
        /// <param name="Span">発生間隔(ミリ秒)</param>
        /// <returns>生成したタイマー</returns>
        public static DispatcherTimer CreateTimer(int Span)
        {
            // タイマー生成（優先度はアイドル時に設定）
            var t = new DispatcherTimer(DispatcherPriority.SystemIdle);
            t.Interval = TimeSpan.FromMilliseconds(Span);
            return t;
        }
    }
}
