using System;
using System.Collections.Generic;
using Microsoft.VisualBasic;

namespace CountElements
{
    public static class Countelements
    {
        public static int CountElements(int[] nums, int k)
        {
            if (k == 0)
            {
                return nums.Length;
            }

            var sortedNums = new List<int>(nums).OrderByDescending(x => x);
            var numAtK = sortedNums.ElementAt(k);
            var numsAfterSkipDuplicates = sortedNums.Skip(k).SkipWhile(x => x == numAtK);
            return numsAfterSkipDuplicates.Count();
        }

        public static void Main()
        {
            var i = 0;

            foreach (var input in ReadInputsFromCsvFile(2))
            {
                var nums = input.ElementAt(0).ToArray();
                var k = input.ElementAt(1).First();
                var result = CountElements(nums, k);
                Console.WriteLine($"Input: {i++} => Result: {result}");
            }
        }

        public static IEnumerable<IEnumerable<IEnumerable<int>>> ReadInputsFromCsvFile(int numLinesPerInput = 1)
        {
            var lines = File.ReadAllLines("inputs.txt");
            var linesScannedForCurrentInput = 0;
            var currentInput = new List<IEnumerable<int>> { };

            foreach (var line in lines)
            {
                var parts = line.Split(';');
                var numbers = Array.ConvertAll(parts[0].Split(','), int.Parse);

                currentInput.Add(numbers);
                linesScannedForCurrentInput++;

                if (linesScannedForCurrentInput == numLinesPerInput)
                {
                    yield return currentInput;
                    linesScannedForCurrentInput = 0;
                    currentInput = [];
                }
            }
        }

    }
}