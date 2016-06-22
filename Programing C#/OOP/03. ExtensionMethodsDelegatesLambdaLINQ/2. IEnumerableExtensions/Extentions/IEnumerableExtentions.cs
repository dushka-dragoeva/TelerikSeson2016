namespace IEnumerable.Extentions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public static class IEnumerableExtentions
    {
        private const string EmptyCollection = "The collection is empty!";

        public static double Avarage<T>(this IEnumerable<T> collection)
                 where T : struct, IConvertible, IComparable
        {
            if (collection.Count() == 0)
            {
                throw new ArgumentException(EmptyCollection);
            }

            var sum = collection.Sum();
            var count = collection.Count();
            double avarage = (dynamic)sum / (double)count;

            return avarage;
        }

        public static T Product<T>(this IEnumerable<T> collection)
             where T : struct, IConvertible, IComparable
        {
            if (collection.Count() == 0)
            {
                throw new ArgumentException(EmptyCollection);
            }

            T product = (dynamic)1;
            foreach (var item in collection)
            {
                product *= (dynamic)item;
            }

            return product;
        }

        public static T Sum<T>(this IEnumerable<T> collection)
               where T : struct, IConvertible, IComparable
        {
            if (collection.Count() == 0)
            {
                throw new ArgumentException(EmptyCollection);
            }

            T sum = (dynamic)0;
            foreach (var item in collection)
            {
                sum += (dynamic)item;
            }

            return sum;
        }

        public static T Max<T>(this IEnumerable<T> collection)
                where T : struct, IConvertible, IComparable
        {
            if (collection.Count() == 0)
            {
                throw new ArgumentException(EmptyCollection);
            }

            T max = collection.First();
            foreach (var item in collection)
            {
                if (item.CompareTo(max) == 1)
                {
                    max = item;
                }
            }

            return max;
        }

        public static T Min<T>(this IEnumerable<T> collection)
                where T : struct, IConvertible, IComparable
        {
            if (collection.Count() == 0)
            {
                throw new ArgumentException(EmptyCollection);
            }

            T min = collection.First();
            foreach (var item in collection)
            {
                if (item.CompareTo(min) == -1)
                {
                    min = item;
                }
            }

            return min;
        }
    }
}