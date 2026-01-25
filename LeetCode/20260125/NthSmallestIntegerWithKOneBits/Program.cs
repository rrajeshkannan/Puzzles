Console.WriteLine(new Solution().NthSmallest(4, 2)); // Output: 9
Console.WriteLine(new Solution().NthSmallest(3, 1)); // Output: 4
Console.WriteLine(new Solution().NthSmallest(1, 2)); // Output: 3
Console.WriteLine(new Solution().NthSmallest(2, 2)); // Output: 5
Console.WriteLine(new Solution().NthSmallest(2, 21)); // Output: 3145727

// You are given two positive integers n and k.
// Return an integer denoting the n'th smallest positive integer that has exactly k ones in its binary representation. It is guaranteed that the answer is strictly less than 2^50.
// Example 1:
// Input: n = 4, k = 2
// Output: 9
// Explanation:
// The 4 smallest positive integers that have exactly k = 2 ones in their binary representations are:
// 3 = 11 base 2
// 5 = 101 base 2
// 6 = 110 base 2
// 9 = 1001 base 2
// Thus, the 4'th smallest integer is 9.
//
// Example 2:
// Input: n = 3, k = 1
// Output: 4
// Explanation:
// The 3 smallest positive integers that have exactly k = 1 one in their binary representations are:
// 1 = 1 base 2
// 2 = 10 base 2
// 4 = 100 base 2
// Thus, the 3'th smallest integer is 4.
//
// Example 3:
// Input: n = 1, k = 2
// Output: 3
// Explanation:
// The 1 smallest positive integer that has exactly k = 2 ones in its binary representations is:
// 3 = 11 base 2
// Thus, the 1'th smallest integer is 3.
//
// Constraints:
// 1 <= n <= 2^50
// 1 <= k <= 50
// The answer is strictly less than 2^50.
//
// Example 4:
// Input: n = 2, k = 21
// Output: 3145727
// Explanation:
// The 2 smallest positive integers that have exactly k = 21 ones in their binary representations are:
// 2097151 = 111111111111111111111 base 2
// 3145727 = 1000000000000000000001 base 2
// Thus, the 2'th smallest integer is 3145727.

public class Solution
{
    private static long[][] binom;

    // Precompute binomial coefficients
    static Solution()
    {
        // k <= 50
        binom = new long[51][];
        for (int i = 0; i <= 50; i++)
        {
            binom[i] = new long[i + 1];
            binom[i][0] = 1;
            if (i > 0) binom[i][i] = 1;
            for (int j = 1; j < i; j++)
            {
                binom[i][j] = binom[i - 1][j - 1] + binom[i - 1][j];
            }
        }
    }

    public long NthSmallest(long n, int k)
    {
        long result = 0;
        while (k > 0)
        {
            int maxE = 0;
            long cum = 0;
            while (true)
            {
                long add = Combination(maxE, k - 1);
                if (cum + add >= n) break;
                cum += add;
                maxE++;
            }
            long remainingN = n - cum;
            result |= (1L << maxE);
            n = remainingN;
            k--;
        }
        return result;
    }

    private long Combination(int position, int k)
    {
        if (k > position || k < 0) return 0;
        return binom[position][k];
    }
}