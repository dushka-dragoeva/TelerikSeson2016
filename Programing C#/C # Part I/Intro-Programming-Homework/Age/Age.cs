/// Write a program that reads your birthday(in the format MM.DD.YYYY) from 
/// the console and prints on the console how old you are you now and how old 
/// will you be after 10 years.
namespace Age
{
    using System;

    public class Age
    {
        public static void Main()
        {
            /// Parse console input to DateTime
            DateTime birthDate = DateTime.Parse(Console.ReadLine());

            /// Check whether the birthday is passed return true or false
            bool isBirthdayPassed = DateTime.Now.Month > birthDate.Month ||
                 (DateTime.Now.Month == birthDate.Month 
                 && DateTime.Now.Day > birthDate.Day);
            int ageNow;

            if (isBirthdayPassed)
            {
                ageNow = DateTime.Now.Year - birthDate.Year;
            }
            else
            {
                ageNow = DateTime.Now.Year - birthDate.Year - 1;
            }

            var ageAfterTenYears = ageNow + 10;

            Console.WriteLine(ageNow);
            Console.WriteLine(ageAfterTenYears);
        }
    }
}
