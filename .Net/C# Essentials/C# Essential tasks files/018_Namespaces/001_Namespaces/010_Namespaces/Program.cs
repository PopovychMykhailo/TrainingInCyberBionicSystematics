
// Пространства имен.  

// Внимание: Распространенные ошибки самоассоциации после первой попытки инстанцирования.

using NamespaceA;                         
using NamespaceA.NamespaceB;              
using NamespaceA.NamespaceB.NamespaceC;   

namespace NamespaceA
{
    namespace NamespaceB
    {
        namespace NamespaceC
        {
            class MyClassC
            {
                MyClassA myA = new MyClassA(); // StackOverflowException   3
                MyClassB myB = new MyClassB(); // StackOverflowException   6
                MyClassC myC = new MyClassC(); // StackOverflowException   7
            }
        }

        class MyClassB
        {
            MyClassA myA = new MyClassA(); // StackOverflowException   4
            MyClassB myB = new MyClassB(); // StackOverflowException   5
            MyClassC myC = new MyClassC();
        }
    }

    class MyClassA
    {
        MyClassA myA = new MyClassA(); // StackOverflowException   1
        MyClassB myB = new MyClassB(); // StackOverflowException   2
        MyClassC myC = new MyClassC();
    }
}

namespace Namespaces
{
    class Program
    {
        static void Main()
        {
            MyClassA myA = new MyClassA();
            MyClassB myB = new MyClassB();
            MyClassC myC = new MyClassC();
        }
    }
}
