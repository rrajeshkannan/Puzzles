// See https://aka.ms/new-console-template for more information

// Prepare test inputs
List<int> testInputs = new List<int>();
for (int i = 0; i < 100; i++)
{
    testInputs.Add(i);
}

Random random = new Random();
for (int i = 0; i < 1000; i++)
{
    testInputs.Add(random.Next(1000000000, int.MaxValue));
}

Console.WriteLine($"Testing {testInputs.Count} inputs...\n");

var totalStopwatch = System.Diagnostics.Stopwatch.StartNew();
int palindromeCount = 0;
long totalTime = 0;
long minTime = long.MaxValue;
long maxTime = 0;

foreach (int input in testInputs)
{
    var stopwatch = System.Diagnostics.Stopwatch.StartNew();
    bool result = BinaryPalindrome(input);
    stopwatch.Stop();

    long elapsedTicks = stopwatch.ElapsedTicks;
    totalTime += elapsedTicks;
    minTime = Math.Min(minTime, elapsedTicks);
    maxTime = Math.Max(maxTime, elapsedTicks);

    if (result)
    {
        palindromeCount++;
    }
}

totalStopwatch.Stop();

double totalMs = totalTime * 1000.0 / System.Diagnostics.Stopwatch.Frequency;
double avgMs = totalMs / testInputs.Count;
double minMs = minTime * 1000.0 / System.Diagnostics.Stopwatch.Frequency;
double maxMs = maxTime * 1000.0 / System.Diagnostics.Stopwatch.Frequency;

double overallMs = totalStopwatch.ElapsedTicks * 1000.0 / System.Diagnostics.Stopwatch.Frequency;

Console.WriteLine($"--- Statistics ---");
Console.WriteLine($"Total inputs tested: {testInputs.Count}");
Console.WriteLine($"Binary palindromes found: {palindromeCount}");
Console.WriteLine($"Total execution time: {totalMs:F3} ms ({totalTime} ticks)");
Console.WriteLine($"Average time per input: {avgMs:F6} ms");
Console.WriteLine($"Min time: {minMs:F6} ms");
Console.WriteLine($"Max time: {maxMs:F6} ms");
Console.WriteLine($"Overall time (including overhead): {overallMs:F3} ms ({totalStopwatch.ElapsedTicks} ticks)");

static bool BinaryPalindrome(int number)
{
    if (number < 0) return false;

    // Work with bits directly - no string conversion needed
    const int LSB_POSITION = 0; // Least Significant Bit position (rightmost when written)
    const int MSB_POSITION = sizeof(int) * 8 - 1; // Most Significant Bit position (leftmost when written, 31 for 32-bit int)

    int lsbPos = LSB_POSITION; // Start from LSB (bit position 0)
    int msbPos = MSB_POSITION; // Start from MSB (bit position 31)

    // Find the position of the highest set bit
    while (msbPos > 0 && (number & (1 << msbPos)) == 0)
    {
        msbPos--;
    }

    // Compare bits from both ends (LSB vs MSB, moving inward)
    while (lsbPos < msbPos)
    {
        bool lsbBit = (number & (1 << lsbPos)) != 0;
        bool msbBit = (number & (1 << msbPos)) != 0;

        if (lsbBit != msbBit)
        {
            return false; // Not a palindrome
        }

        lsbPos++;
        msbPos--;
    }

    return true;
}