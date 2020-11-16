using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BST_Range_Sum
{
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

    //public class Solution
    //{
    //public int RangeSumBST(TreeNode root, int low, int high)
    //{
    //    if (root == null)
    //    {
    //        return 0;
    //    }

    //    var sum = ((root.val >= low) && (root.val <= high)) ? root.val : 0;

    //    return sum + RangeSumBST(root.left, low, high) + RangeSumBST(root.right, low, high);
    //}
    //}

    public class Solution
    {
        private int _low;
        private int _high;
        private int _sum;

        public int RangeSumBST(TreeNode root, int low, int high)
        {
            _low = low;
            _high = high;
            _sum = 0;
            void Traverse(TreeNode node)
            {
                if (node == null) return;

                if (low <= node.val && node.val <= _high)
                {
                    _sum += node.val;
                    Traverse(node.right);
                    Traverse(node.left);
                }
                else if (node.val >= _high)
                {
                    Traverse(node.left);
                }
                else if (node.val <= _low)
                {
                    Traverse(node.right);
                }
            }

            Traverse(root);
            return _sum;
        }
    }

    //public class Solution
    //{
    //    int sum = 0;
    //    public int RangeSumBST(TreeNode root, int L, int R)
    //    {
    //        InOrder(root, L, R);
    //        return sum;
    //    }

    //    private void InOrder(TreeNode node, int L, int R)
    //    {
    //        if (node == null)
    //            return;

    //        if (node.val >= L && node.val <= R)
    //        {
    //            sum += node.val;
    //            if (node.val <= R)
    //                InOrder(node.left, L, R);
    //            if (node.val >= L)
    //                InOrder(node.right, L, R);

    //        }
    //        else if (node.val < L)
    //        {
    //            InOrder(node.right, L, R);
    //        }
    //        else if (node.val > R)
    //        {
    //            InOrder(node.left, L, R);
    //        }
    //    }
    //}

    class Program
    {
        static void Main(string[] args)
        {
            var solution = new Solution();

            var root1 = new TreeNode(
                10,
                new TreeNode(
                    5,
                    new TreeNode(3),
                    new TreeNode(7)),
                new TreeNode(
                    15,
                    null,
                    new TreeNode(18)));
            var result1 = solution.RangeSumBST(root1, 7, 15); // 32

            var root2 = new TreeNode(
                10,
                new TreeNode(
                    5,
                    new TreeNode(
                        3,
                        new TreeNode(1)),
                    new TreeNode(
                        7,
                        new TreeNode(6))),
                new TreeNode(
                    15,
                    new TreeNode(13),
                    new TreeNode(18)));
            var result2 = solution.RangeSumBST(root2, 6, 10); // 23
        }
    }
}
