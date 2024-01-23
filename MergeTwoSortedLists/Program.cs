namespace MergeTwoSortedLists
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var list1 = new ListNode(1, new ListNode(2, new ListNode(3)));
            var list2 = new ListNode(1, new ListNode(2, new ListNode(4)));

            var s = new Solution();
            s.MergeTwoLists(list1, list2);

            Console.WriteLine(s.ToString());
        }
    }

    public class Solution
    {
        public ListNode? MergeTwoLists(ListNode? list1, ListNode? list2)
        {
            if (list1 == null && list2 == null)
            {
                return null;
            }

            var val1 = list1?.val ?? int.MaxValue;
            var val2 = list2?.val ?? int.MaxValue;

            if (val1 > val2)
            {
                var next2 = MergeTwoLists(list1, list2?.next);
                return new ListNode(val2, next2);
            }

            var next1 = MergeTwoLists(list1?.next, list2);
            return new ListNode(val1, next1);
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