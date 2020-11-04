using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsecutiveCharacters
{
    // https://leetcode.com/explore/challenge/card/november-leetcoding-challenge/564/week-1-november-1st-november-7th/3518/

    public class Solution
    {
        // Given a string s, the power of the string is the maximum length of a non-empty substring that contains only one unique character.
        // Return the power of the string.
        public int MaxPower(string s)
        {
            if (string.IsNullOrEmpty(s))
            {
                return 0;
            }

            var power = 0;
            var currentPower = 0;

            for (int i = 1; i < s.Length; i++)
            {
                if (s[i-1] == s[i])
                {
                    currentPower++;
                }
                else
                {
                    currentPower = 0;
                }

                if (power < currentPower)
                {
                    power = currentPower;
                }
            }

            return power + 1;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var solution = new Solution();

            var result = solution.MaxPower("leetcode"); // 2
            result = solution.MaxPower("abbcccddddeeeeedcba"); // 5
            result = solution.MaxPower("triplepillooooow"); // 5
            result = solution.MaxPower("hooraaaaaaaaaaay"); // 11
            result = solution.MaxPower("tourist"); // 1
            result = solution.MaxPower("j"); // 1
            result = solution.MaxPower("cc"); // 2
            result = solution.MaxPower("ccc"); // 3
            result = solution.MaxPower(""); // 0
            result = solution.MaxPower(null); // 0

        }
    }
}
