using System;
using System.Threading;

// Приоритеты потоков. MSDN sample.

namespace Priority
{
    class PriorityTest
    {
        bool loopSwitch;

        public PriorityTest()
        {
            loopSwitch = true;
        }

        public bool LoopSwitch
        {
            set { loopSwitch = value; }
        }

        public void ThreadMethod()
        {
            long threadCount = 0;

            while (loopSwitch)
                threadCount++;

            Console.WriteLine("{0} with {1,11} priority has a count = {2,13}",
                Thread.CurrentThread.Name,
                Thread.CurrentThread.Priority.ToString(),
                threadCount.ToString("N0"));
        }
    }

    class Program
    {
        static void Main()
        {
            PriorityTest priorityTest = new PriorityTest();
            ThreadStart startDelegate = priorityTest.ThreadMethod;

            Thread threadOne = new Thread(startDelegate);
            threadOne.Name = "ThreadOne";
            threadOne.Priority = ThreadPriority.Lowest;

            Thread threadTwo = new Thread(startDelegate);
            threadTwo.Name = "ThreadTwo";

            threadTwo.Priority = ThreadPriority.Highest;

            threadOne.Start();
            threadTwo.Start();

            // Дать 10 секунд на выполнение потоков            
            Thread.Sleep(1000);

            // Остановка работы всех потоков
            priorityTest.LoopSwitch = false;

            // Delay
            Console.ReadKey();
        }
    }
}