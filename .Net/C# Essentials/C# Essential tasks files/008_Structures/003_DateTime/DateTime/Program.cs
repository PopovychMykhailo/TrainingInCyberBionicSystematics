using System;
using System.Text;

// Структура DateTime представляет текущее время, обычно выраженное как дата и время суток.
// Тип значения DateTime представляет дату и время в диапазоне от 00:00:00 1 января 0001 года (н. э.)
// до 23:59:59 31 декабря 9999 года (н. э.)

namespace WorkDateTime
{
    class Program
    {
        static void Main()
        {
            Console.OutputEncoding = Encoding.Unicode;
            // DateTime.Now возвращает объект System.DateTime, которому присвоены текущие дата и время
            // суток данного компьютера
            DateTime now = DateTime.Now;

            Console.WriteLine("Текущая дата и время : {0}", now);
            Console.WriteLine("Год: {0}", now.Year);
            Console.WriteLine("Месяц: {0}", now.Month);
            Console.WriteLine("День месяца: {0}", now.Day);
             
            Console.WriteLine("Текущее время - {0}:{1}:{2}", now.Hour, now.Minute, now.Second);

            Console.WriteLine("День недели : {0}", now.DayOfWeek);
            Console.WriteLine("Это {0}-й день года", now.DayOfYear);
            
            //Получаем дату текущего компьютера и значение времени, равное полуночи (00:00:00).
            Console.WriteLine(DateTime.Now.Date); 
             
            // Задержка.
            Console.ReadKey();
        }
    }
}
