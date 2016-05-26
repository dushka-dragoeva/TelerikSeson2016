using System;

public class BinaryShort
{
    public static void Main()
    {
        short signedShort = short.Parse(Console.ReadLine());

        string shortToBynary = string.Empty;
        string[] binarySign = { "0", "1" };

        for (int i = 0; i < 16; i++)
        {
            var sign = binarySign[(signedShort & 1)];
            shortToBynary = sign + shortToBynary;

            /// shift right
            signedShort >>= 1;
        }

        Console.WriteLine(shortToBynary.PadLeft(16, '0'));
    }
}
