namespace DivisibleBySevenAndThree.Extentions
{
    using System.Collections.Generic;
    using System.Linq;

    internal class IntegerDevider
    {
        internal static IEnumerable<T> FindDivisibleUsingLambda<T>(
            IEnumerable<T> numbers,
            T num1,
            T num2)
            where T : struct
        {
            return numbers
                .Where(x => ((dynamic)x % num1 == 0 && (dynamic)x % num2 == 0));
        }

        internal static IEnumerable<T> FindDivisibleUsingLinq<T>(
            IEnumerable<T> numbers,
            int num1,
            int num2)
            where T : struct
        {
            return from num in numbers
                   where ((dynamic)num % num1 == 0 && (dynamic)num % num2 == 0)
                   select num;
        }
    }
}
