using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AreTwoStringsEqual
{
    // https://leetcode.com/contest/weekly-contest-216/problems/check-if-two-string-arrays-are-equivalent/

    class Program
    {
        public class Solution
        {
            public bool ArrayStringsAreEqual(string[] word1, string[] word2)
            {
                var length1 = 0;

                for (int i = 0; i < word1.Length; i++)
                {
                    length1 += word1[i].Length;
                }

                var length2 = 0;

                for (int i = 0; i < word2.Length; i++)
                {
                    length2 += word2[i].Length;
                }

                if (length1 != length2)
                {
                    return false;
                }

                var s1 = "";

                for (int i = 0; i < word1.Length; i++)
                {
                    s1 += word1[i];
                }

                var s2 = "";

                for (int i = 0; i < word2.Length; i++)
                {
                    s2 += word2[i];
                }

                return (s1 == s2);
            }
        }

        static void Main(string[] args)
        {
            var solution = new Solution();

            var word11 = "ab";
            var word12 = "c";
            var word21 = "a";
            var word22 = "bc";

            var result1 = solution.ArrayStringsAreEqual(
                new string[] { word11, word12 },
                new string[] { word21, word22 }); // true


        }
    }
}
