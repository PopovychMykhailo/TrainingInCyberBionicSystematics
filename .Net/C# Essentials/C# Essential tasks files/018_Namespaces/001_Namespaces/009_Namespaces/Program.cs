
// Пространства имен.

namespace NamespaceA
{
    class MyClassA
    {
        MyClassA my;

        public MyClassA()  // StackOverflowException
        {
            System.Console.WriteLine("Constructor MyClassA");

            // Рефлексивная самоассоциация, после первой попытки инстанцирования приводит к цикличному инстанцированию.

            my = new MyClassA(); 
        }
    }
}

namespace Namespaces
{
    using NamespaceA;

    class Program
    {
        static void Main()
        {
            // Попытка инстанцирования класса MyClassA.

            MyClassA myA = new MyClassA();
        }
    }
}
