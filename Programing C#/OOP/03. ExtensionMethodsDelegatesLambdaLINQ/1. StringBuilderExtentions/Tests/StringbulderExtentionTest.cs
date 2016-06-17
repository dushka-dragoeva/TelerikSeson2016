namespace StringBuilder.Test
{
    using System;
    using System.Text;
    using Extentions;

    public class StringbulderExtentionTest
    {
        public static void Run()
        {
            var text = "Gore Dolu vse e ok";
            var test = new StringBuilder();
            test.Append(text);
            test = test.Substring(5, 4);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("01.StringBuilder substrin extention");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(text);
            Console.WriteLine($"Substring 5,4 {test}");
        }
    }
}
