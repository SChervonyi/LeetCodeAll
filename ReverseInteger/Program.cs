namespace ReverseInteger
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var solution = new Solution();

            var res1 = solution.Reverse(123);
            Console.WriteLine(res1);
            Console.WriteLine(res1 == 321);
            Console.WriteLine("--------------------------------");

            var res2 = solution.Reverse(-123);
            Console.WriteLine(res2);
            Console.WriteLine(res2 == -321);
            Console.WriteLine("--------------------------------");

            var res3 = solution.Reverse(120);
            Console.WriteLine(res3);
            Console.WriteLine(res3 == 21);
            Console.WriteLine("--------------------------------");
        }
    }

    public class Solution
    {
        public int Reverse(int x)
        {
            if(x == 0) return 0;

            var xStr = x.ToString();
            var resultSting = string.Empty;
            for (int i = xStr.Length - 1; i >= 0; i--)
            {
                if (xStr[i] != '-')
                {
                    resultSting += xStr[i];
                }
            }
            var result = long.Parse(resultSting);
            return result > int.MaxValue ? 0 : (x > 0 ? (int)result : (int)result * -1);
        }

        public int Reverse2(int x)
        {
            var result = 0;

            while (x != 0)
            {
                var remainder = x % 10;
                var temp = result * 10 + remainder;

                // in case of overflow, the current value will not be equal to the previous one
                if ((temp - remainder) / 10 != result)
                {
                    return 0;
                }

                result = temp;
                x /= 10;
            }

            return result;
        }
    }
}