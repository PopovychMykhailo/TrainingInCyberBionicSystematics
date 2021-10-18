using System;

namespace _017_Member_Expression_Body
{
    /*
     * Expression Body
     * В случае если тело метода, локальной функции или свойства состоит из одной 
     * инстркукции или одного выражения, может использоваться оператор "=>", а
     * блок из фигурных скобок можно не указывать.
     */

    class Program
    {
        //public string Name 
        //{ 
        //    get 
        //    {
        //        return "MyProgram";
        //    } 
        //}
        public string Name => "MyProgram";

        //static int Sum(int left, int right) 
        //{
        //    return left + right;
        //}
        static int Sum(int left, int right)
            => left + right;

        static int Mul(int left, int right)
            => left * right;

        static void Main(string[] args)
        {
            string FormatName(string value)
                => $", dear {value.ToUpper()}";

            void SayHello(string name)
                => Console.WriteLine($"Hello {FormatName(name)}!");

            SayHello("User");

            Console.WriteLine($"1 + 2 = {Sum(1, 2)}");
            Console.WriteLine($"3 * 4 = {Mul(1, 2)}");
        }
    }
}
