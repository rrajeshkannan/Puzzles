using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdditiveNumber
{
    // https://leetcode.com/problems/additive-number/

    // Additive number is a string whose digits can form additive sequence.

    // A valid additive sequence should contain at least three numbers. 
    // Except for the first two numbers, each subsequent number in the sequence must be the sum of the preceding two.

    // Given a string containing only digits '0'-'9', write a function to determine if it's an additive number.

    // Note: Numbers in the additive sequence cannot have leading zeros, so sequence 1, 2, 03 or 1, 02, 3 is invalid.

    public class Solution
    {
        public bool IsAdditiveNumber(string num)
        {
            return true;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var solution = new Solution();

            var result1 = solution.IsAdditiveNumber("112358");
            var result2 = solution.IsAdditiveNumber("199100199");
        }
    }
}
