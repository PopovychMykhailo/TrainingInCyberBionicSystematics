using System;

namespace Homework_task2
{
    class Program
    {

        /* Techinal task
         * 
         * Используя Visual Studio, создайте проект по шаблону Console Application.
         * Требуется: Описать структуру с именем Train, содержащую следующие поля: название пункта
         * назначения, номер поезда, время отправления.
         * Написать программу, выполняющую следующие действия:
         * - ввод с клавиатуры данных в массив, состоящий из восьми элементов типа Train (записи должны 
         * быть упорядочены по номерам поездов);
         * - вывод на экран информации о поезде, номер которого введен с клавиатуры (если таких поездов
         * нет, вывести соответствующее сообщение).
        */

        struct Train
        {
            string trainNumber;
            string destination;
            DateTime departureTime;

            public Train(string trainNumber, string destination, DateTime departureTime)
            {
                this.trainNumber = trainNumber;
                this.destination = destination;
                this.departureTime = departureTime;
            }

            public string TrainNumber { set => trainNumber = value;     get => trainNumber; }
            public string Destination { set => destination = value;     get => destination; }
            public DateTime DepartureTime { set => departureTime = value;     get => departureTime; }

            public void GetShow()
            {
                Console.WriteLine($"Train number:   {TrainNumber}");
                Console.WriteLine($"Destination:    {Destination}");
                Console.WriteLine($"Departure time: {DepartureTime}");
            }
        }

        static void Main(string[] args)
        {
            Train[] trains = new Train[8];

            // Filling an array of values
            trains[0] = new Train();
            //trains[0] = new Train("T100", "Lviv",       new DateTime(2021, 10, 10, 12, 0, 0));
            trains[1] = new Train("T101", "Kharkiv", new DateTime(2021, 10, 11, 12, 0, 0));
            trains[2] = new Train("T102", "Odessa", new DateTime(2021, 10, 12, 12, 0, 0));
            trains[3] = new Train("T103", "Dnipro", new DateTime(2021, 10, 13, 12, 0, 0));
            trains[4] = new Train("T104", "Chernigiv", new DateTime(2021, 10, 14, 12, 0, 0));
            trains[5] = new Train("T105", "Poltava", new DateTime(2021, 10, 15, 12, 0, 0));
            trains[6] = new Train("T106", "Mariupol", new DateTime(2021, 10, 16, 12, 0, 0));
            trains[7] = new Train("T107", "London", new DateTime(2021, 10, 17, 12, 0, 0));

            // Fill 0 cells a manual values
            Console.WriteLine("Create train 0: ");
            Console.Write("Enter train number:   ");          trains[0].TrainNumber = Console.ReadLine();
            Console.Write("Enter destination:    ");          trains[0].Destination = Console.ReadLine();
            Console.Write("Enter departure time: ");          trains[0].DepartureTime = Convert.ToDateTime(Console.ReadLine());
            Console.WriteLine("-----------------------------------------------------------------------");
            Console.WriteLine();

            // The train searching
            string requestedTrainNumber;
            Console.Write("Enter a requested train number: ");
            requestedTrainNumber = Console.ReadLine();

            // Show all results of the query containing the array (to show partial matches)
            for (int i = 0; i < trains.Length; i++)
            {
                if (trains[i].TrainNumber.Contains(requestedTrainNumber) == true)
                {
                    trains[i].GetShow();
                }
            }
        }
    }
}
