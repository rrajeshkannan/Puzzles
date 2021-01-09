using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyInBank
{
    // Hercy wants to save money for his first car. He puts money in the Leetcode bank every day.
    // He starts by putting in $1 on Monday, the first day.Every day from Tuesday to Sunday, he will put in $1 more than the day before.On every subsequent Monday, he will put in $1 more than the previous Monday.
    // Given n, return the total amount of money he will have in the Leetcode bank at the end of the nth day.

    // Input: n = 4, Output: 10, Explanation: After the 4th day, the total is 1 + 2 + 3 + 4 = 10.
    // Input: n = 10, Output: 37, Explanation: After the 10th day, the total is (1 + 2 + 3 + 4 + 5 + 6 + 7) + (2 + 3 + 4) = 37. Notice that on the 2nd Monday, Hercy only puts in $2.
    // Input: n = 20, Output: 96, Explanation: After the 20th day, the total is (1 + 2 + 3 + 4 + 5 + 6 + 7) + (2 + 3 + 4 + 5 + 6 + 7 + 8) + (3 + 4 + 5 + 6 + 7 + 8) = 96.

    public class Solution
    {
        public int TotalMoney(int n)
        {
            int startOfWeek = 1;
            int money = 0;
            int current = startOfWeek;

            for (int i = 1; i <= n; i++)
            {
                money += current;
                current++;

                if (i % 7 == 0)
                {
                    startOfWeek++;
                    current = startOfWeek;
                }
            }

            return money;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var solution = new Solution();
            var output1 = solution.TotalMoney(4);
            var output2 = solution.TotalMoney(10);
            var output3 = solution.TotalMoney(20);
        }
    }
}
