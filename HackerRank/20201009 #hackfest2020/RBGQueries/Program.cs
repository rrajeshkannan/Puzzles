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

class Result
{

    /*
     * Complete the 'mixColors' function below.
     *
     * The function is expected to return a STRING_ARRAY.
     * The function accepts following parameters:
     *  1. 2D_INTEGER_ARRAY colors
     *  2. 2D_INTEGER_ARRAY queries
     */

    public static List<string> mixColors(List<List<int>> colors, List<List<int>> queries)
    {
        return new List<string>();
    }

    private static void PermutationsAndCombinations()
    {

    }

}

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(Console.OpenStandardOutput());

        string[] firstMultipleInput = Console.ReadLine().TrimEnd().Split(' ');

        int n = Convert.ToInt32(firstMultipleInput[0]);

        int q = Convert.ToInt32(firstMultipleInput[1]);

        List<List<int>> colors = new List<List<int>>();

        for (int i = 0; i < n; i++)
        {
            colors.Add(Console.ReadLine().TrimEnd().Split(' ').ToList().Select(colorsTemp => Convert.ToInt32(colorsTemp)).ToList());
        }

        List<List<int>> queries = new List<List<int>>();

        for (int i = 0; i < q; i++)
        {
            queries.Add(Console.ReadLine().TrimEnd().Split(' ').ToList().Select(queriesTemp => Convert.ToInt32(queriesTemp)).ToList());
        }

        List<string> result = Result.mixColors(colors, queries);

        textWriter.WriteLine(String.Join("\n", result));

        textWriter.Flush();
        textWriter.Close();
    }
}