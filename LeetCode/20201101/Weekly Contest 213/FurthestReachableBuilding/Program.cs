using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurthestReachableBuilding
{
    // https://leetcode.com/contest/weekly-contest-213/problems/furthest-building-you-can-reach/
    public class Solution
    {
        public int FurthestBuilding(int[] heights, int bricks, int ladders)
        {
            int current = 0;

            for (int next = 1; next < heights.Length; current++, next++)
            {
                var heightDifference = heights[next] - heights[current];

                if (heightDifference <= 0)
                {
                    // can go to next building without using bricks or ladders => go further
                    continue;
                }

                // cannot go to next building without using bricks or ladders
                if (heightDifference <= bricks)
                {
                    // can use bricks => deduct required bricks => go further
                    bricks -= heightDifference;
                }
                else if (ladders > 0)
                {
                    // can use ladder => use 1 ladder => go further
                    ladders--;
                }
                else
                {
                    // cannot go further
                    break;
                }
            }

            return current;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var solution = new Solution();

            var heights1 = new int[] { 4, 2, 7, 6, 9, 14, 12 };
            var bricks1 = 5;
            var ladders1 = 1;

            var result1 = solution.FurthestBuilding(heights1, bricks1, ladders1);

            var heights2 = new int[] { 4, 12, 2, 7, 3, 18, 20, 3, 19 };
            var bricks2 = 10;
            var ladders2 = 2;

            var result2 = solution.FurthestBuilding(heights2, bricks2, ladders2);

            var heights3 = new int[] { 14, 3, 19, 3 };
            var bricks3 = 17;
            var ladders3 = 0;

            var result3 = solution.FurthestBuilding(heights3, bricks3, ladders3);
        }
    }
}
