Console.WriteLine(new Solution().MirrorDistance(1234));
Console.WriteLine(new Solution().MirrorDistance(25));
Console.WriteLine(new Solution().MirrorDistance(10));
Console.WriteLine(new Solution().MirrorDistance(7));

public class Solution
{
    public int MirrorDistance(int n)
    {
        return Math.Abs(n - Reverse(n));
    }

    private static int Reverse(int n)
    {
        int reversed = 0;

        while (n > 0)
        {
            int digit = n % 10;
            reversed = reversed * 10 + digit;
            n /= 10;
        }

        return reversed;
    }
}