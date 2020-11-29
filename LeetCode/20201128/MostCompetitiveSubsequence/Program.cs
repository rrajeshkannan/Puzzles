using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MostCompetitiveSubsequence
{
    // https://leetcode.com/contest/weekly-contest-217/problems/find-the-most-competitive-subsequence/

    public class Solution
    {
        public int IndexForSmallestNumber(int[] nums, int begin, int end)
        {
            var smallestNumber = nums[begin];
            var smallestNumberIndex = begin;

            for (int i = begin + 1; i <= end; i++)
            {
                if (nums[i] < smallestNumber)
                {
                    smallestNumber = nums[i];
                    smallestNumberIndex = i;
                }
            }

            return smallestNumberIndex;
        }

        public int IndexForSmallestNumber(int[] nums, int begin, int end, ref int lastFoundSmallestNumber)
        {
            var smallestNumber = nums[begin];
            var smallestNumberIndex = begin;

            if (smallestNumber != lastFoundSmallestNumber)
            {
                for (int i = begin + 1; i <= end; i++)
                {
                    if (nums[i] < smallestNumber)
                    {
                        smallestNumber = nums[i];
                        smallestNumberIndex = i;
                    }
                }
            }

            lastFoundSmallestNumber = smallestNumber;
            return smallestNumberIndex;
        }

        public int[] MostCompetitiveOld(int[] nums, int k)
        {
            var begin = 0;
            var yetInK = k;
            var result = new int[k];
            var lastFoundSmallestNumber = 0;

            for (int i = 0; i < k; i++)
            {
                var end = nums.Length - yetInK;
                var index = IndexForSmallestNumber(nums, begin, end, ref lastFoundSmallestNumber);
                //var index = IndexForSmallestNumber(nums, begin, end);

                result[i] = nums[index];

                begin = index + 1;
                yetInK--;
            }

            return result;
        }

        public int[] MostCompetitive(int[] nums, int k)
        {
            var result = new int[k];

            for (int i = nums.Length - k, j = 0; i < nums.Length; i++, j++)
            {
                result[j] = nums[i];
            }

            for (int i = nums.Length - k - 1; i >= 0; i--)
            {
                if (nums[i] <= result[0])
                {
                    var biggestNumber = result[0];
                    var biggestNumberIndex = 0;

                    for (int j = 1; j < k; j++)
                    {
                        if (result[j] > biggestNumber)
                        {
                            biggestNumberIndex = j;
                            biggestNumber = result[j];
                        }
                    }

                    for (int j = biggestNumberIndex; j >= 1; j--)
                    {
                        result[j] = result[j - 1];
                    }

                    result[0] = nums[i];
                }
            }

            return result;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var solution = new Solution();

            var input1 = new int[] { 3, 5, 2, 6 };
            var result1 = solution.MostCompetitive(input1, 2);

            var input2 = new int[] { 2, 4, 3, 3, 5, 4, 9, 6 };
            var result2 = solution.MostCompetitive(input2, 4);

            var input3 = CSVReader.GetValues("TestInput.csv");
            var watch3 = Stopwatch.StartNew();
            var result3 = solution.MostCompetitive(input3, 50000);
            watch3.Stop();
            Console.WriteLine(watch3.ElapsedMilliseconds);

            //var input4 = CSVReader.GetValues("TestInput1.csv");
            //var watch4 = Stopwatch.StartNew();
            //var result4 = solution.MostCompetitive(input4, 50000);
            //watch3.Stop();
            //Console.WriteLine(watch4.ElapsedMilliseconds);

            Console.ReadKey();
        }
    }
}
