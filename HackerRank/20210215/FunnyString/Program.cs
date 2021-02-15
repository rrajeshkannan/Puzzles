using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunnyString
{
    class Program
    {
        // https://www.hackerrank.com/challenges/funny-string/problem

        // Complete the funnyString function below.
        static string funnyString(string s)
        {
            var length = s.Length;

            if (length <= 2)
            {
                return "Funny";
            }

            var iterations = (length - 1) / 2;

            for (int front = 0; front < iterations; front++)
            {
                var frontDifference = Math.Abs(s[front] - s[front + 1]);
                var rear = length - 1 - front;
                var rearDifference = Math.Abs(s[rear] - s[rear - 1]);

                if (frontDifference != rearDifference)
                {
                    return "Not Funny";
                }
            }

            return "Funny";
        }

        static void Main(string[] args)
        {
            var output1 = funnyString("lmnop"); // Funny
            var output2 = funnyString("acxz"); // Funny
            var output3 = funnyString("bcxz"); // Not Funny
        }
    }
}
