using System.Linq;

namespace ValidBracketParentheses
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }
    }

    public class Solution
    {
        public bool IsValid(string s)
        {
            var bracketsDictionary = new Dictionary<char, char>
            {
                { '(', ')' },
                { '[', ']' },
                { '{', '}' }
            };

            Stack<char> openBrackets = new Stack<char>();

            foreach (char c in s)
            {
                if (bracketsDictionary.ContainsKey(c))
                {
                    openBrackets.Push(c);
                }
                else
                {
                    if (openBrackets.Count == 0)
                    {
                        return false;
                    }

                    var lastOpenBracket = openBrackets.Pop();
                    if (bracketsDictionary[lastOpenBracket] != c)
                    {
                        return false;
                    }
                }
            }

            return openBrackets.Count == 0;
        }

        public bool IsValid2(string s)
        {
            var stack = new char[s.Length];
            int p = -1;
            var dict = new Dictionary<char, char>()
        {
            {')', '('},
            {'}', '{'},
            {']', '['}
        };

            for (int i = 0; i < s.Length; i++)
            {
                if (!dict.ContainsKey(s[i]))
                {
                    p++;
                    stack[p] = s[i];
                }
                else if (p >= 0 && p < s.Length && dict[s[i]] == stack[p])
                {
                    p--;
                }
                else
                    return false;
            }
            return p == -1;
        }
    }
}