using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemoveStones
{
    // https://leetcode.com/contest/weekly-contest-227/problems/maximum-score-from-removing-stones/

    class Program
    {
        public class Solution
        {
            public int MaximumScore(int a, int b, int c)
            {
                var pilesArranged = (new int[] { a, b, c })
                    .OrderBy(number => number)
                    .ToArray();

                var sumOfSmallPiles = pilesArranged[0] + pilesArranged[1];

                if (sumOfSmallPiles <= pilesArranged[2])
                {
                    return sumOfSmallPiles;
                }

                return (sumOfSmallPiles + pilesArranged[2]) / 2;
            }
        }

        static void Main(string[] args)
        {

        }
    }
}
