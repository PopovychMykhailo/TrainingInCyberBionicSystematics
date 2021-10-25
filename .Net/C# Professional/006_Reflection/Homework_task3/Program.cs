using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

namespace Homework_task3
{
    /* Technical task
    
        Создайте программу, в которой предоставьте пользователю доступ к сборке из Задания 2.
        Реализуйте использование метода конвертации значения температуры из шкалы Цельсия в
        шкалу Фаренгейта. Выполняя задание используйте только рефлексию.
    */



    class Program
    {
        static void Main()
        {
            Assembly assembly = null;

            // Open library
            try
            {
                assembly = Assembly.Load("Homework_task2");
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine(e.Message);
            }

            Type type = assembly.GetType("ThermometerLibrary.Thermometer");             // Get type of Thermometer class
            object instance = Activator.CreateInstance(type, new decimal(25));          // Call constructor with parameter '25 Celisus degrees'

            #region View methods and constuctors
            foreach (var method in type.GetMethods())
            {
                StringBuilder parametrsStr = new();
                IEnumerable<ParameterInfo> methodAttributes = method.GetParameters();
                IEnumerator<ParameterInfo> enumerator = methodAttributes.GetEnumerator();

                ColorPrint($"\t Метод: {method.Name}", ConsoleColor.Blue);
                Console.Write(" (");

                if (enumerator.MoveNext())
                    parametrsStr.Append($"{enumerator.Current.ParameterType} {enumerator.Current.Name}");

                while (enumerator.MoveNext())
                    parametrsStr.Append($", {enumerator.Current.ParameterType} { enumerator.Current.Name}");
                parametrsStr.Append(')');

                Console.WriteLine($"{parametrsStr}");

                StringBuilder code = new();
                code.Append(method.ContainsGenericParameters.ToString());
            }
            #endregion

            MethodInfo methodConvert = type.GetMethod("ConvertCelsiusToFahrenheit");    // Get the method of the class
            methodConvert.Invoke(instance, null);                                       // Call the method for convert degrees Celsius to Fahrenheit

            MethodInfo methodGetTemperature = type.GetMethod("get_Temperature");        // Get the method of the class
            decimal temperature = (decimal)methodGetTemperature.Invoke(instance, null); // Call the method for get temperature
            
            Console.WriteLine($"Temperature of Fahrenheit: {temperature}");
        }


        public static void ColorPrintLine(string str, ConsoleColor color)
        {
            ColorPrint(str + Environment.NewLine, color);
        }
        public static void ColorPrint(string str, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.Write(str);
            Console.ResetColor();
        }
    }
}
