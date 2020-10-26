using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerfectSquareStoneGameIV
{
    public class Solution
    {
        public void PerfectSquaresBelow(int n, List<int> perfectSquares)
        {
            if (n == 1)
            {
                perfectSquares.Add(1);
            }
            
            for (int i = n; i > 0; )
            {
                var squareRoot = (int)Math.Floor(Math.Sqrt(i));

                if (squareRoot * squareRoot == i)
                {
                    i = squareRoot;
                    perfectSquares.Add(i);
                }
                else
                {
                    i--;
                }
            }

            return perfectSquares;
        }

        public bool WinnerSquareGame(int n)
        {
            var perfectSquares = PerfectSquaresBelow(n);
            return true;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var solution = new Solution();

            var numbers = 100;

            for (int i = 1; i <= numbers; i++)
            {
                var perfectSquares = solution.PerfectSquaresBelow(i);
            }
        }
    }
}
