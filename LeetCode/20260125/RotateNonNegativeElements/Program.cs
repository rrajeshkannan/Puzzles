// print int array
Console.WriteLine(string.Join(",", new Solution().RotateElements([1, -2, 3, -4], 3))); // Output: [3,-2,1,-4]
Console.WriteLine(string.Join(",", new Solution().RotateElements([-3, -2, 7], 1))); // Output: [-3,-2,7]
Console.WriteLine(string.Join(",", new Solution().RotateElements([-6, -2], 18866))); // Output: [-6,-2]

// Rotate the elements of an array to the right by k steps, where k is non-negative.
// You are given an integer array nums and an integer k.
// Rotate only the non-negative elements of the array to the left by k positions, in a cyclic manner.
// All negative elements must stay in their original positions and must not move.
// After rotation, place the non-negative elements back into the array in the new order, filling only the positions that originally contained non-negative values and skipping all negative positions.
// Return the resulting array.
// Example 1:
// Input: nums = [1,-2,3,-4], k = 3
// Output: [3,-2,1,-4]
// Example 2:
// Input: nums = [-3,-2,7], k = 1
// Output: [-3,-2,7]
// Example 3:
// Input: nums = [5,4,-9,6], k = 2
// Output: [6,5,-9,4]
public class Solution
{
    public int[] RotateElements(int[] nums, int k)
    {
        List<int> nonNegativeElements = [];
        for (int i = 0; i < nums.Length; i++)
        {
            if (nums[i] >= 0)
            {
                nonNegativeElements.Add(nums[i]);
            }
        }

        int n = nonNegativeElements.Count;

        if (n == 0)
        {
            return nums; // No non-negative elements to rotate
        }

        k = k % n; // In case k is greater than the number of non-negative elements

        // Rotate the non-negative elements to the left by k positions
        List<int> rotatedElements = [];
        for (int i = 0; i < n; i++)
        {
            rotatedElements.Add(nonNegativeElements[(i + k) % n]);
        }

        // Place the rotated elements back into the original array
        int index = 0;
        for (int i = 0; i < nums.Length; i++)
        {
            if (nums[i] >= 0)
            {
                nums[i] = rotatedElements[index++];
            }
        }

        return nums;
    }
}