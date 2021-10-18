using System;
using System.Text.RegularExpressions;

// Регулярные выражения. 

/*
          Метод Regex.Replace заменяет в первом параметре - строке (myString) 
          подстроку соответствующую шаблону (String) во втором параметре, на подстроку-вставку в третем параметре (Test).
          Regex.Replace("myString","String","Test"); - результат myTest
  
          Шаблонные переменные - обьявляются в текущем шаблоне таким образом:
          (?<somevar>\d+)  - объявление переменной.
          ${somevar}  -  использование шаблонных переменных в новом шаблоне.
          Пример:  Regex.Replace(@"test123firststr456secondstr", 
                                 @"test(?<first>\d+)firststr(?<second>\d+)secondstr", 
                                 @"test${second}firststr${first}secondstr")
          Этот пример вернёт строку test456firststr123secondstr он изменит шаблон так, что подстрока 123 и 456 поменяются местами. 
  
          В этом же примере используется новая конструкция {1,2} и подобные,
          она определяет кол-во повторов нужного нам элемента(\S, \d, etc). Формат: {min,max}.
          Пример: \d{2,4} - числа длиной от двух до четырёх символов (12, 123, 1234) 12345 - уже не выходит.
*/

namespace RegularExpressions4
{
    class Program
    {
        static void Main()
        {
            // Замена подстроки соответствующей шаблону - пробелом.
            Console.WriteLine(Regex.Replace("test123aaa4x5x6bbb789ccc",  // Исходная строка.
                                            @"\d+",                      // Шаблон.
                                             " "));                      // Символ для замены.

            Console.WriteLine(Regex.Replace("test123aaa4x5x6bbb789ccc",  // Исходная строка.
                                           @"\d",                        // Шаблон.
                                            " "));                       // Символ для замены.

            Console.WriteLine(Regex.Replace("02/05/1982",                                           // Исходная строка. 5 февраля
                                           @"(?<месяц>\d{1,2})/(?<день>\d{1,2})\/(?<год>\d{2,4})",  // Шаблон.
                                           //@"(?<месяц>\d{1,2})\/(?<день>\d{1,2})\/(?<год>\d{2,4})",   // Шаблон.
                                           "${день}-${месяц}-${год}"));                             // Новый формат.
           
            Console.WriteLine(Regex.Replace(@"test123firststr456secondstr",                         // Исходная строка.
                                            @"test(?<var1>\d+)firststr(?<var2>\d+)secondstr",       // Шаблон.
                                            @"test${var2}firststr${var1}secondstr"));               // Новый формат.

            Console.WriteLine(Regex.Replace("5 is less than 10",                                    // Исходная строка.
                                            @"\d",                                                 // Шаблон.
                                            m => (int.Parse(m.Value) + 1).ToString()));            // Функция изменения совпадения
    
            // Delay.
            Console.ReadKey();
        }
    }
}
