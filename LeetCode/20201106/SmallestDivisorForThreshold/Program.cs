using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmallestDivisorForThreshold
{
    public class Solution
    {
        public int SmallestDivisor(int[] nums, int threshold)
        {
            //var divisors = Enumerable.Range(1, threshold).ToArray();
            //binarySearch(nums, divisors, 0, threshold - 1, threshold);

            return binarySearch(nums, 1, threshold, threshold);
        }

        static int binarySearch(int[] numbers, int left, int right, int search)
        {
            if (right >= left)
            {
                int divisor = left + (right - left) / 2;

                int sum = 0;
                for (int i = 0; i < numbers.Length; i++)
                {
                    int roundedQuotient = (int)Math.Ceiling((double)numbers[i] / divisor);
                    sum += roundedQuotient;
                }

                if (sum == search)
                {
                    return divisor;
                }

                if (sum > search)
                {
                    // search in right half
                    return binarySearch(numbers, divisor + 1, right, search);
                }
                else
                {
                    // search in left half
                    return binarySearch(numbers, left, divisor - 1, search);
                }
            }

            // We reach here when element is not present 
            // in array 
            return -1;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var solution = new Solution();

            var nums1 = new int[] { 1, 2, 5, 9 };
            int threshold1 = 6;
            var result1 = solution.SmallestDivisor(nums1, threshold1); // 5

            var nums2 = new int[] { 2, 3, 5, 7, 11 };
            int threshold2 = 11;
            var result2 = solution.SmallestDivisor(nums2, threshold2); // 3
        }
    }
}
