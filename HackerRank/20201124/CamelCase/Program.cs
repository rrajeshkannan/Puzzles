using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CamelCase
{
    // https://www.hackerrank.com/challenges/camelcase/problem

    // Alice wrote a sequence of words in CamelCase as a string of letters, , having the following properties:
    //   It is a concatenation of one or more words consisting of English letters.
    //   All letters in the first word are lowercase.
    //   For each of the subsequent words, the first letter is uppercase and rest of the letters are lowercase.
    //
    // Given 's', print the number of words in on a new line.
    //   For example, "s=oneTwoThree". There are 3 words in the string.
    //
    // Function Description
    //   Complete the camelcase function in the editor below.It must return the integer number of words in the input string.
    //   camelcase has the following parameter(s) :
    //     s: the string to analyze
    // Input Format
    //   A single line containing string s.
    // Constraints
    //   1 <= |s| <= 10^5
    // Output Format
    //   Print the number of words in string s.
    //
    // Sample Input
    //   saveChangesInTheEditor
    // Sample Output
    //   5
    // Explanation
    //   String s contains five words:
    //     save, Changes, In, The, Editor
    //   Thus, we print 5 on a new line.

    class Solution
    {

        // Complete the camelcase function below.
        static int camelcase(string s)
        {
            if (String.IsNullOrEmpty(s))
            {
                return 0;
            }

            var alphabets = new HashSet<char>(Enumerable.Range('A', 'Z' - 'A' + 1)
                .Select(letter => (char)letter));

            return s.Count(letter => alphabets.Contains(letter)) + 1;
        }

        static void Main(string[] args)
        {
            var result1 = camelcase("saveChangesInTheEditor"); // 5
            var result2 = camelcase("save"); // 1
            var result3 = camelcase("s"); // 1
            var result4 = camelcase("saveChangesInI"); // 4

            //TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

            //string s = Console.ReadLine();

            //int result = camelcase(s);

            //textWriter.WriteLine(result);

            //textWriter.Flush();
            //textWriter.Close();
        }
    }
}
