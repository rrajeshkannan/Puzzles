using System.Diagnostics;
using System.Numerics;

var solution = new Solution();

Stopwatch stopwatch2 = Stopwatch.StartNew();
Stopwatch stopwatch1 = Stopwatch.StartNew();
Console.WriteLine($"Result: {solution.MinAllOneMultiple(3)}, Time: {stopwatch1.ElapsedMilliseconds}");
stopwatch1.Restart();
Console.WriteLine($"Result: {solution.MinAllOneMultiple(7)}, Time: {stopwatch1.ElapsedMilliseconds}");
stopwatch1.Restart();
Console.WriteLine($"Result: {solution.MinAllOneMultiple(2)}, Time: {stopwatch1.ElapsedMilliseconds}");
stopwatch1.Restart();
Console.WriteLine($"Result: {solution.MinAllOneMultiple(9)}, Time: {stopwatch1.ElapsedMilliseconds}");
stopwatch1.Restart();
Console.WriteLine($"Result: {solution.MinAllOneMultiple(17)}, Time: {stopwatch1.ElapsedMilliseconds}");
stopwatch1.Restart();
Console.WriteLine($"Result: {solution.MinAllOneMultiple(23)}, Time: {stopwatch1.ElapsedMilliseconds}");
stopwatch1.Restart();
Console.WriteLine($"Result: {solution.MinAllOneMultiple(313)}, Time: {stopwatch1.ElapsedMilliseconds}");
stopwatch1.Restart();
Console.WriteLine($"Result: {solution.MinAllOneMultiple(79251)}, Time: {stopwatch1.ElapsedMilliseconds}");
stopwatch1.Restart();
Console.WriteLine($"Total Time: {stopwatch2.ElapsedMilliseconds}");


// Solved using RepUnit 

public class Solution
{
    public int MinAllOneMultiple(int k)
    {
        if (k % 2 == 0 || k % 5 == 0)
            return -1;

        int remainder = 1 % k;
        int length = 1;

        while (remainder != 0)
        {
            remainder = (remainder * 10 + 1) % k;
            length++;
        }

        return length;
    }
}