using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RichestCustomerWealth
{
    // https://leetcode.com/contest/weekly-contest-217/problems/richest-customer-wealth/

    public class Solution
    {
        public int MaximumWealth(int[][] accounts)
        {
            var amount = accounts
                .Select(personAccount => personAccount.Sum())
                .Max();

            return amount;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var solution = new Solution();

            var input1 = new int[][] { new int[] { 1, 2, 3 }, new int[] { 3, 2, 1 } };
            var result1 = solution.MaximumWealth(input1); // 6

            var input2 = new int[][] { new int[] { 1, 5 }, new int[] { 7, 3 }, new int[] { 3, 5 } };
            var result2 = solution.MaximumWealth(input2); // 10

            var input3 = new int[][] { new int[] { 2, 8, 7 }, new int[] { 7, 1, 3 }, new int[] { 1, 9, 5 } };
            var result3 = solution.MaximumWealth(input3); // 17
        }
    }
}
