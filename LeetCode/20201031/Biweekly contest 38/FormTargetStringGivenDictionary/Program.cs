using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormTargetStringGivenDictionary
{
    class Program
    {
        // https://leetcode.com/contest/biweekly-contest-38/problems/number-of-ways-to-form-a-target-string-given-a-dictionary/

        // 1. To form the i'th character (0-indexed) of target:
        //      you can choose the k'th character of the j'th string in words, if target[i] = words[j][k]
        // 2. Once you use the kth character of the jth string of words:
        //      you can no longer use the xth character of any string in words, where x <= k.
        //      In other words, all characters to the left of or at index k become unusuable for every string.

        public class Slot
        {
            public int WordId { get; set; }
            public int CharacterId { get; set; }

            public Slot ()
            {
                WordId = -1;
                CharacterId = -1;
            }
        }

        public class Way
        {
            public Slot[] Slots { get; private set; }

            public Way(int slotsCount)
            {
                Slots = new Slot[slotsCount];
            }
        }

        public class Solution
        {
            public int NumWays(string[] words, string target)
            {
                var ways = new List<Way>();

                for (int i = 0; i < target.Length; i++)
                {
                    var targetChar = target[i];
                    var lastId = 0;

                    for (int j = 0; j < words.Length; j++)
                    {
                        var word = words[j];

                        for (int k = lastId; k < word.Length; k++)
                        {
                            if (word[k] == targetChar)
                            {
                                bool matchFound = false;

                                for (int l = 0; l < ways.Count; l++)
                                {
                                    var existingWay = ways[l];

                                    if ((existingWay.Slots[i].WordId == j) && (existingWay.Slots[i].CharacterId == k))
                                    {
                                        matchFound = true;
                                        break;
                                    }
                                }

                                if (!matchFound)
                                {
                                    var way = new Way()

                                    way.Slots[i].WordId = j;

                                }
                            }
                        }
                    }
                }

                return 0;
            }
        }

        static void Main(string[] args)
        {
        }
    }
}
