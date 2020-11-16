using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShortestSubarrayWithSum
{
    // use technique of "prefix sum" in combination with "greedy + deque + monotonic stack"
    // https://www.geeksforgeeks.org/maximum-subarray-sum-using-prefix-sum/
    // https://en.wikipedia.org/wiki/Prefix_sum
    // https://lifelongprogrammer.blogspot.com/2018/01/monotone-queue-stack-how-to-succeed-in-algorithms-interview.html
    // https://dev.to/grekz/prefix-sum-suffix-sum-programming-tools-1eh5
    // https://labuladong.gitbook.io/algo-en/ii.-data-structure/monotonicstack
    // https://1e9.medium.com/monotonic-queue-notes-980a019d5793
    // https://algorithmsandme.com/monotonic-queue/
    // https://iq.opengenus.org/prefix-sum-array/
    // https://www.programmersought.com/article/2116762024/
    // https://leetcode.com/problems/shortest-subarray-with-sum-at-least-k/discuss/143726/C%2B%2BJavaPython-O(N)-Using-Deque
    // https://www.google.com/search?q=prefix+sum+greedy+%2B+deque+%2B+monotonic+stack&rlz=1C1GCEA_enIN883IN883&oq=prefix+sum+greedy+%2B+deque+%2B+monotonic+stack&aqs=chrome..69i57.3935j0j7&sourceid=chrome&ie=UTF-8



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

    public class AnotherSolutionFromLeetCode
    {
        public int ShortestSubarray(int[] A, int K)
        {
            int res = Int32.MaxValue;
            long[] prefixSum = new long[A.Length + 1];
            for (int i = 1; i <= A.Length; i++)
            {
                prefixSum[i] = prefixSum[i - 1] + (long)A[i - 1];
            }
            LinkedList<int> q = new LinkedList<int>();
            for (int i = 0; i <= A.Length; i++)
            {
                while (q.Count != 0 && prefixSum[q.First.Value] + K <= prefixSum[i])
                {
                    res = Math.Min(i - q.First.Value, res);
                    q.RemoveFirst();
                }
                while (q.Count != 0 && prefixSum[q.Last.Value] >= prefixSum[i])
                {
                    q.RemoveLast();
                }
                q.AddLast(i);
            }
            return res == Int32.MaxValue ? -1 : res;
        }
    }

    public class Solution
    {
        private bool SubarraySumFirst(int[] A, int K, out int candidateArrayEnd, out int sum, out int subarrayBegin, out int subarrayEnd)
        {
            subarrayBegin = 0;
            candidateArrayEnd = A.Length - 1;

            // Skip negatives and zeros on front
            while ((subarrayBegin <= candidateArrayEnd) && (A[subarrayBegin] <= 0))
                subarrayBegin++;

            // Skip negatives and zeros on rear
            while ((candidateArrayEnd >= 0) && (A[candidateArrayEnd] <= 0))
                candidateArrayEnd--;

            sum = 0;

            for (subarrayEnd = subarrayBegin; subarrayEnd <= candidateArrayEnd; subarrayEnd++)
            {
                sum += A[subarrayEnd];

                if (sum >= K)
                {
                    return true;
                }
            }

            return false;
        }

        private bool SubarraySumNext (int[] A, int K, int candidateArrayEnd, int minSubarrayLength, ref int sum, ref int begin, ref int end)
        {
            // Skip negatives and zeros
            while ((begin <= end) && (A[begin] <= 0))
                sum -= A[begin++];

            // find possibility of preponing "end" by coming from rear
            do
            {
                while ((end > begin) && (sum > K))
                    sum -= A[end--];

                while ((end > begin) && (A[end] <= 0))
                    sum -= A[end--];
            } while ((end > begin) && (sum > K));

            if (sum == K)
                return true;

            int maxSubarrayIndex = begin + minSubarrayLength - 1;

            if (maxSubarrayIndex > candidateArrayEnd)
            {
                maxSubarrayIndex = candidateArrayEnd;
            }

            while ((end < maxSubarrayIndex) && (sum < K))
            {
                sum += A[++end];
            }

            return (sum >= K);
        }

        public int ShortestSubarray(int[] A, int K)
        {
            if (!A.Any())
            {
                return -1;
            }

            var found = SubarraySumFirst(A, K, out int candidateArrayEnd, out int sum, out int subarrayBegin, out int subarrayEnd);

            if (!found)
            {
                return -1;
            }

            var minSubarrayLength = subarrayEnd - subarrayBegin + 1;

            for (; (subarrayBegin <= candidateArrayEnd) && (subarrayEnd <= candidateArrayEnd);)
            {
                sum -= A[subarrayBegin++];

                if (SubarraySumNext(A, K, candidateArrayEnd, minSubarrayLength, ref sum, ref subarrayBegin, ref subarrayEnd))
                {
                    minSubarrayLength = subarrayEnd - subarrayBegin + 1;

                    if (minSubarrayLength == 1)
                    {
                        // Nothing can be lesser than 1
                        return 1;
                    }
                }
            }

            return minSubarrayLength;
        }
    }

    class Program
    {
        static void Main()
        {
            var solution = new Solution();
            //var solution = new AnotherSolutionFromLeetCode();

            var a1 = new int[] { 1 };
            var result1 = solution.ShortestSubarray(a1, 1); // 1

            var a2 = new int[] { 1, 2 };
            var result2 = solution.ShortestSubarray(a2, 4); // -1

            var a3 = new int[] { 2, -1, 2 };
            var result3 = solution.ShortestSubarray(a3, 3); // 3

            var a4 = new int[] { 2, 2, -1 };
            var result4 = solution.ShortestSubarray(a4, 3); // 2

            var a5 = TestData.Data1();
            Stopwatch watch5 = Stopwatch.StartNew();
            var result5 = solution.ShortestSubarray(a5, 5006414); // 19678
            watch5.Stop();
            Console.WriteLine(result5);
            Console.WriteLine(watch5.ElapsedMilliseconds);

            var a6 = new int[] { 17, 85, 93, -45, -21 };
            var result6 = solution.ShortestSubarray(a6, 150); // 2

            var a7 = new int[] { -34, 37, 51, 3, -12, -50, 51, 100, -47, 99, 34, 14, -13, 89, 31, -14, -44, 23, -38, 6 };
            var result7 = solution.ShortestSubarray(a7, 151); // 2

            // 37+51+3-12-50+51+100 = 180 => 7

            // 51+3-12-50+51+100 = 143 => 6
            // 51+3-12-50+51+100-47 = 96 => xx

            // 3-12-50+51+100-47 = 45 => 6
            // 3-12-50+51+100-47+99 = 144 => xx

            // -12-50+51+100-47+99 = 141 => 6
            // 51+100-47+99 = 203 => 4
            // 51+100-47 = 104 => xx
            // 51+100-47+99 = 203 => 4

            var a8 = new int[] { -36, 10, -28, -42, 17, 83, 87, 79, 51, -26, 33, 53, 63, 61, 76, 34, 57, 68, 1, -30 };
            var result8 = solution.ShortestSubarray(a8, 484); // 9

            // 10-28-42+17+83+87+79+51-26+33+53+63+61+76 = 517 => 14
            // -28-42+17+83+87+79+51-26+33+53+63+61+76 = 507 => 13
            // -42+17+83+87+79+51-26+33+53+63+61+76 = 535 => 12
            // 17+83+87+79+51-26+33+53+63+61+76 = 577 => 11
            // 17+83+87+79+51-26+33+53+63+61 = 501 => 10
            // 17+83+87+79+51-26+33+53+63 = 440 => 9
            // 17+83+87+79+51-26+33+53+63+61 = 501 => 10

            // 83+87+79+51-26+33+53+63+61 = 484 => 9

            // 33+53+63+61+76+34+57+68+1 = 446 => xx
            // 51-26+33+53+63+61+76+34+57+68+1 = 471 => xx

            var a9 = TestData.Data2();
            Stopwatch watch9 = Stopwatch.StartNew();
            var result9 = solution.ShortestSubarray(a9, 10723661); // Expected: 42622, Output: 42626
            watch9.Stop();
            Console.WriteLine(result9);
            Console.WriteLine(watch9.ElapsedMilliseconds);

            var a10 = new int[] { 58, -27, -11, 63, 90, 83, 61, -44, -39, 30 };
            var result10 = solution.ShortestSubarray(a10, 61); // 1

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