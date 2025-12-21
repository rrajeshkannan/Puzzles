Console.WriteLine(new Solution().MinCost("aabaac", [1, 2, 3, 4, 1, 10])); // 11
Console.WriteLine(new Solution().MinCost("abc", [10, 5, 8])); // 13
Console.WriteLine(new Solution().MinCost("zzzzz", [67, 67, 67, 67, 67])); // 0
Console.WriteLine(new Solution().MinCost("aaaq", [620973973, 772442621, 842992318, 277245496])); // 277245496

public class Solution
{
    public long MinCost(string s, int[] costs)
    {
        //var duplicates = new List<(int start, int end)>();

        var duplicates = new Dictionary<char, long>();
        var totalCost = 0L;

        for (int i = 0; i < s.Length; i++)
        {
            var character = s[i];
            var cost = costs[i];

            if (!duplicates.TryGetValue(character, out var existingCost))
            {
                duplicates[character] = cost;
            }
            else
            {
                duplicates[character] = existingCost + cost;
            }

            totalCost += cost;
        }

        if (duplicates.Count == 1)
        {
            // All characters in s are equal, so the deletion cost is 0.
            return 0;
        }

        var minCost = long.MaxValue;

        foreach (var duplicate in duplicates)
        {
            minCost = Math.Min(minCost, totalCost - duplicate.Value);
        }

        return minCost;
    }
}