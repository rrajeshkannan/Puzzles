ReadInputsFromCsvFile().ToList().ForEach(input =>
{
    var numbers = input.ElementAt(0).ToArray();

    int[] sorted = SortByReflection(numbers);
    Console.WriteLine(string.Join(", ", sorted));
});

int[] SortByReflection(int[] nums)
{
    var pairs = new BinaryReflectionPair[nums.Length];

    for (int i = 0; i < nums.Length; i++)
    {
        pairs[i].Number = nums[i];
        pairs[i].ReflectedNumber = BinaryReflection(nums[i]);
    }

    Array.Sort(pairs, (a, b) =>
    {

        if (a.ReflectedNumber < b.ReflectedNumber)
        {
            return -1;
        }

        if (a.ReflectedNumber > b.ReflectedNumber)
        {
            return 1;
        }

        if (a.Number < b.Number)
        {
            return -1;
        }

        if (a.Number > b.Number)
        {
            return 1;
        }

        return 0;
    });

    return pairs.Select(p => p.Number).ToArray();
}

int BinaryReflection(int number)
{
    if (number == 0) return 0;

    int bits = 0;

    // Count the number of bits needed
    int temp = number;
    while (temp > 0)
    {
        bits++;
        temp >>= 1;
    }

    int result = 0;

    // Reverse the bits
    for (int i = 0; i < bits; i++)
    {
        result <<= 1;
        result |= (number & 1);
        number >>= 1;
    }

    return result;
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

struct BinaryReflectionPair
{
    public int Number;
    public int ReflectedNumber;
}