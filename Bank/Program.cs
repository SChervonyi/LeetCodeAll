namespace Bank
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var solutionRecurcion = new SolutionRecurcion();
            var resultRecurcion = solutionRecurcion.TotalMoney(26);
            Console.WriteLine(resultRecurcion.ToString());

            var solution = new Solution();
            var result = solution.TotalMoney(26);
            Console.WriteLine(result.ToString());
        }
    }

    public class Solution
    {
        public int TotalMoney(int n)
        {
            var countWeeks = n / 7;
            var daysOnLastWeek = n % 7;
            var a1 = countWeeks + 1;
            var an = a1 + (daysOnLastWeek - 1);
            var lastWeekSum = (daysOnLastWeek*(a1 + an))/2;
            var prevWeeksSum = 0;
            var weekSum = 28; //7*(1 + 7)/2
            if (countWeeks > 0)
            {
                prevWeeksSum = weekSum*countWeeks + FactirialWeeks(countWeeks);
            }

            return lastWeekSum + prevWeeksSum;
        }

        private int FactirialWeeks(int n)
        {
            if (n == 1) return 0;

            return 7*(n-1) + FactirialWeeks(n - 1);
        }
    }

    public class SolutionRecurcion
    {
        public int TotalMoney(int totalDays, int day = 1, int week = 0)
        {
            if (totalDays > (week*7 + day))
            {
                return day + week + TotalMoney(totalDays, day%7 + 1, (day + week*7)/7);
            }
            else
            {
                return day + week;
            }
        }
    }
}