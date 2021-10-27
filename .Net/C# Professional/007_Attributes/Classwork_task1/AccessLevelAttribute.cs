using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classwork_task1
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Field, AllowMultiple = true, Inherited = false)]
    class AccessLevelAttribute : Attribute
    {
        public AccessLevels AccessLevel { init; get; }

        public AccessLevelAttribute(AccessLevels accessLevel)
        {
            AccessLevel = accessLevel;
        }
    }
}
