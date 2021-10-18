using System;
using System.Text.RegularExpressions;

namespace Homework_task2
{
    /* Technical task
     
        Требуется описать структуру с именем Worker, содержащую следующие поля:
            • фамилия и инициалы работника;
            • название занимаемой должности;
            • год поступления на работу.
        Написать программу, выполняющую следующие действия:
            • ввод с клавиатуры данных в массив, состоящий из пяти элементов типа Worker (записи должны быть упорядочены по алфавиту);
            • если значение года введено не в соответствующем формате выдает исключение;
            • вывод на экран фамилии работника, стаж работы которого превышает введенное значение. 
    */


    struct Worker : IComparable
    {
        int yearStartWork;

        public string Fullname { set; get; }
        public string Position { set; get; }
        public int YearStartWork
        {
            set
            {
                if (value >= 1900 && value <= DateTime.Today.Year)
                    yearStartWork = value;
                else
                    throw new IncorectYearException();
            }

            get => yearStartWork;
        }

        public Worker(string fullname, string position, int yearStartWork)
        {

            Fullname = fullname;
            Position = position;
            this.yearStartWork = yearStartWork;
        }

        public string GetInfo()
        {
            return $"Fullname: {Fullname}.\t Position: {Position}.\t WorkExperience: {YearStartWork}";
        }

        public int CompareTo(object worker)
        {
            Worker _worker = (Worker)worker;

            if (worker != null)
                return this.Fullname.CompareTo(_worker.Fullname);
            else
                throw new Exception("Error compare these workers, the second worker is null!");
        }
    }

    class IncorectYearException : Exception
    {
        public IncorectYearException() : base("The year is not correct!") { }
    }

    class Program
    {
        static void Main()
        {
            Worker[] workers = new Worker[5];
            int requiredWorkExperience;


            #region Fill in the array of workers

            workers[0] = new Worker("Popovych M.M.", "Senior .Net Developer", 2020);
            workers[1] = new Worker("Kachai Y.V.", "Senior automation QA", 2021);
            workers[2] = new Worker("Kachai T.V.", "App's arhitector", 2011);
            workers[3] = new Worker("Golobokova A.M.", "UI Designer", 2019);
            workers[4] = new Worker("Mykhailenko L.I.", "PM", 2000);

            // Fill the array with information from the user
            //for (int i = 0; i < workers.Length; i++)
            //{
            //    try
            //    {
            //        Console.WriteLine($"Fill {i} worker: ");
            //        Console.Write($"Enter fullname: "); workers[i].Fullname = Console.ReadLine();
            //        Console.Write($"Enter position: "); workers[i].Position = Console.ReadLine();
            //        Console.Write($"Enter Year of start of work: "); workers[i].YearStartWork = Convert.ToInt32(Console.ReadLine());
            //        Console.WriteLine();
            //    }
            //    catch (IncorectYearException ex)
            //    {
            //        --i;    // Need try again to fill

            //        WriteError("Error: enter incorect year!");
            //        WriteError($"Exception message: {ex.Message}");
            //    }
            //    catch (Exception ex)
            //    {
            //        --i;    // Need try again to fill

            //        WriteError("Error: get unknown exception!");
            //        WriteError($"Exception message: {ex.Message}");
            //    }

            //}

            Array.Sort(workers);

            #endregion


            #region Find workers with the required work experience

            try
            {
                while (true)
                {
                    Console.Write("Enter required work experience: "); requiredWorkExperience = Convert.ToInt32(Console.ReadLine());

                    for (int i = 0; i < workers.Length; i++)
                    {
                        if (DateTime.Today.Year - workers[i].YearStartWork >= requiredWorkExperience)
                        {
                            Console.WriteLine($"Fullname: {workers[i].Fullname}");
                        }

                    }

                    Console.WriteLine();
                }
            }
            catch (Exception ex)
            {
                WriteError("Error: get unknown exception!");
                WriteError($"Exception message: {ex.Message}");
            }
            #endregion
        }

        public static void WriteError(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Console.ResetColor();
        }
    }
}
