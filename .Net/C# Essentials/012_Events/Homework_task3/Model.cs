using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_task3
{
    /*
    class Model
    {
        DateTime startTime;         // Stopwatch start time
        DateTime endTime;           // Stopwatch start time
        TimeSpan stopwatchTime;     // Time elapsed from the beginning to the present moment
        readonly DateTime nullDateTime = new(0); // For reset time
        readonly TimeSpan nullSpanTime = new(0); // For reset time
        public bool StopwatchIsWorking { get; private set; }    // Whether the stopwatch is working?

        public Model()
        {
            startTime = new();
            endTime = new();
            stopwatchTime = new();
        }

        public void StartStopwatch()
        {
            StopwatchIsWorking = true;
            startTime = DateTime.Now;
            endTime = DateTime.Now;

            // The stopwatch start working from now moment
            //if (stopwatchTime.Ticks == 0)
            //{
            //    startTime = DateTime.Now;
            //}
            //// The stopwatch was stopped, but now it has been extended
            //else
            //{
            //    startTime = DateTime.Now;
            //    endTime = DateTime.Now;
            //}
            
        }

        public void StopStopwatch()
        {
            StopwatchIsWorking = false;
            endTime = DateTime.Now;
        }

        public void ResetTime()
        {
            startTime = nullDateTime;
            endTime = nullDateTime;
            stopwatchTime = nullSpanTime;
            StopwatchIsWorking = false;
        }

        public TimeSpan GetElapsedTime()
        {
            if (StopwatchIsWorking == true)
            {
                endTime = DateTime.Now;
            }

            stopwatchTime += endTime - startTime - stopwatchTime;  // Add new elapsed time

            return stopwatchTime;
        }

    }
*/

    class Model
    {
        Stopwatch stopWatch;

        public Model()
        {
            stopWatch = new Stopwatch();
        }

        public void StartStopwatch()
        {
            stopWatch.Start();
        }

        public void StopStopwatch()
        {
            stopWatch.Stop();
        }

        public void ResetStopwatch()
        {
            stopWatch.Reset();
        }

        public TimeSpan GetElapsedTime()
        {
            return stopWatch.Elapsed;
        }

    }
}
