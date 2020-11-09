using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTreeTilt
{
    // https://leetcode.com/explore/challenge/card/november-leetcoding-challenge/565/week-2-november-8th-november-14th/3524/

    // Given the root of a binary tree, return the sum of every tree node's tilt.
    // The tilt of a tree node is the absolute difference between the sum of all left subtree node values and all right subtree node values.
    // If a node does not have a left child, then the sum of the left subtree node values is treated as 0. 
    // The rule is similar if there the node does not have a right child.

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
    }

    public class Solution
    {
        public int FindTilt(TreeNode root)
        {
            return FindTilt(root, out int totalValue);
        }

        public int FindTilt(TreeNode root, out int totalValue)
        {
            totalValue = 0;

            if (root == null)
            {
                return 0;
            }

            var leftTotalTilt = FindTilt(root.left, out int leftTotalValue);
            var rightTotalTilt = FindTilt(root.right, out int rightTotalValue);

            totalValue = leftTotalValue + rightTotalValue + root.val;

            var selfTilt = Math.Abs(leftTotalValue - rightTotalValue);
            root.val = selfTilt;
            var totalTilt = leftTotalTilt + rightTotalTilt + selfTilt;

            return totalTilt;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var solution = new Solution();

            var node1 = new TreeNode(
                1, 
                new TreeNode(2), 
                new TreeNode(3));
            var result1 = solution.FindTilt(node1);

            var node2 = new TreeNode(4,
                new TreeNode(
                    2, new TreeNode(3), new TreeNode(5)),
                new TreeNode(
                    9, null, new TreeNode(7)));
            var result2 = solution.FindTilt(node2);

            var node3 = new TreeNode(
                21,
                new TreeNode(
                    7, new TreeNode(
                        1, new TreeNode(3), new TreeNode(3)),
                    new TreeNode(1)),
                new TreeNode(
                    14, new TreeNode(2), new TreeNode(2)));
            var result3 = solution.FindTilt(node3);
        }
    }
}
