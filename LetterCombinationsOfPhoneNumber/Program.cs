namespace LetterCombinationsOfPhoneNumber
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var s = new Solution();

            var result = s.LetterCombinations("23");
            Console.WriteLine(string.Join(',', result));
        }
    }

    public class Solution
    {
        public IList<string> LetterCombinations(string digits)
        {
            var dictionary = BuildDictionary();

            var charListArrays = new List<char[]>();
            foreach (var digit in digits)
            {
                charListArrays.Add(dictionary[digit]);
            }

            if (charListArrays.Count == 0)
            {
                return new List<string>();
            }

            return AddElements(charListArrays, string.Empty, 0);
        }

        private IList<string> AddElements(List<char[]> charListArrays, string prefix, int index)
        {
            var result = new List<string>();
            if (charListArrays.Count - 1 == index)
            {
                foreach (var charItem in charListArrays[index])
                {
                    result.Add($"{prefix}{charItem}");
                }
            }
            else
            {
                foreach (var charItem in charListArrays[index])
                {
                    var newPrefix = $"{prefix}{charItem}";
                    result.AddRange(AddElements(charListArrays, newPrefix, index + 1));
                }
            }

            return result;
        }

        private Dictionary<char, char[]> BuildDictionary()
        {
            return new Dictionary<char, char[]> {
                //{'1',  new[] {''} },
                {'2',  new[] {'a', 'b', 'c' } },
                {'3',  new[] {'d', 'e', 'f' } },
                {'4',  new[] {'g', 'h', 'i' } },
                {'5',  new[] {'j', 'k', 'l' } },
                {'6',  new[] {'m', 'n', 'o' } },
                {'7',  new[] {'p', 'q', 'r', 's' } },
                {'8',  new[] {'t', 'u', 'v' } },
                {'9',  new[] {'w', 'x', 'y', 'z' } },
            };
        }
    }

    public class Solution2
    {
        Dictionary<char, char[]> keypad = new Dictionary<char, char[]> {{'2', new char[]{'a', 'b', 'c'}},
    {'3', new char[]{'d', 'e', 'f'}}, {'4', new char[] {'g', 'h', 'i'}},
    {'5', new char[] {'j', 'k', 'l'}}, {'6', new char[] {'m', 'n', 'o'}},
    {'7', new char[] {'p', 'q', 'r', 's'}}, {'8', new char[] {'t', 'u', 'v'}},
    {'9', new char[] {'w', 'x', 'y', 'z'}}};

        public void AddCombination(string curr, string digits, int index, IList<string> list)
        {
            if (index >= digits.Length) list.Add(curr);
            else
            {
                char[] map = keypad[digits[index]];

                for (int i = 0; i < map.Length; i++)
                {
                    string newCurr = curr + map[i];

                    AddCombination(newCurr, digits, index + 1, list);
                }
            }
        }

        public IList<string> LetterCombinations(string digits)
        {
            IList<string> combinations = new List<string>();

            if (digits.Length > 0) AddCombination("", digits, 0, combinations);

            return combinations;
        }
    }
}
