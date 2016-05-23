using System;
using System.Text;

public class EncodeAndDecode
{
    public static void Main(string[] args)
    {
        var text = Console.ReadLine();
        var cipher = Console.ReadLine();
        var encoded = EncodeDecodeText(text, cipher);
        var decoded = EncodeDecodeText(encoded, cipher);
        Console.WriteLine(encoded);
        Console.WriteLine(decoded);
    }

    private static string EncodeDecodeText(string text, string cipher)
    {
        var encodedText = new StringBuilder();
        var currentTextLetter = 0;
        var currentCipherLetter = 0;

        for (int i = 0; i < text.Length; i++)
        {
            currentTextLetter = (int)text[i];
            currentCipherLetter = (int)cipher[i % cipher.Length];
            encodedText.Append((char)(currentTextLetter ^ currentCipherLetter));
        }

        return encodedText.ToString();
    }
}