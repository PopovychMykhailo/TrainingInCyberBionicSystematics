using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classwork_task1
{
    class Employee
    {
        public string Position { init; get; }
        public AccessLevels AccessLevel { init; get; }

        public Employee(string potition, AccessLevels accessLevel)
        {
            Position = potition;
            AccessLevel = accessLevel;
        }
    }
}
