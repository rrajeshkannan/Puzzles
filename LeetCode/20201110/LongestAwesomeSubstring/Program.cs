using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LongestAwesomeSubstring
{
    // https://leetcode.com/problems/find-longest-awesome-substring/

    // Given a string s. An awesome substring is a non-empty substring of s such that we can make any number of swaps in order to make it palindrome.
    // Return the length of the maximum length awesome substring of s.

    public class Solution
    {
        public int LongestAwesome(string s)
        {
            if (String.IsNullOrEmpty(s))
            {
                return 0;
            }

            var length = s.Length;
            var maxAwesomeLength = 1; // at least a single character can be considered as a palindrome

            var letters = s
                .Select(letter => letter)
                .ToArray();

            for (int i = 0; i < length - 1; i++)
            {
                for (int j = length - 1; j > i; j--)
                {
                    if (letters[i] != letters[j])
                    {
                        continue;
                    }

                    var substringLength = j - i + 1;
                    var substring = letters.Skip(i).Take(substringLength);
                    var letterGroupCounts = substring
                        .GroupBy(letter => letter)
                        .Select(letterGroup => letterGroup.Count());

                    var pairedLetters = letterGroupCounts.Count(count => count % 2 == 0);
                    var nonPairedLetters = letterGroupCounts.Count(count => count % 2 == 1);

                    if ((pairedLetters > 0) && (nonPairedLetters < 2))
                    {
                        // Case-1: all letters have pairs 
                        // Palindrome can be formed with these letters

                        // OR 

                        // Case-2: only one letter does not have pair
                        // This letter can be placed as center character to form Palindrome with the remaining letters around it

                        maxAwesomeLength = Math.Max(maxAwesomeLength, substringLength);
                    }
                }
            }

            return maxAwesomeLength;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var solution = new Solution();

            var s1 = "3242415";
            var result1 = solution.LongestAwesome(s1); // 5

            var s2 = "12345678";
            var result2 = solution.LongestAwesome(s2); // 1

            var s3 = "213123";
            var result3 = solution.LongestAwesome(s3); // 6

            var s4 = "00";
            var result4 = solution.LongestAwesome(s4); // 2

            var s5 = "0";
            var result5 = solution.LongestAwesome(s5); // 1

            var s6 = "3240724175";
            var result6 = solution.LongestAwesome(s6); // 1

            var s7 = "9811524080783575748129170748140446953606489875710251432327706034589955956823449575498554676678597110717362476298900064412130551163013411853693630342368689371359525581171766994337344853860338329191571460632276885929355828331867651701762746454783176749784019932044334492571957475933305726258980593936154779173456606729622946442000441179855403273385111857508400442920433454953362332107876812672235989950495501574472057756203228619852257524350034904989599040660467698553894";
            var result7 = solution.LongestAwesome(s7);
        }
    }
}
