using System;

namespace CohesionAndCoupling
{
    public class UtilsExamples
    {
        public static void Main()
        {
            Console.WriteLine(FilenameUtils.GetFileExtension("example"));
            Console.WriteLine(FilenameUtils.GetFileExtension("example.pdf"));
            Console.WriteLine(FilenameUtils.GetFileExtension("example.new.pdf"));

            Console.WriteLine(FilenameUtils.GetFileNameWithoutExtension("example"));
            Console.WriteLine(FilenameUtils.GetFileNameWithoutExtension("example.pdf"));
            Console.WriteLine(FilenameUtils.GetFileNameWithoutExtension("example.new.pdf"));

            Console.WriteLine(
                "Distance in the 2D space = {0:f2}",
                GeometricUtils.CalcDistance2D(1, -2, 3, 4));
            Console.WriteLine(
                "Distance in the 3D space = {0:f2}",
                GeometricUtils.CalcDistance3D(5, 2, -1, 3, -6, 4));

            var paralelepiped = new Paralelepiped(3, 4, 5);

            Console.WriteLine("Volume = {0:f2}", paralelepiped.CalcVolume());
            Console.WriteLine("Diagonal XYZ = {0:f2}", paralelepiped.CalcDiagonalXYZ());
            Console.WriteLine("Diagonal XY = {0:f2}", paralelepiped.CalcDiagonalXY());
            Console.WriteLine("Diagonal XZ = {0:f2}", paralelepiped.CalcDiagonalXZ());
            Console.WriteLine("Diagonal YZ = {0:f2}", paralelepiped.CalcDiagonalYZ());
        }
    }
}
