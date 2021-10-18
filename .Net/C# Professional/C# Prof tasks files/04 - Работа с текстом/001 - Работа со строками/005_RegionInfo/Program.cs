using System;
using System.Globalization;
using System.IO.Ports;
using System.Text;

// Работа с регионом.
// Список обозначений культур:
// http://msdn.microsoft.com/en-us/library/system.globalization.cultureinfo(v=vs.71).aspx

namespace StringBasics
{
    class Program
    {
        static void Main()
        {
            Console.OutputEncoding = Encoding.Unicode;
            // Получение информации о текущем регионе.
            RegionInfo regionInfo = RegionInfo.CurrentRegion;
            Console.WriteLine("EnglishName региона:\t{0}.", regionInfo.EnglishName);
            Console.WriteLine("NativeName региона:\t{0}.", regionInfo.NativeName);

            Console.WriteLine(new string('-', 35));

            Console.WriteLine("CurrencySymbol региона:\t{0}", regionInfo.CurrencySymbol);
            Console.WriteLine("CurrencyEnglishName:\t{0}", regionInfo.CurrencyEnglishName);
            Console.WriteLine("CurrencyNativeName:\t{0}", regionInfo.CurrencyNativeName);

            Console.WriteLine(new string('-', 35));

            // Получение информации о текущем формате даты: названия дней.
            string[] days = CultureInfo.CurrentCulture.DateTimeFormat.DayNames;

            Console.WriteLine("Дни недели:");
            foreach (string day in days)
            {
                Console.WriteLine(day);
            }

            Console.WriteLine(new string('-', 35));

            // Получение информации о формате даты в немецком языке: названия дней.
            days = CultureInfo.GetCultureInfo("de-DE").DateTimeFormat.DayNames;

            Console.WriteLine("Дни недели на немецком:");
            foreach (string day in days)
            {
                Console.WriteLine(day);
            }

            // Delay.
            Console.ReadKey();
        }
    }
}
