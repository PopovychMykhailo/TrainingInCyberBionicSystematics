using System;
using System.Text.RegularExpressions;

// Регулярные выражения.

namespace RegularExpressions5
{
    class Program
    {
        static void Main()
        {
            Regex regex;
            string pattern;
            string text;

            // Возможно указать необходимые символы между скобок [].
            pattern = "^[qwerty]+$";
            text = "qwec"; // Анализируемая строка.
            regex = new Regex(pattern);
            Console.WriteLine("{0} == {1} : {2}\n", text, pattern, regex.IsMatch(text));

            // Строка может состоять только из символов - [qwerty]. Например:  qqq, yyqyqyyyq, eeer ...
            pattern = "^[qwerty]+$";
            text = "qrwere";  // Анализируемая строка.
            regex = new Regex(pattern);
            Console.WriteLine("{0} == {1} : {2}\n", text, pattern, regex.IsMatch(text));

            pattern = "^[abcdefghigklmnopqrstuvwxyz]+$";
            text = "test"; // Анализируемая строка.
            regex = new Regex(pattern);
            Console.WriteLine("{0} == {1} : {2}\n", text, pattern, regex.IsMatch(text));

            // Второй способ, a-z это замена более длинного шаблона abcdefghigklmnopqrstuvwxyz
            pattern = @"^[a-z]+$";
            text = "test"; // Анализируемая строка.
            regex = new Regex(pattern);
            Console.WriteLine("{0} == {1} : {2}\n", text, pattern, regex.IsMatch(text));

            // 0-9 это замена 01234567890.
            pattern = "^[a-z0-9]+$";
            text = "test007"; // Анализируемая строка.
            regex = new Regex(pattern);
            Console.WriteLine("{0} == {1} : {2}\n", text, pattern, regex.IsMatch(text));

            // 0-9 это замена 01234567890.
            pattern = "^[a-z0-9]+$";
            text = "test 007"; // Анализируемая строка.
            regex = new Regex(pattern);
            Console.WriteLine("{0} == {1} : {2}\n", text, pattern, regex.IsMatch(text));

            // Шаблон даты.
            pattern = @"^\d{2}-\d{2}-\d{4}$";
            text = "02-05-1982"; // Анализируемая строка.
            regex = new Regex(pattern);
            Console.WriteLine("{0} == {1} : {2}\n", text, pattern, regex.IsMatch(text));

            // Квантификатор * значит, что вхождение 0 и более раз...
            pattern = @"^\d*$";
            text = "ertty"; // Анализируемая строка.
            regex = new Regex(pattern);
            Console.WriteLine("{0} == {1} : {2}\n", text, pattern, regex.IsMatch(text));

            // Квантификатор * значит, что вхождение 0 и более раз...
            pattern = @"^\d*$";
            text = ""; // Анализируемая строка.
            regex = new Regex(pattern);
            Console.WriteLine("{0} == {1} : {2}\n", text, pattern, regex.IsMatch(text));

            // Простой шаблон сравнения e-mail.
            pattern = @"^[0-9a-z_-]+@[\S]+\.\S{2,4}$";
            text = "test@mail123.rлu"; // Анализируемая строка.
            regex = new Regex(pattern);
            Console.WriteLine("{0} == {1} : {2}\n", text, pattern, regex.IsMatch(text));
            
            // Delay.
            Console.ReadKey();
        }
    }
}
