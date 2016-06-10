namespace TestHomeWorkTasks
{
    using System;
    using System.Globalization;
    using System.Reflection;
    using System.Threading;
    using _01_04.Structure;
    using _05_07_GenericList;
    using _08_10.Matrix;
    using _11.Version_Attribute;

    [Version(VersionAttribute.Type.Class, "TestHomeworkTasks", "1.03")]
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
            Console.WriteLine("Test Structure");
            Console.WriteLine(otherPath);

            var a = otherPath[0];
            var b = otherPath[1];
            var distanseAB = Calculate.DistansBetweenTowPoints(a, b);

            Console.WriteLine($"Distance between first tow points in path is: {distanseAB:f4}");
            Console.WriteLine();

            var myList = new GenericList<int>(4);
            myList.Add(67);
            myList.Add(47);
            myList.Add(57);
            myList.Add(677);
            myList.Add(679);
            myList.Add(637);

            Console.WriteLine("Test Generic List");
            Console.WriteLine(myList);
            Console.WriteLine($"Number of elements: {myList.Count}");
            Console.WriteLine($"Index of 57 is: {myList.IndexOf(57)}");

            Console.WriteLine($"Element at index 3 is: {myList[3]}");
            myList.Remove(3);
            Console.WriteLine($"Element at index 3 is removed: { myList}");

            myList.Insirt(1, 100);
            Console.WriteLine($"100 is inserted at index 1: {myList}");

            Console.WriteLine($"Max value in myList is: {myList.Max()}");
            Console.WriteLine($"Min value in myList is: {myList.Min()}");

            myList.Clear();
            Console.WriteLine($"I am empty list.{myList}");
            Console.WriteLine();

            Console.WriteLine("Test Matrix");

            var firstMatrix = new Matrix<int>(2, 4);
            firstMatrix.FillMatrix();
            Console.WriteLine(firstMatrix);

            var secondMatrix = new Matrix<int>(2, 4);
            secondMatrix.FillMatrix();
            secondMatrix[1, 1] = 0;
            Console.WriteLine(secondMatrix);

            var thirdMatrix = new Matrix<int>(6, 2);
            thirdMatrix.FillMatrix();
            Console.WriteLine(thirdMatrix);

            Console.WriteLine($"Addition:\n{firstMatrix + secondMatrix}");
            Console.WriteLine($"Subtraction :\n{firstMatrix - secondMatrix}");
            Console.WriteLine($"Multiplication:\n{firstMatrix * thirdMatrix}");

            var isTrue = firstMatrix ? "True" : "False";
            Console.WriteLine(isTrue);

            isTrue = secondMatrix ? "True" : "False";
            Console.WriteLine(isTrue);
            Console.WriteLine();

            var classAttr = typeof(Startup).GetCustomAttributes<VersionAttribute>();

            foreach (var attribute in classAttr)
            {
                Console.WriteLine("{0}: {1}     Version: {2}", attribute.Component, attribute.Name, attribute.Version);
            }
        }
    }
}
