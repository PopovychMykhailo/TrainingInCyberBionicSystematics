using System;
using System.Linq;

namespace Classwork_task1
{
    /* Technical task
    
        Создайте пользовательский атрибут AccessLevelAttribute, позволяющий определить
        уровень доступа пользователя к системе. Сформируйте состав сотрудников некоторой фирмы
        в виде набора классов, например, Manager, Programmer, Director. При помощи атрибута
        AccessLevelAttribute распределите уровни доступа персонала и отобразите на экране
        реакцию системы на попытку каждого сотрудника получить доступ в защищенную секцию
    */



    class Program
    {
        static void Main(string[] args)
        {
            Employee director = new("Director Michael", AccessLevels.Director);
            Employee manager = new("Manager Larisa", AccessLevels.Manager);
            Employee developer = new("Developer Ilya", AccessLevels.Programmer);

            Project project = new("Cost of the project: $1.000.000.000", "Customer: Elon Musk", "App platform: .Net 7.1");


            Console.Write($"{director.Position} requst \"finances info\": ");
            PrinterResultAccess(project.GetFinancesInfo(director));
            Console.Write($"{director.Position} requst \"customer info\": ");
            PrinterResultAccess(project.GetCustomerInfo(director));
            Console.Write($"{director.Position} requst \"code info\": ");
            PrinterResultAccess(project.GetCodeInfo(director));
            Console.WriteLine(new string('-', 100));

            Console.Write($"{manager.Position} requst \"finances info\": ");
            PrinterResultAccess(project.GetFinancesInfo(manager));
            Console.Write($"{manager.Position} requst \"customer info\": ");
            PrinterResultAccess(project.GetCustomerInfo(manager));
            Console.Write($"{manager.Position} requst \"code info\": ");
            PrinterResultAccess(project.GetCodeInfo(manager));
            Console.WriteLine(new string('-', 100));

            Console.Write($"{developer.Position} requst \"finances info\": ");
            PrinterResultAccess(project.GetFinancesInfo(developer));
            Console.Write($"{developer.Position} requst \"customer info\": ");
            PrinterResultAccess(project.GetCustomerInfo(developer));
            Console.Write($"{developer.Position} requst \"code info\": ");
            PrinterResultAccess(project.GetCodeInfo(developer));
            Console.WriteLine(new string('-', 100));


            Console.WriteLine();
        }
        public static void PrinterResultAccess((bool success, string info) result)
        {
            if (result.success)
                ColorPrinter(result.info, ConsoleColor.Green);
            else
                ColorPrinter(result.info, ConsoleColor.Red);
        }

        public static void ColorPrinter(string str, ConsoleColor consoleColor)
        {
            Console.ForegroundColor = consoleColor;
            Console.WriteLine(str);
            Console.ResetColor();
        }

    }
}
