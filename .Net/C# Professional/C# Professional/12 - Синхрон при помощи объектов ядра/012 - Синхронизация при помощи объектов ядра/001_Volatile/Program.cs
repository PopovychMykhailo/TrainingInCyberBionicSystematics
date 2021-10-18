﻿using System;
using System.Text;
using System.Threading;

/*   
    Ключевое слово volatile можно применять к полям следующих типов:
    1. Ссылочные типы.
    2. Типы, такие как sbyte, byte, short, ushort, int, uint, char, float и bool.
    3. Тип перечисления с одним из следующих базовых типов: byte, sbyte, short, ushort, int или uint.
    4. Параметры универсальных типов, являющиеся ссылочными типами.
    
    Ключевое слово volatile можно применить только к полям класса или структуры.
    Локальные переменные не могут быть объявлены как volatile.

    Поля, помеченные ключевым словом volatile, не проходят оптимизацию компилятором. 
*/

namespace VolatileSample
{
    class Program
    {
        //static volatile bool stop; // Без JIT оптимизации.
        static bool stop; // С JIT оптимизацией.

        static void Main()
        {
            Console.OutputEncoding = Encoding.Unicode;
            Thread thread = new Thread(Function);
            thread.Start();

            Thread.Sleep(2000);

            stop = true;
            Console.WriteLine("Main: ожидание завершения вторичного потока.");
            thread.Join();
        }

        static void Function()
        {            
            int x = 0;

            while (!stop) // Статическое условие (всегда - true)
            {
                x++;
            }

            /*   
               При компиляции данного кода JIT компилятор обнаружит, 
               что переменная stop не изменяется в методе Function.
               JIT Компилятор может создать код, заранее проверяющий условие цикла while,
               а переменная stop принимает участие в формировании условного выражения, 
               но при этом переменная stop не изменяется в методе Function - 
               следовательно оптимизатор делает предположение о том что условие статично,
               (оптимизатор не делает предположений о том что переменная может измениться из другого потока, 
               потому что  официально до определенного времени поток - был просто трюком - игрой с МС 8259А)
               Оптимизатор пытается угодить буферу предсказаний переходов CPU.
                           
               ВНИМАНИЕ! 
               [Оптимизация не производиться в режиме отладки - DEBUG]
               [Если stop - volatile - то оптимизация JIT компилятором производиться не будет]
            */

            // Код метода после JIT оптимизации, если stop не volatile:
            //if (stop != true)
            //{
            //    Label:
            //    x++;
            //    goto Label;  // Оптимизация за счет чистого перехода без проверки условия.
            //}

            Console.WriteLine("Function: поток остановлен при x = {0}.", x);
        }
    }
}
