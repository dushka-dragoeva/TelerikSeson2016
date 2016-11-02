using System;

namespace Northwind.Tasks.Utilities
{
    public class Validator<T>
    {
        public static void ValidateStringLenght(string valueTovalidate, int minLenghth, int maxLenght, string message)
        {
            if (valueTovalidate == null)
            {
                return;
            }

            if (valueTovalidate.Length < minLenghth || valueTovalidate.Length > maxLenght)
            {
                throw new ArgumentException($"{message } must be between {minLenghth} and {maxLenght} symbols long", $"{message}");
            }
        }

        public static void ValidateNull(T objectToValidate, string message)
        {
            if (objectToValidate == null)
            {
                throw new ArgumentNullException($"{message}", $"The {message} can not be null");
            }
        }

        public static void ValidateId(string customerId)
        {
            var idName = Convertors.FirstLetterToUpper(nameof(customerId));
            Validator<string>.ValidateNull(customerId, idName);
            Validator<string>.ValidateStringLenght(customerId, Constants.IdLenght, Constants.IdLenght, idName);
        }
    }
}
