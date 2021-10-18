using System;

// NVI - (Non-Virtual Interface) Невиртуальный Интерфейс

namespace NVI
{
    public class Base
    {
        public void DoWork() // Шаблонный метод
        {
            PreDoWork();
            CoreDoWork();
        }

        protected void PreDoWork() { Console.WriteLine("0"); }
        protected virtual void CoreDoWork() { Console.WriteLine("1"); }
    }

    public class Derived : Base
    {
        protected override void CoreDoWork() { Console.WriteLine("2"); }
    }

    class Program
    {
        static void Main()
        {
            Base instance = new Derived();
            instance.DoWork();  // 02

            // Delay
            Console.ReadKey();
        }
    }
}
