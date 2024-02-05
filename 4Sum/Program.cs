namespace _4Sum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var s = new Solution();
            var arr2 = new[] { -2, -1, -1, 1, 1, 2, 2 };
            var arr3 = new[] { 2, 2, 2, 2, 2 };
            var arr5 = new[] { 1000000000, 1000000000, 1000000000, 1000000000 };
            // -1, 0, [1, 2, -1, -4]  ...
            // -1, 2, 
            var arr4 = new[] { 0, 0, 0, 0 };

            var target = -294967296;
            var res = s.FourSum(arr2, target);

            foreach (var item in res)
            {
                Console.WriteLine(string.Join(',', item));
            }
        }
    }

    public class Solution
    {
        public IList<IList<int>> FourSum(int[] nums, int target)
        {
            var result = new List<int[]>();
            Array.Sort(nums);

            if (nums[nums.Length - 1] > target)
            {
                return result.ToArray();
            }

            int left, right;
            for (int start1 = 0; start1 < nums.Length - 3; start1++)
            {
                if (start1 > 0 && nums[start1] == nums[start1 - 1]) continue; // skipping repeated numbers to avoid repeating triples

                for (int start2 = start1 + 1; start2 < nums.Length - 2; start2++)
                {
                    if (start2 > start1 + 1 && nums[start2] == nums[start2 - 1]) continue; // skipping repeated numbers to avoid repeating triples

                    left = start2 + 1;
                    right = nums.Length - 1;

                    while (left < right)
                    {
                        //long numberSum = (long)number[x] + (long)number[y] + (long)number[leftPointer] + (long)number[rightPointer];

                        long sum = (long)nums[start1] + (long)nums[start2] + (long)nums[right] + (long)nums[left];

                        if (sum == target)
                        {
                            result.Add(new[] { nums[start1], nums[start2], nums[right], nums[left] });
                            while (left < right && nums[left] == nums[left + 1]) left++; // skipping repeated numbers to avoid repeating triples
                            while (left < right && nums[right] == nums[right - 1]) right--; // skipping repeated numbers to avoid repeating triples
                            left++;
                            right--;
                        }
                        else if (sum < target)
                            left++;
                        else
                            right--;
                    }
                }
            }

            return result.ToArray();
        }
    }
}
