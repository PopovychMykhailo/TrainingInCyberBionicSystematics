using System;
using System.Collections;

namespace Culture
{
    class Program
    {
        static void Main()
        {
            // Создание словарей у которых не учитывается культура при сравнении ключей.
            // Например: буква i украинская и английская это одно и то же. 

            var hash = new Hashtable(StringComparer.InvariantCulture);
            var list = new SortedList(StringComparer.InvariantCulture);
        }
    }
}
