using System.Text;

namespace StringToIntegerATOI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var solution = new Solution();

            var res1 = solution.MyAtoi("123");
            Console.WriteLine(res1);
            Console.WriteLine(res1 == 123);
            Console.WriteLine("--------------------------------");

            //var res2 = solution.MyAtoi("-123");
            //Console.WriteLine(res2);
            //Console.WriteLine(res2 == -123);
            //Console.WriteLine("--------------------------------");

            var res3 = solution.MyAtoi("00000-42a1234");
            Console.WriteLine(res3);
            Console.WriteLine(res3 == 0);
            Console.WriteLine("--------------------------------");

            //var res4 = solution.MyAtoi("-6147483648");
            //Console.WriteLine(res4);
            //Console.WriteLine(res4 == -2147483648);
            //Console.WriteLine("--------------------------------");

            //var res5 = solution.MyAtoi("2147483648");
            //Console.WriteLine(res5);
            //Console.WriteLine(res5 == 2147483647);
            //Console.WriteLine("--------------------------------");
        }
    }

    public class Solution
    {
        public int MyAtoi(string s)
        {
            int result = 0;
            int direction = 0;

            foreach (char c in s)
            {
                if (char.IsDigit(c))
                {
                    int addIn = c - '0';
                    var newResult = result * 10 + addIn;
                    if ((newResult - addIn) / 10 == result && newResult >= 0)
                    {
                        result = newResult;
                    }
                    else
                    {
                        return direction > 0 ? int.MaxValue : int.MinValue;
                    }

                    if (direction == 0)
                    {
                        direction = 1;
                    }

                    continue;
                }

                if (c == '-' && result == 0 && direction == 0)
                {
                    direction = -1;
                    continue;
                }

                if (c == '+' && result == 0 && direction == 0)
                {
                    direction = 1;
                    continue;
                }

                if (c == ' ' && result == 0 && direction == 0)
                {
                    continue;
                }

                break;
            }

            return result * direction;
        }


        public int MyAtoi2(string a)
        {
            string s = a.TrimStart();
            for (int i = 0; i < s.Length; i++)
            {
                if (char.IsLetter(s[i]) || s[i] == '.') return 0;
                if (char.IsDigit(s[i]))
                {
                    if (i > 1) return 0;
                    if (i == 1) return MyFunc(i - 1, s);
                    return MyFunc(i, s);
                }
            }
            return 0;
        }

        private int MyFunc(int index, string s)
        {
            StringBuilder res = new StringBuilder();
            if (s[index] == '-')
            {
                res.Append('-');
                index++;
            }
            else if (s[index] == '+') index++;

            for (int i = index; i < s.Length; i++)
            {
                if (!char.IsDigit(s[i]))
                {
                    return CheckNumber(res.ToString());
                }
                res.Append(s[i]);
            }
            return CheckNumber(res.ToString());
        }

        private int CheckNumber(string numberString)
        {
            if (int.TryParse(numberString, out int number))
            {
                if (number > int.MaxValue)
                {
                    return int.MaxValue;
                }
                else if (number < int.MinValue)
                {
                    return int.MinValue;
                }
                else
                {
                    return number;
                }
            }
            return (numberString[0] == '-') ? int.MinValue : int.MaxValue;
        }
    }
}