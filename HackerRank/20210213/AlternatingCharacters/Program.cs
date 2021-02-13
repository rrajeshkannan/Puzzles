using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlternatingCharacters
{
    class Program
    {
        // Complete the alternatingCharacters function below.
        static int alternatingCharacters(string s)
        {
            var deletions = 0;

            if (s.Length <= 0)
            {
                return deletions;
            }

            var lastCharacter = s[0];

            for (int i = 1; i < s.Length; i++)
            {
                if (s[i] == lastCharacter)
                {
                    deletions++;
                }

                lastCharacter = s[i];
            }

            return deletions;
        }

        static void Main(string[] args)
        {
            var output1 = alternatingCharacters("AABAAB"); // 2
            var output2 = alternatingCharacters("AAAA"); // 3
            var output3 = alternatingCharacters("BBBBB"); // 4
            var output4 = alternatingCharacters("ABABABAB"); // 0
            var output5 = alternatingCharacters("BABABA"); // 0
            var output6 = alternatingCharacters("AAABBB"); // 4  
        }
    }
}
