using System;
using System.Collections.Generic;
using System.Reflection;

namespace _003_TypeInfo
{
    public sealed class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public event EventHandler Modified;

        private void OnModified()
        {
            EventHandler handler = Modified;

            if (handler != null)
                handler.Invoke(this, EventArgs.Empty);
        }

        public void Save() { /* ... Some code ... */ }
    }

    static class Program
    {
        static void Main()
        {
            Type type = typeof(Person);

            TypeInfo info = type.GetTypeInfo();

            IEnumerable<PropertyInfo> properties = info.DeclaredProperties;
            properties.PrintValues();

            IEnumerable<MethodInfo> methods = info.DeclaredMethods;
            methods.PrintValues();

            IEnumerable<EventInfo> events = info.DeclaredEvents;
            events.PrintValues();

            // Delay.
            Console.ReadKey();
        }

        private static void PrintValues(this IEnumerable<MemberInfo> members)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(members.GetType().GetElementType().Name);
            Console.ForegroundColor = ConsoleColor.Gray;

            foreach (var member in members)
                Console.WriteLine(member);

            Console.WriteLine(new string('-', 40));
        }
    }
}
