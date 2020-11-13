using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniquePermutations
{
    // solution: copied from:
    // https://softwareengineering.stackexchange.com/a/391224

    // https://leetcode.com/explore/challenge/card/november-leetcoding-challenge/565/week-2-november-8th-november-14th/3528/

    // Given a collection of numbers, nums, that might contain duplicates, return all possible unique permutations in any order.
    // Example 1:
    //   Input: nums = [1,1,2]
    //   Output: [[1,1,2], [1,2,1], [2,1,1]]
    // Example 2:
    //   Input: nums = [1,2,3]
    //   Output: [[1,2,3],[1,3,2],[2,1,3],[2,3,1],[3,1,2],[3,2,1]]


    public static class PermutationExtensions
    {
        // Permutes the list into next permutation
        //   where the set of all permutations is ordered lexicographically with respect to "compareLessThan" function.
        // This method is inspired from: https://en.cppreference.com/w/cpp/algorithm/next_permutation
        private static bool NextPermutation<T>(List<T> list, Func<T, T, bool> compareLessThan)
        {
            if (list.Count() < 2)
            {
                // when "list" has only 2 elements, no more permutations possible
                return false;
            }

            var current = list.Count() - 1;

            while (true)
            {
                int lexicographicallyPrevious = current - 1;

                if (compareLessThan(list[lexicographicallyPrevious], list[current]))
                {
                    int running = list.Count() - 1;

                    while (!(compareLessThan(list[lexicographicallyPrevious], list[running])))
                    {
                        running--;
                    }

                    (list[lexicographicallyPrevious], list[running]) = (list[running], list[lexicographicallyPrevious]);

                    int elementsToReverse = list.Count() - current;
                    list.Reverse(current, elementsToReverse);
                    return true;
                }

                if (lexicographicallyPrevious == 0)
                {
                    // last permutation
                    list.Reverse();
                    return false;
                }

                current = lexicographicallyPrevious;
            }
        }

        public static IEnumerable<IList<T>> Permutations<T>(this IEnumerable<T> items, Func<T, T, bool> compareLessThan)
        {
            var list = items.ToList();
            list.Sort();

            // Clone "list" using ToList, since, it gets modified further
            yield return list.ToList();

            while (NextPermutation(list, compareLessThan))
            {
                yield return list.ToList();
            }
        }
    }

    public class Solution
    {
        public IList<IList<int>> PermuteUnique(int[] nums)
        {
            return nums.Permutations((int item1, int item2) => item1 < item2)
                .ToList();
        }
    }

    class Program
    {
        static void Main()
        {
            var solution = new Solution();

            var nums1 = new int[] { 1, 2, 3 };
            var result1 = solution.PermuteUnique(nums1);
            Print(result1);

            var nums2 = new int[] { 1, 1, 2 };
            var result2 = solution.PermuteUnique(nums2);
            Print(result2);

            var nums3 = new int[] { 1, 1, 1 };
            var result3 = solution.PermuteUnique(nums3);
            Print(result3);

            var nums4 = new int[] { 1, 1, 2, 2 };
            var result4 = solution.PermuteUnique(nums4);
            Print(result4);

            var nums5 = new int[] { 1, 1, 1, 2, 2 };
            var result5 = solution.PermuteUnique(nums5);
            Print(result5);

            var nums6 = new int[] { 1 };
            var result6 = solution.PermuteUnique(nums6);
            Print(result6);

            var nums7 = new int[] { 1, 1 };
            var result7 = solution.PermuteUnique(nums7);
            Print(result7);

            Console.ReadKey();
        }

        static void Print(IList<IList<int>> permutations)
        {
            Console.Write("[");

            for (int i = 0; i < permutations.Count; i++)
            {
                Console.Write("\t[");

                var permutation = permutations[i];

                for (int j = 0; j < permutation.Count; j++)
                {
                    Console.Write("{0}, ", permutation[j]);
                }

                Console.Write("]");
                Console.WriteLine();
            }

            Console.WriteLine("]");
        }
    }
}


//private static bool NextPermutation<T>(List<T> list, Func<T, T, bool> compareLessThan)
//{
//    if (list.Count() < 2)
//    {
//        // when "list" has only 2 elements, no more permutations possible
//        return false;
//    }

//    int i = list.Count() - 1;

//    while (true)
//    {
//        int i1 = i;

//        i--;

//        if (compareLessThan(list[i], list[i1]))
//        {
//            int i2 = list.Count() - 1;

//            while (!(compareLessThan(list[i], list[i2])))
//            {
//                i2--;
//            }

//            (list[i], list[i2]) = (list[i2], list[i]);

//            list.Reverse(i1, list.Count() - i1);
//            return true;
//        }

//        if (i == 0)
//        {
//            list.Reverse();
//            return false;
//        }
//    }
//}