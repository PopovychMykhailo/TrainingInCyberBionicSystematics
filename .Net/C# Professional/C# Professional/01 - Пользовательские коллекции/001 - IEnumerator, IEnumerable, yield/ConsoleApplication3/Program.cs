using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication3
{
    class collection
    {
        public int[] array = new [] {1, 2, 3, 4, 5, 6, 7, 8};
        //public IEnumerable GetEven()
        //{
        //    foreach (var i in array)
        //    {
        //        if (i%2 == 0) yield return i;
        //    }
        //}
        //public IEnumerable GetOdd()
        //{
        //    foreach (var i in array)
        //    {
        //        if (i % 2 != 0) yield return i;
        //    }
        //}

    }
    class Program
    {
       static readonly List<String> _collection = new List<string>
                                      {
                                          "1","2","3"
                                      }; 

        private static void Main()
        {
            var collType = _collection.GetType();
            var _versionField = collType.GetField("_version", BindingFlags.Instance | BindingFlags.NonPublic);

            int _version = (Int32)_versionField.GetValue(_collection);

            Console.WriteLine(_version);

            _collection.Add("Hello");
            _version = (Int32)_versionField.GetValue(_collection);
            Console.WriteLine(_version);
            _versionField.SetValue(_collection,1000);
            _version = (Int32)_versionField.GetValue(_collection);
            Console.WriteLine(_version);

        }
    }
}
