namespace LongestSubstring
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var solution = new Solution();

            var res1 = solution.LengthOfLongestSubstring("abcabcbb");
            Console.WriteLine(res1);
            Console.WriteLine(res1 == 3);
            Console.WriteLine("--------------------------------");

            var res2 = solution.LengthOfLongestSubstring("bbbbb");
            Console.WriteLine(res2);
            Console.WriteLine(res2 == 1);
            Console.WriteLine("--------------------------------");

            var res3 = solution.LengthOfLongestSubstring("pwwkew");
            Console.WriteLine(res3);
            Console.WriteLine(res3 == 3);
            Console.WriteLine("--------------------------------");
        }
    }

    public class Solution
    {
        public int LengthOfLongestSubstring(string s)
        {
            if(s.Length == 0) return 0;

            var result = 1;
            var set = new HashSet<char>();
            for (int i = 0; i < s.Length; i++)
            {
                set.Clear();
                set.Add(s[i]);
                var j = i + 1;
                while (j < s.Length && !set.Contains(s[j]))
                {
                    set.Add(s[j]);
                    j++;
                }
                
                result = result > set.Count ? result : set.Count;
            }

            return result;
        }
    }
}