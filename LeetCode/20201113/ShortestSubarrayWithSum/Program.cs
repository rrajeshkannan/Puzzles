using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShortestSubarrayWithSum
{
    // https://leetcode.com/problems/shortest-subarray-with-sum-at-least-k/

    // Return the length of the shortest, non-empty, contiguous subarray of A with sum at least K.
    // If there is no non-empty subarray with sum at least K, return -1.
    //
    // Example 1:
    //   Input: A = [1], K = 1
    //   Output: 1
    // Example 2:
    //   Input: A = [1,2], K = 4
    //   Output: -1
    // Example 3:
    //   Input: A = [2,-1,2], K = 3
    //   Output: 3

    public class Solution
    {
        public int ShortestSubarray(int[] A, int K)
        {
            if (!A.Any())
            {
                return -1;
            }

            var list = A.OrderByDescending(item => item).ToArray();

            if (list.Last() > K)
            {
                // at least one element in "A" should be less than or equal to K
                return -1;
            }
            
            int i = 0;

            for (; (i < list.Length) && (list[i] > K); i++)
                ;

            if (i == list.Length)
            {
                // all elements are less than or equal to K, so, let's start from beginning
                i = 0;
            }

            int begin = i;
            int sum = 0;

            for (; (i < list.Length) && sum < K; i++)
            {
                sum += list[i];
            }

            if (sum >= K)
            {
                return i - begin;
            }

            return -1;
        }
    }

    class Program
    {
        static void Main()
        {
            var solution = new Solution();

            var a1 = new int[] { 1 };
            var result1 = solution.ShortestSubarray(a1, 1); // 1

            var a2 = new int[] { 1, 2 };
            var result2 = solution.ShortestSubarray(a2, 4); // -1

            var a3 = new int[] { 2, -1, 2 };
            var result3 = solution.ShortestSubarray(a3, 3); // 3
        }
    }
}
