using System;
using System.Text;

// DateTime представляет момент(значение) времени, тогда как TimeSpan представляет интервал(промежуток) времени. 
// Это означает, что можно вычесть один экземпляр DateTime из другого для получения объекта TimeSpan,
// который представляет собой временной интервал между ними.
// Или можно прибавить положительное значение TimeSpan к текущему значению DateTime, чтобы получить значение 
// DateTime, которое представляет собой будущую дату. 

namespace DateTime2
{
    class Program
    {
        static void Main()
        {
            Console.OutputEncoding = Encoding.Unicode;
            // Создание Новой даты. DateTime(гг, мм, дд)
            DateTime newYearDate = new DateTime(DateTime.Now.Year+1, 1, 1);
            DateTime today = DateTime.Now;

            // Представляет интервал времени.
            TimeSpan left = newYearDate - today;
            Console.WriteLine("До нового года осталось " + left.Days + " дней");
            Console.WriteLine("До нового года осталось " + left.TotalHours + " часов");

            // Создание Новой даты и времени. DateTime(гг, мм, дд, чч, мин, сек)
            DateTime newDate = new DateTime(2012, 12, 05, 23, 11, 11);
           
            Console.WriteLine(newDate);                         // Вывод значения даты и времени на экран
            Console.WriteLine(newDate.TimeOfDay);               // Вывод значение времени, установленного 
                                                                // пользователем на экран

            // Преобразует заданное строковое представление даты и времени в его эквивалент
            Console.WriteLine(DateTime.Parse("3/12/2012"));
            
            Console.WriteLine(DateTime.Parse("05 march 2012"));  // Месяц написать на локальном языке OS.

            // Задержка.
            Console.ReadKey();
        }
    }
}
