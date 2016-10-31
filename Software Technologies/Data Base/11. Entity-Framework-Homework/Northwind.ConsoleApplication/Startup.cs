using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Northwind.Tasks.Daos;
using Northwind.Tasks.ViewModels;
using Northwind.Data;

namespace Northwind.ConsoleApplication
{
    public class Startup
    {
        public static void Main()
        {
            //var customer = new CustomerView("ASDFG", "Lions", "Ronny Smith");
            //CustomersDao.InsirtCustomer(customer);

            //Console.WriteLine("Done");

            var context = new NorthwindEntities();

            var customer = new Customer()
            {
                CustomerID = "BSDFG",
                CompanyName = "Rene5874",
                ContactName = "Alala bala vtory"
            };

            context.Customers.Add(customer);
            context.SaveChanges();
        }
    }
}
