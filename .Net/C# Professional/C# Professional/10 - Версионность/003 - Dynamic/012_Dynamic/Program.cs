using System;

// dynamic

namespace Dynamic
{
	class Base<T>
	{
		public T Value { get; set; }
	}

	class DerivedDynamic : Base<dynamic>
	{

	}

	class DerivedObject : Base<object>
	{

	}

	class Program
	{
		static void Main()
		{
			DerivedDynamic instance1 = new DerivedDynamic();
			
			instance1.Value = "Some string...";
            instance1.Value = 20;
			Console.WriteLine(42 + instance1.Value);


			DerivedObject instance2 = new DerivedObject();

			instance2.Value = "Some string...";
			Console.WriteLine(42 + instance2.Value.ToString());

			// Delay.
			Console.ReadKey();
		}
	}
}
