using System;

// https://www.hackerrank.com/challenges/30-binary-search-trees/problem?isFullScreen=true

class Node
{
    public Node left, right;

    public int data;
    public Node(int data)
    {
        this.data = data;
        left = right = null;
    }

    public override string ToString()
    {
        return data.ToString();
    }
}
class Solution
{

    static int getHeight(Node root)
    {
        //Write your code here
        if (root == null)
        {
            // we have traversed one extra level, so, reduce by 1
            return -1;
        }

        // depth-first traversal
        var maxHeight = Math.Max(getHeight(root.left), getHeight(root.right));

        return (1 + maxHeight);
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

        int height1 = getHeight(Input1()); // 3
        int height2 = getHeight(Input2()); // 0
        int height3 = getHeight(Input3()); // -1
        int height4 = getHeight(Input4()); // 2


        Console.ReadKey();
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