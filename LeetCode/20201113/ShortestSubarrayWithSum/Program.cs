using System;
using System.Collections.Generic;
using System.Diagnostics;
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

    // 1 <= A.length <= 50000
    // -10 ^ 5 <= A[i] <= 10 ^ 5
    // 1 <= K <= 10 ^ 9

    public class Solution
    {
        private int ProblemMax = 50000;

        private void SkipNegativeOnFront(int[] A, int max, ref int begin)
        {
            for (; ((begin < max) && (A[begin] <= 0)); begin++)
                ;
        }

        private bool SubarraySumFirst(int[] A, int K, int length, int minSubarrayLength, ref int sum, ref int begin, ref int end)
        {
            for (; ((begin < end) && (A[begin] <= 0)); begin++)
            {
                sum -= A[begin];
            }

            int max = begin + minSubarrayLength;

            if (max > length)
            {
                max = length;
            }

            for (end = begin; end < max; end++)
            {
                sum += A[end];

                if (sum >= K)
                {
                    return true;
                }
            }

            return false;
        }

        private bool SubarraySum (int[] A, int K, int length, int minSubarrayLength, ref int sum, ref int begin, ref int end)
        {
            for (; ((begin < end) && (A[begin] <= 0)); begin++)
            {
                sum -= A[begin];
            }

            int max = begin + minSubarrayLength;

            if (max > length)
            {
                max = length;
            }

            for (end = begin; end < max; end++)
            {
                sum += A[end];

                if (sum >= K)
                {
                    return true;
                }
            }

            return false;
        }

        public int ShortestSubarray(int[] A, int K)
        {
            if (!A.Any())
            {
                return -1;
            }

            int length = A.Length;
            var minSubarrayLength = ProblemMax + 1;
            var found = false;

            int subarrayBegin = 0;
            SkipNegativeOnFront(A, length, ref subarrayBegin);

            int sum = 0;
            int subarrayEnd = length - 1;

            for (; subarrayBegin < length; )
            {
                if (SubarraySum(A, K, length, minSubarrayLength, ref sum, ref subarrayBegin, ref subarrayEnd))
                {
                    found = true;

                    minSubarrayLength = subarrayEnd - subarrayBegin + 1;

                    if (minSubarrayLength == 1)
                    {
                        // Nothing can be lesser than 1
                        return 1;
                    }

                    sum -= A[subarrayBegin];
                    subarrayBegin++;
                }
                else
                {
                    // could not find a subarray between subarrayBegin and subarrayEnd
                    // so, continue outside this subarray
                    subarrayBegin = subarrayEnd + 1;
                }
            }

            return found ? minSubarrayLength : -1;
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

            var a4 = new int[] { 2, 2, -1 };
            var result4 = solution.ShortestSubarray(a4, 3); // 2

            var a5 = TestData.Data1();
            Stopwatch watch = Stopwatch.StartNew();
            var result5 = solution.ShortestSubarray(a5, 5006414); // 19678
            watch.Stop();

            Console.WriteLine(result5);

            var time = watch.ElapsedMilliseconds;
            Console.WriteLine(time);

            var a6 = new int[] { 17, 85, 93, -45, -21 };
            var result6 = solution.ShortestSubarray(a6, 150); // 2

            // 2,20263,20262
            // 4,20264,20261
            // 5,20265,20261
            // 7,20266,20260
            // 9,20266,20258
            // 10,20267,20258
            // 14,20266,



            // 3416 - Debug
            // 781 - Release

            // 3403 - Debug
            // 774 - Release
            Console.ReadKey();
        }
    }
}



//public class TryingToOptimizeSolution
//{
//    public int ShortestSubarray(int[] A, int K)
//    {
//        if (!A.Any())
//        {
//            return -1;
//        }

//        var length = A.Length;

//        var tempLength = length * (length + 1) / 2;
//        var temp = new int[tempLength];
//        var running = 0;

//        for (int i = 0; i < length; i++)
//        {
//            if (A[i] == K)
//            {
//                // nothing can be lesser than 1
//                return 1;
//            }

//            var tempSumEnd = running;
//            var tempSumBegin = running - i;

//            temp[running++] = A[i];

//            for (int j = tempSumBegin; j < tempSumEnd; j++)
//            {
//                temp[running++] = A[i] + A[j];
//            }
//        }

//        return -1;
//    }
//}


//public class FirstSolution
//{
//    public int ShortestSubarray(int[] A, int K)
//    {
//        if (!A.Any())
//        {
//            return -1;
//        }

//        var list = A.OrderByDescending(item => item).ToArray();

//        if (list.Last() > K)
//        {
//            at least one element in "A" should be less than or equal to K
//            return -1;
//        }

//        int i = 0;

//        for (; (i < list.Length) && (list[i] > K); i++)
//            ;

//        if ((i != list.Length) && (list[i] == K))
//        {
//            Nothing can be less than 1
//            return 1;
//        }

//        if (i == list.Length)
//        {
//            all elements are less than or equal to K, so, let's start from beginning
//            i = 0;
//        }

//        int begin = i;
//        int sum = 0;

//        for (; (i < list.Length) && sum < K; i++)
//        {
//            sum += list[i];
//        }

//        if (sum >= K)
//        {
//            return i - begin;
//        }

//        return -1;
//    }
//}