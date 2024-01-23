namespace RemoveElement
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var s = new Solution();

            var arr = new[] { 0, 1, 2, 2, 3, 0, 4, 2 };
            var res = s.RemoveElement(arr, 2);
            Console.WriteLine(res);
        }
    }

    public class Solution
    {
        public int RemoveElement(int[] nums, int val)
        {
            int i = 0;
            int j = 0;
            while (i < nums.Length)
            {
                nums[j] = nums[i];
                if (nums[i] != val)
                {
                    j++;
                }
                i++;
            }

            return i - j;
        }

        public int RemoveElement2(int[] nums, int val)
        {
            int count = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] != val)
                {
                    nums[count]=nums[i];
                    count++;

                }
            }
            return count;
        }
    }
}