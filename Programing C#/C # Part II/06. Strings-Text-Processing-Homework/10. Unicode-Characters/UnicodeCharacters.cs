using System;
using System.Collections.Generic;
using System.Text;

public class UnicodeCharacters
{
   private static readonly Dictionary<string, string> EscSeqDicitonary =
              new Dictionary<string, string>()
              {
                { @"\'", "0027" },
                { @"\""", "0022" },
                { @"\\", "005C" },
                { @"\0", "0000" },
                { @"\a", "0007" },
                { @"\b", "0008" },
                { @"\f", "000C" },
                { @"\n", "000A" },
                { @"\r", "000D" },
                { @"\t", "0009" },
                { @"\v", "000B" }
              };

    public static void Main()
    {
        var text = Console.ReadLine();
        var convertedText = ConvertToUicodeLiterals(text);
        Console.WriteLine(convertedText);
    }

    private static string ConvertToUicodeLiterals(string text)
    {
        var unicodeFormat = @"\u{0}";

        var convertedString = new StringBuilder();
        for (int i = 0; i < text.Length; i++)
        {
            var symbol = text[i];

            if (symbol == '\\' && i < text.Length - 1)
            {
                var substring = text.Substring(text.IndexOf(symbol), 2);
                if (EscSeqDicitonary.ContainsKey(substring))
                {
                    ////convertedString.Append(string.Format(unicodeFormat, EscSeqDicitonary[substring]));
                    ++i;
                    continue;
                }
            }

            convertedString.Append(string.Format(unicodeFormat, ((int)symbol).ToString("X4")));
        }

        return convertedString.ToString();
    }
}
