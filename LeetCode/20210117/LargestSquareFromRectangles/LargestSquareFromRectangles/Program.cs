using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LargestSquareFromRectangles
{
    public class Solution
    {
        public int CountGoodRectangles(int[][] rectangles)
        {
            var longest = 0;
            var count = 0;

            foreach(var rectangle in rectangles)
            {
                var squareSide = Math.Min(rectangle[0], rectangle[1]);

                if (squareSide > longest)
                {
                    count = 1;
                    longest = squareSide;
                }
                else if (squareSide == longest)
                {
                    count++;
                }
            }

            return count;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var solution = new Solution();

            var input1 = new int[][] {
                new int[]{ 5, 8 },
                new int[]{ 3, 9 },
                new int[]{ 5, 12 },
                new int[]{ 16, 5 },
            };

            var output1 = solution.CountGoodRectangles(input1);

            var input2 = new int[][] {
                new int[]{ 2, 3 },
                new int[]{ 3, 7 },
                new int[]{ 4, 3 },
                new int[]{ 3, 7 },
            };

            var output2 = solution.CountGoodRectangles(input2);
        }
    }
}
