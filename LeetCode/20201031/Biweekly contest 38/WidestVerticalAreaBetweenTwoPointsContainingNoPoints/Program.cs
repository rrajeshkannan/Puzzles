using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WidestVerticalAreaBetweenTwoPointsContainingNoPoints
{
    // https://leetcode.com/contest/biweekly-contest-38/problems/widest-vertical-area-between-two-points-containing-no-points/

    public class Solution
    {
        public int MaxWidthOfVerticalArea(int[][] points)
        {
            var xValues = points
                .Select(point => point[0])
                .OrderBy(x => x)
                .Distinct()
                .ToArray();

            var count = xValues.Count();

            return xValues.Take(count - 1)
                .Zip(xValues.Skip(1), (left, right) => (right - left))
                .OrderByDescending(width => width)
                .First();
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            var solution = new Solution();

            var points1 = new int[][]
            {
                new int[] { 8, 7 },
                new int[] { 9, 9 },
                new int[] { 7, 4 },
                new int[] { 9, 7 },
            };

            var result1 = solution.MaxWidthOfVerticalArea(points1);

            var points2 = new int[][]
            {
                new int[] { 3,1 },
                new int[] { 9,0 },
                new int[] { 1,0 },
                new int[] { 1,4 },
                new int[] { 5,3 },
                new int[] { 8,8 },
            };

            var result2 = solution.MaxWidthOfVerticalArea(points2);
        }
    }
}
