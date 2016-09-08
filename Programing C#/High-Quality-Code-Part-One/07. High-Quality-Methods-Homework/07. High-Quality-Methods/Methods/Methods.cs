using System;
using System.Collections.Generic;

namespace Methods
{
    internal class Methods
    {
        internal static double CalculateTriangleArea(double a, double b, double c)
        {
            var anySidesSmallerThanZero = a <= 0 && b <= 0 && c <= 0;

            if (anySidesSmallerThanZero)
            {
                throw new ArgumentOutOfRangeException("Sides should be positive.");
            }

            var treeSidesFormTriangle = a + b > c && a + c > b && b + c > a;

            if (treeSidesFormTriangle)
            {
                double semiPerimeter = (a + b + c) / 2;
                double area = Math.Sqrt(semiPerimeter * (semiPerimeter - a) * (semiPerimeter - b) * (semiPerimeter - c));
                return area;
            }
            else
            {
                throw new ArithmeticException("The sum of each 2 sides must be greater than third side");
            }
        }

        internal static string DigitToWord(int number)
        {
            var digitTranslations = new Dictionary<int, string>()
            {
                { 0, "zero" },
                { 1, "one" },
                { 2, "two" },
                { 3, "three" },
                { 4, "four" },
                { 5, "five" },
                { 6, "six" },
                { 7, "sevem" },
                { 8, "eight" },
                { 9, "nine" }
            };

            string result;

            if (digitTranslations.ContainsKey(number))
            {
                result = digitTranslations[number];
            }
            else
            {
                throw new ArgumentException("Number is not a digit.");
            }

            return result;
        }

        internal static int FindMaxValueInArray(params int[] elements)
        {
            if (elements == null || elements.Length == 0)
            {
                throw new ArgumentException("Array is null or empty!");
            }

            var maxElement = elements[0];

            for (int i = 1; i < elements.Length; i++)
            {
                if (elements[i] > maxElement)
                {
                    maxElement = elements[i];
                }
            }

            return maxElement;
        }

        internal static double CalculateDistance(double x1, double y1, double x2, double y2)
        {
            double distance = Math.Sqrt(((x2 - x1) * (x2 - x1)) + ((y2 - y1) * (y2 - y1)));
            return distance;
        }

        internal static bool ChekIfVertivcalLine(double y1, double y2)
        {
            var isVertical = y1 == y2;
            return isVertical;
        }

        internal static bool CheckIfHorizontalLine(double x1, double x2)
        {
            var isHorizontal = x1 == x2;
            return isHorizontal;
        }
    }
}
