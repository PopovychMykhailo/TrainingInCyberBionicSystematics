using System;
using System.Collections;

namespace Yield
{
    class UserCollection
    {
        public static IEnumerable Power()
        {
            while (true)
                yield return "Hello world!";
        }
    }
}
