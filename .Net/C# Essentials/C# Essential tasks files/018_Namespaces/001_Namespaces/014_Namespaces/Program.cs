
// Пространства имен.

// Два пространства имен одного уровня вложенности, не предоставляют доступа одно другому, к своим стереотипам, без импорта.

namespace MyNamespace
{
    namespace NamespaceA
    {
        class MyClassA
        {
            //MyClassB my = new MyClassB();
        }
    }

    namespace NamespaceB
    {
        class MyClassB
        {
            //MyClassA my = new MyClassA();
        }
    }
}

namespace Namespaces
{
    using MyNamespace.NamespaceA;
    using MyNamespace.NamespaceB;

    class Program
    {
        static void Main()
        {
            MyClassA myA = new MyClassA();
            MyClassB myB = new MyClassB();
        }
    }
}
