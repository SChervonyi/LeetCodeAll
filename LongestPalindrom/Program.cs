using System;

namespace LongestPalindrom
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var solution = new Solution();

            var res1 = solution.LongestPalindrome("babad");
            Console.WriteLine(res1);
            Console.WriteLine(res1 == "aba" || res1 == "bab");
            Console.WriteLine("--------------------------------");

            //var res2 = solution.LongestPalindrome("cbbd");
            //Console.WriteLine(res2);
            //Console.WriteLine(res2 == "bb");
            //Console.WriteLine("--------------------------------");

            //var res3 = solution.LongestPalindrome("abcdefg");
            //Console.WriteLine(res3);
            //Console.WriteLine(res3 == "");
            //Console.WriteLine("--------------------------------");

            //var res4 = solution.LongestPalindrome("abbcddddt");
            //Console.WriteLine(res4);
            //Console.WriteLine(res4 == "dddd");
        }
    }

    public class Solution
    {
        public string LongestPalindrome(string s)
        {
            if (s == null || s.Length < 1)
            {
                return "";
            }

            int start = 0;
            int end = 0;

            for (int i = 0; i < s.Length; i++)
            {
                int len1 = ExpandAroundCenter(s, i, i);
                int len2 = ExpandAroundCenter(s, i, i + 1);
                int len = Math.Max(len1, len2);

                if (len > end - start)
                {
                    start = i - (len - 1) / 2;
                    end = i + len / 2;
                }
            }

            return s.Substring(start, end - start + 1);
        }

        private int ExpandAroundCenter(string s, int left, int right)
        {
            while (left >= 0 && right < s.Length && s[left] == s[right])
            {
                left--;
                right++;
            }
            return right - left - 1;
        }
    }
}