using System;

// Структуры. 

// Пример плохого дизайна.

namespace Structure
{
    struct ZipCode
    {
        // Поля
        int fiveDigitCode;
        int plusFourExtension;

        // Свойства.
        public int FiveDigitCode
        {
            get { return fiveDigitCode; }
            set { fiveDigitCode = value; }
        }

        public int PlusFourExtension
        {
            get { return plusFourExtension; }
            set { plusFourExtension = value; }
        }
    }

    class Program
    {
        static void Main()
        {
            ZipCode zipCode = new ZipCode();

            zipCode.FiveDigitCode = 12345;
            zipCode.PlusFourExtension = 1234;

            Console.WriteLine(zipCode.FiveDigitCode);
            Console.WriteLine(zipCode.PlusFourExtension);

            // Delay.
            Console.ReadKey();
        }
    }
}
