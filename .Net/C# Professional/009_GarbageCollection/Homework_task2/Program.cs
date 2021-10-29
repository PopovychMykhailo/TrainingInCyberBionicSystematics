using System;
using System.Collections.Generic;

namespace Homework_task2
{
    /* Technical task
    
        Создайте класс, который позволит выполнять мониторинг ресурсов, используемых программой.
        Используйте его в целях наблюдения за работой программы, а именно: пользователь может
        указать приемлемые уровни потребления ресурсов (памяти), а методы класса позволят выдать
        предупреждение, когда количество реально используемых ресурсов приблизиться к
        максимально допустимому уровню.
    */


    class MyClass : IDisposable
    {
        public List<int> bigList;
        const int addSizeInOneStep = 1000;
        private bool disposed = false;


        public MyClass()
        {

            bigList = new(addSizeInOneStep);
            for (int i = 0; i < bigList.Capacity; i++)
                bigList.Add(i);
        }

        public void ShowData()
        {
            Console.WriteLine($"Size the list:  {bigList.Count}");
        }

        public void AddSize()
        {
            for (int i = 0; i < addSizeInOneStep; i++)
            {
                bigList.Add(bigList.Count + i);
            }
        }


        public void Dispose()
        {
            Console.WriteLine("Dispose()");

            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            Console.WriteLine("Dispose(bool disposing)");

            if (!disposed)
            {
                // Clear classes
                if (disposing)
                {
                    bigList.Clear();
                }

                // Clear simpler object
                //bigArray = null;
            }
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            MyClass myClass = new();

            long maxSizeUsesMemory;  // KiloBytes
            long currentUsingMemery; // KiloBytes
            Console.Write("Enter the maximum possible memory usage (in KB): ");
            maxSizeUsesMemory = Convert.ToInt32(Console.ReadLine());

            while (true)
            {
                currentUsingMemery = GC.GetTotalMemory(false) / 1024;
                Console.WriteLine($"Current usage memory:  {currentUsingMemery} KB. " +
                    $"{((decimal)currentUsingMemery / maxSizeUsesMemory * 100):0.0}%"); // How many memory

                // If the current memory usage is less than 80% of the maximum allowable
                if (currentUsingMemery < (maxSizeUsesMemory * 0.8))
                {
                    Console.WriteLine($"Usage memory is OK. Press for next");
                }
                else
                {
                    Console.WriteLine("Attention, memory is used more than 80% of the maximum allowable! Pressure for the next");
                }

                if (Console.ReadKey().Key == ConsoleKey.Escape)
                    break;

                myClass.AddSize();
            }

            myClass.Dispose();
            GC.Collect();

            currentUsingMemery = GC.GetTotalMemory(false) / 1024;
            Console.WriteLine($"Current usage memory:  {currentUsingMemery} KB. " +
                    $"{((decimal)currentUsingMemery / maxSizeUsesMemory * 100):0.0}%"); // How many memory
        }
    }
}
