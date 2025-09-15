
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearch
{
    internal class BinarySearchHelper
    {
        public static int BinarySearchOrClosest(int[] sortedArray, int Taraget)
        {
            int low = 0;
            int high = sortedArray.Length - 1;
            int mid;

            while (low <= high)
            {
                // 2.000.000.000 + 2.000.000.001 = 4.000.000.001 / 2 
                // 2.000.000.000 + (2.000.000.001 - 2.000.000.000) = 2.000.000.000 + 1
                //mid = (low + high) / 2; to overcome the overflow problem we use:
                mid = low + (high - low) / 2;
                if (Taraget == sortedArray[mid])
                {
                    Console.WriteLine($"The Target is {Taraget} at index {mid}\n");
                    return -1;
                }
                else if (Taraget < sortedArray[mid])
                {
                    high = mid - 1;
                }
                else
                {
                    low = mid + 1;
                }
            }
            return low < sortedArray.Length - 1 ? low : -1;

        }
    }
}

