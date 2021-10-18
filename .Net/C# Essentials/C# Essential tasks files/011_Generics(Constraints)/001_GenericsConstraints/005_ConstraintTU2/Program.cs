using System;

// Ограничения параметров типа

namespace GenericsConstraints
{
    interface IInterface { /* ... */ }
    interface IInterface<U> : IInterface { /* ... */ }

    class Derived : IInterface, IInterface<object> { /* ... */ }

    class Derived2 : IInterface<object> { /* ... */ } 

    // where T : IInterface, IInterface<object>  -  Аргумент типа должен являться или реализовывать указанный интерфейс. 
    // Можно установить несколько ограничений интерфейса. Ограничивающий интерфейс также может быть универсальным.

    class MyClass<T> where T : IInterface, IInterface<object> { /* ... */ }    

    class MyClass2<T> where T : IInterface<object> { /* ... */ }


    class Program
    {
        static void Main()
        {
            // В качестве аргумента типа подходит Derived, т.к., он наследуется от обоих интерфейсов.
            MyClass<Derived2> my1 = new MyClass<Derived2>();
            //MyClass<IInterface> my1 = new MyClass<IInterface>();   // Ошибка.

            //  Аргумент типа подходит, т.к., IInterface<object> наследуется от IInterface
            MyClass<IInterface<object>> my2 = new MyClass<IInterface<object>>();

            MyClass2<Derived> my3 = new MyClass2<Derived>();
            MyClass2<Derived2> my4 = new MyClass2<Derived2>();
            MyClass2<IInterface<object>> my5 = new MyClass2<IInterface<object>>();
            
            // Delay.
            Console.ReadKey();
        }
    }
}
