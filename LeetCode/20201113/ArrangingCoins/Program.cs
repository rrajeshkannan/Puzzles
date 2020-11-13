using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrangingCoins
{
    public class Solution
    {
        public int ArrangeCoins(int s)
        {
            // s = n (n + 1) / 2
            // 2s = n (n + 1)
            // 2s = n2 + n
            // 2s + (1/4) = n2 + n + (1/4)
            // 2s + (1/4) = pow((n + (1/2)), 2)
            // sqrt(2s + (1/4)) = sqrt(pow((n + (1/2)), 2))
            // in other words, sqrt(pow((n + (1/2)), 2)) = sqrt(2s + (1/4))
            // n + (1/2) = sqrt(2s + (1/4))
            // n = sqrt(2s + (1/4)) - (1/2)
            // n = Math.Sqrt (2 * s + (1.0 / 4.0)) - (1.0 / 2.0)

            // Math.Sqrt(2 * (uint)s + (1.0 / 4.0)) - 1.0 / 2.0
            var result = Math.Sqrt(2 * (uint)s + (0.25)) - 0.5;
            return (int)Math.Floor(result);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var solution = new Solution();

            var result0 = solution.ArrangeCoins(0);
            var result1 = solution.ArrangeCoins(1);
            var result2 = solution.ArrangeCoins(2);
            var result3 = solution.ArrangeCoins(3);
            var result4 = solution.ArrangeCoins(4);
            var result5 = solution.ArrangeCoins(5);
            var result6 = solution.ArrangeCoins(6);
            var result7 = solution.ArrangeCoins(7);
            var result8 = solution.ArrangeCoins(8);
            var result9 = solution.ArrangeCoins(9);
            var result10 = solution.ArrangeCoins(10);
            var result11 = solution.ArrangeCoins(11);
            var result12 = solution.ArrangeCoins(12);
            var result13 = solution.ArrangeCoins(13);
            var result14 = solution.ArrangeCoins(14);
            var result15 = solution.ArrangeCoins(15);
            var result16 = solution.ArrangeCoins(16);
            var result17 = solution.ArrangeCoins(17);
            var result18 = solution.ArrangeCoins(18);
            var result19 = solution.ArrangeCoins(19);
            var result20 = solution.ArrangeCoins(20);
            var result21 = solution.ArrangeCoins(21);
            var result_n = solution.ArrangeCoins(1804289383);
        }
    }
}
