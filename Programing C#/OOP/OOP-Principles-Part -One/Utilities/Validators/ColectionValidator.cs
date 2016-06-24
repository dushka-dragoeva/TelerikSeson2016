namespace Utilities.Validators
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public static class ColectionValidator
    {
        public static List<T> ValidateIsNotNullOrEmpty<T>(this List<T> collection, string name = null)
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