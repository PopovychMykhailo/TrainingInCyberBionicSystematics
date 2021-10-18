
// Пространства имен.

namespace NamespaceA
{
    namespace NamespaceB
    {
        namespace NamespaceC
        {
            class MyClassC { }
        }
        class MyClassB { }
    }
    class MyClassA { }
}

// Повторное создание вложенного пространства имен.

namespace NamespaceA.NamespaceB.NamespaceC
{
    class MyClassC2
    {
        MyClassA myA = new MyClassA();
        MyClassB myB = new MyClassB();
        MyClassC myC = new MyClassC();
    }
}

namespace Namespaces
{
    using NamespaceA.NamespaceB.NamespaceC;

    class Program
    {
        static void Main()
        {
            MyClassC myC = new MyClassC();
            MyClassC2 myC2 = new MyClassC2();
        }
    }
}
