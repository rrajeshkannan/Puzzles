var solution = new Solution();

Console.WriteLine(solution.MaximumScore([10, -1, 3, -4, -5]));
Console.WriteLine(solution.MaximumScore([-7, -5, 3]));
Console.WriteLine(solution.MaximumScore([1, 1]));

public class Solution
{
    public long MaximumScore(int[] nums)
    {
        long cumulativeSum = 0;
        var prefixSums = new long[nums.Length];
        for (int i = 0; i < nums.Length; i++)
        {
            cumulativeSum += nums[i];
            prefixSums[i] = cumulativeSum;
        }

        var suffixMins = new long[nums.Length];
        long currentMin = nums[nums.Length - 1];
        for (int i = nums.Length - 2; i >= 0; i--)
        {
            suffixMins[i] = currentMin;
            currentMin = Math.Min(currentMin, nums[i]);
        }

        long score = long.MinValue;
        for (int i = 0; i < nums.Length - 1; i++)
        {
            score = Math.Max(score, prefixSums[i] - suffixMins[i]);
        }

        return score;
    }
}