using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoveChipsUsingParity
{
    // We have n chips, where the position of the ith chip is position[i].
    //
    // We need to move all the chips to the same position.In one step, we can change the position of the ith chip from position[i] to:
    //   position[i] + 2 or position[i] - 2 with cost = 0.
    //   position[i] + 1 or position[i] - 1 with cost = 1.
    //
    // Return the minimum cost needed to move all the chips to the same position.
    // Hint-1: The first move keeps the parity of the element as it is.
    // Hint-2: The second move changes the parity of the element.
    // Hint-3: Since the first move is free, if all the numbers have the same parity, the answer would be zero.
    // Hint-4: Find the minimum cost to make all the numbers have the same parity.

    public class Solution
    {
        public int MinCostToMoveChips(int[] position)
        {
            int odds = 0;
            int evens = 0;

            for (int i = 0; i < position.Length; i++)
            {
                if (position[i] % 2 == 1)
                {
                    odds++;
                }
                else
                {
                    evens++;
                }
            }

            return Math.Min(odds, evens);

            //var positions = position.Length;
            //int oddPositions = 0;

            //for (int i = 0; i < positions; i++)
            //{
            //    if (position[i] % 2 == 1)
            //    {
            //        oddPositions++;
            //    }
            //}

            //// evenPositions = positions - oddPositions;
            //return Math.Min(oddPositions, positions - oddPositions);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var solution = new Solution();

            var positions1 = new int[] { 1, 2, 3 };
            var result1 = solution.MinCostToMoveChips(positions1); // 1

            var positions2 = new int[] { 2, 2, 2, 3, 3 };
            var result2 = solution.MinCostToMoveChips(positions2); // 2

            var positions3 = new int[] { 1, 1000000000 };
            var result3 = solution.MinCostToMoveChips(positions3); // 1

            var positions4 = new int[] { 2, 2, 2, 2, 2, 3, 3, 4, 4, 4, 5, 5, 5, 5, 5, 5, 5, 5, 5, 6, 6, 6 };
            var result4 = solution.MinCostToMoveChips(positions4); // 11
        }
    }
}
