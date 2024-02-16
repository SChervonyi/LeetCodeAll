namespace SwapNodesInPairs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var list1 = new ListNode(1, new ListNode(2, new ListNode(3, new ListNode(4))));

            var s = new Solution();

            var result = s.SwapPairs(list1);
            Console.WriteLine(result);
        }
    }

    public class Solution
    {
        public ListNode? SwapPairs(ListNode? head)
        {
            var next = head?.next;

            if (head == null || next == null) return next ?? head;

            var nextNext = next.next;

            head.next = SwapPairs(nextNext);
            next.next = head;
            return next;
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
