using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValidSquareCheck
{
    // https://leetcode.com/explore/challenge/card/november-leetcoding-challenge/565/week-2-november-8th-november-14th/3527/

    // Given the coordinates of four points in 2D space, return whether the four points could construct a square.
    // The coordinate(x, y) of a point is represented by an integer array with two integers.
    // Example: Input: p1 = [0,0], p2 = [1,1], p3 = [1,0], p4 = [0,1], Output: True
    // 1. All the input integers are in the range [-10000, 10000].
    // 2. A valid square has four equal sides with positive length and four equal angles(90-degree angles).
    // 3. Input points have no order.

    public class Solution
    {
        private struct Point : IComparable<Point>
        {
            public int x;
            public int y;

            public Point(int[] p)
            {
                x = p[0];
                y = p[1];
            }

            public override string ToString() => String.Format("{0}:{1}", x, y);

            public int CompareTo(Point other)
            {
                return (x < other.x) ? -1 : 
                    (x > other.x) ? 1 : 
                    (y < other.y) ? -1 : 
                    (y > other.y) ? 1 : 0;
            }

            public double Distance(Point other)
            {
                var xDiff = x - other.x;
                var yDiff = y - other.y;

                return Math.Sqrt(xDiff * xDiff + yDiff * yDiff);
            }
        }

        private struct Line
        {
            public Point p1;
            public Point p2;

            public double Length => p1.Distance(p2);

            public double Slope => (double)(p1.y - p2.y) / (double)(p1.x - p2.x);

            public double InnerAngleBetween(Line other)
            {
                double angle1 = Math.Atan2 (p1.y - p2.y, p1.x - p2.x);
                double angle2 = Math.Atan2 (other.p1.y - other.p2.y, other.p1.x - other.p2.x);

                double angleBetweenInRadian = angle1 - angle2;
                double angleBetweenInDegrees = angleBetweenInRadian * (180.0 / Math.PI);

                if (angleBetweenInDegrees > 180)
                {
                    angleBetweenInDegrees = 360.0 - angleBetweenInDegrees;
                }
                else if (angleBetweenInDegrees < 0.0)
                {
                    angleBetweenInDegrees += 360.0;
                }

                return angleBetweenInDegrees;

                // Double Angle = Math.Atan2(y2 - y1, x2 - x1) - Math.Atan2(y4 - y3, x4 - x3);

                //double tanOfAngle = (other.Slope - Slope) / (1 + other.Slope * Slope);
                //double angle = Math.Atan(tanOfAngle) * 180 / Math.PI;

                //return Math.Abs(angle);
            }
        }

        //private bool RectilinearCheck(Point[] points)
        //{
        //    return (
        //        points[0].x == points[1].x &&
        //        points[0].y == points[2].y &&
        //        points[1].y == points[2].x &&
        //        points[2].x == points[3].x &&
        //        points[3].x == points[3].y
        //        );
        //}

        private bool ValidSquare(Point[] points)
        {
            points = points
                .OrderBy(point => point)
                .ToArray();

            var line1 = new Line { p1 = points[0], p2 = points[1] };
            var line2 = new Line { p1 = points[0], p2 = points[2] };
            var line3 = new Line { p1 = points[1], p2 = points[3] };
            var line4 = new Line { p1 = points[2], p2 = points[3] };

            var distance1 = line1.Length;
            var distance2 = line2.Length;

            if (distance1 != distance2)
            {
                return false;
            }

            var distance3 = line3.Length;

            if (distance2 != distance3)
            {
                return false;
            }

            var distance4 = line4.Length;

            if (distance3 != distance4)
            {
                return false;
            }

            if (line1.InnerAngleBetween(line2) != 90.0)
            {
                return false;
            }

            if (line1.InnerAngleBetween(line3) != 90.0)
            {
                return false;
            }

            if (line2.InnerAngleBetween(line4) != 90.0)
            {
                return false;
            }

            if (line3.InnerAngleBetween(line4) != 90.0)
            {
                return false;
            }

            return true;
        }

        public bool ValidSquare(int[] p1, int[] p2, int[] p3, int[] p4)
        {
            return ValidSquare (new Point[] { new Point(p1), new Point(p2), new Point(p3), new Point(p4) });
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var solution = new Solution();
            var result1 = solution.ValidSquare(new int[] { 0, 0 }, new int[] { 1, 1 }, new int[] { 1, 0 }, new int[] { 0, 1 });
            var result2 = solution.ValidSquare(new int[] { 1, 1 }, new int[] { 11, 11 }, new int[] { 1, 11 }, new int[] { 11, 1 });
            var result3 = solution.ValidSquare(new int[] { 1, 1 }, new int[] { 10, 10 }, new int[] { 1, 11 }, new int[] { 11, 1 });
            var result4 = solution.ValidSquare(new int[] { -1, 0 }, new int[] { 0, 1 }, new int[] { 1, 0 }, new int[] { 0, -1 });
            var result5 = solution.ValidSquare(new int[] { 1, 1 }, new int[] { 5, 3 }, new int[] { 3, 5 }, new int[] { 7, 7 });
            var result6 = solution.ValidSquare(new int[] { 0, 0 }, new int[] { 0, 0 }, new int[] { 0, 0 }, new int[] { 0, 0 });
        }
    }
}
