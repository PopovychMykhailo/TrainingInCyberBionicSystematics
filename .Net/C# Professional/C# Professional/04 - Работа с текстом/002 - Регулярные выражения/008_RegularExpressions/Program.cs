using System;
using System.Text;
using System.Text.RegularExpressions;

// Регулярные выражения.

namespace RegularExpressions
{
    class Program
    {
        static void Main()
        {
            Console.OutputEncoding = Encoding.Unicode;
            Regex regex = new Regex(@"[0-9A-Za-z_.-]+@[0-9a-zA-Z-]+\.[a-zA-Z]{2,4}");

            MatchCollection collection = regex.Matches("русский edu@cbsystematics.com текст123ещерусскийsupport@cbsystematics.comтекст");
            
            foreach (Match element in collection)
            {
                Console.WriteLine("{0,-25}  на {1,-3} позиции.", element.Value, element.Index);
            }

            // Delay.
            Console.ReadKey();
        }
    }
}
