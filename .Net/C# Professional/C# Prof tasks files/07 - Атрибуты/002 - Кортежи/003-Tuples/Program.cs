using System;
using System.Text;

namespace _003_Tuples
{
    /*
      Оператор присваивания = можно также использовать для деконструкции экземпляра кортежа в отдельные переменные.
      Начиная с C# 7.3, типы кортежей поддерживают операторы равенства == и !=.
     */
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.Unicode;

            // деконструкция кортежей

            (int, string, double) tuple = (10, "hello", 12.3);
            Console.WriteLine($"Кортеж {nameof(tuple)}: {tuple}");

            var (myInt, myString, myDouble) = tuple;
            Console.WriteLine($"Отдельные переменные: {nameof(myInt)} = {myInt}; {nameof(myString)} = {myString}; {nameof(myDouble)} = {myDouble};");

            Console.WriteLine(new string('-', Console.WindowWidth));

            // Изменение значений переменных с помощью деконструкции

            (myInt, myString) = (9, "Hello World!");
            Console.WriteLine($"{nameof(myInt)} = {myInt}; {nameof(myString)} = {myString};");

            Console.WriteLine(new string('-', Console.WindowWidth));

            // сравнение кортежей

            var t1 = (10,23);
            var t2 = (23, 10);
            Console.WriteLine($"{t1} == {t2} : {t1 == t2}");


            var t3 = ("Hello", 23);
            var t4 = ("World", 23);
            Console.WriteLine($"{t3} == {t4} : {t3 == t4}");


            var t5 = ("Hello World!", 12.3, new DateTime(2000,01,01));
            var t6 = ("Hello World!", 12.3, new DateTime(2000, 01, 01));
            Console.WriteLine($"{t5} == {t6} : {t5 == t6}");
        }
    }
}
