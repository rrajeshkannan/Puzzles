using System;
using System.Collections.Generic;
using System.IO;

class Solution
{
    static long Factorial(long n)
    {
        if(n == 0)
        {
            return 1;
        }

        return n * Factorial(n - 1);
    }

    static long SumOfDigits(long n)
    {
        if (n == 0)
        {
            return 0;
        }

        int lastDigit = (int)(n % 10);
        long numberExcludingLastDigit = n / 10;

        return lastDigit + SumOfDigits(numberExcludingLastDigit);
    }

    static long SumOfDigitsOfFactorial(long n)
    {
        return SumOfDigits(Factorial(n));
    }

    static long SmallestNumberForSumOfDigitsOfFactorial(long i)
    {
        // Find smallest positive integer "n" such that: SumOfDigits(Factorial(n)) == i
        long n = 1;

        while(SumOfDigitsOfFactorial(n) != i)
        {
            n++;
        }

        return n;
    }

    static long SumOfMinimumNumbersForSumOfDigitsOfFactorial(int n)
    {
        var mappingsForSumOfDigitsOfFactorialToSmallestNumber = new Dictionary<long, long>();
        long result = 0;

        for (int i = 1; i <= n; i++)
        {
            var sumOfDigitsOfFactorial = SumOfDigitsOfFactorial(i);

            if (!mappingsForSumOfDigitsOfFactorialToSmallestNumber.TryGetValue(sumOfDigitsOfFactorial, out long smallestNumberForSumOfDigitsOfFactorial))
            {
                smallestNumberForSumOfDigitsOfFactorial = SmallestNumberForSumOfDigitsOfFactorial(i);
                mappingsForSumOfDigitsOfFactorialToSmallestNumber.Add(sumOfDigitsOfFactorial, smallestNumberForSumOfDigitsOfFactorial);
            }

            result += SumOfDigits(smallestNumberForSumOfDigitsOfFactorial);
        }

        return result;
    }

    static void Main(String[] args)
    {
        /* Enter your code here. Read input from STDIN. Print output to STDOUT. Your class should be named Solution */
        int numberOfQueries = Int32.Parse(Console.ReadLine());

        while (numberOfQueries-- > 0)
        {
            string[] digitModulo = Console.ReadLine().Split(' ');

            int n = Convert.ToInt32(digitModulo[0]);
            long m = Convert.ToInt32(digitModulo[1]);

            long result = SumOfMinimumNumbersForSumOfDigitsOfFactorial(n) % m;

            Console.WriteLine(result);
        }

        Console.ReadKey();
    }
}
