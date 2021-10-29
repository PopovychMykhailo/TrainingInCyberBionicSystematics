using System;
using System.Collections.Generic;

namespace Classwork_task1
{
    /* Technical task
    
        Создайте свой класс, объекты которого будут занимать много места в памяти (например, в
        коде класса будет присутствовать большой массив) и реализуйте для этого класса
        формализованный шаблон очистки.
    */



    class MyClass : IDisposable
    {
        public int[] bigArray;
        public List<int> bigList;
        private bool disposed = false;


        public MyClass()
        {
            const int countArray = 50000000;

            bigArray = new int[countArray];
            for (int i = 0; i < countArray; i++)
                bigArray[i] = i;

            bigList = new(10);
            for (int i = 0; i < bigList.Capacity; i++)
                bigList.Add(i);
        }

        public void ShowData()
        {
            Console.WriteLine($"Size the array: {bigArray.Length}");
            Console.WriteLine($"Size the list:  {bigList.Count}");
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
                bigArray = null;
            }
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"GetTotalMemory start: {GC.GetTotalMemory(false) / 1024}KB");        // How many memory

            MyClass myClass = new();
            myClass.ShowData();

            Console.WriteLine($"GetTotalMemory after create: {GC.GetTotalMemory(false) / 1024}KB"); // How many memory
            Console.ReadKey();

            myClass.Dispose();  // Clear the object
            GC.Collect();       // Clear memory in controls heap

            Console.WriteLine($"GetTotalMemory after clear: {GC.GetTotalMemory(false) / 1024}KB");  // How many memory
        }
    }
}
