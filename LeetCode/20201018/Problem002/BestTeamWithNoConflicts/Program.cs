using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BestTeamWithNoConflicts
{
    class Program
    {
        public class ScoreAndAge : IComparable<ScoreAndAge>
        {
            public int Id { get; private set; }
            public int Score { get; private set; }
            public int Age { get; private set; }

            public ScoreAndAge(int id, int score, int age)
            {
                Id = id;
                Score = score;
                Age = age;
            }

            public int CompareTo(ScoreAndAge other)
            {
                // Arrange objects in the reverse of Age, followed by forward of score
                if (this.Age > other.Age)
                {
                    return -1;
                }
                else if (this.Age < other.Age)
                {
                    return 1;
                }
                else
                {
                    if (this.Score < other.Score)
                    {
                        return -1;
                    }
                    else if (this.Score > other.Score)
                    {
                        return 1;
                    }
                    else
                    {
                        return 0;
                    }
                }
            }
        }

        public class Solution
        {
            public int BestTeamScore(int[] scores, int[] ages)
            {
                var bestTeamScore = 0;
                List<ScoreAndAge> scoresAndAges = new List<ScoreAndAge>();

                for (int i = 0; i < scores.Length; i++)
                {
                    scoresAndAges.Add(new ScoreAndAge(i, scores[i], ages[i]));
                }

                scoresAndAges.Sort();

                return bestTeamScore;
            }
        }


        static void Main(string[] args)
        {
            var scores = new int[] { 1, 3, 5, 10, 15 };
            var ages = new int[] { 1, 2, 3, 4, 5 };

            var solution = new Solution();

            Console.WriteLine("{0}", solution.BestTeamScore(scores, ages));
            Console.ReadKey();
        }
    }
}
