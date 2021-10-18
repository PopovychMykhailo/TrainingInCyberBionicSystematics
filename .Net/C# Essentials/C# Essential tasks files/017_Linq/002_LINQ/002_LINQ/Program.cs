using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LINQ
{
    public class Employee
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public decimal Salary { get; set; }
        public DateTime StartDate { get; set; }
    }

    class Program
    {
        static void Main()
        {
            Console.OutputEncoding = Encoding.Unicode;

            // База данных сотрудников.
            var employees = new List<Employee>
            {
                new Employee
                {
                    FirstName = "Ivan",
                    LastName = "Ivanov",
                    Salary = 94000,
                    StartDate = DateTime.Parse("1/4/1992")
                },
                new Employee
                {
                    FirstName = "Petr",
                    LastName = "Petrov",
                    Salary = 123000,
                    StartDate = DateTime.Parse("12/3/1985")
                },
                new Employee
                {
                    FirstName = "Andrey",
                    LastName = "Andreev",
                    Salary = 1000000,
                    StartDate = DateTime.Parse("1/12/2005")
                }
            };

            // Выражение запроса.(Использование вызовов расширяющих методов.)
            var query = // query - переменная запрса.
                        employees
                        .Where(emp => emp.Salary > 100000)
                        .OrderBy(emp => emp.LastName)
                        .OrderBy(emp => emp.FirstName)
                        .Select(emp => new
                        {
                            LastName = emp.LastName,
                            FirstName = emp.FirstName
                        });

            Console.WriteLine("Высокооплачиваемые сотрудники:");

            foreach (var item in query)
                Console.WriteLine("{0} {1}", item.LastName, item.FirstName);

            // Delay.
            Console.ReadKey();
        }
    }
}
