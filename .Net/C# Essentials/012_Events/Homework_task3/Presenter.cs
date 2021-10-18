using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_task3
{
    class Presenter
    {
        MainWindow view;
        Model model;

        public Presenter(MainWindow view)
        {
            this.view = view;
            this.model = new();
        }

        public void Stopwatch_startTime()
        {
            model.StartStopwatch();
        }
        public void Stopwatch_stopTime()
        {
            model.StopStopwatch();
        }
        public void Stopwatch_resetTime()
        {
            model.ResetStopwatch();
        }

        public void UpdateStopwatchTime()
        {
            TimeSpan elapsedTime = model.GetElapsedTime();
            view.TextBlock_updateTime(String.Format($"{elapsedTime.Hours:00}:{elapsedTime.Minutes:00}:{elapsedTime.Seconds:00}.{elapsedTime.Milliseconds:000}"));
        }
    }
}
