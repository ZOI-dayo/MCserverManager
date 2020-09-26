using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;

namespace MCserverManager.Util
{
    class SystemInfo
    {

        /// <summary>
        /// CPU使用率を取得します
        /// </summary>
        /// <returns>CPU使用率(int型,%)</returns>
        public static object getCPUCounter()
        {
            PerformanceCounter cpuCounter = new PerformanceCounter("Processor", "% Processor Time", "_Total");

            // will always start at 0
            dynamic firstValue = cpuCounter.NextValue();
            Thread.Sleep(1000);
            // now matches task manager reading
            dynamic secondValue = cpuCounter.NextValue();

            // test
            

            return secondValue;
        }
    }
}
