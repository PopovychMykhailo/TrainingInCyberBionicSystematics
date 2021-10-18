using System;
using System.Text.RegularExpressions;

namespace Extraction
{
    class Program
    {
        static void Main()
        {
            // Шаблон может состоять из нескольких групп выделенных круглыми скобками.

            string input = "Description, Company name: Contoso, Inc.";
            
            // Шаблон @"(Company name): (.*$)" состоит из нескольких груп:
            // 0. Все соответствие шаблону
            // 1. (Company name) - соответствует строке до знака двоеточия
            // 2. (.*$) - соответствует любому количевству любых символов после знака двоеточия

            Match m = Regex.Match(input, @"(Company name): (.*$)"); 

            for (int i = 0; i < m.Groups.Count; i++)
            {
                Console.WriteLine(m.Groups[i]);
            }

            // Задержка.
            Console.ReadKey();
        }
    }
}
