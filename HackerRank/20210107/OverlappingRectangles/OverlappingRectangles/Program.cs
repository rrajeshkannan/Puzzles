using System;

class Result
{

    /*
     * Complete the 'calculate_area' function below.
     *
     * The function is expected to return an INTEGER.
     * The function accepts following parameters:
     *  1. INTEGER x1
     *  2. INTEGER y1
     *  3. INTEGER x2
     *  4. INTEGER y2
     *  5. INTEGER x3
     *  6. INTEGER y3
     *  7. INTEGER x4
     *  8. INTEGER y4
     */

    

    public static int calculate_area(int x1, int y1, int x2, int y2, int x3, int y3, int x4, int y4)
    {
        if ((x1 >= x4) || (x3 >= x2))
        {
            // no intersection - lying right || left
            return 0;
        }

        if ((y1 <= y4) || (y3 <= y1))
        {
            // no intersection - below || above
            return 0;
        }

        var left = Math.Max(x1, x3);
        var right = Math.Min(x2, x4);
        var length = right - left;

        var top = Math.Min(y1, y3);
        var bottom = Math.Max(y2, y4);
        var breadth = top - bottom;

        return length * breadth;
    }
}

class Solution
{
    public static void Main(string[] args)
    {
        var output1 = Result.calculate_area(-1, -1, 3, 0, 1, 3, 4, -1);
        var output2 = Result.calculate_area(-1, 1, 3, 0, 1, 3, 4, -1);
    }
}