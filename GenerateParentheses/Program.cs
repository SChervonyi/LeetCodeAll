namespace GenerateParentheses
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var s  = new Solution();
            var result = s.GenerateParenthesis(3);
            Console.WriteLine(string.Join(",", result));
        }
    }

    public class Solution
    {
        public IList<string> GenerateParenthesis(int n)
        {
            IList<string> res = new List<string>();
            Helper(res, "(", 1, 0, n);
            return res;
        }

        public void Helper(IList<string> res, string curr, int open, int close, int n)
        {
            if (curr.Length == 2 * n)
            {
                res.Add(curr);
                return;
            }
            if (open < n)
            {
                Helper(res, curr + "(", open + 1, close, n);
            }
            if (close < open)
            {
                Helper(res, curr + ")", open, close + 1, n);
            }
        }

    }
}
