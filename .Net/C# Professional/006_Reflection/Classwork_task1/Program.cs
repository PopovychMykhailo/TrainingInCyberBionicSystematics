using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

namespace Classwork_task1
{
    /* Technical task
    
        Создайте программу-рефлектор, которая позволит получить информацию о сборке и входящих
        в ее состав типах. Для основы можно использовать программу-рефлектор из урока.
    */


    class Program
    {
        static void Main()
        {
            // Строка приема полного имени загружаемой сборки.
            string path = @"D:\Learning\Programming\TrainingInCyberBionicSystematics\.Net\C# Professional\001_UserCollections\Homework_task2\bin\Debug\net5.0\Homework_task2.dll";
            Assembly assembly = null;

            try
            {
                assembly = Assembly.LoadFile(path);

                Console.WriteLine("СБОРКА    " + path + "  -  УСПЕШНО ЗАГРУЖЕНА" + Environment.NewLine + Environment.NewLine);
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
            }

            // Вывод информации о всех типах в сборке.
            Console.WriteLine("СПИСОК ВСЕХ ТИПОВ В СБОРКЕ:     " + assembly.FullName + Environment.NewLine + Environment.NewLine);


            // Get info about all classes in the file
            Type[] types = assembly.GetTypes();
            foreach (Type type in types)
            {
                ColorPrint($"Тип: {type} {Environment.NewLine}", ConsoleColor.Green);

                // Get info about all method and their arguments
                MethodInfo[] methods = type.GetMethods();
                foreach (var method in methods)
                {
                    StringBuilder parametrsStr = new();
                    IEnumerable<ParameterInfo> methodAttributes = method.GetParameters();
                    IEnumerator<ParameterInfo> enumerator = methodAttributes.GetEnumerator();

                    ColorPrint($"\t Метод: {method.Name}", ConsoleColor.Blue);
                    Console.Write(" (");

                    if (enumerator.MoveNext())
                        parametrsStr.Append($"{enumerator.Current.ParameterType} {enumerator.Current.Name}");

                    while(enumerator.MoveNext())
                        parametrsStr.Append($", {enumerator.Current.ParameterType} { enumerator.Current.Name}");
                    parametrsStr.Append(')');

                    Console.WriteLine($"{parametrsStr}");

                    StringBuilder code = new();
                    code.Append(method.ContainsGenericParameters.ToString());
                }

                Console.WriteLine();
            }
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
