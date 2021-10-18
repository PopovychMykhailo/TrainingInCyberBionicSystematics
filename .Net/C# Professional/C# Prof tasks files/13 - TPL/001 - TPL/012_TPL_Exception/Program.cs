using System;
using System.Text;
using System.Threading.Tasks;

// Возбуждение исключений в задачах. (Пример выполнять через CTRL+F5)

namespace TPL
{
    class Program
    {
        // Метод в котором будет возбуждаться исключение.
        static void MyTask()
        {
            Console.WriteLine("Задача запущена.");

            throw new Exception();

            Console.WriteLine("Задача завершена.");
        }

        static void Main()
        {
            Console.OutputEncoding = Encoding.Unicode;
            Console.WriteLine("Основной поток запущен.");

            Task task = new Task(MyTask);

            try
            {
                task.Start();
                task.Wait(); // Для обработки исключения обязательно вызвать Wait!
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception       : " + ex.GetType());
                Console.WriteLine("Message         : " + ex.Message);

                if (ex.InnerException != null)
                    Console.WriteLine("Inner Exception : " + ex.InnerException.GetType());
            }
            finally
            {
                Console.WriteLine("Статус задачи   : " + task.Status);
            }

            Console.WriteLine("Основной поток завершен.");

            // Delay
            Console.ReadKey();
        }
    }
}
