using System;
using System.Text.RegularExpressions;

/*Write a program that extracts from given HTML file its title (if available), and its body text without the HTML tags.
Example input:
<html>
  <head><title>News</title></head>
  <body><p><a href="http://academy.telerik.com">Telerik
    Academy</a>aims to provide free real-world practical
    training for young people who want to turn into
    skilful .NET software engineers.</p></body>
</html>
Output:
Title: News
Text: Telerik Academy aims to provide free real-world practical training for young people who want to turn into skilful .NET software engineers.*/
public class ExtractTextFromHTML
{
    public static void Main()
    {
        /// Console.WriteLine("Enter HTML text: ");
        /// string input = Console.ReadLine();
        string text = @"<html> <head><title>News</title></head> <body><p><a href=""http://academy.telerik.com"">Telerik Academy</a>aims to provide free real-world practical training for young people who want to turn into skilful .NET software engineers.</p></body></html>";
        MatchCollection tags = Regex.Matches(text, "(?<=^|>)[^><]+?(?=<|$)");
        int count = 0;

        foreach (Match tag in tags)
        {
            if (count == 1)
            {
                Console.WriteLine("Title: {0}", tag);
                Console.Write("Text:");
            }
            else
            {
                Console.Write(tag);
            }

            count++;
        }

        Console.WriteLine();
    }
}