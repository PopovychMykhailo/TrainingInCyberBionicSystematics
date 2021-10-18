using System;

namespace Homework_task3
{
    /* Technical task
     
        Используя Visual Studio, создайте проект по шаблону Console Application.
        Создайте анонимный метод, который принимает в качестве аргумента массив делегатов и возвращает
        среднее арифметическое возвращаемых значений методов, сообщенных с делегатами в массиве.
        Методы, сообщенные с делегатами из массива, возвращают случайное значение типа int.
    */

    public delegate int DelegateRandom();
    public delegate float DelegatedArithmeticMean(DelegateRandom[] arrayDelegates);

    class Program
    {
        const int maxValueForRandom = 10;

        static void Main(string[] args)
        {
            DelegateRandom[] arrayDelegates = new DelegateRandom[5];
            DelegatedArithmeticMean delegatedArithmeticMean;

            // Fill the array with an anonymous function
            arrayDelegates[0] = () => { return (new Random()).Next(maxValueForRandom); };
            arrayDelegates[1] = arrayDelegates[0];
            arrayDelegates[2] = arrayDelegates[0];
            arrayDelegates[3] = arrayDelegates[0];
            arrayDelegates[4] = arrayDelegates[0];

            // Write the anonymous function to the main delegated
            delegatedArithmeticMean = (DelegateRandom[] arrayDelegates) => 
            {
                int sum = 0;
                int localSum = 0;   // For show iteration's result in consol

                for (int i = 0; i < arrayDelegates.Length; i++)
                {
                    localSum = arrayDelegates[i]();
                    Console.WriteLine($"{i}-st random function has result: {localSum}");
                    sum += localSum;
                }
                return (float)sum / arrayDelegates.Length;
            };

            Console.WriteLine($"Result of action function: {delegatedArithmeticMean(arrayDelegates)}");
        }
    }
}
