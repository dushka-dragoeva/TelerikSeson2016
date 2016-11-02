using Northwind.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.ConsoleApp
{
    public class TaskResolver
    {
        internal static void FindAllWithOrdersByShippedYearAndShipCountry(int shippedYear, string shipCountry, NorthwindEntities dbContext)
        {
            string shipCountryLowered = shipCountry.ToLower();
            var customers = dbContext.Customers
                .Where(c => c.Orders.Any(o => o.ShipCountry.ToLower() == shipCountryLowered && o.ShippedDate.Value.Year == shippedYear))
                .Select(c => new { c.CompanyName, c.ContactName, c.Country })
                .OrderBy(c => c.CompanyName);

            Console.WriteLine($"Customers with Linq, OrderYear: {shippedYear}, Country: {shipCountry}");
            foreach (var customer in customers)
            {
                Console.WriteLine($"Company: {customer.CompanyName}, Contact Name: {customer.ContactName}, Country: {customer.Country} ");
            }
        }

        internal static void CustomersWithOrdersFromYearToCountryWithSQL(int year, string country, NorthwindEntities dbContext)
        {
            var queryTemplate = @"SELECT *
                    FROM Customers c
                    JOIN Orders o
                        ON o.CustomerID = c.CustomerID
                    WHERE o.ShipCountry = '{1}' AND YEAR(o.OrderDate) = {0}
                    ORDER BY c.CompanyName";
            var query = string.Format(queryTemplate, year, country);

            var customers = dbContext.Customers.SqlQuery(query).Distinct().ToList();

            Console.WriteLine($"Customers with NativeSQL, OrderYear: {year}, Country: {country}");
            foreach (var customer in customers)
            {
                Console.WriteLine($"Company: {customer.CompanyName}, Contact Name: {customer.ContactName}, Country: {customer.Country} ");
            }
        }

        internal static void FindAllSalesByRegionForGivenPeriod(string region, DateTime startDate, DateTime EndDate, NorthwindEntities dbContext)
        {
            var orders = dbContext.Orders
                .Where(o => o.ShipRegion != null &&
                            o.ShipRegion == region &&
                            o.OrderDate >= startDate &&
                            o.OrderDate <= EndDate)
                .OrderBy(o => o.ShippedDate)
                .ToList();

            Console.WriteLine($"Orders between, Start: {startDate.ToShortDateString()}, End: {EndDate.ToShortDateString()}, Region: {region}");
            foreach (var order in orders)
            {
                Console.WriteLine($"Ship date {order.OrderDate} Region: {order.ShipRegion} Company: {order.ShipName}");
            }
        }

        internal static void ConcurencyRequests()
        {
            var contextA = new NorthwindEntities();
            var contextB = new NorthwindEntities();

            var customerA = contextA.Customers.FirstOrDefault();
            var customerB = contextB.Customers.FirstOrDefault();

            customerA.ContactName = "customer A";
            customerB.ContactName = "customer B";

            contextA.SaveChanges();
            contextB.SaveChanges();
        }

        public static void PrintTeritory(NorthwindEntities dbContext)
        {
            var employee = dbContext.Employees.FirstOrDefault();
            var teritory = employee.EntitySetTerritories.FirstOrDefault().TerritoryDescription;
            Console.WriteLine(teritory);
        }
    }
}
