// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

ReadInputsFromCsvFile().ToList().ForEach(input =>
{
    var numbers = input.ElementAt(0).ToArray();
    var minOperations = MinOperations(numbers);

    Console.WriteLine(string.Join(",", minOperations));
});

int[] MinOperations(int[] nums)
{
    var minOperations = new List<int>(0);

    foreach (var number in nums)
    {
        var numberForward = number;
        var minOperationsForward = 0;

        while (!IsBinaryPalindrome(numberForward))
        {
            minOperationsForward++;
            numberForward++;
        }

        if (minOperationsForward == 0)
        {
            minOperations.Add(0);
            continue;
        }

        var numberBackward = number;
        var minOperationsBackward = 0;

        while (numberBackward > 0 && numberBackward < numberForward && !IsBinaryPalindrome(numberBackward))
        {
            minOperationsBackward++;
            numberBackward--;
        }

        if (numberBackward > 0)
        {
            minOperationsForward = Math.Min(minOperationsForward, minOperationsBackward);
        }

        minOperations.Add(minOperationsForward);
    }

    return minOperations.ToArray();
}

bool IsBinaryPalindrome(int number)
{
    var binaryString = Convert.ToString(number, 2);
    var reversedBinaryString = new string(binaryString.Reverse().ToArray());
    return binaryString == reversedBinaryString;
}

static IEnumerable<IEnumerable<IEnumerable<int>>> ReadInputsFromCsvFile(int numLinesPerInput = 1)
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