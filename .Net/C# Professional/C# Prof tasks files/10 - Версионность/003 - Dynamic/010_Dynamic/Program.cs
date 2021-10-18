using System;

// Что нельзя делать с dynamic

namespace Dynamic
{
	// 1. Наследоваться
    class MyDynamic : dynamic
    {

    }

	//// 2. Использовать динамик, как параметр типа при наследовании от обощенного интерфейса
	interface IMyInterface<T>
	{
		void Method(T arg);
	}

    class MyInterfaceClass : IMyInterface<dynamic>
    {
        public void Method(dynamic arg) { Console.WriteLine("Error code..."); }
    }

	class Program
	{
		static void Main()
		{
			// Delay.
			Console.ReadKey();
		}
	}
}
