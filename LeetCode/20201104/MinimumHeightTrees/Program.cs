using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace MinimumHeightTrees
{
    // https://leetcode.com/explore/challenge/card/november-leetcoding-challenge/564/week-1-november-1st-november-7th/3519/

    // A tree is an undirected graph in which any two vertices are connected by exactly one path. 
    // In other words, any connected graph without simple cycles is a tree.
    // 
    // Given a tree of 
    //   n nodes labelled from 0 to n - 1, 
    //   and an array of n - 1 edges 
    //   where edges[i] = [ai, bi] indicates that there is an undirected edge between the two nodes ai and bi in the tree, 
    //   you can choose any node of the tree as the root. 
    // When you select a node x as the root, the result tree has height h. 
    // Among all possible rooted trees, those with minimum height (i.e. min(h)) are called minimum height trees (MHTs).
    // 
    // Return a list of all MHTs' root labels. You can return the answer in any order.
    // 
    // The height of a rooted tree is the number of edges on the longest downward path between the root and a leaf.

    public class TreeNode
    {
        public int Label { get; set; }
        public List<TreeNode> Edges { get; set; } = new List<TreeNode>();
        public Dictionary<int, int> ChildDepth { get; set; } = new Dictionary<int, int>();

        public TreeNode(int label) => Label = label;

        public override string ToString() => this.Label.ToString();

        public int Depth() => 
            Depth(new HashSet<int>() { this.Label });

        public int Depth(HashSet<int> visited)
        {
            var maxDepth = 0;

            foreach (var child in this.Edges)
            {
                // if (visited.Contains(child.Label))
                // -> edges are undirected and tree is acyclic
                //    -> so, the target node can only be such that it is already visited
                //    -> and so, no need to continue treading this path further

                if (!visited.Contains(child.Label))
                {
                    visited.Add(child.Label);

                    if (!ChildDepth.TryGetValue(child.Label, out int depthOfSubtree))
                    {
                        depthOfSubtree = child.Depth(visited);
                        ChildDepth.Add(child.Label, depthOfSubtree);
                    }

                    // The height of a rooted tree is the number of edges on the longest downward path between the root and a leaf.
                    if (maxDepth < depthOfSubtree)
                    {
                        maxDepth = depthOfSubtree;
                    }
                }
            }

            // +1 - for this node
            return maxDepth + 1;
        }
    }

    public class Solution
    {
        public IEnumerable<TreeNode> FormulateTree(int n, int[][] edges)
        {
            var tree = new TreeNode[n];

            for (int i = 0; i < n; i++)
            {
                tree[i] = new TreeNode(i);
            }

            for (int i = 0; i < edges.Length; i++)
            {
                if (!edges[i].Any())
                {
                    continue;
                }

                var left = edges[i][0];
                var right = edges[i][1];

                var leftNode = tree[left];
                var rightNode = tree[right];
                
                leftNode.Edges.Add(rightNode);
                rightNode.Edges.Add(leftNode);
            }

            return tree;
        }

        public IList<int> FindMinHeightTrees(int n, int[][] edges)
        {
            //var stopwatch1 = new Stopwatch();
            //var stopwatch2 = new Stopwatch();
            //var stopwatch3 = new Stopwatch();

            //stopwatch1.Start();

            //stopwatch2.Start();

            // 1. Formulate tree
            var tree = FormulateTree(n, edges);
            
            //stopwatch2.Stop();
            //stopwatch3.Start();

            var minimumHeightTreeRoots = new List<int>();
            var minimumHeight = Int32.MaxValue;

            // 2. Assume a node as root node and measure the height of tree
            // 3. Continue with every other node
            foreach (var root in tree)
            {
                var depth = root.Depth();

                if (minimumHeight == depth)
                {
                    // another tree with same minimum height -> add it
                    minimumHeightTreeRoots.Add(root.Label);
                }
                else if (minimumHeight > depth)
                {
                    // found a new minimum height -> discard already found lists and start considering new ones
                    minimumHeight = depth;
                    minimumHeightTreeRoots = new List<int> { root.Label };
                }
            }

            //stopwatch3.Stop();
            //stopwatch1.Stop();

            //Console.WriteLine("FormulateTree: {0}", stopwatch2.ElapsedMilliseconds);
            //Console.WriteLine("FindMinHeightTrees: {0}", stopwatch3.ElapsedMilliseconds);
            //Console.WriteLine("FindMinHeightTrees-Total: {0}", stopwatch1.ElapsedMilliseconds);

            return minimumHeightTreeRoots;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var solution = new Solution();

            var edges1 = new int[][]
            {
                new int[] {1, 0},
                new int[] {1, 2},
                new int[] {1, 3},
            };
            var result1 = solution.FindMinHeightTrees(4, edges1); // [1]

            var edges2 = new int[][]
            {
                new int[] {3,0},
                new int[] {3,1},
                new int[] {3,2},
                new int[] {3,4},
                new int[] {5,4},
            };
            var result2 = solution.FindMinHeightTrees(6, edges2); // [3,4]

            var edges3 = new int[][]
            {
                new int[]{},
            };
            var result3 = solution.FindMinHeightTrees(1, edges3); // [0]

            var edges4 = new int[][]
            {
                new int[]{0, 1},
            };
            var result4 = solution.FindMinHeightTrees(2, edges4); // [0,1]

            var edges5 = TestData.GetTestInput5();
            var result5 = solution.FindMinHeightTrees(edges5.Length + 1, edges5);

            var edges6 = TestData.GetTestInput6();
            var result6 = solution.FindMinHeightTrees(edges6.Length + 1, edges6);

            var edges7 = new int[][]
            {
                new int[] {1,0},
                new int[] {1,2},
                new int[] {1,3},
            };
            var result7 = solution.FindMinHeightTrees(4, edges7);

            Console.ReadKey();
        }
    }

    // Most optimum solution below - as picked from leetcode site
    //public class Solution
    //{
    //    public IList<int> FindMinHeightTrees(int n, int[][] edges)
    //    {
    //        if (n < 2)
    //        {
    //            var result = new List<int>();
    //            for (var i = 0; i < n; i++)
    //            {
    //                result.Add(i);
    //            }

    //            return result;
    //        }

    //        var neighbours = new List<int>[n];
    //        for (var i = 0; i < n; i++)
    //        {
    //            neighbours[i] = new List<int>();
    //        }

    //        foreach (var edge in edges)
    //        {
    //            var start = edge[0];
    //            var end = edge[1];
    //            neighbours[start].Add(end);
    //            neighbours[end].Add(start);
    //        }

    //        var leaves = new List<int>();
    //        for (var i = 0; i < n; i++)
    //        {
    //            if (neighbours[i].Count == 1)
    //            {
    //                leaves.Add(i);
    //            }
    //        }

    //        int remainingNodes = n;
    //        while (remainingNodes > 2)
    //        {
    //            remainingNodes = remainingNodes - leaves.Count;
    //            var newLeaves = new List<int>();
    //            foreach (var leaf in leaves)
    //            {
    //                var toremoveFrom = neighbours[leaf];
    //                foreach (var node in toremoveFrom)
    //                {
    //                    neighbours[node].Remove(leaf);
    //                    if (neighbours[node].Count == 1)
    //                    {
    //                        newLeaves.Add(node);
    //                    }
    //                }
    //            }

    //            leaves = newLeaves;
    //        }

    //        return leaves;
    //    }
    //}
}
