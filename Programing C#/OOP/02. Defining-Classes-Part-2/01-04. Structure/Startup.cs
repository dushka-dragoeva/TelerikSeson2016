namespace _01_04.Structure
{
    using System;
    using System.Globalization;
    using System.Threading;

    public class Startup
    {
        public static void Main()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
            var path = new Path();

            path.AddPoint(new Point3D(5, 36, 7.9));
            path.AddPoint(new Point3D(15, 6, 7));
            path.AddPoint(new Point3D(5.4, 26, 7));
            path.AddPoint(new Point3D(5.4, 16, 27));
            path.AddPoint(new Point3D(25.5, 6, 7));

            PathStorage.Save(path, "savedPoints");

            var otherPath = PathStorage.Load("savedPoints");

           Console.WriteLine(otherPath);

            var a = otherPath[0];
            var b = otherPath[1];
            var distanseAB = Calculate.DistansBetweenTowPoints(a, b);

            Console.WriteLine($"{distanseAB}");
        }
    }
}
