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

// https://www.hackerrank.com/challenges/sock-merchant/problem?utm_campaign=challenge-recommendation&utm_medium=email&utm_source=24-hour-campaign&h_r=next-challenge&h_v=zen


class Solution
{

    // Complete the sockMerchant function below.
    static int sockMerchant(int n, int[] ar)
    {
        HashSet<int> unpairedYet = new HashSet<int>();
        int pairs = 0;

        for (int i = 0; i < ar.Length; i++)
        {
            var current = ar[i];

            if(unpairedYet.Contains(current))
            {
                pairs++;
                unpairedYet.Remove(current);
            }
            else
            {
                unpairedYet.Add(current);
            }
        }

        return pairs;
    }

    static void Main(string[] args)
    {
        //TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        //int n = Convert.ToInt32(Console.ReadLine());

        //int[] ar = Array.ConvertAll(Console.ReadLine().Split(' '), arTemp => Convert.ToInt32(arTemp))
        //;
        //int result = sockMerchant(n, ar);

        //textWriter.WriteLine(result);

        //textWriter.Flush();
        //textWriter.Close();

        int[] ar1 = new int[] { 10, 20, 20, 10, 10, 30, 50, 10, 20 };
        int result1 = sockMerchant(9, ar1); // 3

        int[] ar2 = new int[] { 1, 2, 1, 2, 1, 3, 2 };
        int result2 = sockMerchant(7, ar2); // 2
    }
}
