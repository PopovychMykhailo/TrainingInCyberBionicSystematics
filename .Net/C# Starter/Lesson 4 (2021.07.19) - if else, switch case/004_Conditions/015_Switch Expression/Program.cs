using System;
using System.Text;

namespace _015_Switch_Expression
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.Unicode;
            Console.InputEncoding = Encoding.Unicode;

            Console.WriteLine("Введите название дня недели:");
            string dayOfWeek = Console.ReadLine();
            string dayOfWeekInLowerCase = dayOfWeek.ToLower(); // ToLower() - приводит строку в нижний регистр

            int dayOfWeekNumber = dayOfWeekInLowerCase switch
            {
                "понедельник" => 1,
                "вторник" => 2,
                "среда" => 3,
                "четверг" => 4,
                "пятница" => 5,
                "суббота" => 6,
                "воскресенье" => 7,
                _ => -1
            };

            if (dayOfWeekNumber > 0)
            {
                Console.WriteLine($"{dayOfWeek} это {dayOfWeekNumber} день недели.");
            }
            else
            {
                Console.WriteLine($"Я не знаю дня недели под названием {dayOfWeek}");
            }
        }
    }
}
