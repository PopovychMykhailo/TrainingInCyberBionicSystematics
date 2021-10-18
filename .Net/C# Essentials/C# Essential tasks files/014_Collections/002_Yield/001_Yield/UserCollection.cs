using System.Collections;

namespace Yield
{
    class UserCollection
    {
        public static IEnumerable Power()
        {
            yield return "Hello world!";
        }
    }
}
