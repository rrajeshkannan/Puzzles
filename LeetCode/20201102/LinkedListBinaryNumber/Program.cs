using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedListBinaryNumber
{
    // https://leetcode.com/explore/featured/card/november-leetcoding-challenge/564/week-1-november-1st-november-7th/3516/

    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int val = 0, ListNode next = null)
        {
            this.val = val;
            this.next = next;
        }
    }

    public class Solution
    {
        public int GetDecimalValue(ListNode head)
        {
            int value = 0;

            while (head != null)
            {
                value = (value * 2) + head.val;
                head = head.next;
            }

            return value;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var solution = new Solution();
            ListNode node;

            var result1 = solution.GetDecimalValue(null); // 0

            var head2 = new ListNode();
            var result2 = solution.GetDecimalValue(head2); // 0

            var head3 = new ListNode(1);
            var result3 = solution.GetDecimalValue(head3); // 1

            node = new ListNode(0);
            var head4 = new ListNode(0, node);
            var result4 = solution.GetDecimalValue(head4); // 0->0 - 0

            node = new ListNode(1);
            var head5 = new ListNode(0, node);
            var result5 = solution.GetDecimalValue(head5); // 0->1 - 1

            node = new ListNode(0);
            node = new ListNode(0, node);
            var head6 = new ListNode(0, node);
            var result6 = solution.GetDecimalValue(head6); // 0->0->0 - 0

            node = new ListNode(1);
            node = new ListNode(0, node);
            var head7 = new ListNode(0, node);
            var result = solution.GetDecimalValue(head7); // 0->0->1 - 1

            node = new ListNode(0);
            node = new ListNode(0, node);
            var head8 = new ListNode(1, node);
            var result8 = solution.GetDecimalValue(head8); // 1->0->0 - 4

            node = new ListNode(1);
            node = new ListNode(0, node);
            node = new ListNode(0, node);
            var head9 = new ListNode(1, node);
            var result9 = solution.GetDecimalValue(head9); // 1->0->0->1 - 9
        }
    }
}
