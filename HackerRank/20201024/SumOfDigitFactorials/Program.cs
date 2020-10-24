using System;
using System.Collections.Generic;
using System.IO;

class Solution
{
    // https://www.hackerrank.com/contests/projecteuler/challenges/euler254/problem
    static uint f(uint n)
    {
        if(n == 0)
        {
            return 1;
        }

        return n * Factorial(n - 1);
    }

    static ulong SumOfDigits(ulong n, Func<uint, uint> digitTransform)
    {
        if (n == 0)
        {
            return 0;
        }

        uint lastDigit = (uint)(n % 10);
        ulong numberExcludingLastDigit = n / 10;

        return digitTransform(lastDigit) + SumOfDigits(numberExcludingLastDigit, digitTransform);
    }

    static Dictionary<ulong, ulong> _smallestNumberMapping = new Dictionary<ulong, ulong>();

    static ulong SmallestNumberForSumOfDigitsOfSumOfFactorialsOfDigits(ulong n)
    {
        var sumOfFactorialsOfDigits = SumOfDigits(n, digit => Factorial(digit));
        var sumOfDigitsOfSumOfFactorialsOfDigits = SumOfDigits(sumOfFactorialsOfDigits, digit => digit);

        if (_smallestNumberMapping.TryGetValue(sumOfDigitsOfSumOfFactorialsOfDigits, out ulong nResult))
        {
            return nResult;
        }

        ulong i = 1;

        while (true)
        {
            sumOfFactorialsOfDigits = SumOfDigits(i, digit => Factorial(digit));
            sumOfDigitsOfSumOfFactorialsOfDigits = SumOfDigits(sumOfFactorialsOfDigits, digit => digit);

            //if (!_smallestNumberMapping.ContainsKey(sumOfDigitsOfSumOfFactorialsOfDigits))
            //{
            //    _smallestNumberMapping.Add(sumOfDigitsOfSumOfFactorialsOfDigits, i);
            //}

            // Find smallest positive integer "i" such that: SumOfDigitsOfSumOfFactorialsOfDigits(i) == n
            if (sumOfDigitsOfSumOfFactorialsOfDigits == n)
            {
                _smallestNumberMapping.Add(sumOfDigitsOfSumOfFactorialsOfDigits, i);
                return i;
            }

            i++;
        }
    }

    static ulong SumOfAllSmallestNumberForSumOfDigitsOfSumOfFactorialsOfDigits(ulong n)
    {
        ulong result = 0;

        for (ulong l = 1; l <= n; l++)
        {
            var interimResult = SmallestNumberForSumOfDigitsOfSumOfFactorialsOfDigits(l);
            var sumOfDigitsOfInterimResult = SumOfDigits(interimResult, digit => digit);

            result += sumOfDigitsOfInterimResult;
        }

        return result;
    }

    static void Main(String[] args)
    {
        //ulong resultTemp1 = SumOfAllSmallestNumberForSumOfDigitsOfSumOfFactorialsOfDigits(4); // 11
        //ulong resultTemp2 = SumOfAllSmallestNumberForSumOfDigitsOfSumOfFactorialsOfDigits(20); // 156
        //ulong resultTemp3 = SumOfAllSmallestNumberForSumOfDigitsOfSumOfFactorialsOfDigits(5); // 156

        ulong resultTemp11 = SmallestNumberForSumOfDigitsOfSumOfFactorialsOfDigits(4); // 15

        /* Enter your code here. Read input from STDIN. Print output to STDOUT. Your class should be named Solution */
        int numberOfQueries = Int32.Parse(Console.ReadLine());

        ulong[] n = new ulong[numberOfQueries];
        ulong[] m = new ulong[numberOfQueries];

        for (int i = 0; i < numberOfQueries; i++)
        {
            string[] digitModulo = Console.ReadLine().Split(' ');

            n[i] = Convert.ToUInt64(digitModulo[0]);
            m[i] = Convert.ToUInt64(digitModulo[1]);
        }

        for (int i = 0; i < numberOfQueries; i++)
        {
            ulong result = SumOfAllSmallestNumberForSumOfDigitsOfSumOfFactorialsOfDigits(n[i]) % m[i];

            Console.WriteLine(result);
        }

        Console.ReadKey();
    }
}
