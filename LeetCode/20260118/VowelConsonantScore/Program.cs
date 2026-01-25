Console.WriteLine(new Solution().VowelConsonantScore("aeiouxyz"));
Console.WriteLine(new Solution().VowelConsonantScore("cooear"));
Console.WriteLine(new Solution().VowelConsonantScore("axeyizou"));
Console.WriteLine(new Solution().VowelConsonantScore("au 123"));

public class Solution
{
    public int VowelConsonantScore(string s)
    {
        int vowelScore = 0;
        int consonantScore = 0;

        HashSet<char> vowels = ['a', 'e', 'i', 'o', 'u'];
        foreach (char c in s)
        {
            if (vowels.Contains(c))
            {
                vowelScore++;
            }
            else if (char.IsLetter(c))
            {
                consonantScore++;
            }
        }

        return (consonantScore == 0) ? 0 : (int)Math.Floor((double)vowelScore / consonantScore);
    }
}