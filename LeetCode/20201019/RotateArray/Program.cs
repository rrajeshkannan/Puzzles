using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RotateArray
{
    // https://leetcode.com/explore/challenge/card/october-leetcoding-challenge/561/week-3-october-15th-october-21st/3496/

    public class Solution
    {
        public void Rotate(int[] nums, int k)
        {
            var currentLocation = 0;

            var numberOfElementsMoved = RotateUntil(nums, k, currentLocation, currentLocation, nums[currentLocation]);

            while (numberOfElementsMoved < nums.Length)
            {
                // when even number of elements in array, 
                //   the iteration quickly comes back to the starting location without finishing all locations
                // many additional iterations are required until finishing with all locations

                // start with next location, and keep doing until all elements are moved
                currentLocation++;

                numberOfElementsMoved += RotateUntil(nums, k, currentLocation, currentLocation, nums[currentLocation]);
            }
        }

        private int RotateUntil(int[] numbers, int numberOfRotations, int terminalLocation, int currentLocation, int cached)
        {
            int locationToSwap = (currentLocation + numberOfRotations) % numbers.Length;

            // swap the array item with backed up value
            int temporary = numbers[locationToSwap];

            numbers[locationToSwap] = cached;
            cached = temporary;

            // all rotations are over, so, terminate
            if (locationToSwap == terminalLocation) return 1;

            // continue with next iteration of rotation
            return 1 + RotateUntil(numbers, numberOfRotations, terminalLocation, locationToSwap, cached);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var solution = new Solution();

            //var numbers1 = new int[] { 1, 2, 3, 4, 5, 6, 7 };
            //var numberOfRotations1 = 3;

            //solution.Rotate(numbers1, numberOfRotations1); // [5,6,7,1,2,3,4]

            //var numbers2 = new int[] { -1, -100, 3, 99 };
            //var numberOfRotations2 = 2;

            //solution.Rotate(numbers2, numberOfRotations2); // [3,99,-1,-100]

            //var numbers3 = new int[] { 1, 2 };
            //var numberOfRotations3 = 1;

            //solution.Rotate(numbers3, numberOfRotations3); // [2,1]

            var numbers4 = new int[] { 1, 2, 3, 4, 5, 6 };
            var numberOfRotations4 = 3;

            solution.Rotate(numbers4, numberOfRotations4); // [4,5,6,1,2,3]
        }
    }
}
