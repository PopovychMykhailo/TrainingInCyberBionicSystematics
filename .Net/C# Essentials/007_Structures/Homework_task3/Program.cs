using System;

namespace Homework_task3
{
    class Program
    {
        /* Technical task
         * 
         * Создайте класс MyClass и структуру MyStruct, которые содержат в себе поля public string change.
            В классе Program создайте два метода:
             static void ClassTaker(MyClass myClass), который присваивает полю change экземпляра
            myClass значение «изменено».
             static void StruktTaker(MyStruct myStruct), который присваивает полю change экземпляра
            myStruct значение «изменено».
            Продемонстрируйте разницу в использовании классов и структур, создав в методе Main() экземпляры
            структуры и класса. Измените, значения полей экземпляров на «не изменено», а затем вызовите методы
            ClassTaker и StruktTaker. Выведите на экран значения полей экземпляров. Проанализируйте
            полученные результаты.
        */

        class MyClass
        {
            public string change;
        }

        struct MyStruct
        {
            public string change;
        }

        static void Main(string[] args)
        {
            MyClass myClass = new MyClass();
            MyStruct myStruct;

            myClass.change = "Не изменено";
            myStruct.change = "Не изменено";

            ClassTaker(myClass);
            StruktTaker(myStruct);

            Console.WriteLine($"myClass:  {myClass.change}");
            Console.WriteLine($"myStruct: {myStruct.change}");

            /* Conclusion:
             * 
             * When I pass the class instance to the method, I pass the reference of the class instance, 
             * so the method works with the real instance.
             * When I pass the structure instance, I pass the copy of the structure instance, so the method 
             * works with copy, and cannot change the original instance.
             */
        }

        static void ClassTaker(MyClass myClass)
        {
            myClass.change = "Изменено";
        }

        static void StruktTaker(MyStruct myStruct)
        {
            myStruct.change = "Изменено";
        }
    }
}
