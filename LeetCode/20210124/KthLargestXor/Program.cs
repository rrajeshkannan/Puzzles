using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KthLargestXor
{
    // https://leetcode.com/contest/weekly-contest-225/problems/find-kth-largest-xor-coordinate-value/

    public class Solution
    {
        public int KthLargestValue(int[][] matrix, int k)
        {
            int rows = matrix.Length;
            int columns = matrix[0].Length;
            var result = new List<int>();

            for (int m = 0; m < rows; m++)
            {
                for (int n = 0; n < columns; n++)
                {
                    var value = matrix[0][0];

                    for (int a = 0; a <= m; a++)
                    {
                        for (int b = 0; b <= n; b++)
                        {
                            if ((a == 0) && (b == 0))
                                continue;

                            value ^= matrix[a][b];
                        }
                    }

                    result.Add(value);
                }
            }

            result = result.OrderByDescending(number => number).ToList();

            return result[k - 1];
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var solution = new Solution();

            var input1 = new int[][]
            {
                new int[]{ 5, 2 },
                new int[]{ 1, 6 }
            };
            var output1 = solution.KthLargestValue(input1, 1);
            var output2 = solution.KthLargestValue(input1, 2);
        }
    }
}
