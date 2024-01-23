namespace _3Sum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var s = new Solution();
            var arr2 = new[] { -1, 0, 1, 2, -1, -4 };
            // -1, 0, [1, 2, -1, -4]  ...
            // -1, 2, 
            var arr3 = new[] { 0, 0, 0, 0 };
            var res = s.ThreeSum(arr2);

            foreach (var item in res)
            {
                Console.WriteLine(string.Join(',', item));
            }
        }
    }

    public class Solution
    {
        public IList<IList<int>> ThreeSum(int[] nums)
        {
            var result = new List<int[]>();
            Array.Sort(nums);

            int left, right;
            for (int start = 0; start < nums.Length - 2; start++)
            {
                if (nums[start] > 0) break; // if the first number is greater than 0, then the sum cannot be 0

                if (start > 0 && nums[start] == nums[start - 1]) continue; // skipping repeated numbers to avoid repeating triples

                left = start + 1;
                right = nums.Length - 1;

                while(left < right)
                {
                    int sum = nums[start] + nums[right] + nums[left];

                    if(sum == 0)
                    {
                        result.Add(new[] { nums[start], nums[right], nums[left] });
                        while (left < right && nums[left] == nums[left + 1]) left++; // skipping repeated numbers to avoid repeating triples
                        while (left < right && nums[right] == nums[right - 1]) right--; // skipping repeated numbers to avoid repeating triples
                        left++;
                        right--;
                    }
                    else if (sum < 0)
                        left++;
                    else
                        right--;
                }
            }
            return result.ToArray();
        }
    }
}