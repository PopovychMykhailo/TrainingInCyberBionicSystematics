using System;

namespace _012_Interfaces
{
    class Program
    {
        interface IInterface
        {
            // Методы интерфейсов могут иметь модификаторы доступа 

            private void PrivateMethod()
            {
                Console.WriteLine("Private method in Interface");
            }
            protected void ProtectedMethod()
            {
                Console.WriteLine("Protected method in Interface");
            }
            void PublicMethod()
            {
                Console.WriteLine("Public method in Interface");
            }

            // Реализация метода интерфейса по умолчанию
            void MethodWithDefaultImplementation()
            {
                Console.WriteLine("MethodWithDefaultImplementation default implementation from Interface begin.");
                Console.WriteLine("MethodWithDefaultImplementation default implementation from Interface end.");
            }
        }

        interface IMoreConcreteInterface : IInterface 
        {
            void AnotherMethod() 
            {
                this.ProtectedMethod();
                this.PublicMethod();
            }
        }


        class MyClass : IMoreConcreteInterface
        {
            public void MethodWithoutImplementation()
            {
                ((IMoreConcreteInterface)(this)).PublicMethod();
                Console.WriteLine("MethodWithoutImplementation implementation from MyClass.");
            }
        }

        static void Main(string[] args)
        {
            MyClass instance = new MyClass();

            instance.MethodWithoutImplementation();

            // При отсутствии реализации метода в классе MyClass, для вызова MethodWithDefaultImplementation или PublicMethod
            // необходимо приведение к интерфейсу Interface

            //instance.MethodWithDefaultImplementation();
            //instance.PublicMethod();

            IInterface upcasted = instance;
            upcasted.PublicMethod();
            upcasted.MethodWithDefaultImplementation();

            IMoreConcreteInterface updasted2 = instance;
            updasted2.PublicMethod();
            updasted2.MethodWithDefaultImplementation();
            updasted2.AnotherMethod();
        }
    }
}
