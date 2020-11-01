using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountSortedVowelStrings
{
    // https://leetcode.com/contest/weekly-contest-213/problems/count-sorted-vowel-strings/

    public class Solution
    {
        public int CountVowelStrings(int n)
        {
            var vowels = new char[] { 'a', 'e', 'i', 'o', 'u' };
            var texts = new List<String>();

            for (int k = 0; k < n; k++)
            {
                for (int l = k; l < n; l++)
                {
                    var text = new StringBuilder();

                    for (int i = 0; i < vowels.Length; i++)
                    {
                        text.Append(vowels[l]);
                    }
                }
            }

            return texts.Count;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var solution = new Solution();

            var number1 = 1;
            var result1 = solution.CountVowelStrings(number1);

            var number2 = 2;
            var result2 = solution.CountVowelStrings(number2);

            var number3 = 33;
            var result3 = solution.CountVowelStrings(number3);
        }
    }
}
