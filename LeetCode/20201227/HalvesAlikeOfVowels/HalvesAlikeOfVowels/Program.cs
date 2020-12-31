using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HalvesAlikeOfVowels
{
    public class Solution
    {
        public bool HalvesAreAlike(string s)
        {
            int halfLength = s.Length / 2;

            var firstHalf = s.Take(halfLength);
            var secondHalf = s.Skip(halfLength);

            int CountVowels(IEnumerable<char> text)
            {
                return text.Count(c
                    => c == 'a' || c == 'e' || c == 'i' || c == 'o' || c == 'u' ||
                    c == 'A' || c == 'E' || c == 'I' || c == 'O' || c == 'U');
            }

            var firstVowels = CountVowels(firstHalf);
            var secondVowels = CountVowels(secondHalf);

            return firstVowels == secondVowels;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var solution = new Solution();

            var input1 = "book";
            var output1 = solution.HalvesAreAlike(input1);

            var input2 = "textbook";
            var output2 = solution.HalvesAreAlike(input2);

            var input3 = "MerryChristmas";
            var output3 = solution.HalvesAreAlike(input3);

            var input4 = "AbCdEfGh";
            var output4 = solution.HalvesAreAlike(input4);
        }
    }
}
