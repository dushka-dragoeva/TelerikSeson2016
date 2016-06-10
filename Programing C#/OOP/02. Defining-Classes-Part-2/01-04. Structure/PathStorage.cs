namespace _01_04.Structure
{
    using System;
    using System.Linq;
    using IO = System.IO;

    internal static class PathStorage
    {
        public static void Save(Path path, string fileName)
        {
            string fullFilePath = IO.Path.Combine(@"..\..\Paths", $"{fileName.Trim()}.txt");
            using (IO.StreamWriter writer = IO.File.CreateText(fullFilePath))
            {
                writer.Write(path.ToString());
            }
        }

        public static Path Load(string fileName)
        {
            Path path = new Path();
            string fullFilePath = IO.Path.Combine(@"..\..\Paths", $"{fileName.Trim()}.txt");

            try
            {
                using (IO.StreamReader reader = new IO.StreamReader(fullFilePath))
                {
                    string[] allPoints = reader.ReadToEnd()
                        .Split(new string[] { "\n", "\r" }, StringSplitOptions.RemoveEmptyEntries);

                    foreach (var point in allPoints)
                    {
                        double[] coordinates = point.Trim('[', ']', ' ')
                            .Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries)
                            .Select(double.Parse)
                            .ToArray();

                        path.AddPoint(new Point3D(coordinates[0], coordinates[1], coordinates[2]));
                    }
                }
            }
            catch (IO.FileNotFoundException)
            {
                Console.WriteLine($"The file path {fileName} cannot be found");
            }

            return path;
        }
    }
}
