namespace RomanToInteger
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var solution = new Solution();

            var res1 = solution.RomanToInt("MCMXCIV");
            Console.WriteLine(res1);
            Console.WriteLine("--------------------------------");
        }
    }

    public class Solution
    {
        public int RomanToInt(string s)
        {
            int result = 0;
            for (int i = 0; i < s.Length; i++)
            {
                int current = SymbolToValue(s[i]);
                if (i + 1 < s.Length)
                {
                    int nextCharValue = SymbolToValue(s[i + 1]);

                    if (nextCharValue > current)
                    {
                        result = result + nextCharValue - current;
                        i++;
                    }
                    else
                    {
                        result += current;
                    }
                }
                else
                {
                    result += current;
                }
            }

            return result;
        }

        private int SymbolToValue(char c)
        {
            return c switch
            {
                'I' => 1,
                'V' => 5,
                'X' => 10,
                'L' => 50,
                'C' => 100,
                'D' => 500,
                'M' => 1000,
                _ => 0
            };
        }
    }
}