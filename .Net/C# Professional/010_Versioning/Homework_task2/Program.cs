using System;
using System.Threading;

namespace Homework_task2
{
    /* Technical task
        
        Выучите описание шаблона Template method (Шаблонный метод). Обратите внимание на
        применимость шаблона, а также на состав его участников и связи отношения между ними.
        Напишите небольшую программу на языке C#, представляющую собой абстрактную
        реализацию данного шаблона.
    */


    abstract class MusicalInstrument
    {
        public void PlayMelody()
        {
            TakeMusicInstrument();
            PlayNotes();
        }

        protected abstract void TakeMusicInstrument();
        protected abstract void PlayNotes();
    }

    class Guitar : MusicalInstrument
    {
        protected override void TakeMusicInstrument()
        {
            Console.WriteLine("Take the guitar");
        }

        protected override void PlayNotes()
        {
            int duration = 200;
            Console.Beep(610, duration); // 5-th
            Console.Beep(696, duration); // 3-th
            Console.Beep(747, duration); // 2-th
            Console.Beep(830, duration); // 1-th
            Console.Beep(747, duration); // 2-th
            Console.Beep(696, duration); // 3-th

            Console.Beep(610, duration); // 5-th
            Console.Beep(696, duration); // 3-th
            Console.Beep(747, duration); // 2-th
            Console.Beep(830, duration); // 1-th
            Console.Beep(747, duration); // 2-th
            Console.Beep(696, duration); // 3-th
        }
    }

    class Piano : MusicalInstrument
    {
        protected override void TakeMusicInstrument()
        {
            Console.WriteLine("Take the piano");
        }

        protected override void PlayNotes()
        {
            // Found this melody on https://metanit.com/sharp/articles/15.php

            Console.Beep(659, 120);
            Thread.Sleep(130);
            Console.Beep(622, 120);
            Thread.Sleep(130);

            Console.Beep(659, 120);
            Thread.Sleep(130);
            Console.Beep(622, 120);
            Thread.Sleep(130);
            Console.Beep(659, 120);
            Thread.Sleep(130);
            Console.Beep(494, 120);
            Thread.Sleep(130);
            Console.Beep(587, 120);
            Thread.Sleep(130);
            Console.Beep(523, 120);
            Thread.Sleep(130);

            Console.Beep(440, 120);
            Thread.Sleep(150);
            Console.Beep(262, 120);
            Thread.Sleep(130);
            Console.Beep(330, 120);
            Thread.Sleep(130);
            Console.Beep(440, 120);
            Thread.Sleep(130);

            Console.Beep(494, 120);
            Thread.Sleep(150);
            Console.Beep(330, 120);
            Thread.Sleep(130);
            Console.Beep(415, 120);
            Thread.Sleep(130);
            Console.Beep(494, 120);
            Thread.Sleep(130);

            Console.Beep(523, 120);
            Thread.Sleep(150);
            Console.Beep(330, 120);
            Thread.Sleep(130);
            Console.Beep(659, 120);
            Thread.Sleep(130);
            Console.Beep(622, 120);
            Thread.Sleep(130);

            Console.Beep(659, 120);
            Thread.Sleep(130);
            Console.Beep(622, 120);
            Thread.Sleep(130);
            Console.Beep(659, 120);
            Thread.Sleep(130);
            Console.Beep(494, 120);
            Thread.Sleep(130);
            Console.Beep(587, 120);
            Thread.Sleep(130);
            Console.Beep(523, 120);
            Thread.Sleep(130);

            Console.Beep(440, 120);
            Thread.Sleep(150);
            Console.Beep(262, 120);
            Thread.Sleep(130);
            Console.Beep(330, 120);
            Thread.Sleep(130);
            Console.Beep(440, 120);
            Thread.Sleep(130);

            Console.Beep(494, 120);
            Thread.Sleep(150);
            Console.Beep(330, 120);
            Thread.Sleep(130);
            Console.Beep(523, 120);
            Thread.Sleep(130);
            Console.Beep(494, 120);
            Thread.Sleep(150);
            Console.Beep(440, 120);
        }
    }


    class Program
    {
        static void Main()
        {
            Guitar guitar = new Guitar();
            Piano piano = new Piano();

            guitar.PlayMelody();
            Thread.Sleep(1000);
            piano.PlayMelody();
        }
    }
}
