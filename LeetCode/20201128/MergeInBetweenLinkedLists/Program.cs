using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MergeInBetweenLinkedLists
{
    // https://leetcode.com/contest/biweekly-contest-40/problems/merge-in-between-linked-lists/

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

        public override string ToString()
        {
            return String.Format($"{val}->{this.next?.ToString() ?? String.Empty}");
        }
    }

    public class Solution
    {
        public ListNode MergeInBetween(ListNode list1, int a, int b, ListNode list2)
        {
            var current = list1;
            ListNode previous = null;
            ListNode head = null;
            var headFound = false;
            ListNode tail = null;
            var tailFound = false;

            while ((current != null) && !headFound)
            {
                if (current.val == a)
                {
                    head = previous;
                    headFound = true;
                    break;
                }

                previous = current;
                current = current.next;
            }

            if (!headFound)
            {
                return null;
            }

            while ((current != null) && !tailFound)
            {
                if (current.val == b)
                {
                    tail = current;
                    tailFound = true;
                }

                current = current.next;
            }

            if (headFound && tailFound)
            {
                if (head == null)
                {
                    list1 = list2;
                }
                else
                {
                    head.next = list2;
                }

                head = list2;

                while (head.next != null)
                {
                    head = head.next;
                }

                head.next = tail.next;
            }
            
            return list1;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var solution = new Solution();

            var list11 = new ListNode(
                0, new ListNode(
                    1, new ListNode(
                        2, new ListNode(
                            3, new ListNode(
                                4, new ListNode(
                                    5))))));
            var list12 = new ListNode(
                1000000, new ListNode(
                    1000001, new ListNode(
                        1000002)));

            var result1 = solution.MergeInBetween(list11, 3, 4, list12);

            var list21 = new ListNode(
                0, new ListNode(
                    1, new ListNode(
                        2, new ListNode(
                            3, new ListNode(
                                4, new ListNode(
                                    5, new ListNode(
                                        6)))))));
            var list22 = new ListNode(
                1000000, new ListNode(
                    1000001, new ListNode(
                        1000002, new ListNode(
                            1000003, new ListNode(
                                1000004)))));

            var result2 = solution.MergeInBetween(list21, 2, 5, list22);

            var list23 = new ListNode(
                0, new ListNode(
                    1, new ListNode(
                        2)));

            var list24 = new ListNode(
                1000000, new ListNode(
                    1000001, new ListNode(
                        1000002, new ListNode(1000003))));

            var result3 = solution.MergeInBetween(list23, 1, 1, list24);
        }
    }
}
