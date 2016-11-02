using System;
using System.Reflection;
using Ninject;
using Northwind.Data;
using Northwind.Tasks.Daos;

namespace Northwind.ConsoleApp
{
    public class Program
    {
        private static readonly string separator = new string('=', 80);

        public static void Main()
        {
            var kernel = new StandardKernel();
            kernel.Load(Assembly.GetExecutingAssembly());
            var customersDao = kernel.Get<CustomersDao>();

            CustomersDaoTestClass.Run();
            Console.WriteLine(separator);

            /// ===============================================================================

            var dbContext = new NorthwindEntities();

            using (dbContext)
            {
                /// Task 03. Write a method that finds all customers who have orders made in 1997 and shipped to Canada.

                TaskResolver.FindAllWithOrdersByShippedYearAndShipCountry(1997, "Canada", dbContext);
                Console.WriteLine(separator);

                /// Task 04. mplement previous by using native SQL query and executing it through the DbContext

                TaskResolver.CustomersWithOrdersFromYearToCountryWithSQL(1997, "Canada", dbContext);
                Console.WriteLine(separator);

                ///  Task 05. Write a method that finds all the sales by specified region and period (start / end dates).  
                TaskResolver.FindAllSalesByRegionForGivenPeriod("SP", new DateTime(1997, 01, 01), new DateTime(1998, 01, 01), dbContext);

                // Task 07 By inheriting the Employee entity class create a class which allows employees to access their 
                //corresponding territories as property of type EntitySet<T>.
                TaskResolver.PrintTeritory(dbContext);
            }

            /// Task 06. Try to open two different data contexts and perform concurrent changes on the same records.
            ///    What will happen at SaveChanges() ? => Second change overite the first
            /// How to deal with it ?
            TaskResolver.ConcurencyRequests();
        }
    }
}