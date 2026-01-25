// See https://aka.ms/new-console-template for more information
var results = new Solution().WordSquares(["able", "area", "echo", "also"]);
Console.WriteLine("Results:");
Console.WriteLine(string.Join(Environment.NewLine, results.Select(rs => string.Join(", ", rs))));

var results1 = new Solution().WordSquares(["code", "cafe", "eden", "edge"]);
Console.WriteLine("Results:");
Console.WriteLine(string.Join(Environment.NewLine, results1.Select(rs => string.Join(", ", rs))));

var results2 = new Solution().WordSquares(["avvj", "dooe", "exxj", "diia"]);
Console.WriteLine("Results:");
Console.WriteLine(string.Join(Environment.NewLine, results2.Select(rs => string.Join(", ", rs))));

var results3 = new Solution().WordSquares(["aaay", "dgzy", "rrrh", "aiir", "yiih"]);
Console.WriteLine("Results:");
Console.WriteLine(string.Join(Environment.NewLine, results3.Select(rs => string.Join(", ", rs))));

var results4 = new Solution().WordSquares(["aaay", "dgzy", "rrrh", "aiir", "yiih"]);
Console.WriteLine("Results:");
Console.WriteLine(string.Join(Environment.NewLine, results4.Select(rs => string.Join(", ", rs))));

var results5 = new Solution().WordSquares(["akka", "aoov", "lvmm", "xvvv", "ahhx", "cvli"]);
Console.WriteLine("Results:");
Console.WriteLine(string.Join(Environment.NewLine, results5.Select(rs => string.Join(", ", rs))));

public class Solution
{
    public IList<IList<string>> WordSquares(string[] words)
    {
        var results = new List<IList<string>>();

        var indices = new int[words.Length];

        for (int i = 0; i < words.Length; i++)
        {
            indices[i] = i;
        }

        List<int[]> indicesPermutations = [];
        GeneratePermutations(indices, 0, indices.Length - 1, indicesPermutations);

        // Console.WriteLine($"Total Permutations: {indicesPermutations.Count}");
        foreach (var perm in indicesPermutations)
        {
            // Console.Write("Permutation: ");

            // foreach (var index in perm)
            // {
            //     Console.Write(words[index] + " ");
            // }

            // Console.WriteLine();

            var top = words[perm[0]];
            var left = words[perm[1]];
            var right = words[perm[2]];
            var bottom = words[perm[3]];

            if (top[0] != left[0] || top[3] != right[0] || right[3] != bottom[3] || bottom[0] != left[3])
                continue;

            results.Add([top, left, right, bottom]);
        }

        return [.. results.Distinct(new SequenceEqualityComparer()).OrderBy(list => list, new ListLexicographer())];

        //return [.. results.OrderBy(list => list, new ListLexicographer())];
    }

    public class ListLexicographer : IComparer<IList<string>>
    {
        public int Compare(IList<string> x, IList<string> y)
        {
            if (x == null || y == null) return 0;

            // Compare words at each index
            int minCount = Math.Min(x.Count, y.Count);
            for (int i = 0; i < minCount; i++)
            {
                int cmp = string.Compare(x[i], y[i], StringComparison.Ordinal);
                if (cmp != 0) return cmp;
            }

            // If all words match up to the end of the shorter list, 
            // the shorter list comes first.
            return x.Count.CompareTo(y.Count);
        }
    }

    // Comparer to find DISTINCT sequences (SequenceEqual)
    public class SequenceEqualityComparer : IEqualityComparer<IList<string>>
    {
        public bool Equals(IList<string> x, IList<string> y)
        {
            if (ReferenceEquals(x, y)) return true;
            if (x == null || y == null) return false;
            return x.SequenceEqual(y); // Checks if contents match in order
        }

        public int GetHashCode(IList<string> obj)
        {
            if (obj == null) return 0;
            // Hash based on content to ensure duplicates group together
            return obj.Aggregate(0, (current, s) => current ^ (s?.GetHashCode() ?? 0));
        }
    }

    static void GeneratePermutations(int[] arr, int left, int right, List<int[]> results)
    {
        if (left == right)
        {
            results.Add((int[])arr.Clone());
        }
        else
        {
            for (int i = left; i <= right; i++)
            {
                Swap(ref arr[left], ref arr[i]);
                GeneratePermutations(arr, left + 1, right, results);
                Swap(ref arr[left], ref arr[i]); // Backtrack
            }
        }
    }

    static void Swap(ref int a, ref int b)
    {
        (b, a) = (a, b);
    }
}