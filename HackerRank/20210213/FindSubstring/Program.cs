using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindSubstring
{
    // https://www.hackerrank.com/challenges/hackerrank-in-a-string/problem

    class Solution
    {

        private const string _search = "hackerrank";

        // Complete the hackerrankInString function below.
        public static string hackerrankInString(string s)
        {
            int si = 0;
            int terminal = _search.Length;

            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == _search[si])
                {
                    si++;

                    if (si == terminal)
                    {
                        return "YES";
                    }
                }
            }

            return "NO";
        }
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            var output1 = Solution.hackerrankInString("haacckkerrannkk"); // YES
            var output2 = Solution.hackerrankInString("haacckkerannk"); // NO
            var output3 = Solution.hackerrankInString("hccaakkerrannkk"); // NO
            var output4 = Solution.hackerrankInString("hereiamstackerrank"); // YES
            var output5 = Solution.hackerrankInString("hackerworld"); // NO
        }
    }
}
