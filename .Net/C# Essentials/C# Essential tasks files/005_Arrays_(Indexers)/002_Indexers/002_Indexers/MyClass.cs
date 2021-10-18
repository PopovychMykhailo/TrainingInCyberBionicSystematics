using System;

namespace Indexers
{
    class MyClass
    {
        private string[] array = new string[5];

        // Индексатор. 
        public string this[int index]
        {
            get    // Аксессор.
            {
                if (index >= 0 && index < array.Length)
                    return array[index];
                else
                    return "Попытка обращения за пределы массива.";
            }
            set    // Мутатор.
            {
                if (index >= 0 && index < array.Length)
                    array[index] = value;
                else
                    Console.WriteLine("Попытка записи за пределами массива.");
            }
        }
    }
}
