
// Пространства имен.

// Два пространства имен одного уровня вложенности, не предоставляют доступа одно другому, к своим стереотипам, без импорта.

namespace MyNamespace
{
    namespace NamespaceA
    {
        class BaseClass
        {
        }
    }

    namespace NamespaceB
    {
        class DerivedClass : NamespaceA.BaseClass
        {
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
            BaseClass instance1 = new BaseClass();
            DerivedClass instance2 = new DerivedClass();
        }
    }
}
