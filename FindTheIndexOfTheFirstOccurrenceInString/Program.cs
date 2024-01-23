namespace FindTheIndexOfTheFirstOccurrenceInString
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var s = new Solution();
            //var res = s.StrStr("mississippi", "issipi");
            var res2 = s.StrStr("sadbutsad", "sad");


            Console.WriteLine(res2);
        }
    }

    public class Solution
    {
        public int StrStr(string haystack, string needle)
        {
            if (needle.Length > haystack.Length)
            {
                return -1;
            }

            ushort i = 0, j = 0;
            while (i < haystack.Length && j < needle.Length)
            {
                if (haystack[i] == needle[j])
                {
                    j++;
                }
                else
                {
                    i = (ushort)(i - j);
                    j = 0;
                }
                i++;
            }

            return j == needle.Length ? i - j : -1;
        }
    }
}