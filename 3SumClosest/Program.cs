namespace _3SumClosest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var s = new Solution();

            var arr2 = new[] { 4, 0, 5, -5, 3, 3, 0, -4, -5 };
            var arr3 = new[] { -1000, -5, -5, -5, -5, -5, -5, -1, -1, -1 };

            var arr = new[] { 0, 0, 0 };

            var target = -14;
            var result = s.ThreeSumClosest(arr3, target);
            Console.WriteLine(result);
        }

        public class Solution
        {
            public int ThreeSumClosest(int[] nums, int target)
            {
                Array.Sort(nums);
                int closestSum = nums[0] + nums[1] + nums[2];
                int left, right;
                for (int start = 0; start < nums.Length - 2; start++)
                {
                    if (start > 0 && nums[start - 1] == nums[start]) continue;

                    left = start + 1;
                    right = nums.Length - 1;

                    while(right > left)
                    {
                        int sum = nums[start] + nums[left] + nums[right];
                        if (target == sum)
                        {
                            return target;
                        }
                        else if (sum < target)
                        {
                            if (Math.Abs(sum - target) < Math.Abs(closestSum - target))
                            {
                                closestSum = sum;
                            }
                            left++;
                        }
                        else
                        {
                            if (Math.Abs(sum - target) < Math.Abs(closestSum - target))
                            {
                                closestSum = sum;
                            }

                            right--;
                        }
                    }
                }

                return closestSum;
            }
        }
    }
}
