using System;
using MyNamespace;

namespace Classwork_task1
{
    /* Technical task
    
        Создайте собственное пространство имен MyNamespace с классом MyClass и подключите его в другом
        приложении
     */



    class Program
    {
        static void Main()
        {
            MyClass myClass = new();
            myClass.Method();
        }
    }
}
