using System;

// Ограничения параметров типа

namespace GenericsConstraints
{
    interface IInterface { /* ... */ }
    interface IInterface<U> : IInterface { /* ... */ }

    class Derived : IInterface, IInterface<object> { /* ... */ }

    // where T : IInterface, IInterface<object>  -  Аргумент типа должен являться или реализовывать указанный интерфейс. 
    // Можно установить несколько ограничений интерфейса.
    // Ограничивающий интерфейс также может быть универсальным.
    class MyClass<T> where T : IInterface, IInterface<object> { /* ... */ }

    class MyClass2<T> where T : IInterface { /* ... */ }

    class MyClass3<T> where T : IInterface<object> { /* ... */ }

    
    class Program
    {
        static void Main()
        {
            // В качестве аргумента типа подходит Derived, т.к., он наследуется от обоих интерфейсов.
            MyClass<Derived> my1 = new MyClass<Derived>();
            // MyClass<IInterface> my1 = new MyClass<IInterface>();   // Ошибка.
            // MyClass<IInterface<object>> my1 = new MyClass<IInterface<object>>();   // Ошибка.

            MyClass2<IInterface<object>> my2 = new MyClass2<IInterface<object>>();
            MyClass2<Derived> my3 = new MyClass2<Derived>();

            MyClass3<IInterface<object>> my4 = new MyClass3<IInterface<object>>();
            MyClass3<Derived> my5 = new MyClass3<Derived>();

            // Delay.
            Console.ReadKey();
        }
    }
}
