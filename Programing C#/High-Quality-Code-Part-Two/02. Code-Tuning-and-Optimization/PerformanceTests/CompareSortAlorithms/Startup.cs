using System;
using System.Collections.Generic;
using System.Diagnostics;

using CompareSortAlorithms.Utilities;

namespace CompareSortAlorithms
{
    public class Startup
    {
        private const string RandomKey = "Random Values";
        private const string SorterKey = "Sorted Values";
        private const string ReversedKey = "Sorted Reversed Values";

        private const string SelectionSort = "Selection Sort Performance";
        private const string InsertionSort = "Insertion Sort Performance";
        private const string QuickSort = "Quick Sort Performance";

        private const string IntDataType = "Integer Data Type Tests";
        private const string DoubleDataType = "Double Data Type Tests";
        private const string StringDataType = "String Data Type Tests";

        private static readonly string Underline = new string('-', 50);
        private static readonly string Separator = new string('=', 50);

        private static Stopwatch sw = new Stopwatch();

        public static void Main(string[] args)
        {
            var intTestData = new Dictionary<string, dynamic>();
            intTestData[RandomKey] = new List<int> { 435, 16, 736, 81, 358, 10251, 110 };
            intTestData[SorterKey] = new List<int> { 16, 81, 110, 358, 435, 736, 10251 };
            intTestData[ReversedKey] = new List<int> { 10251, 736, 435, 358, 110, 81, 16 };

            var doubleTestData = new Dictionary<string, dynamic>();
            doubleTestData[RandomKey] = new List<double> { 435.01, 16.33, 736.65, 81.2587, 358.36, 10251.02, 110.00 };
            doubleTestData[SorterKey] = new List<double> { 16.33, 81.2587, 110.00, 358.36, 435.01, 736.65, 10251.02 };
            doubleTestData[ReversedKey] = new List<double> { 10251.02, 736.65, 435.01, 358.36, 110.00, 81.2587, 16.33 };

            var stringTestData = new Dictionary<string, dynamic>();
            stringTestData[RandomKey] = new List<string> { "int", "long", "float", "double", "and", "decimal", "alabala", "krokodil" };
            stringTestData[SorterKey] = new List<string> { "alabala", "and", "decimal", "double", "float", "int", "krokodil", "long" };
            stringTestData[ReversedKey] = new List<string> { "long", "krokodil", "int", "float", "double", "decimal", "and", "alabala" };

            PrintTestResult(IntDataType, intTestData);
            PrintTestResult(DoubleDataType, doubleTestData);
            PrintTestResult(StringDataType, stringTestData);
        }

        private static void TestPerformance(Dictionary<string, dynamic> intTestData)
        {
            foreach (var data in intTestData)
            {
                Console.WriteLine(data.Key);
                Console.WriteLine(Underline);

                var insertionSortTime = Timer.MeasureTime(
                    sw,
                    InsertionSort,
                    () => SortAlgorithm.ExecuteInsertionSort(data.Value));
                Console.WriteLine($" {InsertionSort} -  {insertionSortTime:F4} miliseconds");

                var selectionSortTime = Timer.MeasureTime(
                    sw,
                    SelectionSort,
                    () => SortAlgorithm.ExecuteSelectionSort(data.Value));
                Console.WriteLine($" {SelectionSort} -  {selectionSortTime:F4} miliseconds ");

                var quickSortTime = Timer.MeasureTime(
                    sw,
                    QuickSort,
                    () => SortAlgorithm.ExecuteQuicSortAlgorithm(data.Value, 0, data.Value.Count - 1));

                Console.WriteLine($" {QuickSort,-26} -  {quickSortTime:F4} miliseconds ");
                Console.WriteLine(Separator);
            }
        }

        private static void PrintTestResult(string dataType, Dictionary<string, dynamic> testData)
        {
            Console.WriteLine(dataType);
            Console.WriteLine(Underline);
            TestPerformance(testData);
        }
    }
}
