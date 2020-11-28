using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaximumRepeatingSubstring
{
    // https://leetcode.com/contest/biweekly-contest-40/problems/maximum-repeating-substring/

    public class Solution
    {
        public int MaxRepeating(string sequence, string word)
        {
            var maxRepeating = 0;
            var currentRepeating = 0;

            for (int i = 0; i <= sequence.Length - word.Length; )
            {
                if (sequence[i] == word[0])
                {
                    var matching = true;

                    for (int j = 1; j < word.Length; j++)
                    {
                        if (sequence[i + j] != word[j])
                        {
                            matching = false;
                            break;
                        }
                    }

                    if (matching)
                    {
                        currentRepeating++;

                        i += word.Length;
                        continue;
                    }
                }

                if (maxRepeating < currentRepeating)
                {
                    maxRepeating = currentRepeating;
                }

                currentRepeating = 0;
                i++;
            }

            if (maxRepeating < currentRepeating)
            {
                maxRepeating = currentRepeating;
            }

            return maxRepeating;
        }
    }

    class Program
    {
        static void Main()
        {
            var solution = new Solution();

            var result1 = solution.MaxRepeating("ababc", "ab"); // 2
            var result2 = solution.MaxRepeating("ababab", "ab"); // 3
            var result3 = solution.MaxRepeating("abbab", "ab"); // 1
            var result10 = solution.MaxRepeating("abaab", "ab"); // 1
            var result4 = solution.MaxRepeating("aabab", "ab"); // 2
            var result5 = solution.MaxRepeating("ab", "ab"); // 1
            var result6 = solution.MaxRepeating("ba", "ab"); // 0
            var result7 = solution.MaxRepeating("a", "ab"); // 0
            var result8 = solution.MaxRepeating("baba", "b"); // 1
            var result9 = solution.MaxRepeating("bbaba", "b"); // 2
        }
    }
}
