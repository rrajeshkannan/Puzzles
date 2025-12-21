// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");



public class Solution
{
    public int AbsDifference(int[] nums, int k)
    {
        Array.Sort(nums);

        int min = nums.Take(k).Sum();
        int max = nums.Skip(nums.Length - k).Sum();
        return max - min;
    }
}