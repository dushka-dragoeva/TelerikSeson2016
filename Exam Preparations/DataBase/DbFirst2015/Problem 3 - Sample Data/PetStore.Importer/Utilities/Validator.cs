using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetStore.Importer.Utilities
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
    }
}
