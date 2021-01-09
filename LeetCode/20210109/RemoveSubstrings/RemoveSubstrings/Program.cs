using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemoveSubstrings
{
    public class Solution
    {
        public int MaximumGain(string s, int x, int y)
        {
            var text = new StringBuilder(s);
            int score1;
            int score2;

            if (x > y)
            {
                (text, score1) = Maximum(text, "ab", x);
                (_, score2) = Maximum(text, "ba", y);
            }
            else
            {
                (text, score1) = Maximum(text, "ba", y);
                (_, score2) = Maximum(text, "ab", x);
            }

            return score1 + score2;
        }

        public (StringBuilder removedText, int score) Maximum(StringBuilder text, String textToRemove, int pointsPerRemoval)
        {
            var preLength = text.Length;
            var removedText = text.Replace(textToRemove, String.Empty);
            var postLength = removedText.Length;
            var totalRemoved = ((preLength - postLength) / 2);

            var score = totalRemoved * pointsPerRemoval;

            return (removedText, score);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var solution = new Solution();

            var output1 = solution.MaximumGain("cdbcbbaaabab", 4, 5);
            var output2 = solution.MaximumGain("aabbaaxybbaabb", 5, 4);
        }
    }
}
