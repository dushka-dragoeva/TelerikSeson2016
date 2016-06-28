namespace Utilities.Validators
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public static class ColectionValidator
    {
        public static ICollection<T> ValidateIsNotNullOrEmpty<T>(this ICollection<T> collection, string name = null)
        {
            if (collection == null || collection.Count<T>() < 0)
            {
                throw new ArgumentNullException(name, $"{name}" + Constants.EmptyList);
            }
            else
            {
                return collection;
            }
        }
    }
}