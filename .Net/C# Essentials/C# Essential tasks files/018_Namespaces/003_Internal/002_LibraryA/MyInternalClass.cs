using System;

namespace LibraryA
{
    // internal - Доступ к типу или члену возможен из любого кода в той же сборке, но не из другой сборки.

    internal class MyInternalClass
    {
        public MyInternalClass()
        {
            Console.WriteLine("Constructor - MyInternalClassA");
        }
    }
}
