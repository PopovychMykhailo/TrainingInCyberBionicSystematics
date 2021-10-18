using System;

namespace _002_NullableReferenceTypes
{
    class Program
    {

        public static void PrintNotNullableString(string notNullableString)
        {
            Console.WriteLine($"\"{notNullableString}\" length is: {notNullableString.Length}"); // предупреждения нет
        }

        public static void PrintNullableStringSafe(string? nullableString)
        {
            if (nullableString != null)
            {
                Console.WriteLine($"\"{nullableString}\" length is: {nullableString.Length}"); // предупреждения нет
            }
            else
            {
                Console.WriteLine($"{nameof(nullableString)} is null.");
            }
        }

        public static void PrintNullableString(string? nullableString)
        {
            Console.WriteLine($"\"{nullableString}\" length is: {nullableString.Length}"); // при выполнении действий, которые могут привести к NullReferenceException, появляется предупреждение
        }

        public static void PrintNullableStringSuppressWarning(string? nullableString)
        {
            // добавление символа "!" приводит к подавлению предупреждения
            // это означает, что написавший код знает, что при этом вызове может возникнуть исключение, 
            // но это нормально и вызов всё равно должен быть совершен без дополнительных проверок
            Console.WriteLine($"\"{nullableString}\" may be null but it's OK, it's length is: {nullableString!.Length}");
        }


        static void Main(string[] args)
        {
            PrintNullableString("some string 1");
            PrintNullableStringSafe(null);
            PrintNullableStringSuppressWarning("some string 2");
            // PrintNotNullableString(null); // предупреждение
            PrintNotNullableString("some string 3"); // предупреждение
        }
    }
}
