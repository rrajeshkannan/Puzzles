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
     * Complete the 'maximumStones' function below.
     *
     * The function is expected to return an INTEGER.
     * The function accepts INTEGER_ARRAY arr as parameter.
     */

    public static int maximumStones(List<int> arr)
    {
        int oddsSum = 0;
        int evensSum = 0;

        int partitionSize = arr.Count / 2;
        int evenId = 0;
        int oddId = 1;

        // Even elements
        for (int partitionId = 0; partitionId < partitionSize; partitionId++, evenId += 2, oddId += 2)
        {
            evensSum += arr[evenId];
            oddsSum += arr[oddId];
        }

        if (arr.Count % 2 == 1)
        {
            // one more element pending
            evensSum += arr[evenId];
        }

        return Math.Min(oddsSum, evensSum) * 2;


        //// descending order
        //var evenElementsReverse = evenElements.OrderByDescending(i => i).ToList();
        //var oddElementsReverse = oddElements.OrderByDescending(i => i).ToList();

        //var stones = 0;

        ////for (int i = 0; i < oddElementsReverse.Count(); i++)
        ////{
        ////    int minimum = (evenElementsReverse[i] < oddElementsReverse[i]) ?
        ////        evenElementsReverse[i] : oddElementsReverse[i];

        ////    stones = stones + minimum;
        ////}

        //var leftElementsCount = arr.Count / 2;
        //var evenElementsLeftSum = evenElementsReverse.Take(leftElementsCount).Sum();
        //var oddElementsSum = oddElementsReverse.Take(leftElementsCount).Sum();

        //if (arr.Count % 2 == 0)
        //{
        //    if (oddElementsSum < evenElementsLeftSum)
        //    {
        //        return oddElementsSum * 2;
        //    }
        //    else
        //    {
        //        return evenElementsLeftSum * 2;
        //    }
        //}
        //else
        //{
        //    // should we take that into account?
        //    if (oddElementsSum < evenElementsLeftSum)
        //    {
        //        // not required
        //    }
        //        if (evenElementsLeftSum < oddElementsSum)
        //    {
        //        var difference = oddElementsSum - evenElementsLeftSum;
        //    }
        //    else
        //    {

        //    }
        //}

        //return stones * 2;
    }

}

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(Console.OpenStandardOutput());

        int n = Convert.ToInt32(Console.ReadLine().Trim());

        List<int> arr = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(arrTemp => Convert.ToInt32(arrTemp)).ToList();

        int result = Result.maximumStones(arr);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();

        Console.ReadKey();
    }
}
