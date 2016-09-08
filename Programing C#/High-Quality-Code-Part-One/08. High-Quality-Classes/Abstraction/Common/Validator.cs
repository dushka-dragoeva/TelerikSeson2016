using System;

namespace Abstraction.Common
{
    public static class Validator
    {
        public static void CheckIfPositiveDouble(double dimention, string message = null)
        {
            var isValid = 0 < dimention && dimention < double.MaxValue;
            if (!isValid)
            {
                throw new ArgumentException(message);
            }
        }

        public static void CheckIfValidRecktangleSides(double width, double heigth, string message = null)
        {
            var areValid = width * heigth <= double.MaxValue && 2 * (width + heigth) <= double.MaxValue;
            if (!areValid)
            {
                throw new ArgumentException(message);
            }
        }

        public static void CheckIfValidRadius(double radius, string message = null)
        {
            var isValid = Math.PI * radius * radius <= double.MaxValue && 2 * radius <= double.MaxValue;
            if (!isValid)
            {
                throw new ArgumentException(message);
            }
        }
    }
}
