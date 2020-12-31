using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ConsecutiveBinaryNumbers
{
    // https://leetcode.com/contest/weekly-contest-218/problems/concatenation-of-consecutive-binary-numbers/

    public static class BigIntegerExtensions
    {
        /// <summary>
        /// Converts a <see cref="BigInteger"/> to a binary string.
        /// </summary>
        /// <param name="bigint">A <see cref="BigInteger"/>.</param>
        /// <returns>
        /// A <see cref="System.String"/> containing a binary
        /// representation of the supplied <see cref="BigInteger"/>.
        /// </returns>
        public static string ToBinaryString(this BigInteger bigint)
        {
            var bytes = bigint.ToByteArray();
            var idx = bytes.Length - 1;

            // Create a StringBuilder having appropriate capacity.
            var base2 = new StringBuilder(bytes.Length * 8);

            // Convert first byte to binary.
            var binary = Convert.ToString(bytes[idx], 2);

            // Ensure leading zero exists if value is positive.
            if (binary[0] != '0' && bigint.Sign == 1)
            {
                base2.Append('0');
            }

            // Append binary string to StringBuilder.
            base2.Append(binary);

            // Convert remaining bytes adding leading zeros.
            for (idx--; idx >= 0; idx--)
            {
                base2.Append(Convert.ToString(bytes[idx], 2).PadLeft(8, '0'));
            }

            return base2.ToString();
        }
    }
    
    public class Solution
    {
        public int ConcatenatedBinary(int n)
        {
            var result = new BigInteger();

            var digits = 1;
            var currentPositionalMax = 1;

            //for (var i = 1; i <= n; )
            for (var i = 1; i <= n; i++)
            {
                //var max = Math.Min(n, currentPositionalMax);

                //for (int j = i; j <= max; j++)
                //{
                //    result = (result << digits) + j;
                //}

                //i = max + 1;
                //currentPositionalMax = (currentPositionalMax << 1) + 1;
                //digits++;

                if (i > currentPositionalMax)
                {
                    currentPositionalMax = (currentPositionalMax << 1) + 1;
                    digits++;
                }

                result = (result << digits) + i;
            }

            var roundOff = BigInteger.Pow(10, 9) + 7;
            result = result % roundOff;

            return (int)result;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var solution = new Solution();

            var result1 = solution.ConcatenatedBinary(1); // 1 -> 1
            var result2 = solution.ConcatenatedBinary(3); // 11011 -> 27
            var result3 = solution.ConcatenatedBinary(4); // 11011100 -> 220
            var result4 = solution.ConcatenatedBinary(12); // 1101110010111011110001001101010111100 -> 118505380540
                                                           // After modulo 10^9 + 7, the result is 505379714.
            var result5 = solution.ConcatenatedBinary((int)Math.Pow(10, 5));
        }
    }
}
