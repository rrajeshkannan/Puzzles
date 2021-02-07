using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortedOrRotatedArray
{
    // https://leetcode.com/contest/weekly-contest-227/problems/check-if-array-is-sorted-and-rotated

    public class Solution
    {
        public bool Check(int[] nums)
        {
            if (nums.Length <= 0)
            {
                return true;
            }

            bool rotated = false;

            var lastElement = nums[0];
            var lastSmallElement = nums[0];

            for (int i = 1; i < nums.Length; i++)
            {
                var currentElement = nums[i];

                if (lastElement > currentElement)
                {
                    if (!rotated)
                    {
                        rotated = true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else if ((rotated) && (currentElement > lastSmallElement))
                {
                    return false;
                }

                lastElement = currentElement;
            }

            return true;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var solution = new Solution();

            var input1 = new int[] { 3, 4, 5, 1, 2 }; // true
            var output1 = solution.Check(input1);
            var input2 = new int[] { 2, 1, 3, 4 }; // false
            var output2 = solution.Check(input2);
            var input3 = new int[] { 1, 2, 3 }; // true
            var output3 = solution.Check(input3);
            var input4 = new int[] { 1, 1, 1 }; // true
            var output4 = solution.Check(input4);
            var input5 = new int[] { 2, 1 }; // true
            var output5 = solution.Check(input5);
            var input6 = new int[] { 3, 4, 5, 1, 2, 3 }; // true
            var output6 = solution.Check(input6);
        }
    }
}
