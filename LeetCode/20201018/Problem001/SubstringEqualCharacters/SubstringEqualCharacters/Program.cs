using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubstringEqualCharacters
{
    public class Solution
    {
        public int MaxLengthBetweenEqualCharacters(string s)
        {
            var maxLength = -1;

            for (int i = 0; i < s.Length; i++)
            {
                for (int j = s.Length - 1; j > i; j--)
                {
                    if (s[i] == s[j])
                    {
                        int currentLength = j - i - 1;
                        maxLength = Math.Max(maxLength, currentLength);

                        break;
                    }
                }
            }

            return maxLength;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var s = "cabbac";
            var solution = new Solution();

            Console.WriteLine("{0}", solution.MaxLengthBetweenEqualCharacters(s));
            Console.ReadKey();
        }
    }
}
