
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearch
{
    internal class BinarySearchHelper
    {
        public static void BinarySearchOrClosest(int[] sortedArray, int Taraget)
        {
            int low = 0;
            int high = sortedArray.Length - 1;
            int mid;
            int right = 0;
            int left = 0;

            while (low <= high)
            {
                // 2.000.000.000 + 2.000.000.001 = 4.000.000.001 / 2 
                // 2.000.000.000 + (2.000.000.001 - 2.000.000.000) = 2.000.000.000 + 1
                //mid = (low + high) / 2; to overcome the overflow problem we use:
                mid = low + (high - low) / 2;
                if (Taraget == sortedArray[mid])
                {
                    Console.WriteLine($"The Target is {Taraget} at index {mid}\n");
                    return;
                }
                else if (Taraget < sortedArray[mid])
                {
                    right = sortedArray[mid];
                    high = mid - 1;

                }
                else
                {
                    left = sortedArray[mid];
                    low = mid + 1;
                }
            }
            if (Math.Abs(Taraget - left) < Math.Abs(Taraget - right))
            {
                Console.WriteLine($"left is Closer to target Left: {left} | Right: {right}\n");
            }
            else if (Math.Abs(Taraget - left) > Math.Abs(Taraget - right))
                Console.WriteLine($"right is Closer to target Right: {right} | Left {left}\n");
            else
            {
                Console.WriteLine($"Both are equally close: Left: {left} | Right: {right}\n");
            }
        }
    }
}

