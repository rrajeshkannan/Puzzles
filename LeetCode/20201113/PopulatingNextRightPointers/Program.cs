using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PopulatingNextRightPointers
{
    // Definition for a Node.
    public class Node
    {
        public int val;
        public Node left;
        public Node right;
        public Node next;

        public Node() { }

        public Node(int _val)
        {
            val = _val;
        }

        public Node(int _val, Node _left, Node _right, Node _next)
        {
            val = _val;
            left = _left;
            right = _right;
            next = _next;
        }

        public override string ToString()
        {
            return val.ToString();
        }
    }

    public class Solution
    {
        public void Connect(Queue<Node> queue)
        {
            if (!queue.Any())
            {
                return;
            }

            var childrenQueue = new Queue<Node>();
            Node previous = null;

            while (queue.Any())
            {
                Node current = queue.Dequeue();

                if (current.left != null)
                {
                    childrenQueue.Enqueue(current.left);
                }

                if (current.right != null)
                {
                    childrenQueue.Enqueue(current.right);
                }

                if (previous != null)
                {
                    previous.next = current;
                }

                previous = current;
            }

            Connect(childrenQueue);
        }

        public Node Connect(Node root)
        {
            if (root != null)
            {
                Connect(new Queue<Node>(new Node[] { root }));
            }

            return root;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var solution = new Solution();

            var root1 = new Node(
                1,
                new Node(
                    2,
                    new Node(4),
                    new Node(5),
                    null),
                new Node(
                    3,
                    new Node(6),
                    new Node(7),
                    null),
                null);

            var result1 = solution.Connect(root1);
        }
    }
}
