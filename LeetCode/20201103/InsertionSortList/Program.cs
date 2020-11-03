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
    }

    public class Solution
    {
        public ListNode InsertionSortList(ListNode head)
        {
            if (head == null)
            {
                // 0 or 1 element -> list is already sorted
                return null;
            }

            ListNode sorted = head;
            ListNode current = head;

            // How Insertion Sort works?
            // It "splits" the list into three groups of nodes:
            // * sorted subset - starts as empty
            // * current node 
            // * unsorted subset - empty in the end
            // 
            // ** The subset of nodes lying before current node - is sorted
            // ** The subset of nodes lying after current node - yet to be sorted

            // The algorithm goes through every node:
            // * compare current node with next node - this node lying after current item -> thus belongs to unsorted subset
            // * if next node is greater than or equal to current node -> it is already sorted -> thus, mark it "current" and continue
            // * if next node is less than current node then, need to find the correct end position for "next" node in sorted subset:
            // ** backup next item somewhere into "temp" and "remove" it from list, by making current->next = current->next->next
            // ** find right place for "temp":
            // *** start from beginning of "sorted" list
            // *** go forward until finding correct position for "temp"
            // *** insert "temp" there
            // * continue insertion sort

            while (current != null)
            {
                var temp = current.next;

                if (temp == null)
                {
                    break;
                }

                if (temp.val < current.val)
                {
                    // find right place for "temp"
                    var sortedCurrent = sorted;

                    if (sortedCurrent.val > temp.val)
                    {
                        sorted = temp;
                        
                    }
                    else
                    {

                        
                        var sortedNext = sortedCurrent.next;



                        while (sortedCurrent != current)
                        {


                            sortedCurrent = sortedCurrent.next;
                        }
                    }
                }

                current = current.next;
            }
            

            return sorted;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
        }
    }
}
