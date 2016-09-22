using System;
using System.Diagnostics;

namespace CompareSortAlorithms.Utilities
{
    public class Timer
    {
        public static double MeasureTime(Stopwatch sw, string sortingType, Action sortingMethod)
        {
            sw.Reset();
            sw.Start();
            sortingMethod();
            sw.Stop();

            var totalTime = sw.Elapsed.TotalMilliseconds;
            return totalTime;
        }
    }
}