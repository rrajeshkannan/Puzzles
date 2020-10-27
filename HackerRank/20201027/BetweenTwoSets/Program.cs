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
    // https://www.hackerrank.com/challenges/between-two-sets/problem?isFullScreen=true

    /*
     * Complete the 'getTotalX' function below.
     *
     * The function is expected to return an INTEGER.
     * The function accepts following parameters:
     *  1. INTEGER_ARRAY a
     *  2. INTEGER_ARRAY b
     */

    public static int getTotalX(List<int> a, List<int> b)
    {
        var begin = a.Max();
        var end = b.Min();

        if (end < begin)
        {
            return 0;
        }

        //var factors = new List<int>();

        //for (int number = begin; number <= end; number++)
        //{
        //    if (a.All(ai => number % ai == 0))
        //    {
        //        if (b.All(bi => bi % number == 0))
        //        {
        //            factors.Add(number);
        //        }
        //    }
        //}

        return Enumerable.Range(begin, end - begin + 1)
            .Where(number => a.All(ai => number % ai == 0))
            .Where(number => b.All(bi => bi % number == 0))
            .Count();
    }
}

class Solution
{
    public static void Main(string[] args)
    {
        //TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        //string[] firstMultipleInput = Console.ReadLine().TrimEnd().Split(' ');

        //int n = Convert.ToInt32(firstMultipleInput[0]);

        //int m = Convert.ToInt32(firstMultipleInput[1]);

        //List<int> arr = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(arrTemp => Convert.ToInt32(arrTemp)).ToList();

        //List<int> brr = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(brrTemp => Convert.ToInt32(brrTemp)).ToList();

        //int total = Result.getTotalX(arr, brr);

        //textWriter.WriteLine(total);

        //textWriter.Flush();
        //textWriter.Close();

        List<int> a = new List<int> { 2, 4 };
        List<int> b = new List<int> { 16, 32, 96 };

        var result = Result.getTotalX(a, b);

        Console.WriteLine(result);
    }
}
