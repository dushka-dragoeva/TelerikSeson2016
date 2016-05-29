using System;
using System.Collections.Generic;
using System.Linq;

/// Counting open closed brackets can reach the end of scope of method 
/// Geth Method bodies by spliting "static"
/// All called name methods begin with capital letter and are folowed with (
/// new keyword can be after the method name, never before
/// Method Name is third
public class Konspiration
{
    public static void Main()
    {
        var n = int.Parse(Console.ReadLine());

        var lines = Enumerable
            .Range(0, n)
            .Select(x => Console.ReadLine())
            .ToArray();

        for (int i = 0; i < n; i++)
        {
            if (lines[i].Contains(" static "))
            {
                var methodName = lines[i]
                    .Split('(')[0]
                    .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Last();

                var invockedMethods = new List<string>();

                int bracketsCount = 1;

                i += 2; /// jump over first bracket

                while (bracketsCount > 0 && i < n)
                {
                    var current = lines[i];
                    string currentMethodName = string.Empty;

                    if (current.Contains("("))
                    {
                        var beforeBrackets = current
                              .Split(new[] { '(' }, StringSplitOptions.RemoveEmptyEntries)
                              .Select(x => x.Trim())
                              .ToArray();

                        if (beforeBrackets.Length > 0)
                        {
                            var currentLength = beforeBrackets.Length;

                            if (currentLength > 1)
                            {
                                currentLength = currentLength - 1;
                            }

                            for (int j = 0; j < currentLength; j++)

                            {
                                currentMethodName = ExtractMethodName(beforeBrackets[j]);
                                if (currentMethodName != null)
                                {
                                    invockedMethods.Add(currentMethodName);
                                }
                            }
                        }
                    }

                    if (lines[i].Contains("{"))
                    {
                        bracketsCount++;
                    }

                    if (lines[i].Contains("}"))
                    {
                        bracketsCount--;
                    }

                    i++;
                }

                if (invockedMethods.Count > 0)
                {
                    Console.WriteLine(methodName + " -> " + invockedMethods.Count + " -> " + string.Join(", ", invockedMethods));
                }
                else
                {
                    Console.WriteLine(methodName + " -> None");
                }

                invockedMethods.Clear();
            }
        }
    }

    private static string ExtractMethodName(string text)
    {
        var beforeBrackets = text
                .Split(new[] { ' ', '.', '.', '=', '!' }, StringSplitOptions.RemoveEmptyEntries);

        string methodName = beforeBrackets[beforeBrackets.Length - 1];

        if (char.IsUpper(methodName[0]) && !beforeBrackets.Contains("new"))
        {
            return methodName;
        }
        else
        {
            return null;
        }
    }
}