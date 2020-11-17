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
                                // start new mountain
                                maxHillLength = Math.Max(currentHillLength, maxHillLength);
                                // A[i] contributes to new mountain, so, consider it
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
                    switch (currentStanding)
                    {
                        case Surface.Downhill:
                            // start new mountain
                            maxHillLength = Math.Max(currentHillLength, maxHillLength);
                            currentHillLength = 0;
                    }
                }
            }

            return maxHillLength;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
        }
    }
}
