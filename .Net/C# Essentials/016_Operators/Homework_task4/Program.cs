using System;

namespace Homework_task4
{
    /* Technical task
    
        Создайте класс, который будет содержать информацию о дате (день, месяц, год). С помощью
        механизма перегрузки операторов, определите операцию разности двух дат (результат в виде
        количества дней между датами), а также операцию увеличения даты на определенное количество дней.
    */

    class MyDate
    {
        public int Year { set; get; }
        public int Month { set; get; }
        public int Day { set; get; }


        public MyDate() { }
        public MyDate(int year, int month, int day)
        {
            Year = year;
            Month = month;
            Day = day;
        }
        public override string ToString()
        {
            return $"Type: {this.GetType()}; Date: {Year}.{Month}.{Day}";
        }


        public static int operator -(MyDate date1, MyDate date2)
        {
            // In order not to complicate, I make approximate calculations
            return ((date1.Year * 365) + (date1.Month * 30) + (date1.Day)) - ((date2.Year * 365) + (date2.Month * 30) + (date2.Day));
        }
        public static MyDate operator +(MyDate date, int daysAdd)
        {
            date.Year += (daysAdd / 365);    // Add year
            daysAdd -= (daysAdd / 365) * 365;

            date.Month += (daysAdd / 30);     // Add month
            daysAdd -= (daysAdd / 30) * 30;

            date.Day += (daysAdd % 30);            // Add days

            // If days is more 1 month
            if (date.Day > 30)
            {
                date.Day -= 30;
                date.Month += 1;
            }

            // If moths is more 1 year
            if (date.Month > 12)
            {
                date.Month -= 12;
                date.Year += 1;
            }

            return date;
        }

    }

    class Program
    {
        static void Main()
        {
            MyDate date1 = new(2001, 03, 01);
            MyDate date2 = new(2000, 01, 01);

            date2 += 60;
            Console.WriteLine($"Result: {date2}");

            Console.WriteLine($"Difference days: {date1 - date2}");

        }
    }
}
