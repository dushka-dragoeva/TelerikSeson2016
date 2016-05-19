using System;

public class TriangleSurfaceByTreeSides
{
    public static void Main(string[] args)
    {
        double[] triangleSides = new double[3];

        for (int i = 0; i < 3; i++)
        {
            triangleSides[i] = double.Parse(Console.ReadLine());
        }

        /* https://en.wikipedia.org/wiki/Heron%27s_formula
        Heron's formula numerically unstable for triangles with a very small angle when using floating point arithmetic. 
        A stable alternative involves arranging the lengths of the sides so that a ≥ b ≥ c and computing*/

        Array.Sort(triangleSides);
        double a = triangleSides[2];
        double b = triangleSides[1];
        double c = triangleSides[0];

        double s = (a + b + c) / 2;
        double surface = Math.Sqrt(s * (s - a) * (s - b) * (s - c));

        //// double surface = (Math.Sqrt((a + (b + c)) * (c - (a - b)) * (c + (a - b)) * (a + (b - c))))/4;

        Console.WriteLine("{0:f}", surface);
    }
}