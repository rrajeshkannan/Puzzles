using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTreeDepth
{
    // https://leetcode.com/explore/challenge/card/october-leetcoding-challenge/562/week-4-october-22nd-october-28th/3504/

    // Definition for a binary tree node.
    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
        {
            this.val = val;
            this.left = left;
            this.right = right;
        }

        public override string ToString()
        {
            return val.ToString();
        }
    }

    public class Solution
    {
        // Given a binary tree, find its minimum depth.
        // The minimum depth is the number of nodes along the shortest path from the root node down to the nearest leaf node.
        // Note: A leaf is a node with no children.
        public int MinDepth(TreeNode root)
        {
            if (root == null)
            {
                // cannot go further, also, its parent has at least one children, so, 
                // terminate and return 0 to not consider treading this path
                return 0;
            }

            if ((root.left == null) && (root.right == null))
            {
                // "root" is a leaf node, since it has no children
                // so, can consider the path leading until "root"
                return 1;
            }

            // depth-first traversal
            var leftDepth = MinDepth(root.left);
            var rightDepth = MinDepth(root.right);

            int minDepth;

            if (leftDepth == 0)
            {
                // do not proceed further on this path
                minDepth = rightDepth;
            }
            else if (rightDepth == 0)
            {
                // do not proceed further on this path
                minDepth = leftDepth;
            }
            else
            {
                // When directions in both left and right are valid, consider the shortest path (smallest depth)
                minDepth = Math.Min(leftDepth, rightDepth);
            }

            return 1 + minDepth;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var solution = new Solution();

            var rootNode1 = Input1();
            var minDepth1 = solution.MinDepth(rootNode1); // 5
            Console.WriteLine(minDepth1);

            var rootNode2 = Input2();
            var minDepth2 = solution.MinDepth(rootNode2); // 2
            Console.WriteLine(minDepth2);

            var rootNode3 = Input3();
            var minDepth3 = solution.MinDepth(rootNode3); // 3
            Console.WriteLine(minDepth3);

            var rootNode4 = Input4();
            var minDepth4 = solution.MinDepth(rootNode4); // 3
            Console.WriteLine(minDepth4);

            var rootNode5 = Input5();
            var minDepth5 = solution.MinDepth(rootNode5); // 0
            Console.WriteLine(minDepth5);

            Console.ReadKey();
        }

        private static TreeNode Input1()
        {
            var node6 = new TreeNode(6);
            var node5 = new TreeNode(5, null, node6);
            var node4 = new TreeNode(4, null, node5);
            var node3 = new TreeNode(3, null, node4);
            var node2 = new TreeNode(2, null, node3);

            return node2;
        }

        private static TreeNode Input2()
        {
            var node15 = new TreeNode(15);
            var node27 = new TreeNode(27);
            var node20 = new TreeNode(20, node15, node27);
            var node9 = new TreeNode(9);
            var node3 = new TreeNode(3, node9, node20);

            return node3;
        }

        private static TreeNode Input3()
        {
            var node7 = new TreeNode(7);
            var node6 = new TreeNode(6, null, node7);
            var node4 = new TreeNode(4);
            var node5 = new TreeNode(5, node4, node6);
            var node1 = new TreeNode(1);
            var node2 = new TreeNode(2, node1);
            var node3 = new TreeNode(3, node2, node5);

            return node3;
        }

        private static TreeNode Input4()
        {
            var node8 = new TreeNode(8);
            var node6 = new TreeNode(6);
            var node7 = new TreeNode(7, node6, node8);

            var node1 = new TreeNode(1);
            var node4 = new TreeNode(4);
            var node3 = new TreeNode(3, node1, node4);

            var node5 = new TreeNode(5, node3, node7);

            return node5;
        }

        private static TreeNode Input5()
        {
            return null;
        }
    }
}
