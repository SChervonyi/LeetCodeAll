using System.Text;

namespace LongestCommonPrefix
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //var d1 = new DateTime(2024, 1, 2);
            //var d2 = new DateTime(2023, 1, 1);
            //var span = TimeSpan.FromDays(365);

            //var res = (d1 - d2) <= span;

            var s = new Solution();
            var res = s.LongestCommonPrefix2(new[] { "ab", "a" });

            Console.WriteLine("Hello, World!");
        }
    }

    public class Solution
    {
        public string LongestCommonPrefix2(string[] strs)
        {
            for (int i = 0; i < strs[0].Length; i++)
            {
                for (int j = 1; j < strs.Length; j++)
                {
                    if (i >= strs[j].Length || strs[j][i] != strs[0][i])
                    {
                        return strs[0].Substring(0, i);
                    }
                }
            }
            return strs[0];
        }

        public string LongestCommonPrefix(string[] strs)
        {
            if (strs.Length == 0) return string.Empty;

            var first = strs[0];
            var res = new StringBuilder();
            for (int i = 0; i < first.Length; i++)
            {
                if (strs.All(str => str.Length > i && str[i] == first[i]))
                {
                    res.Append(first[i]);
                }
                else
                {
                    break;
                }
            }

            return res.ToString();
        }
    }
}