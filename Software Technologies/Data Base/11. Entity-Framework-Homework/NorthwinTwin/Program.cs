using System;
using System.Linq;

using Northwind.Data;

namespace NorthwinTwin
{
    public class Program
    {
        public static void Main()
        {
            var context = new NorthwindEntities();
            using (context)
            {
                context.Database.CreateIfNotExists();
                Console.WriteLine($"Number = {context.Categories.Count()}");
            }
        }
    }
}