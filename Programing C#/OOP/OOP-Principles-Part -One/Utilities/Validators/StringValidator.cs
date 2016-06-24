namespace Utilities.Validators
{
    using System;

    public static class StringValidator
    {
        public static string ValidateName(
            this string name,
            int minLength,
            int maxLenght,
            string messageName = "Name")
        {
            if (string.IsNullOrEmpty(name.Trim()))
            {
                throw new ArgumentNullException(
                    messageName,
                    $"{messageName} can not be null or empty string.");
            }
            else if (name.Length < minLength || name.Length > maxLenght)
            {
                throw new ArgumentOutOfRangeException(
                    messageName,
                    $"{messageName} must be between {minLength} and {maxLenght}");
            }

            return name;
        }
    }
}