using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MirrorReflection
{
    // https://leetcode.com/problems/mirror-reflection/

    // There is a special square room with mirrors on each of the four walls.  
    //   Except for the southwest corner, there are receptors on each of the remaining corners, numbered 0, 1, and 2.
    // The square room has walls of length p, and a laser ray from the southwest corner first meets 
    //   the east wall at a distance q from the 0th receptor.
    // Return the number of the receptor that the ray meets first.  (It is guaranteed that the ray will meet a receptor eventually.)
    // 
    // Example 1:
    //   Input: p = 2, q = 1
    //   Output: 2
    //   Explanation: The ray meets receptor 2 the first time it gets reflected back to the left wall.

    public class Solution
    {
        public int MirrorReflection(int p, int q)
        {
            return MirrorReflectionApproach1(p, q);
            // return MirrorReflectionApproach2(p, q);
        }

        // Approach 1: Simulation
        // Intuition:
        //   The initial ray can be described as going from an origin(x, y) = (0, 0) in the direction(rx, ry) = (p, q). 
        //   From this, we can figure out which wall it will meet and where, and what the appropriate new ray will be 
        //   (based on reflection.) We keep simulating the ray until it finds it's destination.
        // Algorithm:
        //   The parameterized position of the laser after time t will be(x + rx* t, y + ry* t). 
        //   From there, we know when it will meet the east wall(if x + rx* t == p), and so on.
        //   For a positive(and nonnegligible) time t, it meets the next wall.
        // 
        //   We can then calculate how the ray reflects.If it hits an east or west wall, then rx *= -1, else ry *= -1.
        // 
        //   Care must be taken with floating point operations.
        // Complexity Analysis
        //   Time Complexity: O(p). We can prove(using Approach #2) that the number of bounces is bounded by this.
        //   Space Complexity: O(1).
        public int MirrorReflectionApproach1(int p, int q)
        {
            double EPS = 1e-6;

            bool close(double x1, double y1)
            {
                return Math.Abs(x1 - y1) < EPS;
            }

            double x = 0, y = 0;
            double rx = p, ry = q;

            // While it hasn't reached a receptor,...
            while (!(close(x, p) && (close(y, 0) || close(y, p))
                      || close(x, 0) && close(y, p)))
            {
                // Want smallest t so that some x + rx, y + ry is 0 or p
                // x + rxt = 0, then t = -x/rx etc.
                double t = 1e9;
                if ((-x / rx) > EPS) t = Math.Min(t, -x / rx);
                if ((-y / ry) > EPS) t = Math.Min(t, -y / ry);
                if (((p - x) / rx) > EPS) t = Math.Min(t, (p - x) / rx);
                if (((p - y) / ry) > EPS) t = Math.Min(t, (p - y) / ry);

                x += rx * t;
                y += ry * t;

                if (close(x, p) || close(x, 0)) rx *= -1;
                if (close(y, p) || close(y, 0)) ry *= -1;
            }

            if (close(x, p) && close(y, p)) return 1;
            return close(x, p) ? 0 : 2;
        }

        // Approach 2: Mathematical
        // Intuition and Algorithm
        //   Instead of modelling the ray as a bouncing line, model it as a straight line through reflections of the room.
        //   For example, if p = 2, q = 1, then we can reflect the room horizontally, and draw a straight line from (0, 0) to(4, 2). The ray meets the receptor 2, which was reflected from(0, 2) to(4, 2).
        //   In general, the ray goes to the first integer point(kp, kq) where k is an integer, and kp and kq are multiples of p.Thus, the goal is just to find the smallest k for which kq is a multiple of p.
        //   The mathematical answer is k = p / gcd(p, q).
        // Complexity Analysis
        //   Time Complexity: O(log P), the complexity of the gcd operation.
        //   Space Complexity: O(1).
        public int MirrorReflectionApproach2(int p, int q)
        {
            int GCD(int a, int b)
            {
                if (a == 0) return b;
                return GCD(b % a, a);
            }

            int gcd = GCD(p, q);

            p = (p / gcd) % 2;
            q = (q / gcd) % 2;

            if (p == 1)
            {
                if (q == 1)
                {
                    return 1;
                }

                return 0;
            }

            return 2;
        }

        // The idea is to think about a box that grows indefinitely to the top.
        public int MirrorReflectionApproach3(int p, int q)
        {
            int x = 0, y = 0;
            while (true)
            {
                y += q;

                // If left then right. If right then left.
                if (x == 0) x = p;
                else x = 0;

                // If we hited any corner.
                if (y % p == 0)
                {
                    if (y / p % 2 == 0) return 0;
                    else if (x == p) return 1;
                    else return 2;
                }
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var solution = new Solution();

            var result1 = solution.MirrorReflection(2, 1); // 2
        }
    }
}
