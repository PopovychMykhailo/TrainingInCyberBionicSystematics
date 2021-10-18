using System;
using System.Text;

namespace _002_Tuples
{
    class Program
    {
        static void Main()
        {
            Console.OutputEncoding = Encoding.Unicode;

            const string sentence = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.";

            const string substring = "pariatur";

            // возврат нескольких значений из метода с помощью out параметров
            bool found = FindSubstring(sentence, substring, out int startPosition);
            if (found)
            {
                Console.WriteLine($"Подстрока \"{substring}\" найдена начиная с {startPosition} символа.");
            }
            else 
            {
                Console.WriteLine($"Подстрока \"{substring}\" не найдена.");
            }

            // возврат нескольких значений из метода с помощью кортежей

            const string substring1 = "C#";

            var findResult = FindSubstring(sentence, substring1);
            if (findResult.Found)
            {
                Console.WriteLine($"Подстрока \"{substring1}\" найдена начиная с {findResult.StartPosition} символа.");
            }
            else
            {
                Console.WriteLine($"Подстрока \"{substring1}\" не найдена.");
            }
        }

        private static bool FindSubstring(string sentence, string substring, out int startPosition)
        {
            var index = sentence.IndexOf(substring);
            startPosition = index;
            return index > -1;
        }

        private static (bool Found, int StartPosition) FindSubstring(string sentence, string substring)
        {
            var index = sentence.IndexOf(substring);
            return (index > -1, index);
        }
    }
}
