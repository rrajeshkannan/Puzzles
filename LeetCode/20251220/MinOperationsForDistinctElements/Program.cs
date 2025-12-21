var nums = new int[] { 3, 8, 3, 6, 5, 8 };
Console.WriteLine(MinOperations(nums));

var nums2 = new int[] { 1, 2, 3, 4, 5, 6 };
Console.WriteLine(MinOperations(nums2));

var nums3 = new int[] { 2, 2 };
Console.WriteLine(MinOperations(nums3));

var nums4 = new int[] { 4, 3, 5, 1, 2 };
Console.WriteLine(MinOperations(nums4));

var nums5 = new int[] { 90 };
Console.WriteLine(MinOperations(nums5));

var nums6 = new int[] { 35, 92, 99, 99 };
Console.WriteLine(MinOperations(nums6));

int MinOperations(int[] nums)
{
    var operations = 0;
    int i = 0;

    for (; i < nums.Length - 2; i += 3)
    {
        if ((nums[i] == nums[i + 1]) || (nums[i + 1] == nums[i + 2]) || (nums[i] == nums[i + 2]))
        {
            operations++;
        }
    }

    if (i == nums.Length - 2)
    {
        if (nums[i] == nums[i + 1])
            operations++;
    }

    return operations;
}