namespace LongestString
{
    using System;
    using StringExtentions;

    public class LongestStringTest
    {
        public static void Run()
        {
            var words = new string[] { "lorem", "ipsum", "dolor", "sit", "amet", "consectetuer" };

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("17. Longest string in array");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(words.FindLongestString());
        }
    }
}