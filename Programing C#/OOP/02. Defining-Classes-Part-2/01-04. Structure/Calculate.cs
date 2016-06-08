namespace _01_04.Structure
{
    using System;

    internal static class Calculate
    {
        public static double DistansBetweenTowPoints(Point3D a, Point3D b)
        {
            double diatance = Math.Sqrt(
               ((a.X - b.X) * (a.X - b.X)) +
               ((a.Y - b.Y) * (a.Y - b.Y)) +
              ((a.Z - b.Z) * (a.Z - b.Z)));

            return diatance;
        }
    }
}
