using System;
using System.Text;

namespace Authentication
{
    class Program
    {
        static void Main()
        {
            Console.OutputEncoding = Encoding.Unicode;
            Console.InputEncoding = Encoding.Unicode;

            string login = "Admin";
            string password = "P@ssw0rd";

            Console.Write("Введите login: ");

            // На 17 строке создаем строкову локальную переменную с именем usersLogin 
            // и принимаем в нее ввод от пользователя

            string usersLogin = Console.ReadLine();

            if (login == usersLogin)
            {
                Console.Write("Введите password: ");
                string usersPassword = Console.ReadLine();

                if (password == usersPassword)
                {
                    Console.WriteLine($"Здравствуйте {usersLogin}, Вы вошли в систему.");
                }
                else
                {
                    Console.WriteLine("Вы ввели неверный пароль.");
                }
            }
            else
            {
                Console.WriteLine("Нет пользователя с таким именем.");
            }

            // Delay.
            Console.ReadKey();
        }
    }
}

