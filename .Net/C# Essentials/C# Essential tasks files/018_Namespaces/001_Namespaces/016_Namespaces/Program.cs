
// Пространства имен.  Сокрытие имен стереотипов.

// В случае наличия одноименных стереотипов во вложенном и во внешнем пространствах имен, 
// происходит сокрытие имени стереотипа внешнего пространства имен. 
// Обращение к одноименному стереотипу внешнего пространства имен, потребует полной квалификации имени стереотипа.

namespace NamespaceA
{
    namespace NamespaceB
    {
        class MyClass { }  // Одноименный стереотип.

        class MyClassB
        {
            MyClass my1;
            NamespaceA.MyClass my2; // Прямая видимость отсутствует.
            MyClassA my3;           // Прямая видимость имеется.
        }
    }

    class MyClass { }      // Одноименный стереотип.           
    class MyClassA { }
}


namespace Namespaces
{
    using NamespaceA;
    using NamespaceA.NamespaceB;

    class Program
    {
        static void Main()
        {
        }
    }
}
