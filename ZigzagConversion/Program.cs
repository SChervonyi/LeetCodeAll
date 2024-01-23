using System.Text;

namespace ZigzagConversion
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var solution = new Solution();

            var res1 = solution.Convert("PAYPALISHIRING", 3);
            Console.WriteLine(res1);
            Console.WriteLine("--------------------------------");

            var res2 = solution.Convert("PAYPALISHIRING", 4);
            Console.WriteLine(res2);
            Console.WriteLine("--------------------------------");
        }
    }

    public class Solution
    {
        public string Convert(string s, int numRows)
        {
            if (numRows == 1 || s.Length <= 1)
            {
                return s;
            }

            string[] solution = new string[numRows];

            int i = 0, direction = 1;
            foreach (char c in s)
            {
                solution[i] += c;

                i += direction;

                if (i == numRows-1 || i==0) direction *= -1;
            }

            return string.Concat(solution);
        }

        //public string Convert(string s, int numRows)
        //{
        //    if (numRows == 1 || s.Length <= 1)
        //    {
        //        return s;
        //    }

        //    var strBuilder = new string[numRows];
        //    int i = 0;
        //    int j = 0;
        //    foreach (var letter in s)
        //    {

        //    }
        //}

        //private int CalcWidth(int strLength,  int numRows)
        //{
        //    if (strLength < numRows)
        //    {
        //        return 1;
        //    }

        //    var result = 1;
        //    var leftOver = strLength - numRows;
        //    if
        //}
    }
}