using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmallestStringForNumericValue
{
    // https://leetcode.com/contest/weekly-contest-216/problems/smallest-string-with-a-given-numeric-value/



    class Program
    {
        public class Solution
        {
            public string GetSmallestString(int n, int k)
            {
                var result = String.Empty;

                if (n <= 0)
                {
                    return result;
                }

                var alphabets = Enumerable.Range('a', 'z' - 'a' + 1)
                    .Select(c => (char)c)
                    .ToList();

                var chosen = alphabets.Count;
                var repeat = k / chosen;
                var nBalance = n - repeat;

                if (repeat > 0)
                {
                    var balance = k % chosen;

                    if (balance < n - repeat)
                    {
                        repeat--;
                    }

                    result = new string(Enumerable.Repeat('z', repeat)
                        .Select(c => (char)c)
                        .ToArray());

                    k = k - (chosen * repeat);
                    n = n - repeat;
                }

                if (n > 0)
                {
                    chosen = k - (n - 1);

                    result = alphabets[chosen - 1] + result;
                    k -= chosen;
                    n--;

                    var prefix = new string(Enumerable.Repeat('a', n)
                            .Select(c => (char)c)
                            .ToArray());

                    result = prefix + result;
                }

                return result;
            }
        }

        static void Main(string[] args)
        {
            var solution = new Solution();

            var result1 = solution.GetSmallestString(3, 27); // "aay"
            var result2 = solution.GetSmallestString(5, 73); // "aaszz"
            var result3 = solution.GetSmallestString(2, 2); // "aa"
            var result4 = solution.GetSmallestString(2, 3); // "ab"
            var result5 = solution.GetSmallestString(2, 5); // "ad"
            var result6 = solution.GetSmallestString(3, 7); // "aaf"

            var watch = Stopwatch.StartNew();
            var tesolution = new TimeExceededSolution();
            var result7 = tesolution.GetSmallestString(74657, 743771)
                .TakeWhile(character => character == 'a')
                .Count();
            Console.WriteLine(result7);
            Console.WriteLine(watch.ElapsedMilliseconds);

            Console.ReadKey();
        }
    }

    public class TimeExceededSolution
    {
        public string GetSmallestString(int n, int k)
        {
            var alphabets = Enumerable.Range('a', 'z' - 'a' + 1).
                 Select(c => (char)c)
                 .ToList();

            var result = String.Empty;

            while (n > 0)
            {
                var chosen = alphabets.Count;
                var kBalance = k - chosen;
                var nBalance = n - 1;

                if (kBalance >= nBalance)
                {
                    result = alphabets[chosen - 1] + result;

                    k -= chosen;
                    n--;
                }
                else
                {
                    chosen = k - (n - 1);

                    result = alphabets[chosen - 1] + result;
                    k -= chosen;
                    n--;

                    while (n > 0)
                    {
                        chosen = 1;
                        result = alphabets[chosen - 1] + result;
                        k -= chosen;
                        n--;
                    }
                }
            }

            return result;
        }
    }
}
