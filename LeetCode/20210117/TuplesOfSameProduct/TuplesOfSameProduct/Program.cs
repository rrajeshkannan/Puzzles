using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TuplesOfSameProduct
{
    public class Solution1
    {
        public int TupleSameProduct(int[] nums)
        {
            var count = 0;

            for (int i = 0; i < nums.Length; i++)
            {
                for (int j = 0; j < nums.Length; j++)
                {
                    if (i == j)
                    {
                        continue;
                    }

                    for (int k = 0; k < nums.Length; k++)
                    {
                        if ((i == k) || (j == k))
                        {
                            continue;
                        }

                        for (int l = 0; l < nums.Length; l++)
                        {
                            if ((i == l) || (j == l) || (k == l))
                            {
                                continue;
                            }

                            if (nums[i] * nums[j] == nums[k] * nums[l])
                            {
                                count++;
                            }
                        }
                    }
                }
            }

            return count;
        }
    }

    public class Solution
    {
        public int TupleSameProduct(int[] nums)
        {
            int res = 0;

            Dictionary<int, int> map = new Dictionary<int, int>();

            for (int i = 0; i < nums.Length; i++)
            {
                for (int j = i + 1; j < nums.Length; j++)
                {
                    var product = nums[i] * nums[j];

                    if (map.TryGetValue(product, out var count))
                    {
                        res += count;
                    }

                    map[product] = ++count;
                }
            }

            return res * 8;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var solution = new Solution();

            var input1 = new int[] { 2, 3, 4, 6 };
            var output1 = solution.TupleSameProduct(input1);

            var input2 = new int[] { 1, 2, 4, 5, 10 };
            var output2 = solution.TupleSameProduct(input2);

            var input3 = new int[] { 2, 3, 4, 6, 8, 12 };
            var output3 = solution.TupleSameProduct(input3);

            var input4 = new int[] { 2, 3, 5, 7 };
            var output4 = solution.TupleSameProduct(input4);

            var input5 = new int[] { 8, 448, 264, 525, 435, 486, 378, 308, 144, 75, 196, 110, 231, 120, 39, 288, 50, 616, 140, 261, 272, 783, 225, 552, 598, 30, 128, 570, 322, 77, 340, 19, 72, 224, 294, 390, 276, 87, 238, 180, 80, 33, 68, 210, 725, 243, 696, 198, 208, 46, 21, 58, 360, 170, 190, 510, 375, 551, 348, 396, 377, 69, 84, 300, 572, 468, 160, 24, 34, 667, 29, 64, 253, 115, 690, 100, 870, 754, 102, 1, 11, 312, 609, 161, 493, 450, 342, 133, 588, 48, 152, 10, 42, 273, 440, 728, 65, 98, 5, 23, 250, 242, 38, 182, 26, 648, 99, 357, 400, 275, 187, 483, 414, 323, 408, 105, 230, 520, 750, 4, 500, 32, 286, 418, 189, 638, 528, 234, 315, 96, 352, 812, 232, 40, 3, 130, 184, 17, 15, 324, 240, 392, 7, 174, 270, 416, 513, 25, 203, 221, 399, 475, 9, 54, 476, 442, 406, 840, 12, 504, 114, 675, 624, 621, 56, 405, 125, 119, 136, 506, 702, 364, 70, 60, 228, 20, 85, 575, 135, 117, 78, 171, 156, 55, 299, 462, 116, 780, 52, 432, 165, 88, 325, 338, 391, 546, 522, 209, 176, 108 };
            var output5 = solution.TupleSameProduct(input5); // 251424
        }
    }
}