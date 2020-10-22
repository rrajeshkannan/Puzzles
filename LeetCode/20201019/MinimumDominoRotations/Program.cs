using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinimumDominoRotations
{
    // https://leetcode.com/explore/challenge/card/october-leetcoding-challenge/561/week-3-october-15th-october-21st/3500/

    public class Solution
    {
        public int MinDominoRotations(int[] A, int[] B)
        {
            var requiredRotationsForSwapsA = B.Take(1).Concat(A.Skip(1));
            var requiredRotationsForSwapsB = A.Take(1).Concat(B.Skip(1));

            var requiredRotations = new int[]
            {
                FindRequiredRotations(A, B, false),
                FindRequiredRotations(B, A, false),
                FindRequiredRotations(requiredRotationsForSwapsA, requiredRotationsForSwapsB, true),
                FindRequiredRotations(requiredRotationsForSwapsB, requiredRotationsForSwapsA, true),
            };

            var filtered = requiredRotations
                .Where(rotation => rotation != -1);

            return filtered.Any() ? filtered.Min() : -1;
        }

        private int FindRequiredRotations(IEnumerable<int> source, IEnumerable<int> other, bool firstItemSwapped)
        {
            var source0 = source.First();

            var matches = source.Skip(1)
                .Zip(other.Skip(1), (s, o) => (s == source0))
                .Count(flag => flag);

            var requiredRotations = source.Skip(1)
                .Zip(other.Skip(1), (s, o) => ((s != source0) && (o == source0)))
                .Count(flag => flag);

            if (matches + requiredRotations == source.Count() - 1)
            {
                return requiredRotations +
                    // Add 1, because first item is rotated
                    (firstItemSwapped ? 1 : 0);
            }

            return -1;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var solution = new Solution();

            int[] A1 = new int[] { 2, 1, 2, 4, 2, 2 };
            int[] B1 = new int[] { 5, 2, 6, 2, 3, 2 };

            var rotations1 = solution.MinDominoRotations(A1, B1); // 2

            int[] A2 = { 3, 5, 1, 2, 3 };
            int[] B2 = { 3, 6, 3, 3, 4 };

            var rotations2 = solution.MinDominoRotations(A2, B2); // -1

            int[] A3 = { 1, 1, 1, 1, 1 };
            int[] B3 = { 2, 2, 2, 2, 2 };

            var rotation3 = solution.MinDominoRotations(A3, B3); // 0

            int[] A4 = { 1, 2 };
            int[] B4 = { 1, 2 };

            var rotation4 = solution.MinDominoRotations(A4, B4); // -1

            int[] A5 = { 1, 2, 1, 2, 1, 2 };
            int[] B5 = { 2, 1, 2, 1, 2, 1 };

            var rotation5 = solution.MinDominoRotations(A5, B5); // 3

            int[] A6 = { 1, 2, 1, 1, 1 };
            int[] B6 = { 2, 1, 2, 2, 2 };

            var rotation6 = solution.MinDominoRotations(A6, B6); // 1

            int[] A7 = { 2, 1, 1, 1, 1 };
            int[] B7 = { 1, 2, 2, 2, 2 };

            var rotation7 = solution.MinDominoRotations(A7, B7); // 1

            int[] A8 = { 2, 1, 1 };
            int[] B8 = { 1, 2, 2 };

            var rotation8 = solution.MinDominoRotations(A8, B8); // 1

            int[] A9 = { 1, 1, 2, 2 };
            int[] B9 = { 2, 2, 1, 1 };

            var rotation9 = solution.MinDominoRotations(A9, B9); // 2

            int[] A10 = { 1, 3, 2, 2 };
            int[] B10 = { 2, 4, 1, 1 };

            var rotation10 = solution.MinDominoRotations(A10, B10); // -1

            int[] A11 = { 2, 1, 2, 4, 2, 2 };
            int[] B11 = { 5, 2, 6, 2, 3, 2 };

            var rotation11 = solution.MinDominoRotations(A11, B11); // 2

            //int[] A = { };
            //int[] B = { };

            //var rotation = solution.MinDominoRotations(A, B); // 
        }
    }
}