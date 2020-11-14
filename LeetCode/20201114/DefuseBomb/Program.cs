using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DefuseBomb
{
    // https://leetcode.com/contest/biweekly-contest-39/problems/defuse-the-bomb/

    // You have a bomb to defuse, and your time is running out! 
    // Your informer will provide you with a circular array code of length of n and a key k.
    // 
    // To decrypt the code, you must replace every number.All the numbers are replaced simultaneously.
    // 
    // If k > 0, replace the ith number with the sum of the next k numbers.
    // If k < 0, replace the ith number with the sum of the previous k numbers.
    // If k == 0, replace the ith number with 0.
    // As code is circular, the next element of code[n - 1] is code[0], and the previous element of code[0] is code[n - 1].
    // 
    // Given the circular array code and an integer key k, return the decrypted code to defuse the bomb!

    // Example-1:
    // Input: code = [5,7,1,4], k = 3
    // Output: [12,10,16,13]
    // Explanation: 
    //   Each number is replaced by the sum of the next 3 numbers.
    //   The decrypted code is [7+1+4, 1+4+5, 4+5+7, 5+7+1].
    //   Notice that the numbers wrap around.
    //
    // Example-2:
    // Input: code = [1,2,3,4], k = 0
    // Output: [0,0,0,0]
    // Explanation: 
    //   When k is zero, the numbers are replaced by 0. 
    // 
    // Example-3:
    // Input: code = [2,4,9,3], k = -2
    // Output: [12,5,6,13]
    // Explanation:
    //   The decrypted code is [3+9, 2+3, 4+2, 9+4]. Notice that the numbers wrap around again.If k is negative, the sum is of the previous numbers.


    public class Solution
    {
        public int[] Decrypt(int[] code, int k)
        {
            var length = code.Length;

            if (k == 0)
            {
                return Enumerable.Repeat(0, length).ToArray();
            }

            var result = new int[length];

            if (k > 0)
            {
                for (int i = 0; i < length; i++)
                {
                    var sum = 0;

                    for (int j = 0, begin = i + 1; j < k; j++, begin++)
                    {
                        sum += code[begin % length];
                    }

                    result[i] = sum;
                }
            }
            else
            {
                k = -k;

                for (int i = 0; i < length; i++)
                {
                    var sum = 0;

                    for (int j = 0, begin = i - 1; j < k; j++, begin--)
                    {
                        sum += code[(begin + length) % length];
                    }

                    result[i] = sum;
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

            var code1 = new int[] { 5, 7, 1, 4 };
            var result1 = solution.Decrypt(code1, 3); // [12,10,16,13]

            var code2 = new int[] { 1, 2, 3, 4 };
            var result2 = solution.Decrypt(code2, 0); // [0,0,0,0]

            var code3 = new int[] { 2, 4, 9, 3 };
            var result3 = solution.Decrypt(code3, -2); // [12,5,6,13]
        }
    }
}
