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

static class FruitsReachability
{
    public static int Reachable(this int[] fruits, int treeLocation, int areaBegin, int areaEnd)
    {
        return fruits.Where(fruitRelative =>
        {
            int fruitAbsolute = fruitRelative + treeLocation;

            return ((fruitAbsolute >= areaBegin) && (fruitAbsolute <= areaEnd));
        }).Count();
    }
}

class Solution
{
    // Complete the countApplesAndOranges function below.
    static void countApplesAndOranges(int s, int t, int a, int b, int[] apples, int[] oranges)
    {
        Console.WriteLine(apples.Reachable(a, s, t));
        Console.WriteLine(oranges.Reachable(b, s, t));
    }



    static void Main(string[] args)
    {
        //string[] st = Console.ReadLine().Split(' ');

        //int s = Convert.ToInt32(st[0]);

        //int t = Convert.ToInt32(st[1]);

        //string[] ab = Console.ReadLine().Split(' ');

        //int a = Convert.ToInt32(ab[0]);

        //int b = Convert.ToInt32(ab[1]);

        //string[] mn = Console.ReadLine().Split(' ');

        //int m = Convert.ToInt32(mn[0]);

        //int n = Convert.ToInt32(mn[1]);

        //int[] apples = Array.ConvertAll(Console.ReadLine().Split(' '), applesTemp => Convert.ToInt32(applesTemp));

        //int[] oranges = Array.ConvertAll(Console.ReadLine().Split(' '), orangesTemp => Convert.ToInt32(orangesTemp));

        countApplesAndOranges(7, 10, 4, 12, new int[] { 2, 3, -4 }, new int[] { 3, -2, -4 });
        countApplesAndOranges(7, 11, 5, 15, new int[] { -2, 2, 1 }, new int[] { 5, -6 });


        //countApplesAndOranges(s, t, a, b, apples, oranges);

        Console.ReadKey();
    }
}
