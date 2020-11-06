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

// https://www.hackerrank.com/challenges/bon-appetit/problem?utm_campaign=challenge-recommendation&utm_medium=email&utm_source=24-hour-campaign

class Solution
{

    // Complete the bonAppetit function below.
    // bill - bill values
    // k - Anna declined item - should not consider for dividing
    // b - brian charged amount
    static void bonAppetit(List<int> bill, int k, int b)
    {
        int totalExcludingDeclined = 0;

        for (int i = 0; i < bill.Count; i++)
        {
            if (i != k)
            {
                totalExcludingDeclined += bill[i];
            }
        }

        int estimated = totalExcludingDeclined / 2;
        int overCharged = b - estimated;

        if (overCharged == 0)
        {
            Console.WriteLine("Bon Appetit");
        }
        else
        {
            Console.WriteLine(overCharged);
        }
    }

    static void Main(string[] args)
    {
        //string[] nk = Console.ReadLine().TrimEnd().Split(' ');

        //int n = Convert.ToInt32(nk[0]);

        //int k = Convert.ToInt32(nk[1]);

        //List<int> bill = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(billTemp => Convert.ToInt32(billTemp)).ToList();

        //int b = Convert.ToInt32(Console.ReadLine().Trim());

        //bonAppetit(bill, k, b);

        var bill1 = new List<int>() { 3, 10, 2, 9 };
        int k1 = 1;
        int b1 = 12;
        bonAppetit(bill1, k1, b1); // 5

        var bill2 = new List<int>() { 3, 10, 2, 9 };
        int k2 = 1;
        int b2 = 7;
        bonAppetit(bill2, k2, b2); // Bon Appetit

        Console.ReadKey();
    }
}
