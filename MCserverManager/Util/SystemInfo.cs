using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
