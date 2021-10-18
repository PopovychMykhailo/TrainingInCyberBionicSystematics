
// Пространства имен. Псевдонимы типов.

namespace NamespaceA
{
    namespace NamespaceB
    {
        namespace NamespaceC
        {
            class MyClassC
            {
                public void Method()
                {
                    System.Console.WriteLine("Hello world!");
                }
            }
        }
        class MyClassB { }
    }
    class MyClassA { }
}


namespace Namespaces
{
    // Создание псевдонима MyClass, для класса MyClassC из пространства имен NamespaceA.NamespaceB.NamespaceC.

    using MyClass = NamespaceA.NamespaceB.NamespaceC.MyClassC;

    class Program
    {
        static void Main()
        {
            MyClass my = new MyClass();
            my.Method();
            System.Console.WriteLine(my.GetType());
        }
    }
}
