using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwapNodes
{
    // Definition for singly-linked list.
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
    public class ReverseListNode
    {
        public ReverseListNode next;
        public ListNode actual;
        public int val => actual.val;

        public ReverseListNode(ListNode actual, ReverseListNode next = null)
        {
            this.next = next;
            this.actual = actual;
        }
    }

    public class Solution
    {
        public ListNode SwapNodes(ListNode head, int k)
        {
            ReverseListNode reverseHead = null;
            ListNode headCopy = head;

            while(headCopy != null)
            {
                reverseHead = new ReverseListNode(headCopy, reverseHead);
                headCopy = headCopy.next;
            }

            headCopy = head;
            var reverseHeadCopy = reverseHead;

            for (int i = 1; i < k; i++)
            {
                headCopy = headCopy.next;
                reverseHeadCopy = reverseHeadCopy.next;
            }

            var value = headCopy.val;
            headCopy.val = reverseHeadCopy.val;
            reverseHeadCopy.actual.val = value;

            return head;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var solution = new Solution();

            var head1 = new ListNode(1, new ListNode(2, new ListNode(3, new ListNode(4, new ListNode(5)))));
            var output1 = solution.SwapNodes(head1, 2);

            var head2 = 
                new ListNode(7, new ListNode(9, new ListNode(6, new ListNode(6, 
                new ListNode(7, new ListNode(8, new ListNode(3, new ListNode(0, 
                new ListNode(9, new ListNode(5))))))))));
            var output2 = solution.SwapNodes(head2, 5);

            var head3 = new ListNode(1);
            var output3 = solution.SwapNodes(head3, 1);

            var head4 = new ListNode(1, new ListNode(2));
            var output4 = solution.SwapNodes(head4, 1);

            var head5 = new ListNode(1, new ListNode(2, new ListNode(3)));
            var output5 = solution.SwapNodes(head5, 2);
        }
    }
}
