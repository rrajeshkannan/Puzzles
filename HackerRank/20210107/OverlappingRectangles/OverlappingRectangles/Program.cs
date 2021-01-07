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

    private struct Rectangle
    {
        public static readonly Rectangle Empty = new Rectangle(0, 0, 0, 0);

        int Left;
        int Top;
        int Right;
        int Bottom;

        public Rectangle(int left, int top, int right, int bottom)
            => (Left, Top, Right, Bottom) = (left, top, right, bottom);

        public int Width => Right - Left;

        public int Height => Top - Bottom;

        public int Area => Width * Height;

        public Rectangle Overlapping(Rectangle other)
        {
            if (Left >= other.Right)
            {
                // not overlapping - this rectangle lies right of other rectangle
                return Empty;
            }

            if (Right <= other.Left)
            {
                // not overlapping - this rectangle lies left of other rectangle
                return Empty;
            }

            if (Top <= other.Bottom)
            {
                // not overlapping - this rectangle lies below other rectangle
                return Empty;
            }

            if (Bottom >= other.Top)
            {
                // not overlapping - this rectangle lies above other rectangle
                return Empty;
            }

            var overlapLeft = Math.Max(Left, other.Left);
            var overlapRight = Math.Min(Right, other.Right);
            var overlapTop = Math.Min(Top, other.Top);
            var overlapBottom = Math.Max(Bottom, other.Bottom);

            return new Rectangle(overlapLeft, overlapTop, overlapRight, overlapBottom);
        }
    }    

    public static int calculate_area(int x1, int y1, int x2, int y2, int x3, int y3, int x4, int y4)
    {
        var rectangle1 = new Rectangle(x1, y1, x2, y2);
        var rectangle2 = new Rectangle(x3, y3, x4, y4);

        var overlappingRectangle = rectangle1.Overlapping(rectangle2);
        return overlappingRectangle.Area;
    }
}

class Solution
{
    public static void Main(string[] args)
    {
        var output1 = Result.calculate_area(-1, -1, 3, 0, 1, 3, 4, -1);
        var output2 = Result.calculate_area(-1, 1, 3, 0, 1, 3, 4, -1);
        var output3 = Result.calculate_area(1, 3, 2, 0, 2, 1, 4, -2);
        var output4 = Result.calculate_area(-5, 4, 5, -2, -4, 2, 2, -1);
    }
}