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
                if (n <= 0)
                {
                    return String.Empty;
                }

                var result = new StringBuilder();

                var alphabets = Enumerable.Range('a', 'z' - 'a' + 1)
                    .Select(c => (char)c)
                    .ToList();

                var chosen = alphabets.Count;
                var repeat = k / chosen;

                if (repeat > 0)
                {
                    var nBalance = n - repeat;

                    if (nBalance > 0)
                    {
                        // how many number of 'z' from "repeat" can be donated by replacing 'z' with 'a' to reach required 'n'?
                        // (26 - 1) => 26 represents 'z', 1 represents 'a'
                        //   for 1 'z', 26 'a' can come in => 26 letters replace 1 letter
                        //   meaning a net addition of 25 letters coming in => 1 'z' replaced by 1 'a' + 25 'a'
                        var donateFromRepeat = nBalance / (chosen - 1);
                        
                        //var donatedLeftovers = nBalance % (chosen - 1);

                        //if (donatedLeftovers > 0)
                        //{
                        //    donateFromRepeat++;
                        //}

                        repeat -= donateFromRepeat;
                    }

                    result.Insert(0, new string('z', repeat));
                    k -= chosen * repeat;
                    n -= repeat;
                }

                if (n > 0)
                {
                    chosen = k - (n - 1);

                    if (chosen > 0)
                    {
                        result.Insert(0, alphabets[chosen - 1]);

                        k -= chosen;
                        n--;
                    }

                    result.Insert(0, new string('a', n));
                }

                return result.ToString();
            }
        }

        static void Main(string[] args)
        {
            var solution = new Solution();

            var result1 = solution.GetSmallestString(3, 27); // "aay"
            //var result2 = solution.GetSmallestString(5, 73); // "aaszz"
            //var result3 = solution.GetSmallestString(2, 2); // "aa"
            //var result4 = solution.GetSmallestString(2, 3); // "ab"
            //var result5 = solution.GetSmallestString(2, 5); // "ad"
            //var result6 = solution.GetSmallestString(3, 7); // "aae"
            //var result9 = solution.GetSmallestString(2, 52); // "zz"
            //var result10 = solution.GetSmallestString(2, 51); // "yz"
            //var result11 = solution.GetSmallestString(80, 576);
            //// Expected:
            //// "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaavzzzzzzzzzzzzzzzzzzz"
            //// Actual:
            //// "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaazzzzzzzzzzzzzzzzzzzz"

            //var watch7 = Stopwatch.StartNew();
            //var result7 = solution.GetSmallestString(74657, 743771);
            //// 'a' - 47892
            //// 'o' - 1
            //// 'z' - 26764
            //watch7.Stop();
            //Console.WriteLine(watch7.ElapsedMilliseconds); // 5

            //var result7Groups = result7
            //    .GroupBy(character => character)
            //    .Select(group => new { character = group.Key, count = group.Count() })
            //    .ToList();

            //for (int i = 0; i < result7Groups.Count; i++)
            //{
            //    Console.WriteLine("Group-character: {0}, Group-count: {1}", result7Groups[i].character, result7Groups[i].count);
            //}

            var tesolution = new Solution();
            var watch101 = Stopwatch.StartNew();
            var result101 = tesolution.GetSmallestString(74657, 743771);
            // a - 47892
            // o - 1
            // z - 26764
            watch101.Stop();
            Console.WriteLine(watch101.ElapsedMilliseconds);

            var result101Groups = result101
                .GroupBy(character => character)
                .Select(group => new { character = group.Key, count = group.Count() })
                .ToList();

            foreach (var result101Group in result101Groups)
            {
                Console.WriteLine($"{result101Group.character} - {result101Group.count}");
            }

            var watch102 = Stopwatch.StartNew();
            var result102 = tesolution.GetSmallestString(96109, 1229657);
            // a - 50767
            // x - 1
            // z - 45341
            watch102.Stop();
            Console.WriteLine(watch101.ElapsedMilliseconds); 

            var result102Groups = result102
                .GroupBy(character => character)
                .Select(group => new { character = group.Key, count = group.Count() })
                .ToList();

            foreach (var result102Group in result102Groups)
            {
                Console.WriteLine($"{result102Group.character} - {result102Group.count}");
            }

            var result103 = tesolution.GetSmallestString(80, 576);

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

            var result = new StringBuilder();

            while (n > 0)
            {
                var chosen = alphabets.Count;
                var kBalance = k - chosen;
                var nBalance = n - 1;

                if (kBalance >= nBalance)
                {
                    result.Insert(0, alphabets[chosen - 1]);

                    k -= chosen;
                    n--;
                }
                else
                {
                    chosen = k - (n - 1);

                    result.Insert(0, alphabets[chosen - 1]);
                    k -= chosen;
                    n--;

                    if (n > 0)
                    {
                        result.Insert(0, new string('a', n));

                        k -= n;
                        n -= n;
                    }
                }
            }

            return result.ToString();
        }
    }
}
