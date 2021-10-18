
// Пространства имен.

namespace NamespaceA
{
    namespace NamespaceB
    {
        namespace NamespaceC
        {
            class MyClass
            {
                public MyClass()
                {
                    System.Console.WriteLine(this.GetType().Name);
                }
            }
        }
    }
}


namespace Namespaces
{
    using NamespaceA.NamespaceB.NamespaceC;

    class Program
    {
        static void Main()
        {
            MyClass my = new MyClass();
        }
    }
}
