using System;

namespace Northwind.Tasks.Utilities
{
    internal class Validator<T>
    {
        internal static void ValidateStringLenght(string valueTovalidate, int minLenghth, int maxLenght, string message)
        {
            if (valueTovalidate.Length < minLenghth || valueTovalidate.Length > maxLenght)
            {
                throw new ArgumentException($"{message } must be between {minLenghth} and {maxLenght} symbols long", $"{message}");
            }
        }

        internal static void ValidateNull(T objectToValidate, string message)
        {
            if (objectToValidate == null)
            {
                throw new ArgumentNullException($"{message}", $"The {message} can not be null");
            }
        }
    }
}
