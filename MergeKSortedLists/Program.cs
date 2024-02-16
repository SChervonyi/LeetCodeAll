﻿namespace MergeKSortedLists
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }
    }

    // Use merge of two linked lists k times
    public class Solution
    {
        public ListNode? MergeKLists(ListNode[] lists)
        {
            if (lists == null || lists.Length == 0)
            {
                return null;
            }

            var result = lists[0];

            for (var i = 1; i < lists.Length; i++)
            {
                result = Merge(result, lists[i]);
            }

            return result;
        }

        private static ListNode? Merge(ListNode? a, ListNode? b)
        {
            var result = new ListNode();
            var last = result;

            while (a != null && b != null)
            {
                if (a.val > b.val)
                {
                    last.next = b;
                    b = b.next;
                }
                else
                {
                    last.next = a;
                    a = a.next;
                }

                last = last.next;
            }

            last.next = a ?? b;

            return result.next;
        }
    }

    public class ListNode
    {
        public int val;
        public ListNode? next;
        public ListNode(int val = 0, ListNode? next = null)
        {
            this.val = val;
            this.next = next;
        }
    }
}
