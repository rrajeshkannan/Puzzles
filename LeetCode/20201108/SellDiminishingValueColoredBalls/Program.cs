using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SellDiminishingValueColoredBalls
{
    // https://leetcode.com/contest/weekly-contest-214/problems/sell-diminishing-valued-colored-balls/

    public class Solution
    {
        public int MaxProfit(int[] inventory, int orders)
        {
            var moduloDouble = Math.Pow(10, 9) + 7;
            var modulo = (int)moduloDouble;

            var profit = 0;

            for (int i = 0; i < orders; i++)
            {
                inventory = inventory
                    .OrderByDescending(item => item)
                    .ToArray();

                var highValue = inventory[0];
                profit += highValue;

                var remainingInventory = Math.Max(highValue - 1, 0);
                inventory[0] = remainingInventory;
            }

            return profit % modulo;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var solution = new Solution();

            var inventory1 = new int[] { 2, 5 };
            var orders1 = 4;
            var result = solution.MaxProfit(inventory1, orders1);
            
            var inventory2 = new int[] { 3, 5 };
            var orders2 = 6;
            var result2 = solution.MaxProfit(inventory2, orders2);
            
            var inventory3 = new int[] { 2, 8, 4, 10, 6 };
            var orders3 = 20;
            var result3 = solution.MaxProfit(inventory3, orders3);

            var inventory4 = new int[] { 1000000000 };
            var orders4 = 1000000000;
            var result4 = solution.MaxProfit(inventory4, orders4);
        }
    }
}
