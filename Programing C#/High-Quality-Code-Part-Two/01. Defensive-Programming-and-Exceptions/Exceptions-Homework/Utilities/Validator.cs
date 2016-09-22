namespace ExceptionsHomework.Utilities
{
    internal class Validator
    {
        public static bool ValidateIntegerRange(int value, int minValue = int.MinValue, int maxValue = int.MaxValue)
        {
            var isInRange = minValue <= value && value <= maxValue;

            return isInRange;
        }

        public static bool ValidateString(string text)
        {
            var isStringValid = text != null && text != string.Empty;
            return isStringValid;
        }
    }
}
