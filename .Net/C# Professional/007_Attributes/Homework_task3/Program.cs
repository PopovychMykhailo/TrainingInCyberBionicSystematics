using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

namespace Homework_task3
{
    /* Technical task
    
        Расширьте возможности программы-рефлектора из предыдущего урока следующим образом:
        1. Добавьте возможность выбирать, какие именно члены типа должны быть показаны
            пользователю. При этом должна быть возможность выбирать сразу несколько членов
            типа, например, методы и свойства.
        2. Добавьте возможность вывода информации об атрибутах для типов и всех членов типа,
            которые могут быть декорированы атрибутами
    */

    [Flags]
    enum ReflectionTargets
    {
        Constructors = AttributeTargets.Constructor,
        Methods = AttributeTargets.Method,
        Parameters = AttributeTargets.Parameter,
        Propertyes = AttributeTargets.Property,
        Fields = AttributeTargets.Field
    }

    class Program
    {
        static void Main()
        {
            ReflectionTargets userSelectedTargets = UserSelectTargets();

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
                ColorPrint($"Type: {type} {Environment.NewLine}", ConsoleColor.Green);

                // Get info about all constructors and their arguments
                if ((userSelectedTargets & ReflectionTargets.Constructors) > 0)
                {
                    ConstructorInfo[] constructors = type.GetConstructors();

                    foreach (var constructor in constructors)
                    {
                        StringBuilder parametrsStr = new();
                        IEnumerable<ParameterInfo> constructorAttributes = constructor.GetParameters();
                        IEnumerator<ParameterInfo> enumerator = constructorAttributes.GetEnumerator();

                        ColorPrint($"\t Constructor: {constructor.Name}", ConsoleColor.DarkYellow);

                        // Get info about all parameters of this constructor
                        if ((userSelectedTargets & ReflectionTargets.Parameters) > 0)
                        {
                            Console.Write(" (");

                            if (enumerator.MoveNext())
                                parametrsStr.Append($"{enumerator.Current.ParameterType} {enumerator.Current.Name}");

                            while (enumerator.MoveNext())
                                parametrsStr.Append($", {enumerator.Current.ParameterType} { enumerator.Current.Name}");
                            //parametrsStr.Append(')');

                            ColorPrint($"{parametrsStr}", ConsoleColor.DarkMagenta);
                            Console.WriteLine(')');
                        }
                    }

                    if (constructors.Length > 0)
                        Console.WriteLine();
                }

                // Get info about all method and their arguments
                if ((userSelectedTargets & ReflectionTargets.Methods) > 0)
                {
                    MethodInfo[] methods = type.GetMethods();

                    foreach (var method in methods)
                    {
                        StringBuilder parametrsStr = new();
                        IEnumerable<ParameterInfo> methodAttributes = method.GetParameters();
                        IEnumerator<ParameterInfo> enumerator = methodAttributes.GetEnumerator();

                        ColorPrint($"\t Method: {method.Name}", ConsoleColor.Yellow);

                        // Get info about all parameters of this method
                        if ((userSelectedTargets & ReflectionTargets.Parameters) > 0)
                        {
                            Console.Write(" (");

                            if (enumerator.MoveNext())
                                parametrsStr.Append($"{enumerator.Current.ParameterType} {enumerator.Current.Name}");

                            while (enumerator.MoveNext())
                                parametrsStr.Append($", {enumerator.Current.ParameterType} { enumerator.Current.Name}");
                            //parametrsStr.Append(')');

                            ColorPrint($"{parametrsStr}", ConsoleColor.DarkMagenta);
                            Console.WriteLine(')');
                        }
                    }

                    if (methods.Length > 0)
                        Console.WriteLine();
                }

                // Get info about all propertyes
                if ((userSelectedTargets & ReflectionTargets.Propertyes) > 0)
                {
                    PropertyInfo[] propertyes = type.GetProperties();

                    foreach (var property in propertyes)
                    {
                        ColorPrintLine($"\t Property: {property.Name}", ConsoleColor.Cyan);
                    }

                    if (propertyes.Length > 0)
                        Console.WriteLine();
                }

                // Get info about all fields
                if ((userSelectedTargets & ReflectionTargets.Fields) > 0)
                {
                    FieldInfo[] fields = type.GetFields();

                    foreach (var field in fields)
                    {
                        ColorPrintLine($"\t Field: {field.Name}", ConsoleColor.DarkBlue);
                    }

                    if (fields.Length > 0)
                        Console.WriteLine();
                }

            }
        }

        public static ReflectionTargets UserSelectTargets()
        {

            List<KeyValuePair<int, ReflectionTargets>> listOption = new(5);
            ReflectionTargets selectedTargets = 0;
            (int min, int max, int currentRow) cursor = (0, listOption.Capacity, 0);
            ConsoleKeyInfo presedKey;

            listOption.Add(new KeyValuePair<int, ReflectionTargets>(0, ReflectionTargets.Constructors));   // Constructors
            listOption.Add(new KeyValuePair<int, ReflectionTargets>(1, ReflectionTargets.Methods));        // Methods
            listOption.Add(new KeyValuePair<int, ReflectionTargets>(2, ReflectionTargets.Parameters));     // Method's and consturctor's parameters
            listOption.Add(new KeyValuePair<int, ReflectionTargets>(3, ReflectionTargets.Propertyes));     // Propertyes
            listOption.Add(new KeyValuePair<int, ReflectionTargets>(4, ReflectionTargets.Fields));         // Fields

            while (true)
            {
                Console.Clear();
                Console.WriteLine("Select targets (\"press\" to select, ↑↓ keys to move the cursor)");

                // Show all options to choose from
                for (int i = 0; i < listOption.Count; i++)
                {
                    ColorPrintLine(listOption[i].Value.ToString(),
                        (selectedTargets & listOption[i].Value) > 0 ? ConsoleColor.Green : ConsoleColor.Red,     // Highlight if this option selected
                        cursor.currentRow == listOption[i].Key ? ConsoleColor.White : ConsoleColor.Black);  // Highlight if cursor is on this row
                }

                presedKey = Console.ReadKey();

                switch (presedKey.Key)
                {
                    case ConsoleKey.Spacebar:
                        {
                            selectedTargets ^= listOption[cursor.currentRow].Value; // Bits inverted AND
                            break;
                        }
                    case ConsoleKey.UpArrow:
                        {
                            if (cursor.currentRow > cursor.min)
                                --cursor.currentRow;
                            break;
                        }
                    case ConsoleKey.DownArrow:
                        {
                            if (cursor.currentRow < cursor.max - 1)
                                ++cursor.currentRow;
                            break;
                        }
                    default:    // ConsoleKey.Enter or other key
                        {
                            Console.WriteLine();
                            Console.WriteLine();
                            return selectedTargets;
                        }
                }
            }
        }

        public static void ColorPrintLine(string str, ConsoleColor charsColor, ConsoleColor backgroundColor = ConsoleColor.Black)
        {
            ColorPrint(str + Environment.NewLine, charsColor, backgroundColor);
        }
        public static void ColorPrint(string str, ConsoleColor charsColor, ConsoleColor backgroundColor = ConsoleColor.Black)
        {
            Console.ForegroundColor = charsColor;
            Console.BackgroundColor = backgroundColor;
            Console.Write(str);
            Console.ResetColor();
        }
    }
}
