using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloneTheGraph
{
    // Definition for a Node.
    public class Node
    {
        public int val;
        public IList<Node> neighbors;

        public Node()
        {
            val = 0;
            neighbors = new List<Node>();
        }

        public Node(int _val)
        {
            val = _val;
            neighbors = new List<Node>();
        }

        public Node(int _val, List<Node> _neighbors)
        {
            val = _val;
            neighbors = _neighbors;
        }
    }


    public class Solution
    {
        Dictionary<int, Node> visited = new Dictionary<int, Node>();

        public Node CloneGraph(Node node)
        {
            if (visited.TryGetValue(node.val, out Node clone))
            {
                return clone;
            }

            clone = new Node(node.val);

            visited.Add(clone.val, clone);

            foreach (var neighbor in node.neighbors)
            {
                clone.neighbors.Add(
                    CloneGraph(neighbor));
            }

            return clone;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Node node1 = new Node(1);
            Node node2 = new Node(2);
            Node node3 = new Node(3);
            Node node4 = new Node(4);

            node1.neighbors.Add(node2);
            node1.neighbors.Add(node4);

            node2.neighbors.Add(node1);
            node2.neighbors.Add(node3);

            node3.neighbors.Add(node2);
            node3.neighbors.Add(node4);

            node4.neighbors.Add(node1);
            node4.neighbors.Add(node3);

            var solution = new Solution();

            var clonedGraph = solution.CloneGraph(node1);
        }
    }
}
