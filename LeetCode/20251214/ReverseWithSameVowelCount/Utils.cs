namespace UtilsLibrary
{
    public static class Utils
    {
        public static IEnumerable<string> ReadLinesFromCsvFile(
            char separator = ' ')
        {
            var lines = File.ReadAllLines("inputs.txt");

            foreach (var line in lines)
            {
                yield return line;
            }
        }

        public static IEnumerable<IEnumerable<string>> ReadStringsFromCsvFile(
            char separator = ' ')
        {
            var lines = File.ReadAllLines("inputs.txt");

            foreach (var line in lines)
            {
                var words = line.Split(separator);
                yield return words;
            }
        }

        public static IEnumerable<IEnumerable<IEnumerable<int>>> ReadNumbersFromCsvFile(
            int numLinesPerInput = 1,
            char partSeparator = ';',
            char separator = ',')
        {
            var lines = File.ReadAllLines("inputs.txt");
            var linesScannedForCurrentInput = 0;
            var currentInput = new List<IEnumerable<int>> { };

            foreach (var line in lines)
            {
                var parts = line.Split(partSeparator);
                var numbers = Array.ConvertAll(parts[0].Split(separator), int.Parse);

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
}