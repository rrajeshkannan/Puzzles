using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortArrayIncreasingFrequency
{
    //https://leetcode.com/contest/biweekly-contest-38/problems/sort-array-by-increasing-frequency/

    public class NumberOccurrence
    {
        public int Number { get; set; }
        public int Frequency { get; set; }
    }

    public class NumberOccurrenceComparer : IComparer<NumberOccurrence>
    {
        public int Compare(NumberOccurrence x, NumberOccurrence y)
        {
            if (x.Frequency < y.Frequency)
            {
                return -1;
            }

            if (x.Frequency > y.Frequency)
            {
                return 1;
            }

            if (x.Number < y.Number)
            {
                return 1;
            }

            if (x.Number > y.Number)
            {
                return -1;
            }

            return 0;
        }
    }


    public class Solution
    {
        public int[] FrequencySort(int[] nums)
        {
            return nums.GroupBy(
                number => number,
                number => number,
                (number, groupedNumbers) => new NumberOccurrence
                {
                    Number = number,
                    Frequency = groupedNumbers.Count()
                })
                .OrderBy(numberOccurrence => numberOccurrence, new NumberOccurrenceComparer())
                .SelectMany(numberOccurrence => Enumerable.Repeat(numberOccurrence.Number, numberOccurrence.Frequency))
                .ToArray();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var solution = new Solution();

            var numbers1 = new int[] { 1, 1, 2, 2, 2, 3 };
            var result1 = solution.FrequencySort(numbers1);

            var numbers2 = new int[] { 2, 3, 1, 3, 2 };
            var result2 = solution.FrequencySort(numbers2);

            var numbers3 = new int[] { -1, 1, -6, 4, 5, -6, 1, 4, 1 };
            var result3 = solution.FrequencySort(numbers3);
        }
    }
}
