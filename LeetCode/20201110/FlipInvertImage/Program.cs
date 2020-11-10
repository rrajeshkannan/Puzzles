using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlipInvertImage
{
    // https://leetcode.com/problems/flipping-an-image

    // Given a binary matrix A, we want to flip the image horizontally, then invert it, and return the resulting image.
    // To flip an image horizontally means that each row of the image is reversed.For example, flipping[1, 1, 0] horizontally results in [0, 1, 1].
    // To invert an image means that each 0 is replaced by 1, and each 1 is replaced by 0. For example, inverting[0, 1, 1] results in [1, 0, 0].
    // Example 1:
    //   Input: [[1,1,0],[1,0,1],[0,0,0]]
    //   Output: [[1,0,0],[0,1,0],[1,1,1]]
    //   Explanation: First reverse each row: [[0,1,1],[1,0,1],[0,0,0]].
    //   Then, invert the image: [[1,0,0],[0,1,0],[1,1,1]]
    // Example 2:
    //   Input: [[1,1,0,0],[1,0,0,1],[0,1,1,1],[1,0,1,0]]
    //   Output: [[1,1,0,0],[0,1,1,0],[0,0,0,1],[1,0,1,0]]
    //   Explanation: First reverse each row: [[0,0,1,1],[1,0,0,1],[1,1,1,0],[0,1,0,1]].
    //   Then invert the image: [[1,1,0,0],[0,1,1,0],[0,0,0,1],[1,0,1,0]]

    public class Solution
    {
        public int[][] FlipAndInvertImage(int[][] A)
        {
            FlipImage(A);
            InvertImage(A);

            return A;
        }

        private static void FlipImage(int[][] A)
        {
            var rows = A.Length;

            for (int row = 0; row < rows; row++)
            {
                var columns = A[row].Length;

                for (int column = 0; column < columns / 2; column++)
                {
                    var swapColumn = (columns - 1) - column;

                    var swap = A[row][column];
                    A[row][column] = A[row][swapColumn];
                    A[row][swapColumn] = swap;
                }
            }
        }

        private static void InvertImage(int[][] A)
        {
            var rows = A.Length;

            for (int row = 0; row < rows; row++)
            {
                var columns = A[row].Length;

                for (int column = 0; column < columns; column++)
                {
                    A[row][column] = ((A[row][column]) + 1) % 2;
                }
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var solution = new Solution();

            var image1 = new int[][]
            {
                new int[] { 1, 1, 0 },
                new int[] {1,0,1},
                new int[] {0,0,0},
            };

            var result1 = solution.FlipAndInvertImage(image1); // [[1,0,0],[0,1,0],[1,1,1]]

            var image2 = new int[][]
            {
                new int[] {1,1,0,0},
                new int[] {1,0,0,1},
                new int[] {0,1,1,1},
                new int[] {1,0,1,0},
            };

            var result2 = solution.FlipAndInvertImage(image2); // [[1,1,0,0],[0,1,1,0],[0,0,0,1],[1,0,1,0]]

            //var image = new int[][]
            //{
            //    new int[] {},
            //    new int[] {},
            //    new int[] {},
            //};
        }
    }
}
