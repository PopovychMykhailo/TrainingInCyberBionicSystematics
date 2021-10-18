using System;
using System.Text;
using System.Text.RegularExpressions;

// Регулярные выражения.

/*
  
  МЕТАСИМВОЛЫ - это символы для составления Шаблона поиска.
       
  \d    Определяет символы цифр. 
  \D 	Определяет любой символ, который не является цифрой. 
  \w 	Определяет любой символ цифры, буквы или подчеркивания. 
  \W    Определяет любой символ, который не является цифрой, буквой или подчеркиванием. 
  \s 	Определяет любой непечатный символ, включая пробел. 
  \S 	Определяет любой символ, кроме символов табуляции, новой строки и возврата каретки.
   .    Определяет любой символ кроме символа новой строки. 
  \.    Определяет символ точки.
 
 */

namespace RegularExpressions2
{
    class Program
    {
        static void Main()
        {
            Console.OutputEncoding = Encoding.Unicode;
            string pattern = @"\d";

            var regex = new Regex(pattern);

            // Массив строк для стравнения.
            var array = new[] { "test", "123", "test123test", "123test", "test123" };

            foreach (string element in array)
            {
                Console.WriteLine(
                    regex.IsMatch(element)
                        ? "Строка \"{0}\" соответствует шаблону \"{1}\""
                        : "Строка \"{0}\" НЕ соответствует шаблону \"{1}\"", element, pattern);

                Console.WriteLine(new string('-', 50));
            }

            Console.WriteLine("\n\n");

            while (true)
            {
                Console.WriteLine("Введите строку для сравнения: ");

                // Строка с которой будет сравниваться шаблон.
                string input = Console.ReadLine();

                if (input == "exit")
                    break;

                Console.WriteLine(
                    input != null && regex.IsMatch(input)
                        ? "Строка \"{0}\" соответствует шаблону \"{1}\""
                        : "Строка \"{0}\" НЕ соответствует шаблону \"{1}\"", input, pattern);

                Console.WriteLine(new string('-', 50));
            }
        }
    }
}
