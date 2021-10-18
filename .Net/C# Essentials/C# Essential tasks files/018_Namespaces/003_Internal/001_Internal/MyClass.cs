using System;
using LibraryA;

namespace Internal
{
    class MyClass : MyPublicClass
    {
        // Возможность обращения к internal protected методу базового класса из другой сборки.

        public void MyMethod()
        {
            this.InternalProtectedMethod();
            //this.PrivateProtectedMethod(); // Недоступен.
        }
    }
}
