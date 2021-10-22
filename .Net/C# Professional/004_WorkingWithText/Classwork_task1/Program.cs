using System;
using System.Text.RegularExpressions;

namespace Classwork_task1
{
    /* Technical task 
    
        Напишите консольное приложение, позволяющие пользователю зарегистрироваться под
        «Логином», состоящем только из символов латинского алфавита, и пароля, состоящего из
        цифр и символов.
    */


    class Program
    {
        static void Main()
        {
            string userLogin;
            string userPassword;

            //Entering a user login
            do
            {
                Console.Write("Create login: ");
                userLogin = Console.ReadLine();

                // If login is only letters
                if (Regex.IsMatch(userLogin, @"^[A-Za-z]{3,}$") == true)
                    break;
                else
                    Console.WriteLine("Wrong login! Login should have only letters!\n");

            } while (true);

            //Entering a user password
            do
            {
                Console.Write("Create pass:  ");
                userPassword = Console.ReadLine();

                // If the data are numbers and symbols (not letters)
                if (Regex.IsMatch(userPassword, @"^[\x21-\x40|\x5b-\x60|\x7b-\x7e]{8,}$") == true)
                    break;
                else
                    Console.WriteLine("Wrong password! Password should have 8 numbers and/or symbols (not letters)!\n");

            } while (true);

            Console.WriteLine();
            Console.WriteLine("Data succesffuly enter!");
            Console.WriteLine($"Login:    {userLogin}");
            Console.WriteLine($"Password: {userPassword}");
        }
    }
}
