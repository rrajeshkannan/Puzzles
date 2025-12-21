// See https://aka.ms/new-console-template for more information
using System.Globalization;

ReadInputsFromCsvFile().ToList().ForEach(input =>
{
    var number = input.ElementAt(0).ElementAt(0);
    Console.WriteLine($"Largest Consecutive Prime Sum for:{number} is {LargestPrime(number)}");
});


// Returns the largest prime number less than or equal to n.
// Returns -1 if no such prime exists.
int LargestPrime(int n)
{
    if (n < 2) return 0;
    if (n == 2) return 2;

    var sum = 2;
    var largestPrime = 2;

    for (int i = 3; i < n / 2; i += 2)
    {
        if (IsPrime(i))
        {
            if (sum == i)
            {
                largestPrime = sum;
            }

            sum += i;

            if (sum > n) break;
        }
    }

    return largestPrime;
}

// int LargestPrime(int n)
// {
//     if (n < 2) return 0;
//     if (n == 2) return 2;

//     var primes = new List<int>();

//     for (int i = n; i >= 2; i--)
//     {
//         if (IsPrime(i))
//         {
//             primes.Add(i);
//         }
//     }

//     var primesArray = primes.ToArray();

//     for (int i = 0; i < primesArray.Length; i++)
//     {
//         var current = primesArray[i];

//         if (current == 2) return 2;

//         var sum = 0;

//         for (int j = primesArray.Length - 1; j > i; j--)
//         {
//             sum += primesArray[j];

//             if (sum == current) return sum;

//             if (sum > current) break;
//         }
//     }

//     return 0;
// }

// Largest Consecutive Prime Sum for:20 is 17
// Largest Consecutive Prime Sum for:2 is 2
// Largest Consecutive Prime Sum for:3 is 2
// Largest Consecutive Prime Sum for:1 is 0
// Largest Consecutive Prime Sum for:5 is 5
// Largest Consecutive Prime Sum for:6 is 5
// Largest Consecutive Prime Sum for:498639 is 398771
// Largest Consecutive Prime Sum for:499929 is 398771

bool IsPrime(int x)
{
    if (x < 2) return false;
    if (x == 2) return true;
    if (x % 2 == 0) return false;
    int sqrtX = (int)Math.Sqrt(x);
    for (int i = 3; i <= sqrtX; i += 2)
    {
        if (x % i == 0) return false;
    }
    return true;
}

static IEnumerable<IEnumerable<IEnumerable<int>>> ReadInputsFromCsvFile(int numLinesPerInput = 1)
{
    var lines = File.ReadAllLines("inputs.txt");
    var linesScannedForCurrentInput = 0;
    var currentInput = new List<IEnumerable<int>>();

    foreach (var line in lines)
    {
        var parts = line.Split(';');
        var numbers = Array.ConvertAll(parts[0].Split(',', StringSplitOptions.RemoveEmptyEntries), int.Parse);

        currentInput.Add(numbers);
        linesScannedForCurrentInput++;

        if (linesScannedForCurrentInput == numLinesPerInput)
        {
            yield return currentInput;
            linesScannedForCurrentInput = 0;
            currentInput = new List<IEnumerable<int>>();
        }
    }
}

struct PairsOfPrimes
{
    public int number { get; set; }

    public List<int> smallerPrimes { get; set; }
}