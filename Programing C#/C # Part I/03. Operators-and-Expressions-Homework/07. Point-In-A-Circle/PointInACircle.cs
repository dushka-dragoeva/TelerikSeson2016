/*Write a program that reads the coordinates of a point x and y and using an expression checks if given point (x, y) 
is inside a circle K({0, 0}, 2) - the center has coordinates (0, 0) and the circle has radius 2. The program should 
then print "yes DISTANCE" if the point is inside the circle or "no DISTANCE" if the point is outside the circle.
In place of DISTANCE print the distance from the beginning of the coordinate system - (0, 0) - to the given point.
(x - center_x)^2 + (y - center_y)^2 < radius^2.*/

using System;
using System.Globalization;
using System.Threading;

public class PointInACircle
{
    public const double CenterX = 0;
    public const double CenterY = 0;
    public const double Radius = 2;

    public static void Main()
    {
        Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
        double pointX = double.Parse(Console.ReadLine());
        double pointY = double.Parse(Console.ReadLine());

        double distance = Math.Sqrt(Math.Pow(pointX - CenterX, 2) + Math.Pow(pointY - CenterY, 2));

        var output = distance <= Radius ? "yes {0:0.00}" : "no {0:0.00}";
        Console.WriteLine(output, distance);
    }
}
