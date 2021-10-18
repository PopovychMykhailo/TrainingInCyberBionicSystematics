using System;
using System.Collections.Generic;

namespace _007_Yield
{
    static class ListExtentsions 
    {
        public static IEnumerable<T> FilterWithYield<T>(this IEnumerable<T> source, Func<T, bool> condition)
        {
            foreach (var item in source)
            {
                if (condition(item))
                {
                    yield return item;
                }
            }
        }

        public static IEnumerable<T> FilterWithCustomEnumerator<T>(this IEnumerable<T> source, Func<T, bool> condition) 
        {
            return (IEnumerable<T>)new FilteringEnumerator<T>(source, condition);
        }

        public static List<T> FilterWithExtraMemoryUsage<T>(this List<T> source, Func<T, bool> condition) 
        {
            // для фильтрации пришлось создать ещё одну коллекцию, в результате была использована лишняя оперативная память
            List<T> result = new List<T>();
            foreach (var item in source)
            {
                if (condition(item))
                {
                    result.Add(item);
                }
            }
            return result;
        }

        private class FilteringEnumerator<T> : IEnumerable<T>, IEnumerator<T>
        {
            private IEnumerator<T> _sourceEnumerator;
            private Func<T, bool> _condition;
            private T _current;

            public FilteringEnumerator(IEnumerable<T> source, Func<T, bool> condition)
            {
                _sourceEnumerator = source.GetEnumerator();
                _condition = condition;
            }

            public T Current => _current;

            object System.Collections.IEnumerator.Current => _current;

            public bool MoveNext()
            {
                while (_sourceEnumerator.MoveNext())
                {
                    var currentSourceElement = _sourceEnumerator.Current;
                    if (_condition(currentSourceElement))
                    {
                        _current = currentSourceElement;
                        return true;
                    }
                    else
                    {
                        continue;
                    }
                }
                return false;
            }

            public void Dispose()
            {
                Reset();
            }

            public IEnumerator<T> GetEnumerator()
            {
                return this;
            }

            public void Reset()
            {
                _sourceEnumerator.Reset();
            }

            System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
            {
                return this;
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<int> list = new List<int>() 
            {
                1,2,3,4,5,6,7,8,9,0
            };

            var reusult1 = list.FilterWithExtraMemoryUsage(x => x % 2 == 0);
            foreach (var item in reusult1)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine(new string('-', 30));

            var reusult2 = list.FilterWithCustomEnumerator(x => x % 2 == 0);
            foreach (var item in reusult2)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine(new string('-', 30));

            var reusult3 = list.FilterWithYield(x => x % 2 == 0);
            foreach (var item in reusult3)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine(new string('-', 30));
        }
    }
}
