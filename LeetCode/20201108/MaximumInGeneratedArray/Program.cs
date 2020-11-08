using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaximumInGeneratedArray
{
    public class Solution
    {
        public int GetMaximumGenerated(int n)
        {
            if (n == 0)
            {
                return 0;
            }

            if (n == 1)
            {
                return 1;
            }

            var array = new int[n + 1];

            array[0] = 0;
            array[1] = 1;

            for (int i = 2; i <= n; i++)
            {
                array[i] = array[i/2];
                if (i % 2 == 1)
                {
                    array[i] += array[i / 2 + 1];
                }
            }

            return array.Max();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var solution = new Solution();

            int n1 = 0;
            var result1 = solution.GetMaximumGenerated(n1); // 0

            int n2 = 1;
            var result2 = solution.GetMaximumGenerated(n2); // 1

            int n3 = 2;
            var result3 = solution.GetMaximumGenerated(n3); // 1

            int n4 = 7;
            var result4 = solution.GetMaximumGenerated(n4); // 3

            int n5 = 6;
            var result5 = solution.GetMaximumGenerated(n5); // 3

            int n6 = 8;
            var result6 = solution.GetMaximumGenerated(n6); // 3

            int n7 = 15;
            var result7 = solution.GetMaximumGenerated(n7); // 5
        }
    }
}
