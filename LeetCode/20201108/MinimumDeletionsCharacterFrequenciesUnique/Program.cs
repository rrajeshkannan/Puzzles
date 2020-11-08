using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinimumDeletionsCharacterFrequenciesUnique
{
    public class Solution
    {
        public int MinDeletions(string s)
        {
            if(String.IsNullOrEmpty(s))
            {
                return 0;
            }

            var groupedCounts = s.GroupBy(c => c)
                .Select(grouped => grouped.Count())
                .OrderByDescending(count => count)
                .ToArray();

            var deletions = 0;
            var groups = groupedCounts.Count();

            for (int i = 1; i < groups; i++)
            {
                int current = groupedCounts[i];
                int expected = Math.Max((groupedCounts[i - 1] - 1), 0);

                if (current > expected)
                {
                    deletions += (current - expected);

                    groupedCounts[i] = expected;
                }
            }

            return deletions;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var solution = new Solution();

            var s1 = "aab";
            var result1 = solution.MinDeletions(s1); // 0

            var s2 = "aaabbbcc";
            var result2 = solution.MinDeletions(s2); // 2

            var s3 = "ceabaacb";
            var result3 = solution.MinDeletions(s3); // 2

            var s4 = "";
            var result4 = solution.MinDeletions(s4);

            var s5 = "aaabbbcccdde";
            var result5 = solution.MinDeletions(s5); // 6

            var s6 = "aaaaabbbbcccdde";
            var result6 = solution.MinDeletions(s6); // 0
        }
    }
}
