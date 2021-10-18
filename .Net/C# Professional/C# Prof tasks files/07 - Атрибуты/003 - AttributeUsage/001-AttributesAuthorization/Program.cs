using System;
using System.Text;

namespace AttributesAuthorization
{
    class Program
    {
        static void Main()
        {
            Console.OutputEncoding = Encoding.Unicode;
            Console.WriteLine("Нажмите Enter чтобы попробовать авторизоваться.");

            while ((Console.ReadLine()) != "exit")
            {
                User user = new User();

                Console.Write($"{"Email:",-10}");
                user.Email = Console.ReadLine();

                Console.Write($"{"Password:",-10}");
                user.Password = Console.ReadLine();

                var application = Application.GetCurrentApplication();
                application.Authorize(user);
            }

            Console.WriteLine("Ready.");
            Console.ReadLine();
        }
    }
}
