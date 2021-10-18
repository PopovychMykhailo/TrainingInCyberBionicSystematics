using System;

namespace _003_NullableReferenceTypes
{
    /*
    Для того, чтобы предупреждения, связанные с проверками на NULL препядствовали компиляции проекта, 
    можно добавить следующую строку в элемент PropertyGroup в файле .csproj:
    <WarningsAsErrors>nullable</WarningsAsErrors>

    Для того, чтобы любое предупреждение трактовалось как ошибка компиляции, можно добавить следующую настройку:
    <TreatWarningsAsErrors>true</TreatWarningsAsErrors>

    Пример:
    <PropertyGroup>
      <OutputType>Exe</OutputType>
      <TargetFramework>netcoreapp3.1</TargetFramework>
      <RootNamespace>_003_NullableReferenceTypes</RootNamespace>
      <Nullable>enable</Nullable>
      <WarningsAsErrors>nullable</WarningsAsErrors>
    </PropertyGroup>

     */
    class Program
    {
        static void Main(string[] args)
        {       
            string notNullableString = null; // ошибка компиляции, потому что notNullableString не допускает значения NULL

            Console.WriteLine(notNullableString.Length); // ошибка компиляции, потому возможно возникновение NullReferenceException
        }
    }
}
