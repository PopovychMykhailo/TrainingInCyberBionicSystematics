using System;

namespace _015_LocalFunctions
{
    public delegate void MyDelegate(string value);
    class Program
    {
        static void Main(string[] args)
        {
            // Локальные функции создаются внутри тела метода
            // и могут быть использованы только в теле этого метода

            void PrintHello(string name) 
            {
                Console.WriteLine($"Hello {name}!");
            }

            PrintHello("User");

            // Локальные функции могут быть сообщены с делегатами 

            MyDelegate myDelegate = PrintHello;

            myDelegate("from delegate");            
        }
    }
}
