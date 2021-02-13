using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LargestMergedString
{
    // https://leetcode.com/contest/weekly-contest-227/problems/largest-merge-of-two-strings/

    public class Solution
    {
        public string LargestMerge(string word1, string word2)
        {
            var text1 = new StringBuilder(word1);
            var text2 = new StringBuilder(word2);
            var merged = new StringBuilder();

            while (true)
            {
                if (text1.Length == 0)
                {
                    merged.Append(text2);
                    break;
                }

                if (text2.Length == 0)
                {
                    merged.Append(text1);
                    break;
                }

                if (text1[0] >= text2[0])
                {
                    merged.Append(text1[0]);
                    text1.Remove(0, 1);
                }
                else
                {
                    merged.Append(text2[0]);
                    text2.Remove(0, 1);
                }
                //else if (text2[0] > text1[0])
                //{
                //    merged.Append(text2[0]);
                //    text2.Remove(0, 1);
                //}
                //else
                //{
                //    int i = 0;

                //    for (; i < text1.Length; i++)
                //    {
                //        if (text1[i] != text2[0])
                //        {
                //            break;
                //        }
                //    }

                //    var subLength = Math.Min(i + 1, text1.Length);
                //    var subChosenText = text1.ToString(0, subLength);

                //    merged.Append(subChosenText);
                //    text1.Remove(0, subLength);
                //}
            }

            return merged.ToString();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var solution = new Solution();

            var output1 = solution.LargestMerge("cabaa", "bcaaa");
            var output2 = solution.LargestMerge("abcabc", "abdcaba");
            var output3 = solution.LargestMerge(
                "guguuuuuuuuuuuuuuguguuuuguug",
                "gguggggggguuggguugggggg"); // "guguuuuuuuuuuuuuuguguuuuguugguggggggguuggguuggggggg"

            var output4 = solution.LargestMerge(
                "uuurruuuruuuuuuuuruuuuu",
                "urrrurrrrrrrruurrrurrrurrrrruu"); // "uuuurruuuruuuuuuuuruuuuurrrurrrrrrrruurrrurrrurrrrruu"
        }
    }
}
