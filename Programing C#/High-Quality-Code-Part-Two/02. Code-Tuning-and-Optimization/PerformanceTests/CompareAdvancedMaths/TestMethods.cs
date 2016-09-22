namespace CompareAdvancedMaths
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;

    internal static class TestMethods
    {
        private const int LoopsCount = 2000000;
        private const int OperationRepeatCount = 10;

        private static Stopwatch watchTime = new Stopwatch();
        private static List<int> storeResults = new List<int>(OperationRepeatCount);
        private static double result = 0;

        internal static void TestOperation(float number, Operations operation)
        {
            storeResults.Clear();
            for (int i = 0; i < OperationRepeatCount; i++)
            {
                watchTime.Reset();
                watchTime.Start();
                for (int j = 0; j < LoopsCount; j++)
                {
                    switch (operation)
                    {
                        case Operations.Sqrt:
                            result = Math.Sqrt(number);
                            break;
                        case Operations.Log:
                            result = Math.Log(number);
                            break;
                        case Operations.Sin:
                            result = Math.Sin(number);
                            break;
                        default:
                            throw new InvalidOperationException("You have entered an invalid operation");
                    }
                }

                watchTime.Stop();
                storeResults.Add(watchTime.Elapsed.Milliseconds);
            }

            double averageResult = storeResults.Average();
            Console.WriteLine("Math {0} with float finished in {1} miliseconds", operation, averageResult);
        }

        internal static void TestOperation(double number, Operations operation)
        {
            storeResults.Clear();
            for (int i = 0; i < OperationRepeatCount; i++)
            {
                watchTime.Reset();
                watchTime.Start();
                for (int j = 0; j < LoopsCount; j++)
                {
                    switch (operation)
                    {
                        case Operations.Sqrt:
                            result = Math.Sqrt(number);
                            break;
                        case Operations.Log:
                            result = Math.Log(number);
                            break;
                        case Operations.Sin:
                            result = Math.Sin(number);
                            break;
                        default:
                            throw new InvalidOperationException("You have entered an invalid operation");
                    }
                }

                watchTime.Stop();
                storeResults.Add(watchTime.Elapsed.Milliseconds);
            }

            double averageResult = storeResults.Average();
            Console.WriteLine("Math {0} with double finished in {1} miliseconds", operation, averageResult);
        }

        internal static void TestOperation(decimal number, Operations operation)
        {
            storeResults.Clear();
            for (int i = 0; i < OperationRepeatCount; i++)
            {
                watchTime.Reset();
                watchTime.Start();
                for (int j = 0; j < LoopsCount; j++)
                {
                    switch (operation)
                    {
                        case Operations.Sqrt:
                            result = Math.Sqrt((double)number);
                            break;
                        case Operations.Log:
                            result = Math.Log((double)number);
                            break;
                        case Operations.Sin:
                            result = Math.Sin((double)number);
                            break;
                        default:
                            throw new InvalidOperationException("You have entered an invalid operation");
                    }
                }

                watchTime.Stop();
                storeResults.Add(watchTime.Elapsed.Milliseconds);
            }

            double averageResult = storeResults.Average();
            Console.WriteLine("Math {0} with decimal finished in {1} miliseconds", operation, averageResult);
        }
    }
}
