Console.WriteLine(new Solution().ReversePrefix("abcd", 2));
Console.WriteLine(new Solution().ReversePrefix("xyz", 3));
Console.WriteLine(new Solution().ReversePrefix("hey", 1));


public class Solution
{
    public string ReversePrefix(string s, int k)
    {
        char[] arr = s.ToCharArray();
        Array.Reverse(arr, 0, k);
        return new string(arr);
    }
}