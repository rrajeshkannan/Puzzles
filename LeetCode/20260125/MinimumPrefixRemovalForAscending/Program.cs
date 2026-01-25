Console.WriteLine(new Solution().MinimumPrefixLength([1, -1, 2, 3, 3, 4, 5]));
Console.WriteLine(new Solution().MinimumPrefixLength([4, 3, -2, -5]));
Console.WriteLine(new Solution().MinimumPrefixLength([1, 2, 3, 4, 5]));
Console.WriteLine(new Solution().MinimumPrefixLength([4]));


public class Solution
{
    // Return an integer denoting the minimum length of the removed prefix such that the remaining array is strictly increasing.
    public int MinimumPrefixLength(int[] nums)
    {
        int n = nums.Length;
        int right = n - 1;

        // Find the longest increasing suffix
        while (right > 0 && nums[right - 1] < nums[right])
        {
            right--;
        }

        return right;

        // If the entire array is strictly increasing
        // if (right == 0)
        // {
        //     return 0;
        // }

        // int minPrefixLength = right;

        // // Try to merge prefix and suffix
        // for (int left = 0; left < n; left++)
        // {
        //     if (left > 0 && nums[left] <= nums[left - 1])
        //     {
        //         break; // Prefix is no longer strictly increasing
        //     }

        //     // Move the right pointer to find a valid merge point
        //     while (right < n && nums[right] <= nums[left])
        //     {
        //         right++;
        //     }

        //     // Calculate the length of the removed prefix
        //     minPrefixLength = Math.Min(minPrefixLength, right - left - 1);
        // }

        // return minPrefixLength;
    }
}