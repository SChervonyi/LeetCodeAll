using static System.Net.Mime.MediaTypeNames;

namespace RemoveNthNodeFromEndList
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var node = new ListNode(1, new ListNode(2, new ListNode(3, new ListNode(4, new ListNode(5)))));
            var node2 = new ListNode(1);

            var s = new Solution2();
            var result = s.RemoveNthFromEnd(node, 2);
            Console.WriteLine(result);
        }
    }


    public class Solution
    {
        public ListNode? RemoveNthFromEnd(ListNode head, int n)
        {
            return Run(head, n, out _);
        }

        public ListNode? Run(ListNode? node, int n, out int count)
        {
            if (node == null)
            {
                count = 0;
                return null;
            }

            var next = Run(node.next, n, out count);
            count++;

            if (count == n)
            {
                return next;
            }

            return new ListNode(node.val, next);
        }
    }

    public class Solution2
    {
        public ListNode? RemoveNthFromEnd(ListNode head, int n)
        {
            ListNode? prev = null;

            for (var (node, i) = (head, 0); node != null; node = node.next, i++)
                if (i >= n)
                    if (prev == null) prev = head;
                    else prev = prev.next;

            if (prev == null) return head.next;
            if (prev.next != null) prev.next = prev.next.next;
            return head;
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
