using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BallsInBox
{
    // https://leetcode.com/contest/weekly-contest-226/problems/maximum-number-of-balls-in-a-box/

    public class Solution
    {
        public int CountBalls(int lowLimit, int highLimit)
        {
            if (highLimit - lowLimit + 1 <= 0)
            {
                return 0;
            }

            var boxes = new Dictionary<int, int>();

            for (int i = lowLimit; i <= highLimit; i++)
            {
                int sum = 0;
                int current = i;

                while (current != 0)
                {
                    var digit = current % 10;
                    sum += digit;
                    current /= 10;
                }

                if (boxes.TryGetValue(sum, out var count))
                {
                    boxes[sum]++;
                }
                else
                {
                    boxes.Add(sum, 1);
                }
            }

            var orderedCounts = boxes.Values
                .OrderByDescending(count => count)
                .ToArray();

            return orderedCounts[0];
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var solution = new Solution();

            var output1 = solution.CountBalls(1, 10);
            var output2 = solution.CountBalls(5, 15);
            var output3 = solution.CountBalls(19, 28);
            var output4 = solution.CountBalls(1, 100);
        }
    }
}
