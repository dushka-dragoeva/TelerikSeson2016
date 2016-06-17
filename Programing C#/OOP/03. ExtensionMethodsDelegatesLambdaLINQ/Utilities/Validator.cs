namespace Utilities
{
    using System;
    using System.Text.RegularExpressions;

    public class Validator
    {
        public static void CheckName(string name)
        {
            foreach (var letter in name)
            {
                if (!char.IsLetter(letter) && letter != ' ' && letter != '-')
                {
                    throw new ArgumentException(Constants.InvalidName);
                }
            }
        }

        public static void CheckAge(int age)
        {
            if (age < 0)
            {
                throw new ArgumentException(Constants.InvalidAge);
            }

            if (age < 14)
            {
                throw new ArgumentException(Constants.YoungStudent);
            }

            if (age > 150)
            {
                throw new ArgumentException(Constants.InvalidAge);
            }
        }

        public static void CheckEmail(string email)
        {
            if (!Regex.IsMatch(email.Trim(), Constants.EmailRegex, RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250)))
            {
                throw new ArgumentException(Constants.InvalidEmail);
            }
        }

        public static void CheckPhone(string phone)
        {
            if (!Regex.IsMatch(phone.Trim(), Constants.PhoneRegex))
            {
                throw new ArgumentException(Constants.InvalidPhone);
            }
        }
    }
}
