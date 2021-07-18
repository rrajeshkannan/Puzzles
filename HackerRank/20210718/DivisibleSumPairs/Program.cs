using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Text;
using System;

class Result
{

    /*
     * Complete the 'divisibleSumPairs' function below.
     *
     * The function is expected to return an INTEGER.
     * The function accepts following parameters:
     *  1. INTEGER n
     *  2. INTEGER k
     *  3. INTEGER_ARRAY ar
     */

    public static int divisibleSumPairs(int n, int k, List<int> ar)
    {
        int match = 0;

        for (int i = 0; i < n - 1; i++)
        {
            for (int j = i + 1; j < n; j++)
            {
                if ((ar[i] + ar[j]) % k == 0)
                {
                    Debug.WriteLine($"{ar[i]}+{ar[j]}");
                    match++;
                }
            }
        }

        return match;
    }

}

class Solution
{
    public static void Main(string[] args)
    {
        int n = 6;
        int k = 5;
        List<int> ar = new List<int>{1, 2, 3, 4, 5, 6};

        var result1 = Result.divisibleSumPairs(n, k, ar);

        k = 3;
        ar = new List<int>{1, 3, 2, 6, 1, 2};
        var result2 = Result.divisibleSumPairs(n, k, ar);


        // TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        // string[] firstMultipleInput = Console.ReadLine().TrimEnd().Split(' ');

        // int n = Convert.ToInt32(firstMultipleInput[0]);

        // int k = Convert.ToInt32(firstMultipleInput[1]);

        // List<int> ar = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(arTemp => Convert.ToInt32(arTemp)).ToList();

        // int result = Result.divisibleSumPairs(n, k, ar);

        // textWriter.WriteLine(result);

        // textWriter.Flush();
        // textWriter.Close();
    }
}
