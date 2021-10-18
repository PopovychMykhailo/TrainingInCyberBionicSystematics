
// Пространства имен.

// Технически, допускается создание нескольких пространств имен с одним именем. 
// Логически, несколько одноименных пространств имен, объединяются в одно пространство имен.

namespace MyNamespace
{
    class MyClass { }
}

namespace MyNamespace
{
    // Недопустимо иметь в одноименных пространствах имен, одноименные типы.

    //class MyClass { }  // Ошибка.
}

namespace Namespaces
{
    class Program
    {
        static void Main()
        {
            MyNamespace.MyClass my = new MyNamespace.MyClass();
        }
    }
}
