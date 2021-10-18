using System;
using System.Text;

namespace ArraysAndIndexers
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.Unicode;
            Dictionary dictionary = new Dictionary();

            Console.WriteLine(dictionary["солнце"]);
            Console.WriteLine(dictionary.TranslateByUA("хмара"));
            Console.WriteLine(dictionary.TranslateByEN("apple"));

            // Delay.
            Console.ReadKey();
        }
    }
}
