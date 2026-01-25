Console.WriteLine(new Solution().MinLength([1, 2, 3, 4, 5], 5));
Console.WriteLine(new Solution().MinLength([3, 2, 3, 4], 5));
Console.WriteLine(new Solution().MinLength([5, 5, 4], 5));
Console.WriteLine(new Solution().MinLength([1, 12], 7));
Console.WriteLine(new Solution().MinLength([5, 4, 12], 9));
Console.WriteLine(new Solution().MinLength([57, 75, 43, 52, 80, 27, 18, 33, 16, 75, 77, 71, 10, 34], 152));
Console.WriteLine(new Solution().MinLength([63, 47, 9, 23, 47, 29, 47, 23, 36, 47, 9], 121));

/// <summary>
/// Return the minimum length of a subarray whose sum of the distinct values present in that subarray (each value counted once) is at least k. If no such subarray exists, return -1.
/// </summary>
public class Solution
{
    public int MinLength(int[] nums, int k)
    {
        int n = nums.Length;
        int minLength = int.MaxValue;

        int currentGroupSum = 0;
        var currentGroupStart = 0;

        var distinctValues = new HashSet<int>();
        var duplicateValues = new Dictionary<int, int>();

        for (int i = 0; i < n; i++)
        {
            if (distinctValues.Add(nums[i]))
            {
                currentGroupSum += nums[i];
            }
            else
            {
                duplicateValues.Add(nums[i], i);
            }

            if (currentGroupSum >= k)
            {
                minLength = Math.Min(minLength, i - currentGroupStart + 1);

                for (int j = currentGroupStart; j <= i; j++)
                {
                    currentGroupSum -= nums[j];
                    currentGroupStart++;

                    if (currentGroupSum >= k)
                    {
                        minLength = Math.Min(minLength, i - currentGroupStart + 1);
                    }
                    else
                    {
                        break;
                    }
                }
            }
            else if (minLength == i - currentGroupStart + 1)
            {
                currentGroupSum -= nums[currentGroupStart];
                currentGroupStart++;
            }
        }

        return minLength == int.MaxValue ? -1 : minLength;

        // int n = nums.Length;
        // int minLength = int.MaxValue;

        // for (int start = 0; start < n; start++)
        // {
        //     HashSet<int> distinctValues = new HashSet<int>();
        //     int currentSum = 0;

        //     for (int end = start; end < n; end++)
        //     {
        //         if (distinctValues.Add(nums[end]))
        //         {
        //             currentSum += nums[end];
        //         }

        //         if (currentSum >= k)
        //         {
        //             minLength = Math.Min(minLength, end - start + 1);
        //             break; // No need to explore with this subarray further
        //         }
        //         else if (minLength == end - start + 1)
        //         {
        //             break; // No need to explore with this subarray further
        //         }
        //     }
        // }

        // return minLength == int.MaxValue ? -1 : minLength;
    }
}