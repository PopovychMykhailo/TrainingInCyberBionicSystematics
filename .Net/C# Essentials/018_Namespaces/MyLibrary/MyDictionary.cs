using System;
using System.Collections.Generic;

namespace MyLibrary
{
    public class MyDictionary<TKey, TValue>
        where TKey : notnull
        where TValue : notnull
    {
        TKey[] arrayKeys;
        TValue[] arrayValues;
        public int Length
        {
            get => arrayKeys.Length;
        }

        public MyDictionary(int length)
        {
            arrayKeys = new TKey[length];
            arrayValues = new TValue[length];

            //for (int i = 0; i < length; i++)
            //{
            //    arrayKeys[i] = new TKey();
            //    arrayValues[i] = new TValue();
            //}
        }
        public MyDictionary()
        {
            arrayKeys = Array.Empty<TKey>();
            arrayValues = Array.Empty<TValue>();
        }

        public void Add(TKey key, TValue value)
        {
            TKey[] newArrayKeys = new TKey[arrayKeys.Length + 1];
            TValue[] newArrayValues = new TValue[arrayValues.Length + 1];

            for (int i = 0; i < arrayKeys.Length; i++)
            {
                newArrayKeys[i] = arrayKeys[i];
                newArrayValues[i] = arrayValues[i];
            }

            newArrayKeys[arrayKeys.Length] = key;
            newArrayValues[arrayKeys.Length] = value;

            arrayKeys = newArrayKeys;
            arrayValues = newArrayValues;
        }
        public KeyValuePair<TKey, TValue> this[int index]
        {
            set
            {
                if (index >= 0 && index < arrayValues.Length)
                {
                    arrayKeys[index] = value.Key;
                    arrayValues[index] = value.Value;
                }
                else
                    throw new Exception("Attention: index out of range!");
            }

            get
            {
                if (index >= 0 && index < arrayValues.Length)
                    return new KeyValuePair<TKey, TValue>(arrayKeys[index], arrayValues[index]);
                else
                    throw new Exception("Attention: index out of range!");
            }
        }

        public IEnumerable<KeyValuePair<TKey, TValue>> GetEnumerable()
        {
            for (int i = 0; i < arrayValues.Length; i++)
            {
                yield return new KeyValuePair<TKey, TValue>(arrayKeys[i], arrayValues[i]);
            }
        }

        //public IEnumerable<TValue> GetEnumerableValues()
        //{
        //    for (int i = 0; i < arrayValues.Length; i++)
        //    {
        //        yield return arrayValues[i];
        //    }
        //}

        //public IEnumerable<TKey> GetEnumerableKeys()
        //{
        //    for (int i = 0; i < arrayKeys.Length; i++)
        //    {
        //        yield return arrayKeys[i];
        //    }
        //}
    }

}
