using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArithmeticSubarrays
{
    // https://leetcode.com/contest/weekly-contest-212/problems/arithmetic-subarrays/

    public class NumberWithIndex
    {
        public int Number { get; private set; }
        public int Index { get; private set; }

        public NumberWithIndex(int number, int index)
        {
            this.Number = number;
            this.Index = index;
        }

        public override string ToString()
        {
            return String.Format("Number: {0}, Index: {1}", this.Number, this.Index);
        }
    }

    public class LeftAndRight
    {
        public int Left { get; private set; }
        public int Right { get; private set; }

        public LeftAndRight(int left, int right)
        {
            this.Left = left;
            this.Right = right;
        }

        public override string ToString()
        {
            return String.Format("Left: {0}, Right: {1}", this.Left, this.Right);
        }
    }

    public class Solution
    {
        public IList<bool> CheckArithmeticSubarrays(int[] nums, int[] l, int[] r)
        {
            var indices = Enumerable
                .Range(0, nums.Length);

            var numbersWithIndices = nums
                .Zip(indices, (number, index) => new NumberWithIndex (number, index));

            var leftsAndRights = l
                .Zip(r, (left, right) => new LeftAndRight(left, right));

            var subarray = leftsAndRights.GroupJoin(
                numbersWithIndices,
                leftAndRight => 0, // match everything
                numberWithIndex => 0, // match everything
                (leftAndRight, numbersWithIndicesInner) => numbersWithIndicesInner
                    .Where(numberWithIndexInner => numberWithIndexInner.Index >= leftAndRight.Left && numberWithIndexInner.Index <= leftAndRight.Right)
                    .Select(numberWithIndexToSelect => numberWithIndexToSelect.Number)
                    .OrderBy(number => number));

            var subarrayChecked = subarray
                .Select(numbers =>
                {
                    var sorted = numbers.OrderBy(number => number);

                    var exceptLast = sorted.Take(sorted.Count() - 1);
                    var exceptFirst = sorted.Skip(1);

                    var differencesOfPreviousNext = exceptLast
                        .Zip(exceptFirst, (previous, next) => new { previous, next })
                        .Select(pair => pair.previous - pair.next);

                    var differenceFirst = differencesOfPreviousNext.First();
                    return !differencesOfPreviousNext.Any(difference => difference != differenceFirst);
                })
                .ToList();

            return subarrayChecked;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var solution = new Solution();

            var nums1 = new int[] { 4, 6, 5, 9, 3, 7 };
            var l1 = new int[] { 0, 0, 2 };
            var r1 = new int[] { 2, 3, 5 };

            var result1 = solution.CheckArithmeticSubarrays(nums1, l1, r1);

            var nums2 = new int[] { -12, -9, -3, -12, -6, 15, 20, -25, -20, -15, -10 };
            var l2 = new int[] { 0, 1, 6, 4, 8, 7 };
            var r2 = new int[] { 4, 4, 9, 7, 9, 10 };

            var result2 = solution.CheckArithmeticSubarrays(nums2, l2, r2);
        }
    }
}
