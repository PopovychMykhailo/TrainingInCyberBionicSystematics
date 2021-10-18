using System;

namespace _001_NullableReferenceTypes
{

    /* 
    В C# 8.0 появилась возможность использования ссылочных типов, допускающих или не допускающих значение NULL.
    Эта возможность полезна для того чтобы избежать NullReferenceException. 
    При создании ссылочной переменно или члена типа можно указать, допускает ли данная переменная или член типа значение NULL.
    В этом случа, при использовании соответствующих параметров компиляции, компилятор может выдать предупреждене 
    (или ошибку, это можно настроить), если к ссылочному типу, допускающему значение NULL происходит доступ без проверки.
     */

    /* 
    Для того, чтобы включить проверку ссылочных типов, допускающих значение NULL,
    необходимо добавить следующюю строку в .csproj файлб в элемент PropertyGroup:
    <Nullable>enable</Nullable>

    Пример: 
    <PropertyGroup>
      <OutputType>Exe</OutputType>
      <TargetFramework>netcoreapp3.1</TargetFramework>
      <RootNamespace>_001_NullableReferenceTypes</RootNamespace>
      <Nullable>enable</Nullable>
    </PropertyGroup>
     */

    class Program
    {
        static void Main(string[] args)
        {
            // notNullableString не подразумевает возможности принимать значение NULL
            string notNullableString = null; // компилятор выдает предупреждение при попытке присвоить NULL в notNullableString

            // компилятор выдает предупреждение при попытке обратиться к свойству Length, 
            // потому что ранее notNullableString было присвоено значение NULL
            Console.WriteLine(notNullableString.Length);
            
            string realNotNullableString = "string"; // нет предупреждения
            Console.WriteLine(realNotNullableString.Length); // нет предупреждения

            // nullableString подразумевает возможность принимать значение NULL
            string? nullableString = null;
            // компилятор выдает предупреждение при попытке обратиться к свойству Length, 
            // потому что ранее nullableString было присвоено значение NULL
            Console.WriteLine(nullableString.Length);

            if (nullableString != null)
            {
                Console.WriteLine(nullableString.Length); // нет предупреждения, nullableString здесб точно не NULL
            }

            Console.WriteLine("Hello World!");
        }
    }
}
