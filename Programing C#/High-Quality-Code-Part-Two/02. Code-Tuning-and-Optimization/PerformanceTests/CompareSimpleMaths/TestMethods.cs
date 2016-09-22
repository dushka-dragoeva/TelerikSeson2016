namespace CompareSimpleMaths
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;

    internal static class TestMethods
    {
        private const int LoopsCount = 2000000;
        private const int OperationRepeatCount = 10;
        private const int PerformOperationWith = 1;

        private static Stopwatch watchTime = new Stopwatch();
        private static List<int> storeResults = new List<int>(OperationRepeatCount);

        internal static void TestOperation(int number, Operations operation)
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
                        case Operations.Add:
                            number += PerformOperationWith;
                            break;
                        case Operations.Division:
                            number /= PerformOperationWith;
                            break;
                        case Operations.Substaction:
                            number -= PerformOperationWith;
                            break;
                        case Operations.Multiply:
                            number *= PerformOperationWith;
                            break;
                        case Operations.Increment:
                            number++;
                            break;
                        default:
                            throw new InvalidOperationException("You have entered an invalid operation");
                    }
                }

                watchTime.Stop();
                storeResults.Add(watchTime.Elapsed.Milliseconds);
            }

            double averageResult = storeResults.Average();
            Console.WriteLine("Operation {0} with int finished in {1} miliseconds", operation, averageResult);
        }

        internal static void TestOperation(long number, Operations operation)
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
                        case Operations.Add:
                            number += PerformOperationWith;
                            break;
                        case Operations.Division:
                            number /= PerformOperationWith;
                            break;
                        case Operations.Substaction:
                            number -= PerformOperationWith;
                            break;
                        case Operations.Multiply:
                            number *= PerformOperationWith;
                            break;
                        case Operations.Increment:
                            number++;
                            break;
                        default:
                            throw new InvalidOperationException("You have entered an invalid operation");
                    }
                }

                watchTime.Stop();
                storeResults.Add(watchTime.Elapsed.Milliseconds);
            }

            double averageResult = storeResults.Average();
            Console.WriteLine("Operation {0} with long finished in {1} miliseconds", operation, averageResult);
        }

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
                        case Operations.Add:
                            number += PerformOperationWith;
                            break;
                        case Operations.Division:
                            number /= PerformOperationWith;
                            break;
                        case Operations.Substaction:
                            number -= PerformOperationWith;
                            break;
                        case Operations.Multiply:
                            number *= PerformOperationWith;
                            break;
                        case Operations.Increment:
                            number++;
                            break;
                        default:
                            throw new InvalidOperationException("You have entered an invalid operation");
                    }
                }

                watchTime.Stop();
                storeResults.Add(watchTime.Elapsed.Milliseconds);
            }

            double averageResult = storeResults.Average();
            Console.WriteLine("Operation {0} with float finished in {1} miliseconds", operation, averageResult);
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
                        case Operations.Add:
                            number += PerformOperationWith;
                            break;
                        case Operations.Division:
                            number /= PerformOperationWith;
                            break;
                        case Operations.Substaction:
                            number -= PerformOperationWith;
                            break;
                        case Operations.Multiply:
                            number *= PerformOperationWith;
                            break;
                        case Operations.Increment:
                            number++;
                            break;
                        default:
                            throw new InvalidOperationException("You have entered an invalid operation");
                    }
                }

                watchTime.Stop();
                storeResults.Add(watchTime.Elapsed.Milliseconds);
            }

            double averageResult = storeResults.Average();
            Console.WriteLine("Operation {0} with double finished in {1} miliseconds", operation, averageResult);
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
                        case Operations.Add:
                            number += PerformOperationWith;
                            break;
                        case Operations.Division:
                            number /= PerformOperationWith;
                            break;
                        case Operations.Substaction:
                            number -= PerformOperationWith;
                            break;
                        case Operations.Multiply:
                            number *= PerformOperationWith;
                            break;
                        case Operations.Increment:
                            number++;
                            break;
                        default:
                            throw new InvalidOperationException("You have entered an invalid operation");
                    }
                }

                watchTime.Stop();
                storeResults.Add(watchTime.Elapsed.Milliseconds);
            }

            double averageResult = storeResults.Average();
            Console.WriteLine("Operation {0} with decimal finished in {1} miliseconds", operation, averageResult);
        }
    }
}
