using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinimumOperations
{
    // https://leetcode.com/contest/weekly-contest-215/problems/minimum-operations-to-reduce-x-to-zero/

    // You are given an integer array nums and an integer x. 
    // In one operation, you can either remove the leftmost or the rightmost element from the array nums and subtract its value from x. 
    // Note that this modifies the array for future operations.
    // 
    // Return the minimum number of operations to reduce x to exactly 0 if it's possible, otherwise, return -1.

    // Input: nums = [1,1,4,2,3], x = 5
    // Output: 2
    // Explanation: The optimal solution is to remove the last two elements to reduce x to zero.

    // Input: nums = [5,6,7,8,9], x = 4
    // Output: -1

    // Input: nums = [3,2,20,1,1,3], x = 10
    // Output: 5
    // Explanation: The optimal solution is to remove the last three elements and the first two elements(5 operations in total) to reduce x to zero.

    // Constraints:
    // 1 <= nums.length <= 10 power 5
    // 1 <= nums[i] <= 10 power 4
    // 1 <= x <= 10 power 9

    public class Solution
    {
        public int MinOperationsUsingMin(int[] nums, int x)
        {
            var front = 0;
            var rear = nums.Length - 1;
            var operations = 0;

            while ((front <= rear) && (x != 0))
            {
                var valueFront = nums[front];

                if (valueFront <= x)
                {
                    var valueRear = nums[rear];

                    if (valueRear <= x)
                    {
                        if (valueFront < valueRear)
                        {
                            operations++;
                            front++;

                            //Console.Write("{0},", valueFront);
                            x -= valueFront;
                        }
                        else
                        {
                            operations++;
                            rear--;

                            //Console.Write("{0},", valueRear);
                            x -= valueRear;
                        }
                    }
                    else
                    {
                        operations++;
                        front++;

                        //Console.Write("{0},", valueFront);
                        x -= valueFront;
                    }
                }
                else
                {
                    var valueRear = nums[rear];

                    if (valueRear <= x)
                    {
                        operations++;
                        rear--;

                        //Console.Write("{0},", valueRear);
                        x -= valueRear;
                    }
                    else
                    {
                        // both valueFront and valueRear are not less than x
                        // so, can't find solution
                        //Console.WriteLine("\n Operations: -1");
                        return -1;
                    }
                }
            }

            //Console.WriteLine("\nOperations: {0}", (x == 0) ? operations : -1);
            return (x == 0) ? operations : -1;
        }

        public int MinOperations(int[] nums, int x)
        {
            var front = 0;
            var rear = nums.Length - 1;
            var operations = 0;
            var xBackup = x;

            while ((front <= rear) && (x != 0))
            {
                var valueFront = nums[front];

                if (valueFront <= x)
                {
                    var valueRear = nums[rear];

                    if (valueRear <= x)
                    {
                        if (valueFront > valueRear)
                        {
                            operations++;
                            front++;

                            //Console.Write("{0},", valueFront);
                            x -= valueFront;
                        }
                        else
                        {
                            operations++;
                            rear--;

                            //Console.Write("{0},", valueRear);
                            x -= valueRear;
                        }
                    }
                    else
                    {
                        operations++;
                        front++;

                        //Console.Write("{0},", valueFront);
                        x -= valueFront;
                    }
                }
                else
                {
                    var valueRear = nums[rear];

                    if (valueRear <= x)
                    {
                        operations++;
                        rear--;

                        //Console.Write("{0},", valueRear);
                        x -= valueRear;
                    }
                    else
                    {
                        // both valueFront and valueRear are not less than x
                        // so, can't find solution
                        //Console.WriteLine("\n Operations: -1");
                        return MinOperationsUsingMin(nums, xBackup);
                    }
                }
            }

            //Console.WriteLine("\nOperations: {0}", (x == 0) ? operations : -1);
            return (x == 0) ? operations : -1;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var solution = new Solution();

            var nums7 = new int[] { 10, 5, 2, 9 };
            var result7 = solution.MinOperations(nums7, 11); // 2

            var nums1 = new int[] { 1, 1, 4, 2, 3 };
            var result1 = solution.MinOperations(nums1, 5); // 2

            var nums2 = new int[] { 5, 6, 7, 8, 9 };
            var result2 = solution.MinOperations(nums2, 4); // -1

            var nums3 = new int[] { 3, 2, 20, 1, 1, 3 };
            var result3 = solution.MinOperations(nums3, 10); // 5

            var nums4 = new int[] { 1, 1 };
            var result4 = solution.MinOperations(nums4, 3); // -1

            var nums5 = new int[] { 8828, 9581, 49, 9818, 9974, 9869, 9991, 10000, 10000, 10000, 9999, 9993, 9904, 8819, 1231, 6309 };
            var result5 = solution.MinOperations(nums5, 134365); // 16

            var nums6 = new int[] {
                5207, 5594, 477, 6938, 8010, 7606, 2356, 6349, 3970, 751, 5997, 6114, 9903, 3859, 6900, 7722, // 16
                2378, 1996, 8902, 228, 4461, 90, 7321, 7893, 4879, 9987, 1146, 8177, 1073, 7254, 5088, 402, // 32 
                4266, 6443, 3084, 1403, 5357, 2565, 3470, 3639, 9468, 8932, 3119, 5839, 8008, 2712, 2735, 825, // 48
                4236, 3703, 2711, 530, 9630, 1521, 2174, 5027, 4833, 3483, 445, 8300, 3194, 8784, 279, 3097, // 64
                1491, 9864, 4992, 6164, 2043, 5364, 9192, 9649, 9944, 7230, 7224, 585, 3722, 5628, 4833, 8379, // 80
                3967, 5649, 2554, 5828, 4331, 3547, 7847, 5433, 3394, 4968, 9983, 3540, 9224, 6216, 9665, 8070, // 96
                31, 3555, 4198, 2626, 9553, 9724, 4503, 1951, 9980, 3975, 6025, 8928, 2952, 911, 3674, 6620, 
                3745, 6548, 4985, 5206, 5777, 1908, 6029, 2322, 2626, 2188, 5639 }; // 123 elements
            var result6 = solution.MinOperations(nums6, 565610); // 113

            Console.ReadKey();
        }
    }
}
