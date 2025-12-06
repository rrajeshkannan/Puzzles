namespace CompletePrimeNumber;

internal static class Program
{
    private static void Main(string[] args)
    {
        ReadInputsFromCsvFile().ToList().ForEach(input =>
        {
            var number = input.ElementAt(0).First();
            Console.WriteLine($"{number} is complete prime number: {IsCompletePrimeNumber(number)}");
        });
    }

    private static bool IsCompletePrimeNumber(int number)
    {
        // Check prefixes
        var prefix = number;
        while (prefix != 0)
        {
            if (!IsPrime(prefix))
            {
                return false;
            }
            prefix /= 10;
        }

        // Check suffixes
        var suffix = 0;
        var divisor = 10;
        while (suffix != number)
        {
            suffix = number % divisor;
            if (!IsPrime(suffix))
            {
                return false;
            }
            divisor *= 10;
        }

        return true;
    }

    private static bool IsPrime(int number)
    {
        if (number <= 1) return false;
        if (number == 2) return true;
        if (number % 2 == 0) return false;

        var boundary = (int)Math.Floor(Math.Sqrt(number));

        for (int i = 3; i <= boundary; i += 2)
        {
            if (number % i == 0) return false;
        }

        return true;
    }

    public static IEnumerable<IEnumerable<IEnumerable<int>>> ReadInputsFromCsvFile(int numLinesPerInput = 1)
    {
        var lines = File.ReadAllLines("inputs.txt");
        var linesScannedForCurrentInput = 0;
        var currentInput = new List<IEnumerable<int>> { };

        foreach (var line in lines)
        {
            var parts = line.Split(';');
            var numbers = Array.ConvertAll(parts[0].Split(','), int.Parse);

            currentInput.Add(numbers);
            linesScannedForCurrentInput++;

            if (linesScannedForCurrentInput == numLinesPerInput)
            {
                yield return currentInput;
                linesScannedForCurrentInput = 0;
                currentInput = [];
            }
        }
    }
}