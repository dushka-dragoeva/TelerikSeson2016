/*Write a program that reads a pair of coordinates x and y and uses an expression to checks for given 
point (x, y) if it is within the circle K({1, 1}, 1.5) and out of the rectangle 
R(top=1, left=-1, width=6, height=2).*/
using System;
using System.Globalization;
using System.Threading;

public class PointCircleRectangle
{
    public const double CenterY = 1;
    public const double Radius = 1.5;
    public const double TopY = 1;
    public const double LeftX = -1;
    public const double Width = 6;
    public const double Height = 2;
    public const double CenterX = 1;

    public static void Main()
    {
        Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
        double pointX = double.Parse(Console.ReadLine());
        double pointY = double.Parse(Console.ReadLine());

        double rightX = LeftX + Width;
        double bottomY = TopY - Height;

        double distance = Math.Sqrt(Math.Pow(pointX - CenterX, 2) + Math.Pow(pointY - CenterY, 2));
        bool isWithinCircle = distance <= Radius;
        bool isOutOfRectangle = pointX < LeftX || rightX < pointX || pointY < bottomY || pointY > TopY;

        var output = isWithinCircle && isOutOfRectangle ? "yes" : "no";
        Console.WriteLine(output);
    }
}
