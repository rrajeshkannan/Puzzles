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
using System.Windows.Markup;

class Solution
{

    // https://www.hackerrank.com/challenges/kangaroo/problem?isFullScreen=true

    // You are choreographing a circus show with various animals. 
    // For one act, you are given two kangaroos on a number line ready to jump in the positive direction (i.e, toward positive infinity).
    // The first kangaroo starts at location  and moves at a rate of  meters per jump.
    // The second kangaroo starts at location  and moves at a rate of  meters per jump.
    // You have to figure out a way to get both kangaroos at the same location at the same time as part of the show.If it is possible, return YES, otherwise return NO.
    // For example, kangaroo starts at with a jump distance and kangaroo starts at with a jump distance of . After one jump, they are both at, (, ), so our answer is YES.

    // Complete the kangaroo function below.
    static string kangaroo(int x1, int v1, int x2, int v2)
    {
        int jumps = 0;

        while (x1 != x2)
        {
            // (x1 == x2) ==> means both first and second kangaroo are in same place

            if ((x1 < x2) && (v1 <= v2))
            {
                // first kangaroo is behind and slower than second kangaroo -> so, can't catch up
                return "NO";
            }

            if ((x2 < x1) && (v2 <= v1))
            {
                // second kangaroo is behind and slower than first kangaroo -> so, can't catch up
                return "NO";
            }

            x1 += v1;
            x2 += v2;
            jumps++;
        }

        // both first and second kangaroo are in same place
        return "YES";
    }

    static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        string[] x1V1X2V2 = Console.ReadLine().Split(' ');

        int x1 = Convert.ToInt32(x1V1X2V2[0]);

        int v1 = Convert.ToInt32(x1V1X2V2[1]);

        int x2 = Convert.ToInt32(x1V1X2V2[2]);

        int v2 = Convert.ToInt32(x1V1X2V2[3]);

        // string result = kangaroo(x1, v1, x2, v2);

        string result1 = kangaroo(0, 3, 4, 2);

        textWriter.WriteLine(result1);

        textWriter.Flush();
        textWriter.Close();
    }
}
