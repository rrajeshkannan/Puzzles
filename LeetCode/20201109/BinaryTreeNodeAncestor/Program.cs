using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTreeNodeAncestor
{
    // https://leetcode.com/explore/challenge/card/november-leetcoding-challenge/565/week-2-november-8th-november-14th/3525/

    // Given the root of a binary tree
    //   find the maximum value V for which there exist different nodes A and B,
    //   where V = |A.val - B.val| and A is an ancestor of B.
    // A node A is an ancestor of B if either:
    //   any child of A is equal to B
    //   or any child of A is an ancestor of B.

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
        public int MaxAncestorDiff(TreeNode root)
        {
            return MaxAncestorDiff(root, out int? minDescendant);
        }

        public int MaxAncestorDiff(TreeNode root, out int? minDescendant)
        {
            if (root == null)
            {
                minDescendant = null;
                return 0;
            }

            var maxAncestorDiff = Math.Max(
                MaxAncestorDiff(root.left, out int? leftMinDescendant),
                MaxAncestorDiff(root.right, out int? rightMinDescendant));

            if (leftMinDescendant.HasValue)
            {
                if (rightMinDescendant.HasValue)
                {
                    minDescendant = Math.Min(leftMinDescendant.Value, rightMinDescendant.Value);
                }
                else
                {
                    minDescendant = leftMinDescendant;
                }
            }
            else
            {
                minDescendant = rightMinDescendant;
            }

            if (!minDescendant.HasValue)
            {
                minDescendant = root.val;
                return 0;
            }
            else
            {
                maxAncestorDiff = Math.Max(maxAncestorDiff, Math.Abs(root.val - minDescendant.Value));
                minDescendant = Math.Min(root.val, minDescendant.Value);

                return maxAncestorDiff;
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var solution = new Solution();

            var root1 = new TreeNode(
                8,
                new TreeNode(
                    3,
                    new TreeNode(1),
                    new TreeNode(
                        6, new TreeNode(4), new TreeNode(7))),
                new TreeNode(
                    10,
                    null,
                    new TreeNode(
                        14, new TreeNode(13))));
            var result1 = solution.MaxAncestorDiff(root1); // 7

            var root2 = new TreeNode(
                1,
                null,
                new TreeNode(
                    2,
                    null,
                    new TreeNode(
                        0, new TreeNode(3))));
            var result2 = solution.MaxAncestorDiff(root2); // 3

            var root3 = new TreeNode(1);
            var result3 = solution.MaxAncestorDiff(root3); // 0
        }
    }
}
