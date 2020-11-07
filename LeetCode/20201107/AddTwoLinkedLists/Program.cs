using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddTwoLinkedLists
{
    // https://leetcode.com/explore/challenge/card/november-leetcoding-challenge/564/week-1-november-1st-november-7th/3522/

    // You are given two non-empty linked lists representing two non-negative integers. 
    //   The most significant digit comes first and each of their nodes contain a single digit.
    //
    // Add the two numbers and return it as a linked list.
    //
    // You may assume the two numbers do not contain any leading zero, except the number 0 itself.
    //
    // Follow up:
    //   What if you cannot modify the input lists? In other words, reversing the lists is not allowed.
    // 
    // Example:
    //   Input: (7 -> 2 -> 4 -> 3) + (5 -> 6 -> 4)
    //   Output: 7 -> 8 -> 0 -> 7

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
    public class SolutionNotAccepted
    {
        public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            var number1 = GetNumberFromList(l1, out int digits1);
            var number2 = GetNumberFromList(l2, out int digits2);
            var digits = (digits1 > digits2) ? digits1 : digits2;

            return GetListFromNumber(number1 + number2, digits);
        }

        public int GetNumberFromList(ListNode l, out int digits)
        {
            int number = 0;
            digits = 0;

            while (l != null)
            {
                number = (number * 10) + l.val;
                l = l.next;
                digits++;
            }

            return number;
        }

        public ListNode GetListFromNumber(int number, int digits)
        {
            ListNode head = null;

            while (number != 0)
            {
                head = new ListNode(number % 10, head);
                number /= 10;
                digits--;
            }

            for (int i = digits; i > 0; i--)
            {
                head = new ListNode(0, head);
            }

            return head;
        }
    }

    public class Solution
    {
        public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            var number1 = GetStackFromList(l1);
            var number2 = GetStackFromList(l2);

            return AddTwoStacksOfNumbers(number1, number2);
        }

        public Stack<int> GetStackFromList(ListNode l)
        {
            var number = new Stack<int>();

            while (l != null)
            {
                number.Push(l.val);
                l = l.next;
            }

            return number;
        }

        public ListNode AddTwoStacksOfNumbers(Stack<int> number1, Stack<int> number2)
        {
            ListNode head = null;
            var carry = 0;

            while (number1.Any() && number2.Any())
            {
                var digit1 = number1.Pop();
                var digit2 = number2.Pop();

                var sum = digit1 + digit2 + carry;

                carry = sum / 10;
                head = new ListNode(sum % 10, head);
            }

            var number = number1.Any() ? number1 : number2.Any() ? number2 : new Stack<int>();

            while(number.Any())
            {
                var digit = number.Pop();
                var sum = digit + carry;

                carry = sum / 10;
                head = new ListNode(sum % 10, head);
            }

            if (carry > 0)
            {
                head = new ListNode(1, head);
            }

            return head;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var solution = new Solution();
            var solutionNotAccepted = new SolutionNotAccepted();

            var list11 = new ListNode(7, new ListNode(2, new ListNode(4, new ListNode(3))));
            var list12 = new ListNode(5, new ListNode(6, new ListNode(4)));
            var result1 = solutionNotAccepted.AddTwoNumbers(list11, list12);
            var result12 = solution.AddTwoNumbers(list11, list12);

            var list21 = new ListNode(0, new ListNode(0, new ListNode(0)));
            var list22 = new ListNode(9, new ListNode(9, new ListNode(9, new ListNode(9))));
            var result2 = solutionNotAccepted.AddTwoNumbers(list21, list22);
            var result22 = solution.AddTwoNumbers(list21, list22);

            var list31 = new ListNode(1, new ListNode(1, new ListNode(1, new ListNode(1))));
            var list32 = new ListNode(9, new ListNode(9, new ListNode(9, new ListNode(9))));
            var result3 = solutionNotAccepted.AddTwoNumbers(list31, list32);
            var result32 = solution.AddTwoNumbers(list31, list32);

            var list41 = new ListNode(0, new ListNode(0, new ListNode(0)));
            var list42 = new ListNode(0, new ListNode(0, new ListNode(0, new ListNode(0))));
            var result4 = solutionNotAccepted.AddTwoNumbers(list41, list42);
            var result42 = solution.AddTwoNumbers(list41, list42);

            // [3,9,9,9,9,9,9,9,9,9]
            // [7]
            var list51 = new ListNode(
                3, new ListNode(
                    9, new ListNode(
                        9, new ListNode(
                            9, new ListNode(
                                9, new ListNode(
                                    9, new ListNode(
                                        9, new ListNode(
                                            9, new ListNode(
                                                9, new ListNode(
                                                    9)
                                                )
                                            )
                                        )
                                    )
                                )
                            )
                        )
                    )
                );
            var list52 = new ListNode(7);
            var result5 = solutionNotAccepted.AddTwoNumbers(list51, list52);
            var result52 = solution.AddTwoNumbers(list51, list52);
        }
    }
}
