using System;
using System.Text;
using System.Globalization;
using System.Threading;

// Если дискриминант меньше нуля (D < 0), то квадратное уравнение 
// не имеет действительных корней, а имеет комплексные корни.

// Создание форматированного пользовательского вывода.

namespace StringBasics
{
    public struct Complex : IFormattable
    {
        private double real;
        private double imaginary;

        public Complex(double real, double imaginary)
        {
            this.real = real;
            this.imaginary = imaginary;
        }

        // Реализация IFormattable 
        public string ToString(string format, IFormatProvider formatProvider)
        {
            var builder = new StringBuilder();

            if (format == "TEST")
            {
                // Генерация отладочного вывода для данного объекта 
                builder.Append(this.GetType() + "\n");
                builder.AppendFormat(" действительная:\t{0}\n", real);
                builder.AppendFormat(" мнимая:\t\t{0}\n", imaginary);
            }
            else
            {
                builder.Append(" ( ");
                builder.Append(real.ToString(format, formatProvider));
                builder.Append(" : ");
                builder.Append(imaginary.ToString(format, formatProvider));
                builder.Append(" ) ");
            }

            return builder.ToString();
        }
    }

    public class Program
    {
        static void Main()
        {
            Console.OutputEncoding = Encoding.Unicode;
            var my = CultureInfo.CurrentCulture;
            var ua = new CultureInfo("uk-UA");
            
            var complex = new Complex(12.3456, 1234.5678);

            string stringComplex = complex.ToString("F", my); // F - по умолчанию = F2.
            Console.WriteLine(stringComplex); // RU - запятая в числе.

            stringComplex = complex.ToString("F2", ua);
            Console.WriteLine(stringComplex); // US - точка в числе.

            Console.WriteLine("\nОтладочный вывод:\n{0:TEST}", complex);

            // Delay.
            Console.ReadKey();
        }
    }
}