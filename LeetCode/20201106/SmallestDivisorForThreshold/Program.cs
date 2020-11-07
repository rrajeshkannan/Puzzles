using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmallestDivisorForThreshold
{
    // https://leetcode.com/explore/challenge/card/november-leetcoding-challenge/564/week-1-november-1st-november-7th/3521/
    // Given an array of integers nums and an integer threshold, 
    //   we will choose a positive integer divisor 
    //   and divide all the array by it 
    //   and sum the result of the division.
    // 
    // Find the smallest divisor such that the result mentioned above is less than or equal to threshold.
    // 
    // Each result of division is rounded to the nearest integer greater than or equal to that element.
    //   (For example: 7/3 = 3 and 10/2 = 5)
    //
    // It is guaranteed that there will be an answer.

    public class Solution
    {
        public int SmallestDivisor(int[] nums, int threshold)
        {
            return binarySearch(nums, 1, nums.Max(), threshold, Int32.MaxValue);
        }

        static int binarySearch(int[] numbers, int left, int right, int search, int lastChosenDivisor)
        {
            if (right < left)
            {
                // we cannot go further
                return lastChosenDivisor;
            }

            int divisor = left + (right - left) / 2;

            int roundedSum = 0;
            for (int i = 0; i < numbers.Length; i++)
            {
                roundedSum += (int)Math.Ceiling((double)numbers[i] / divisor);
            }

            if (roundedSum > search)
            {
                // if sum is bigger, it means chosen divisor is smaller
                // try searching for divisor on the bigger numbers' side
                // -> search in right half
                return binarySearch(numbers, divisor + 1, right, search, lastChosenDivisor);
            }
            
            // if sum is smaller, it can be a potential result to return
            // -> still continue searching for possibly even smaller number
            lastChosenDivisor = divisor;
            
            // if sum is smaller, it means chosen divisor is bigger
            // try searching divisor on the smaller numbers' side
            // -> search in left half
            return binarySearch(numbers, left, divisor - 1, search, lastChosenDivisor);
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

            var nums3 = new int[] { 19 };
            int threshold3 = 5;
            var result3 = solution.SmallestDivisor(nums3, threshold3); // 4

            var nums4 = new int[] { 2, 3, 5, 7, 11 };
            int threshold4 = 9;
            var result4 = solution.SmallestDivisor(nums4, threshold4); // 4

            var nums5 = new int[] { 962551, 933661, 905225, 923035, 990560 };
            int threshold5 = 10;
            var result5 = solution.SmallestDivisor(nums5, threshold5); // 495280

            var nums6 = new int[]
            {
                46480, 71852, 4544, 23598, 962, 66567, 66601, 90661, 30701, 30463, 
                76184, 35590, 50634, 82516, 3847, 83498, 40938, 82092, 17753, 21195, 
                3748, 94798, 77080, 49254, 24184, 81610, 80045, 69248, 10776, 45690, 
                59496, 15406, 38198, 47381, 13353, 93106, 71420, 14775, 99118, 6866, 
                62300, 57444, 3966, 91603, 56289, 26752, 16439, 96836, 80050, 14948, 
                14487, 3034, 79113, 23445, 78123, 91204, 77022, 36837, 38978, 94389, 
                77331, 523, 42947, 25830, 55630, 45936, 76823, 32614, 49959, 5111, 
                74080, 59558, 79203, 93414, 11356, 87885, 50858, 4490, 11503, 35141, 
                4446, 52051, 75511, 41767, 64622, 61572, 28298, 21584, 77878, 99083, 
                47585, 75926, 84968, 12477, 86333, 55299, 99291, 47402, 82539, 19070
            };
            int threshold6 = 549;
            var result6 = solution.SmallestDivisor(nums6, threshold6); // 10134
        }
    }
}
