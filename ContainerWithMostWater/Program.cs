namespace ContainerWithMostWater
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var arr = new[] { 1, 8, 6, 2, 5, 4, 8, 3, 7 };

            var s = new Solution();
            var res = s.MaxArea(arr);
            Console.WriteLine(res);
        }
    }

    public class Solution
    {
        public int MaxArea(int[] height)
        {
            int i = 0, j = height.Length - 1;
            int maxAmount = Math.Min(height[i], height[j]) * (j - i);
            while (i < j)
            {
                if (height[i] > height[j])
                {
                    j--;
                }
                else
                {
                    i++;
                }

                int amount = Math.Min(height[i], height[j]) * (j - i);
                maxAmount = Math.Max(maxAmount, amount);
            }

            return maxAmount;
        }
    }
}