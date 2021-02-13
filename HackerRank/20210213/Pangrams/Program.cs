using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pangrams
{
    // https://www.hackerrank.com/challenges/pangrams/problem

    class Program
    {
        // Complete the pangrams function below.
        static string pangrams(string s)
        {
            var lowerA = 'a';
            var lowerZ = 'z';
            var upperA = 'A';
            var upperZ = 'Z';

            var count = new int[26];

            for (int i = 0; i < s.Length; i++)
            {
                if ((s[i] >= lowerA) && (s[i] <= lowerZ))
                {
                    var ascii = s[i] - lowerA;
                    count[ascii]++;
                }
                else if ((s[i] >= upperA) && (s[i] <= upperZ))
                {
                    var ascii = s[i] - upperA;
                    count[ascii]++;
                }
            }

            for (int i = 0; i < 26; i++)
            {
                if (count[i] == 0)
                {
                    return "not pangram";
                }
            }

            return "pangram";
        }

        static void Main(string[] args)
        {
            var output1 = pangrams("The quick brown fox jumps over the lazy dog"); // pangram
            var output2 = pangrams("We promptly judged antique ivory buckles for the next prize"); // pangram
            var output3 = pangrams("We promptly judged antique ivory buckles for the prize"); // not pangram
        }
    }
}
