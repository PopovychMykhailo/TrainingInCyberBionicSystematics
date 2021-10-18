using System;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

// Регулярные выражения.

/*  
          Match представляет подстроку соответсвующую шаблону.
          Match.Success - булево значение, которое показывает найдено вхождение или нет.
          Все переменные обьявленные в шаблоне( (?<mylink>) и (?<mylnktext>) ) хранятся в колекции Mathes.Groups.
          В нашем случае нам прийдется использовать m.Groups["mylink"] и m.Groups["mylnktext"],
          для вывода значения каждой переменной. 
*/

namespace RegularExpressions7
{
    class Program
    {
        static void Main()
        {
            Console.OutputEncoding = Encoding.Unicode;
            string input = "";
            input += "<a href='http://cbsystematics.com'>Home-page</a>";
            input += "<a href='http://google.com'>Search</a>";
            input += "<a href='https://ya.ru'>Yandex</a>";
            input += "<a href='https://yandex.ru'>Yandex Full</a>";
            input += "<a href='http://microsoft.com'>Microsoft</a>";

            var regex = new Regex(@"href='(?<link>\S+)'>(?<text>\S+)</a>");
            Console.WriteLine(input);
            
            // for(текущее_значение_m; условие; действие_при_каждой_итерации).
            for (Match m = regex.Match(input); m.Success; m = m.NextMatch())
            {
                // {0,-25} - значит что выделить 25 знакомест под вывод {0}. (-) - значит "прижаться" влево :)
                Console.WriteLine("ССЫЛКА: {0,-25} на: {1,-4} позиции с именем: {2}", m.Groups["link"],
                                                                                      m.Groups["link"].Index,
                                                                                      m.Groups["text"]);
            }

            Console.WriteLine(new string('-', 25));

            foreach (Match m in regex.Matches(input))
            {
                Console.WriteLine("ССЫЛКА: {0,-25} на: {1,-4} позиции с именем: {2}", m.Groups["link"],
                                  m.Groups["link"].Index,
                                  m.Groups["text"]);
            }

            Console.WriteLine(new string('-',20));
            var htmlQuery = from Match m in regex.Matches(input)
                            where m.Groups["link"].Value.StartsWith("https")
                            select m;


            foreach (var m in htmlQuery)
            {
                Console.WriteLine("ССЫЛКА: {0,-25} на: {1,-4} позиции с именем: {2}", m.Groups["link"],
                                 m.Groups["link"].Index,
                                 m.Groups["text"]);
            }
            // Delay.
            Console.ReadKey();
        }
    }
}
