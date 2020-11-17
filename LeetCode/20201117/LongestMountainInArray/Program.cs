using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LongestMountainInArray
{
    // https://leetcode.com/explore/challenge/card/november-leetcoding-challenge/566/week-3-november-15th-november-21st/3533/

    // https://leetcode.com/explore/featured/card/november-leetcoding-challenge/566/week-3-november-15th-november-21st/3533/discuss/938147/C++-Real-one-pass-(no-extra-while's)
    // https://leetcode.com/problems/longest-mountain-in-array/discuss/937652/Python-one-pass-O(1)-space-explained
    // https://www.geeksforgeeks.org/longest-mountain-subarray/
    // https://www.tutorialspoint.com/longest-mountain-in-array-in-cplusplus
    // https://massivealgorithms.blogspot.com/2018/11/leetcode-845-longest-mountain-in-array.html


    public class Solution
    {
        public enum Surface
        {
            Flat,
            Uphill,
            Downhill
        }

        public int LongestMountain(int[] A)
        {
            // when the array itself is smaller than 3, it can't form a mountain shape
            if (A.Length < 3)
            {
                return 0;
            }

            var maxHillLength = 0;
            var currentHillLength = 0;
            var currentStanding = Surface.Flat;

            for (int i = 0; i < A.Length - 1; i++)
            {
                if (A[i] < A[i + 1])
                {
                    switch(currentStanding)
                    {
                        case Surface.Flat:
                        case Surface.Uphill:
                            {
                                // either starting or continuing up-hill
                                currentHillLength++;
                            }
                            break;

                        case Surface.Downhill:
                            {
                                // current mountain ends at A[i], so, consider it
                                maxHillLength = Math.Max(currentHillLength + 1, maxHillLength);

                                // new mountain begins at A[i], so, consider it as part of new mountain also
                                currentHillLength = 1;
                            }
                            break;
                    }

                    currentStanding = Surface.Uphill;
                }
                else if (A[i] > A[i+1])
                {
                    switch(currentStanding)
                    {
                        case Surface.Uphill:
                        case Surface.Downhill:
                            {
                                // either starting or continuing down-hill
                                currentStanding = Surface.Downhill;
                                currentHillLength++;
                            }
                            break;
                    }
                }
                else
                {
                    // any current mountain ends or breaks at A[i]
                    if (currentStanding == Surface.Downhill)
                    {
                        // current mountain ends at A[i], so, consider it
                        maxHillLength = Math.Max(currentHillLength + 1, maxHillLength);
                    }

                    // no new mountain begins at A[i], so, do not consider it
                    currentHillLength = 0;
                }
            }

            return maxHillLength;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var solution = new Solution();

            var numbers1 = new int[] { 2, 1, 4, 7, 3, 2, 5 };
            var result1 = solution.LongestMountain(numbers1); // 5 - [1,4,7,3,2]

            var numbers2 = new int[] { 2, 2, 2 };
            var result2 = solution.LongestMountain(numbers2); // 0

            var numbers3 = new int[] { 2, 2, 2, 2, 2 };
            var result3 = solution.LongestMountain(numbers3); // 0

            var numbers4 = new int[] { 3, 2, 1, 2, 3, 4, 5, 4, 3, 2, 3, 4, 3, 2, 1, 2, 3 };
            var result4 = solution.LongestMountain(numbers4); // 8

            var numbers5 = new int[] { 2, 2, 3, 4, 3, 1, }
        }
    }
}
