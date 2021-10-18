using System;
using System.Threading;
using System.Collections;

namespace Race
{
    class Game
    {
        Car car;
        Road road;

        public Game()
        {
            car = new Car(40, 20);
            road = new Road();
        }

        public void Run()
        {
            car.Show();
           // Thread.Sleep(100);
            road.Movie();

            // Игровая петля.
            while (true)
            {
                try
                {
                    Thread.Sleep(1000);
                    road.Speed = car.Acceleration(10);
                }
                catch (Exception e)
                {
                    road.Speed = 0;
                    Console.SetCursorPosition(38, 20);
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine(e.Message);
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.Gray;

                    Console.SetCursorPosition(0, 46);

                    foreach (DictionaryEntry de in e.Data)
                        Console.WriteLine("{0}: {1}", de.Key, de.Value);

                    break;
                } 
            }            
        }
    }
}
