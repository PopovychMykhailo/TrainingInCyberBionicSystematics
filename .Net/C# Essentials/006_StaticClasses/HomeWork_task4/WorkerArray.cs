using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork_task3
{
    static class WorkerArray
    {
        static public int[] SortAscending(this int[] array)
        {
            int minValue = array[0];
            int indexMinValue = 0;

            for (int i = 0; i < array.Length - 1; i++)
            {
                // Finding the minimum value in the remaining part of the array
                for (int j = i; j < array.Length; j++)
                {
                    if (array[j] < minValue)
                    {
                        minValue = array[j];
                        indexMinValue = j;
                    }
                }

                // If the minimum value is less than the current item - replace them
                if (array[i] > minValue)
                {
                    int temp = array[i];
                    array[i] = minValue;
                    array[indexMinValue] = temp;
                }

                // Do this so that the new iteration looks for the next minimum value
                minValue = array[i + 1];
                indexMinValue = 0;
            }

            return array;
        }
    }
}
