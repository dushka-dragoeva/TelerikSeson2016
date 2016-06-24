namespace Utilities.Validators
{
    using System;

    public static class NumberValidator
    {
        public static T ValidateIntegerRange<T>(this T number, T minNumber, T maxNumber)
            where T : struct, IComparable
        {
            if (number.CompareTo(minNumber) < 0 || number.CompareTo(maxNumber) > 0)
            {
                throw new ArgumentException();
            }
            else
            {
                return number;
            }
        }
    }
}
