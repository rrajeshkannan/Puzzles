using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HouseRobberIII
{
    // https://leetcode.com/explore/challenge/card/november-leetcoding-challenge/567/week-4-november-22nd-november-28th/3541/
    // The thief has found himself a new place for his thievery again. 
    //
    // There is only one entrance to this area, called the "root." Besides the root, each house has one and only one parent house. 
    // After a tour, the smart thief realized that "all houses in this place forms a binary tree". 
    // It will automatically contact the police if two directly-linked houses were broken into on the same night.
    //
    // Determine the maximum amount of money the thief can rob tonight without alerting the police.
    // 
    // Example 1:
    // Input: [3,2,3,null,3,null,1]
    //      3*
    //     / \
    //    2   3
    //     \   \ 
    //      3*  1*
    // Output: 7
    // Explanation: Maximum amount of money the thief can rob = 3 + 3 + 1 = 7.
    // 
    // Example 2:
    // Input: [3,4,5,1,3,null,1]
    //      3
    //     / \
    //    4*  5*
    //   / \   \ 
    //  1   3   1
    // Output: 9
    // Explanation: Maximum amount of money the thief can rob = 4 + 5 = 9.

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

    // Solution from: https://leetcode.com/problems/house-robber-iii/discuss/946193/2-Solution-or-Top-Down-DP-with-Map-and-Array
    // Idea:
    // At every house node we can either rob it or skip it.
    // rob current house node:
    //   -> rob amount is current house node value (meaning money) + rob(root.left.left) + rob(root.left.right) + rob(root.right.left) + rob(root.right.right);
    // skip current house node:
    //   -> rob(root.left) + rob(root.right));
    // Take maximum of above two condition.
    // Detailed Video Explanation - https://www.youtube.com/watch?v=FYho45iq68Y
    //class Solution
    //{
    //    public int Rob(TreeNode root)
    //    {
    //        int[] result = RobSub(root);
    //        return Math.Max(result[0], result[1]);
    //    }

    //    private int[] RobSub(TreeNode root)
    //    {
    //        if (root == null)
    //            return new int[2];

    //        int[] left = RobSub(root.left);
    //        int[] right = RobSub(root.right);
    //        int[] result = new int[2];

    //        // 0-index=not including, 1-index=including
    //        result[0] = Math.Max(left[0], left[1]) + Math.Max(right[0], right[1]);
    //        result[1] = root.val + left[0] + right[0];

    //        return result;
    //    }
    //}
    
    class Solution
    {
        public int Rob(TreeNode root)
        {
            Rob(root, out int rob, out int noRob);

            return Math.Max(rob, noRob);
        }

        private void Rob(TreeNode root, out int rob, out int noRob)
        {
            rob = 0;
            noRob = 0;

            if (root == null)
            {
                return;
            }

            Rob(root.left, out int robLeft, out int noRobLeft);
            Rob(root.right, out int robRight, out int noRobRight);

            // do not rob current, rob children
            // rob children -> means, summing the maximum result for left and right subtrees
            noRob = Math.Max(robLeft, noRobLeft) + Math.Max(robRight, noRobRight);

            // rob current, followed by do not rob children
            rob = root.val + noRobLeft + noRobRight;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var solution = new Solution();

            var root1 = new TreeNode(
                3,
                new TreeNode(
                    2,
                    null,
                    new TreeNode(3)),
                new TreeNode(
                    3,
                    null,
                    new TreeNode(1)));
            var result1 = solution.Rob(root1); // 7

            var root2 = new TreeNode(
                3,
                new TreeNode(
                    4,
                    new TreeNode(1),
                    new TreeNode(3)),
                new TreeNode(
                    5,
                    null,
                    new TreeNode(1)));
            var result2 = solution.Rob(root2); // 9

            var root3 = new TreeNode(
                4,
                new TreeNode(
                    1,
                    new TreeNode(
                        2,
                        new TreeNode(3)
                        )
                    )
                );
            var result3 = solution.Rob(root3); // 7 {4 + 3}
        }
    }

    public class WrongSolution
    {
        public int Rob(TreeNode root)
        {
            var sums = new int[] { 0, 0 };

            void Traverse(TreeNode node, int index)
            {
                if (node == null)
                {
                    return;
                }

                sums[index] += node.val;
                index = (index + 1) % 2;

                Traverse(node.left, index);
                Traverse(node.right, index);
            }

            Traverse(root, 0);
            return (sums[0] > sums[1]) ? sums[0] : sums[1];
        }
    }
}