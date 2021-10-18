using System;
using System.Text;
using System.Globalization;

// Создание форматированного пользовательского вывода.

namespace StringBasics
{
    public class ComplexTestFormatter : ICustomFormatter, IFormatProvider
    {
        // Реализация IFormatProvider. Неявно вызывается методом String.Format(...
        public object GetFormat(Type formatType)
        {
            return formatType == typeof(ICustomFormatter)
                ? this
                : CultureInfo.CurrentCulture.GetFormat(formatType);
        }

        // Реализация ICustomFormatter 
        public string Format(string format, object argument, IFormatProvider formatProvider)
        {
            if (argument is Complex && format == "TEST")
            {
                var complex = (Complex)argument;

                // Сгенерировать отладочный вывод для данного объекта 
                var builder = new StringBuilder();

                builder.Append(argument.GetType() + "\n");
                builder.AppendFormat("^действительная:\t{0}\n", complex.Real);
                builder.AppendFormat("^мнимая:\t\t{0}\n", complex.Imaginary);

                return builder.ToString();
            }
            else
            {
                var formattable = argument as IFormattable;

                return formattable != null
                    ? formattable.ToString(format, formatProvider)
                    : argument.ToString();
            }
        }
    }

    public struct Complex : IFormattable
    {
        private double real;
        private double imaginary;

        public Complex(double real, double imaginary)
        {
            this.real = real;
            this.imaginary = imaginary;
        }

        public double Real
        {
            get { return real; }
        }

        public double Imaginary
        {
            get { return imaginary; }
        }

        // Реализация IFormattable 
        public string ToString(string format, IFormatProvider formatProvider)
        {
            var builder = new StringBuilder();

            builder.Append(" ( ");
            builder.Append(real.ToString(format, formatProvider));
            builder.Append(" : ");
            builder.Append(imaginary.ToString(format, formatProvider));
            builder.Append(" ) ");

            return builder.ToString();
        }
    }

    public class Program
    {
        static void Main()
        {
            Console.OutputEncoding = Encoding.Unicode;
            var my = CultureInfo.CurrentCulture;
            var en = new CultureInfo("uk-UA");

            var complex = new Complex(12.3456, 1234.56);

            string stringComplex = complex.ToString("F", my);
            Console.WriteLine(stringComplex);

            stringComplex = complex.ToString("F", en);
            Console.WriteLine(stringComplex);

            var testFormatter = new ComplexTestFormatter();
            stringComplex = String.Format(testFormatter, "{0:TEST}", complex);

            Console.WriteLine("\nОтладочный вывод:\n{0}", stringComplex);

            // Delay.
            Console.ReadKey();
        }
    }
}
