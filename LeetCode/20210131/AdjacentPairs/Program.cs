using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdjacentPairs
{
    // https://leetcode.com/contest/weekly-contest-226/problems/restore-the-array-from-adjacent-pairs/

    public class Node
    {
        public Node Predecessor { get; set; }
        public Node Successor { get; set; }

        public int Value { get; set; }

        public override string ToString()
            => $"{{{Predecessor?.Value.ToString() ?? "E"}<- {Value} ->{Successor?.Value.ToString() ?? "E"}}}";
    }

    public class Solution
    {
        public int[] RestoreArray(int[][] adjacentPairs)
        {
            var pairs = new Dictionary<int, Node>();

            foreach (var adjacentPair in adjacentPairs)
            {
                var (first, second) = (adjacentPair[0], adjacentPair[1]);

                if (pairs.TryGetValue(first, out var existing))
                {
                    if (existing.Predecessor == null)
                    {
                        existing.Predecessor = second;
                    }
                    else if (existing.Successor == null)
                    {
                        existing.Successor = second;
                    }
                    else
                    {
                        throw new InvalidOperationException("shouldn't be");
                    }
                }
                else
                {
                    existing = new Node() { Value = first, Predecessor = second };

                    pairs.Add(first, existing);
                }
            }

            List<Node> headOrTail = new List<Node>();

            foreach (var pair in pairs.Values)
            {
                if (pair.Successor == null)
                {
                    headOrTail.Add(pair);
                }
            }



            return null;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var solution = new Solution();
            var input1 = new int[][]
            {
                new int[]{ 2,1 },
                new int[]{ 3,4},
                new int[]{3,2 },
            };
            var output1 = solution.RestoreArray(input1);

//  [2,1]
//	1 < -2-> null

//    null < -1-> 2
//[3, 4]

//    4 < -3-> null

//    null < -4-> 3
//[3, 2]

//    3 already there

//    2 already there


//    2 does not have successor : but 3 has predecessor as 4

//        3's predecessor 4 does not have predecessor

//            1 < -2-> 3

//    change predecessor of 3

//        2 < -3-> 4





//[2, 1]

//    null < -2-> 1

//    2 < -1-> null
//[3, 4]

//    null < -3-> 4

//    3 < -4-> null
//[3, 2]

//    3 already there

//    2 already there


//    3 has successor as 4

//    and

//    2 has successor as 1


//    Can we make 4 as predecessor of 4 ?
//    In other words, is it possible to find 4 or any of 4's successors does not have any successor?

//    Yes
//    Reverse the linked list



//null < -5->4->3
//3->4->5->null

//5 < -4-> 3
//null < -5-> 4


            //var input = new int[][]
            //{
            //    new int[]{ },
            //    new int[]{ },
            //    new int[]{ },
            //    new int[]{ },
            //};
            //var output = solution.RestoreArray(input);
        }
    }
}
