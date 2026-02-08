// You are given an integer n.
// An integer is called Monobit if all bits in its binary representation are the same.
// Return the count of Monobit integers in the range [0, n] (inclusive).
// Example 1:
// Input: n = 1
// Output: 2
// Explanation:
// The integers in the range [0, 1] have binary representations "0" and "1".
// Each representation consists of identical bits. Thus, the answer is 2.
// Example 2:
// Input: n = 4
// Output: 3
// Explanation:
// The integers in the range [0, 4] include binaries "0", "1", "10", "11", and "100".
// Only 0, 1 and 3 satisfy the Monobit condition. Thus, the answer is 3.
// Constraints:
// 0 <= n <= 1000

Console.WriteLine(new Solution().CountMonobit(4)); // Output: 3
Console.WriteLine(new Solution().CountMonobit(1)); // Output: 2


public class Solution
{
    public int CountMonobit(int n)
    {
        int count = 0;

        for (int i = 0; i <= n; i++)
        {
            if (IsMonobit(i))
            {
                count++;
            }
        }

        return count;
    }

    private bool IsMonobit(int num)
    {
        if (num == 0) return true;

        int lastBit = num & 1;
        num >>= 1;

        while (num > 0)
        {
            if ((num & 1) != lastBit)
            {
                return false;
            }
            num >>= 1;
        }

        return true;
    }
}