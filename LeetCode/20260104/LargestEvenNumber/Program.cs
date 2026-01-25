Console.WriteLine(new Solution().LargestEven("1234")); // Output: "4231"
Console.WriteLine(new Solution().LargestEven("1112"));
Console.WriteLine(new Solution().LargestEven("1357"));
Console.WriteLine(new Solution().LargestEven("221"));
Console.WriteLine(new Solution().LargestEven("1"));


public class Solution
{
    public string LargestEven(string s)
    {
        for (int i = s.Length - 1; i >= 0; i--)
        {
            if ((s[i] - '0') % 2 == 0)
            {
                return s[..(i + 1)];
            }
        }

        return string.Empty;
    }
}