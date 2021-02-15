using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gemstones
{
    class Program
    {
        // https://www.hackerrank.com/challenges/gem-stones/problem

        // Complete the gemstones function below.
        static int gemstones(string[] arr)
        {
            const char lowerA = 'a';

            var stones = Enumerable.Range(0, 26)
                .ToDictionary(number => number, number => new int[arr.Length]);

            for (int i = 0; i < arr.Length; i++)
            {
                var rock = arr[i];

                for (int j = 0; j < rock.Length; j++)
                {
                    var stone = rock[j] - lowerA;
                    stones[stone][i]++;
                }
            }

            return stones.Values
                .Where(stoneCountInRocks => stoneCountInRocks.All(stoneCountInRock => stoneCountInRock > 0))
                .Count();
        }

        static void Main(string[] args)
        {
            var input1 = new string[] { "abcdde", "baccd", "eeabg" };
            var output1 = gemstones(input1); // 2
        }
    }
}
