using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecodeXorArray
{
    public class Solution
    {
        public int[] Decode(int[] encoded, int first)
        {
            var result = new int[encoded.Length + 1];
            result[0] = first;

            for (int i = 0; i < encoded.Length; i++)
            {
                result[i + 1] = result[i] ^ encoded[i];
            }

            return result;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var solution = new Solution();

            var input1 = new int[] { 1, 2, 3 };
            var output1 = solution.Decode(input1, 1);

            var input2 = new int[] { 6, 2, 7, 3 };
            var output2 = solution.Decode(input2, 4);
        }
    }
}
