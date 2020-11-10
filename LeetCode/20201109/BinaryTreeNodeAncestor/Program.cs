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
            if (root == null)
            {
                return 0;
            }

            return MaxAncestorDiff(root, out int minDescendant, out int maxDescendant);
        }

        public int MaxAncestorDiff(TreeNode root, out int minDescendant, out int maxDescendant)
        {
            var leftPresent = root.left != null;
            var rightPresent = root.right != null;

            int leftMaxAncestorDiff = 0;
            int rightMaxAncestorDiff = 0;

            int maxDescendantBelow;
            int? minDescendantBelow;

            if (leftPresent)
            {
                leftMaxAncestorDiff = MaxAncestorDiff(root.left, out int leftMinDescendant, out int leftMaxDescendant);

                if (rightPresent)
                {
                    rightMaxAncestorDiff = MaxAncestorDiff(root.right, out int rightMinDescendant, out int rightMaxDescendant);

                    minDescendantBelow = Math.Min(leftMinDescendant, rightMinDescendant);
                    maxDescendantBelow = Math.Max(leftMaxDescendant, rightMaxDescendant);
                }
                else
                {
                    minDescendantBelow = leftMinDescendant;
                    maxDescendantBelow = leftMaxDescendant;
                }
            }
            else if (rightPresent)
            {
                rightMaxAncestorDiff = MaxAncestorDiff(root.right, out int rightMinDescendant, out int rightMaxDescendant);

                minDescendantBelow = rightMinDescendant;
                maxDescendantBelow = rightMaxDescendant;
            }
            else
            {
                minDescendantBelow = null;
                maxDescendantBelow = 0;
            }

            int maxAncestorDiff;

            if (minDescendantBelow.HasValue)
            {
                minDescendant = Math.Min(root.val, minDescendantBelow.Value);
                maxDescendant = Math.Max(root.val, maxDescendantBelow);

                maxAncestorDiff = Math.Max(Math.Abs(root.val - minDescendantBelow.Value), Math.Abs(root.val - maxDescendantBelow));
                maxAncestorDiff = Math.Max(maxAncestorDiff, leftMaxAncestorDiff);
                maxAncestorDiff = Math.Max(maxAncestorDiff, rightMaxAncestorDiff);
            }
            else
            {
                // both side descendants - left and right - are not available
                minDescendant = root.val;
                maxDescendant = root.val;
                maxAncestorDiff = 0;
            }

            return maxAncestorDiff;
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

            var root4 = new TreeNode(3, new TreeNode(1));
            var result4 = solution.MaxAncestorDiff(root4); // 2

            var root5 = new TreeNode(3, new TreeNode(2), new TreeNode(1));
            var result5 = solution.MaxAncestorDiff(root5); // 2

            var root6 = new TreeNode(
                2,
                null,
                new TreeNode(
                    0,
                    null,
                    new TreeNode(
                        4,
                        null,
                        new TreeNode(
                            3,
                            null,
                            new TreeNode(1)))));
            var result6 = solution.MaxAncestorDiff(root6); // 4
        }
    }
}
