
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
    using MyNamespace;
    using MyNamespace.MyNamespace;

    class Program
    {
        static void Main()
        {
            // Если несколько импортируемых пространств имен содержат одноименные стереотипы, 
            // то инстанцирование требует полной квалификации имени стереотипа.

            //MyClass my = new MyClass();  // Ошибка.

            MyNamespace.MyClass my1 = new MyNamespace.MyClass();
            MyNamespace.MyNamespace.MyClass my2 = new MyNamespace.MyNamespace.MyClass();
        }
    }
}
