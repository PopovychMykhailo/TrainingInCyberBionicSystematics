using System;

namespace ResultExample
{

    class DivideResult
    {
        public int Value { get; }
        public string Error { get; }
        public bool IsValid { get; }

        private DivideResult(int result, string error, bool isValid)
        {
            if (isValid)
            {
                Value = result;
            }
            else
            {
                Error = error;
            }
            IsValid = isValid;
        }

        public static DivideResult Success(int result) 
        {
            return new DivideResult(result, null, true);
        }

        public static DivideResult DivideByZeroError()
        {
            return new DivideResult(0, "Cannot divide by zero", false);
        }

    }

    class Program
    {

        public static DivideResult Divide(int dividend, int divisor)
        {
            if (divisor == 0)
            {
                return DivideResult.DivideByZeroError();
            }
            else
            {
                return DivideResult.Success(dividend / divisor);
            }
        }

        static void Main()
        {
            var result = Divide(10, 0);

            if (result.IsValid)
            {
                Console.WriteLine(result.Value);
            }
            else
            {
                Console.WriteLine("ERROR! " + result.Error);
            }
        }
    }
}
