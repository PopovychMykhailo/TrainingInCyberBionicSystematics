
// Пространства имен.

namespace MyNamespace
{
    class MyClass { }

    namespace MyNamespace
    {
        // Допустимо иметь во вложенных пространствах имен, одноименные стереотипы.

        class MyClass { }
    }
}


namespace Namespaces
{
    class Program
    {
        static void Main()
        {
            MyNamespace.MyClass my1 = new MyNamespace.MyClass();
            MyNamespace.MyNamespace.MyClass my2 = new MyNamespace.MyNamespace.MyClass();
        }
    }
}
