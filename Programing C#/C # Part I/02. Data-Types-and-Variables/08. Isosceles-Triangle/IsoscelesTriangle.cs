/* Write a program that prints an isosceles triangle of 9 copyright symbols ©, 
something like this:
   ©

  © ©

 ©   ©

© © © © */
using System;
using System.Text;

public class IsoscelesTriangle
{
    public static void Main()
    {
        Console.OutputEncoding = Encoding.UTF8;
        char copyRightSymbol = '\u00A9';
        string firstLine = "   {0}\n\n";
        string secondLine = "  {0} {0}\n\n";
        string thirdLine = " {0}   {0}\n\n";
        string forthLine = "{0} {0} {0} {0}";

        Console.WriteLine(firstLine + secondLine + thirdLine + forthLine, copyRightSymbol);
    }
}
