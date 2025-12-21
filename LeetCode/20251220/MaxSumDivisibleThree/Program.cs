// var nums1 = new int[] { 2, 7, 6, 1, 4, 5 };
// Console.WriteLine(MaximumSum(nums1));

// var nums2 = new int[] { 1, 2, 3, 4, 5, 6 };
// Console.WriteLine(MaximumSum(nums2));

// var nums3 = new int[] { 3, 3, 3, 3, 3 };
// Console.WriteLine(MaximumSum(nums3));

// var nums4 = new int[] { 1, 1, 1, 1, 1 };
// Console.WriteLine(MaximumSum(nums4));

// var nums5 = new int[] { 4, 2, 3, 1 };
// Console.WriteLine(MaximumSum(nums5));

// var nums6 = new int[] { 2, 1, 5 };
// Console.WriteLine(MaximumSum(nums6));

// var nums7 = new int[] { 8, 7, 4, 3 };
// Console.WriteLine(MaximumSum(nums7));

var nums8 = new int[] { 6, 1, 8, 6, 6 };
Console.WriteLine(MaximumSum(nums8));

int MaximumSum(int[] nums)
{
    Array.Sort(nums, (a, b) => b.CompareTo(a));

    for (int i = 0; i < nums.Length - 2; i++)
    {
        for (int j = i + 1; j < nums.Length - 1; j++)
        {
            for (int k = j + 1; k < nums.Length; k++)
            {
                var currentSum = nums[i] + nums[j] + nums[k];

                if (currentSum % 3 == 0)
                {
                    return currentSum;
                }
            }
        }
    }

    return 0;
}