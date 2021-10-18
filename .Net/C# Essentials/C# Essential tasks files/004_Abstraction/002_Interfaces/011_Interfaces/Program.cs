using System;

namespace _011_Interfaces
{
    interface Interface
    {
        void MethodWithoutImplementation();

        // Реализация метода интерфейса по умолчанию
        void MethodWithDefaultImplementation() 
        {
            Console.WriteLine("MethodWithDefaultImplementation default implementation from Interface begin.");
            MethodWithoutImplementation();
            Console.WriteLine("MethodWithDefaultImplementation default implementation from Interface end.");
        }
    }

    class MyClass : Interface
    {
        public void MethodWithoutImplementation()
        {
            Console.WriteLine("MethodWithoutImplementation implementation from MyClass.");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            MyClass instance = new MyClass();

            instance.MethodWithoutImplementation();

            // При отсутствии реализации метода в классе MyClass, для вызова MethodWithDefaultImplementation
            // необходимо приведение к интерфейсу Interface

            //instance.MethodWithDefaultImplementation();

            Interface upcasted = instance;
            upcasted.MethodWithDefaultImplementation();
        }
    }
}
