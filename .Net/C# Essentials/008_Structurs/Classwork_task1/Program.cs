using System;
using System.Text.RegularExpressions;

namespace _008_Structures
{
    /* Techinal task
     
        Используя Visual Studio, создайте проект по шаблону Console Application.
        Реализуйте программу, которая будет принимать от пользователя дату его рождения и выводить
        количество дней до его следующего дня рождения.
    */

    class Program
    {
        static void Main(string[] args)
        {
            DateTime todayDate = new(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
            DateTime upcomingBirthdayDate;

            int birthdayDate_month;
            int birthdayDate_day;

            int differenceDays = 0;


            Console.WriteLine("Enter birthday date: ");
            Console.Write("Month: "); birthdayDate_month = Convert.ToInt32(Console.ReadLine());
            Console.Write("Day: "); birthdayDate_day = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();
            upcomingBirthdayDate = new DateTime(todayDate.Year, birthdayDate_month, birthdayDate_day);


            // If the birthday is over this year - count to next year
            if (upcomingBirthdayDate < todayDate)
            {
                upcomingBirthdayDate = new DateTime(upcomingBirthdayDate.Year + 1, upcomingBirthdayDate.Month, upcomingBirthdayDate.Day);
                differenceDays = Math.Abs(DifferenceDatesInDays(todayDate, upcomingBirthdayDate));
            }
            else
            {
                differenceDays = Math.Abs(DifferenceDatesInDays(upcomingBirthdayDate, todayDate));
            }

            Console.WriteLine($"Today: {todayDate}; <---> Birthday: {upcomingBirthdayDate}");
            Console.WriteLine($"Days to the birthday: {differenceDays}");
        }

        static int DifferenceDatesInDays(DateTime date1, DateTime date2)
        {
            TimeSpan difference = date1 - date2;

            return difference.Days;
        }
    }
}
