using System;

namespace PreprocessorDirectives
{
    class Program
    {
        static void Main()
        {

            // 1.

#line 123   //  В окне ошибок показывает строку 123
            Console.WriteLine(1); // Снять комментарий. (строка с ошибкой)


           // Console.WriteLine()
            // 2.

            Console.WriteLine("Строка #1.");
#line hidden // Скрывает строку от отладчика.
            Console.WriteLine("Скрытая строка."); // Установить BreakPoint.
#line default
            Console.WriteLine("Строка #2.");



            // Delay.
            Console.ReadKey();
        }
    }
}
