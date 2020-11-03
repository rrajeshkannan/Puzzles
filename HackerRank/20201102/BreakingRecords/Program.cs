using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Text;
using System;

class Solution
{

    // Complete the breakingRecords function below.
    static int[] breakingRecords(int[] scores)
    {
        int minChangeCount = 0;
        int maxChangeCount = 0;

        if (scores.Any())
        {
            int min = scores[0];
            int max = scores[0];

            for (int i = 1; i < scores.Length; i++)
            {
                if (scores[i] < min)
                {
                    min = scores[i];
                    minChangeCount++;
                }

                if (scores[i] > max)
                {
                    max = scores[i];
                    maxChangeCount++;
                }
            }
        }

        return new int[] { maxChangeCount, minChangeCount };
    }

    static void Main(string[] args)
    {
        //TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        //int n = Convert.ToInt32(Console.ReadLine());

        //int[] scores = Array.ConvertAll(Console.ReadLine().Split(' '), scoresTemp => Convert.ToInt32(scoresTemp));

        var scores1 = new int[] { 10, 5, 20, 20, 4, 5, 2, 25, 1 };
        var result1 = breakingRecords(scores1); // 2 4

        var scores2 = new int[] { 3, 4, 21, 36, 10, 28, 35, 5, 24, 42 };
        var result2 = breakingRecords(scores2); // 4 0

        //var scores3 = new int[] { };
        //var result3 = breakingRecords(scores3);

        //var scores4 = new int[] { };
        //var result4 = breakingRecords(scores4);

        //textWriter.WriteLine(string.Join(" ", result));

        //textWriter.Flush();
        //textWriter.Close();
    }
}
