using System;
using System.Collections;
using System.Text;

// Обработка исключений.

namespace Exceptions
{
    class MyClass
    {
        public void MyMethod()
        {
            Method1();
        }

        private void Method1() 
        {
            Method2();
        }

        private void Method2()
        {
            Method3();
        }

        private void Method3()
        {
            Method4();
        }

        private void Method4()
        {
            Method5();
        }

        private void Method5()
        {
            Exception exception = new Exception("Мое исключение");

            exception.HelpLink = "http://MyCompany.com/ErrorService";
            exception.Data.Add("Причина исключения: ", "Тестовое исключение");
            exception.Data.Add("Время возникновения исключения: ", DateTime.Now);

            throw exception;
        }

    }

    class Program
    {
        static void Main()
        {
            Console.OutputEncoding = Encoding.Unicode;
            try
            {
                MyClass instance = new MyClass();
                instance.MyMethod();
            }
            catch (Exception e)
            {
                Console.WriteLine("Имя члена:               {0}", e.TargetSite);
                Console.WriteLine("Класс определяющий член: {0}", e.TargetSite.DeclaringType);
                Console.WriteLine("Тип члена:               {0}", e.TargetSite.MemberType);
                Console.WriteLine("Message:                 {0}", e.Message);
                Console.WriteLine("Source:                  {0}", e.Source);
                Console.WriteLine("Help Link:               {0}", e.HelpLink);
                Console.WriteLine("Stack:                   {0}", e.StackTrace);

                foreach (DictionaryEntry de in e.Data)
                    Console.WriteLine("{0} : {1}", de.Key, de.Value);
            }

            // Delay.
            Console.ReadKey();
        }
    }
}
