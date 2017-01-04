namespace Palindromize
{
    using System;

    public class Startup
    {
        public static void Main()
        {
            var str = Console.ReadLine();
            var answer = Palindromize(str);
            Console.WriteLine(answer);
        }

        public static string Palindromize(string str)
        {
            for (var i = 0; i <= str.Length; i++)
            {
                var toAppend = str.Substring(0, i).ToCharArray();
                Array.Reverse(toAppend);
                var candidate = str + new string(toAppend);
                if (IsPalindrome(candidate))
                {
                    return candidate;
                }
            }

            return string.Empty;
        }

        private static bool IsPalindrome(string str)
        {
            for (var i = 0; i < str.Length / 2; i++)
            {
                if (str[i] != str[str.Length - 1 - i])
                {
                    return false;
                }
            }

            return true;
        }
    }
}
