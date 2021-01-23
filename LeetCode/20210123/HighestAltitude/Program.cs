using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HighestAltitude
{

    //https://leetcode.com/contest/biweekly-contest-44/problems/find-the-highest-altitude/

    public class Solution
    {
        public int LargestAltitude(int[] gain)
        {
            var currentAltitude = 0;
            var highestAltitude = 0;

            for (int i = 0; i < gain.Length; i++)
            {
                currentAltitude += gain[i];

                if (highestAltitude < currentAltitude)
                {
                    highestAltitude = currentAltitude;
                }
                
            }

            return highestAltitude;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var solution = new Solution();

            var output1 = solution.LargestAltitude(new int[] { -5, 1, 5, 0, -7 });
            var output2 = solution.LargestAltitude(new int[] { -4, -3, -2, -1, 4, 3, 2 });
        }
    }
}
