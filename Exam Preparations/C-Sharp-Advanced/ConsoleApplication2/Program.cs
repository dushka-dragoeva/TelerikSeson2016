using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Program
{
    public static void Main(string[] args)
    {
      ///  var input = "CheckCurrentPattern";
        var current = "  Console.WriteLine(";

        var beforeBrackets = current
                         .Split(new[] { '(' }, StringSplitOptions.RemoveEmptyEntries)
                         .Select(x => x.Trim())
                         .ToArray();

        var all = new List<string>();

        for (int i = 0; i < beforeBrackets.Length; i++)
        {
            var temp = ExtractMethodName2(beforeBrackets[i]);

            if (temp != null)
            {
                all.Add(temp);
            }

            Console.WriteLine(ExtractMethodName2(beforeBrackets[i]));
        }
    }

    private static string ExtractMethodName2(string text)
    {
        var beforeBrackets = text
                .Split(new[] { ' ', '.' }, StringSplitOptions.RemoveEmptyEntries);

        var methodName = beforeBrackets[beforeBrackets.Length - 1];

        if (char.IsUpper(methodName[0]) && !beforeBrackets.Contains("new"))
        {
            return methodName;
        }
        else
        {
            return null;
        }
    }

    private static string ExtractMethodName(string text)
    {
        string methodName = string.Empty;
        if (text.Contains("("))
        {
            methodName = text.Split('(')[0]

                .Split(new[] { ' ', '.', '=' }, StringSplitOptions.RemoveEmptyEntries)
                .Last();

            if (char.IsUpper(methodName[0]))
            {
                return methodName;
            }
            else
            {
                return null;
            }
        }

        return null;
    }
}
