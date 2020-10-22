using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Messaging;

class Node
{
    public Node left, right;
    public int data;
    public Node(int data)
    {
        this.data = data;
        left = right = null;
    }
}

static class TreeTraversals
{
    //public static IEnumerable<T> BreadthFirstTopDownTraversal<T>(this T root, Func<T, IEnumerable<T>> children) where T : Node
    //{
    //    if (root != null)
    //    {
    //        var q = new Queue<T>();
    //        q.Enqueue(root);
    //        while (q.Count > 0)
    //        {
    //            T current = q.Dequeue();
    //            yield return current;
    //            foreach (var child in children(current))
    //                q.Enqueue(child);
    //        }
    //    }
    //}
}

class Solution
{
    public static IEnumerable<T> BreadthFirstTopDownTraversal<T>(T root, Func<T, IEnumerable<T>> children) where T : Node
    {
        if (root != null)
        {
            var q = new Queue<T>();
            q.Enqueue(root);
            while (q.Count > 0)
            {
                T current = q.Dequeue();
                yield return current;
                foreach (var child in children(current))
                    q.Enqueue(child);
            }
        }
    }

    static void levelOrder(Node root)
    {
        //Write your code here

        foreach (var node in BreadthFirstTopDownTraversal(root, node => (new[] { node.left, node.right }).Where(child => child != null)))
        {
            Console.Write("{0} ", node.data);
        }
    }

    static Node insert(Node root, int data)
    {
        if (root == null)
        {
            return new Node(data);
        }
        else
        {
            Node cur;
            if (data <= root.data)
            {
                cur = insert(root.left, data);
                root.left = cur;
            }
            else
            {
                cur = insert(root.right, data);
                root.right = cur;
            }
            return root;
        }
    }
    static void Main(String[] args)
    {
        //Node root = null;
        //int T = Int32.Parse(Console.ReadLine());
        //while (T-- > 0)
        //{
        //    int data = Int32.Parse(Console.ReadLine());
        //    root = insert(root, data);
        //}

        int i = 1;

        Console.WriteLine("Traversal-{0}",  i++);
        levelOrder(Input1());

        Console.WriteLine("Traversal-{0}", i++);
        levelOrder(Input2());

        Console.WriteLine("Traversal-{0}", i++);
        levelOrder(Input3());

        Console.WriteLine("Traversal-{0}", i++);
        levelOrder(Input4());

        Console.WriteLine("Traversal-{0}", i++);
        levelOrder(Input5());

        Console.ReadKey();
    }

    private static Node Input5()
    {
        Node root = null;

        //root = insert(root, 6);
        root = insert(root, 3);
        root = insert(root, 5);
        root = insert(root, 4);
        root = insert(root, 7);
        root = insert(root, 2);
        root = insert(root, 1);

        return root;
    }

    private static Node Input4()
    {
        Node root = null;

        root = insert(root, 4);
        root = insert(root, 2);
        root = insert(root, 6);
        root = insert(root, 1);
        root = insert(root, 3);
        root = insert(root, 5);
        root = insert(root, 7);

        return root;
    }

    private static Node Input3()
    {
        return null;
    }

    private static Node Input2()
    {
        Node root = null;

        root = insert(root, 3);

        return root;
    }

    private static Node Input1()
    {
        Node root = null;

        root = insert(root, 3);
        root = insert(root, 5);
        root = insert(root, 2);
        root = insert(root, 1);
        root = insert(root, 4);
        root = insert(root, 6);
        root = insert(root, 7);

        return root;
    }
}