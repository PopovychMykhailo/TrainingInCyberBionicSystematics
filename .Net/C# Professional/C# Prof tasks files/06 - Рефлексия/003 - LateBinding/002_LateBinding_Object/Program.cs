using System;
using System.IO;
using System.Reflection;
using System.Text;

//using CarLibrary;

namespace LateBinding
{
    class Program
    {
        static void Main()
        {
            Console.OutputEncoding = Encoding.Unicode;
            Assembly assembly = null;

            try
            {
                assembly = Assembly.Load("001_CarLibrary");
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine(e.Message);
            }

            // Создание экземпляра класса MiniVan "на лету"
            // При помощи класса Activator производится позднее связывание.
            // Метод CreateInstance() - предназначен для создания экземпляра типа во время выполнения.
            Type type = assembly.GetType("CarLibrary.MiniVan");

            object instance = Activator.CreateInstance(type); // new MiniVan();

            // Получаем экземпляр класса MethodInfo для метода Acceleration(). 
            MethodInfo method = type.GetMethod("Acceleration");

            // Вызов метода Acceleration().
            // Первый параметр - ссылка на экземпляр для которого будет вызван метод Acceleration
            // Второй параметр - массив аргументов метода Acceleration (в данном случае без параметров - null)
            method.Invoke(instance, null);

            // Получаем экземпляр класса MethodInfo для метода Driver(). 
            method = type.GetMethod("Driver");

            // Массив параметров для метода Driver("Shumaher", 36).  
            object[] parameters = { "Shumaher", 36 };
            
            // Вызов метода Driver().
            // Первый параметр - ссылка на экземпляр для которого будет вызван метод Acceleration
            // Второй параметр - массив аргументов метода Acceleration (в данном случае - name:"Shumaher", age:36 )
            method.Invoke(instance, parameters);

            // Delay.
            Console.ReadKey();
        }
    }
}
