using System;
using System.Collections.Generic;
using System.IO;

class Solution
{
    static uint Factorial(uint n)
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
        // Find smallest positive integer "i" such that: SumOfDigitsOfSumOfFactorialsOfDigits(i) == n
        ulong i = 1;

        if (_smallestNumberMapping.TryGetValue(n, out ulong result))
        {
            return result;
        }

        while(true)
        {
            if (_smallestNumberMapping.TryGetValue(n, out ulong result))
            {
                return result;
            }

            var sumOfFactorialsOfDigits = SumOfDigits(i, digit => Factorial(digit));
            var sumOfDigitsOfSumOfFactorialsOfDigits = SumOfDigits(sumOfFactorialsOfDigits, digit => digit);

            if (sumOfDigitsOfSumOfFactorialsOfDigits == n)
            {
                break;
            }

            i++;
        }

        return i;
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
