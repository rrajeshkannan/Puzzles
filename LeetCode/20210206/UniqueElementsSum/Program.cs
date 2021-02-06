using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniqueElementsSum
{
    public class Solution
    {
        public int SumOfUnique(int[] nums)
        {
            int length = nums.Length;

            if (length <= 0)
            {
                return 0;
            }

            var ordered = nums
                .OrderBy(num => num)
                .ToArray();

            var lastElement = ordered[0];
            var sum = lastElement;
            var duplicate = false;

            for (int i = 1; i < length; i++)
            {
                var currentElement = ordered[i];

                if (lastElement == currentElement)
                {
                    if (!duplicate)
                    {
                        sum -= lastElement;
                        duplicate = true;
                    }
                }
                else
                {
                    duplicate = false;
                    sum += currentElement;
                }

                lastElement = currentElement;
            }

            return sum;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var solution = new Solution();

            var input1 = new int[] { 1, 2, 3, 2 };
            var output1 = solution.SumOfUnique(input1);

            var input2 = new int[] { 1, 1, 1, 1, 1 };
            var output2 = solution.SumOfUnique(input2);

            var input3 = new int[] { 1, 2, 3, 4, 5 };
            var output3 = solution.SumOfUnique(input3);
        }
    }
}
