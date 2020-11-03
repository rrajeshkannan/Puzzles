using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsertionSortList
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

        public override string ToString()
        {
            if (next == null)
            {
                return val.ToString();
            }

            return String.Format("{0}->{1}", val, next.ToString());
        }
    }

    public class Solution
    {
        public ListNode InsertionSortList(ListNode head)
        {
            if (head == null)
            {
                // 0 elements - no need to sort
                return head;
            }

            ListNode current = head;

            // How Insertion Sort works? It "splits" the list into three groups of nodes:
            // * sorted subset - starts as empty
            // * current node 
            // * unsorted subset - ends as empty
            // 
            // ** The subset of nodes lying before current node - is sorted
            // ** The subset of nodes lying after current node - yet to be sorted
            //
            // The algorithm goes through every node:
            // * compare current node with next node - "next" node lying after current item -> thus belongs to unsorted subset
            // * if next node is greater than or equal to current node - it is already sorted -> thus, mark it "current" and continue insertion sort
            // * if next node is less than current node - need to find correct end position for "next" node in sorted subset:
            // ** save next node as "temp" - "delink" it from list, by making current->next = current->next->next
            // ** find right place for "temp":
            // *** start from beginning of "sorted" list
            // *** go forward until finding correct position for "temp"
            // *** insert "temp" there
            // * continue insertion sort

            while (current.next != null)
            {
                if (current.val <= current.next.val)
                {
                    // "current" is already in sorted position -> so, continue insertion sort
                    current = current.next;
                }
                else
                {
                    var toInsert = current.next;

                    // delink "insert" so that it can be moved to its end position
                    current.next = toInsert.next;

                    // find right place for "insert"
                    if (toInsert.val < head.val)
                    {
                        // "insert" becomes "head"
                        toInsert.next = head;
                        head = toInsert;
                    }
                    else
                    {
                        var insertAt = head;

                        while ((insertAt.next != current) && (toInsert.val > insertAt.next.val))
                        {
                            insertAt = insertAt.next;
                        }

                        // insert at the found location
                        toInsert.next = insertAt.next;
                        insertAt.next = toInsert;
                    }
                }
            }            

            return head;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var solution = new Solution();
            ListNode node;

            var result1 = solution.InsertionSortList(null); // null

            var head2 = new ListNode(0);
            var result2 = solution.InsertionSortList(head2); // 0

            node = new ListNode(0);
            var head3 = new ListNode(1, node);
            var result3 = solution.InsertionSortList(head3); // 0->1

            node = new ListNode(1);
            var head4 = new ListNode(0, node);
            var result4 = solution.InsertionSortList(head4); // 0->1

            node = new ListNode(1);
            node = new ListNode(0, node);
            var head5 = new ListNode(2, node);
            var result5 = solution.InsertionSortList(head5); // 0->1->2

            node = new ListNode(2);
            node = new ListNode(1, node);
            var head6 = new ListNode(0, node);
            var result6 = solution.InsertionSortList(head6); // 0->1->2

            node = new ListNode(5);
            node = new ListNode(4, node);
            node = new ListNode(3, node);
            node = new ListNode(2, node);
            node = new ListNode(1, node);
            var head7 = new ListNode(0, node);
            var result7 = solution.InsertionSortList(head7); // 0->1->2->3->4->5

            node = new ListNode(5);
            node = new ListNode(2, node);
            node = new ListNode(3, node);
            node = new ListNode(1, node);
            node = new ListNode(4, node);
            var head8 = new ListNode(0, node);
            var result8 = solution.InsertionSortList(head8); // 0->1->2->3->4->5
        }
    }
}
