using System;

namespace HomeWork_task2
{
    class Program
    {
        static void Main(string[] args)
        {
            Random random = new();
            int[] myArray = new int[20];
            int[] oddArray;

            for (int i = 0; i < myArray.Length; ++i)
                myArray[i] = random.Next(100);

            oddArray = MathForArray.Odd(myArray);

            Console.WriteLine($"maxValue:   {MathForArray.Max(myArray)}");
            Console.WriteLine($"minValue:   {MathForArray.Min(myArray)}");
            Console.WriteLine($"sum:        {MathForArray.Sum(myArray)}");
            Console.WriteLine($"avarage     {MathForArray.Average(myArray)}");
            Console.Write(    $"odd:        {oddArray[0]}");
            for (int i = 1; i < oddArray.Length; ++i)
                Console.Write($", {oddArray[i]}");

            Console.WriteLine();
        }

        static class MathForArray
        {
            // Посик максимального числа в масиве
            static public int Max(int[] array)
            {
                if (array.Length > 0) {
                    
                    int maxValue = array[0];

                    for (int i = 0; i < array.Length; ++i)
                        if (array[i] > maxValue)
                            maxValue = array[i];

                    return maxValue;
                }
                else
                {
                    Console.WriteLine("Масив пуст!");
                    return 0;
                }
            }
            
            // Посик минимального числа в масиве
            static public int Min(int[] array)
            {
                if (array.Length > 0) {
                    
                    int minValue = array[0];

                    for (int i = 0; i < array.Length; ++i)
                        if (array[i] < minValue)
                            minValue = array[i];

                    return minValue;
                }
                else
                {
                    Console.WriteLine("Масив пуст!");
                    return 0;
                }
            }

            // Подсчет суммы всех значений масива
            static public int Sum(int[] array)
            {
                if (array.Length > 0)
                {

                    int sumValue = 0;

                    for (int i = 0; i < array.Length; ++i)
                            sumValue += array[i];

                    return sumValue;
                }
                else
                {
                    Console.WriteLine("Масив пуст!");
                    return 0;
                }
            }

            // Подсчет среднего арифметического числа
            static public float Average(int[] array)
            {
                if (array.Length > 0)
                {
                    return (float)Sum(array) / (float)array.Length;
                }
                else
                {
                    Console.WriteLine("Масив пуст!");
                    return 0;
                }
            }

            // Поиск нечетных чисел
            static public int[] Odd(int[] array)
            {
                if (array.Length > 0)
                {
                    int[] oddArray = new int[array.Length];
                    int oddArray_fullness = 0;

                    for (int i = 0; i < array.Length; ++i)
                        if (array[i] % 2 == 1)
                           oddArray[oddArray_fullness++] += array[i];

                    int[] newOddArray = new int[oddArray_fullness];
                    for (int i = 0; i < newOddArray.Length; ++i)
                        newOddArray[i] = oddArray[i];

                    return newOddArray;
                }
                else
                {
                    Console.WriteLine("Масив пуст!");
                    return new int[] { 0 };
                }
            }
        }
    }
}
