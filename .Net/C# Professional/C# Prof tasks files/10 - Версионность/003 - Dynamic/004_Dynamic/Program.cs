using System;

// dynamic

namespace Dynamic
{
	class MyClass
	{
		public void ProcessInput(int x)
		{
			Console.WriteLine("int: " + x.ToString());
		}

		public void ProcessInput(string msg)
		{
			Console.WriteLine("string: " + msg);
		}

		private void ProcessInput(double d)
		{
			Console.WriteLine("double: " + d.ToString());
		}
	}
	
	class Program
	{
		static void Main()
		{
			dynamic @int = 123;
			dynamic @string = "Some string...";
			dynamic @double = 3.14;

			MyClass instance = new MyClass();
			instance.ProcessInput(@int);
			instance.ProcessInput(@string);
            instance.ProcessInput(@double);

            dynamic cast = instance;
            cast.ProcessInput(@double); // попытка обратиться к закрытому методу.

			// Delay.
			Console.ReadKey();
		}
	}
}
