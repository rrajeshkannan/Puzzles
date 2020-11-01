using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


// https://leetcode.com/contest/weekly-contest-213/problems/check-array-formation-through-concatenation/

namespace CheckArrayFormationThroughConcatenation
{
    public class Solution
    {
        public bool CanFormArray(int[] arr, int[][] pieces)
        {
            var result = true;
            var terminals = Enumerable.Repeat(-1, pieces.Length)
                .ToArray();

            for (int i = 0; i < arr.Length; i++)
            {
                var target = arr[i];
                var canFormTarget = false;

                for (int j = 0; j < pieces.Length; j++)
                {
                    var potentialTerminal = terminals[j] + 1;

                    for (int k = potentialTerminal; k < pieces[j].Length; k++)
                    {
                        if (pieces[j][k] == target)
                        {
                            // target found, continue with next number
                            terminals[j] = k;
                            canFormTarget = true;
                            break;
                        }
                    }

                    if (canFormTarget)
                    {
                        // target found, continue with next number
                        break;
                    }
                }

                if (!canFormTarget)
                {
                    // cannot form target, no need to continue with further numbers
                    result = false;
                    break;
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

            var array1 = new int[] { 85 };
            var pieces1 = new int[][]
            {
                new int[]{ 85 },
            };

            var result1 = solution.CanFormArray(array1, pieces1);

            var array2 = new int[] { 15, 88 };
            var pieces2 = new int[][]
            {
                new int[]{ 88 },
                new int[]{ 15 },
            };

            var result2 = solution.CanFormArray(array2, pieces2);

            var array3 = new int[] { 49, 18, 16 };
            var pieces3 = new int[][]
            {
                new int[]{ 16,18,49 }
            };

            var result3 = solution.CanFormArray(array3, pieces3);

            var array4 = new int[] { 91, 4, 64, 78 };
            var pieces4 = new int[][]
            {
                new int[]{ 78 },
                new int[]{ 4,64 },
                new int[]{ 91 },
            };

            var result4 = solution.CanFormArray(array4, pieces4);

            var array5 = new int[] { 1, 3, 5, 7 };
            var pieces5 = new int[][]
            {
                new int[]{ 2,4,6,8 },
            };

            var result5 = solution.CanFormArray(array5, pieces5);

        }
    }
}
