using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinimumPeopleToTeach
{
    // https://leetcode.com/contest/biweekly-contest-44/problems/minimum-number-of-people-to-teach/

    public class Solution
    {
        public int MinimumTeachings(int n, int[][] languages, int[][] friendships)
        {
            var result = 0;
            var missingLanguagesBetweenFriendships = new List<int>[languages.Length];

            for (int i = 0; i < friendships.Length; i++)
            {
                var friend1 = friendships[i][0] - 1;
                var friend2 = friendships[i][1] - 1;

                var language1 = languages[friend1];
                var language2 = languages[friend2];

                var commonLanguage = language1.Intersect(language2);

                if (!commonLanguage.Any())
                {
                    missingLanguagesBetweenFriendships[i] = new List<int>();
                    missingLanguagesBetweenFriendships[i].AddRange(language1);
                    missingLanguagesBetweenFriendships[i].AddRange(language2);
                }
            }

            IEnumerable<int> leastCommonLanguage = Enumerable.Range(1, n);

            foreach (var missingLanguagesBetweenFriendship in missingLanguagesBetweenFriendships)
            {
                if (missingLanguagesBetweenFriendship == null)
                {
                    continue;
                }

                leastCommonLanguage = leastCommonLanguage.Intersect(missingLanguagesBetweenFriendship);
            }

            var leastCommonLanguageArray = leastCommonLanguage.ToArray();

            List<>

            return result;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var solution = new Solution();

            var n1 = 2;
            var languages1 = new int[][]
            {
                new int[]{ 1 },
                new int[]{ 2 },
                new int[]{ 1, 2 },
            };
            var friendships1 = new int[][]
            {
                new int[]{ 1, 2 },
                new int[]{ 1, 3 },
                new int[]{ 2, 3 },
            };

            var output1 = solution.MinimumTeachings(n1, languages1, friendships1);

            var n2 = 3;
            var languages2 = new int[][]
            {
                new int[]{ 2 },
                new int[]{ 1, 3 },
                new int[]{ 1, 2 },
                new int[]{ 3 },
            };
            var friendships2 = new int[][]
            {
                new int[]{ 1, 4 },
                new int[]{ 1, 2 },
                new int[]{ 3, 4 },
                new int[]{ 2, 3 },
            };

            var output2 = solution.MinimumTeachings(n2, languages2, friendships2);

            //var n = 0;
            //var languages = new int[][]
            //{
            //    new int[],
            //    new int[],
            //    new int[],
            //};
            //var friendships = new int[][]
            //{
            //    new int[],
            //    new int[],
            //    new int[],
            //};

            //var output = solution.MinimumTeachings(n, languages, friendships);
        }
    }
}
