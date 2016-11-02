using Northwind.Tasks.Daos;
using Northwind.Tasks.ViewModels;
using System;

namespace Northwind.ConsoleApp
{
    public class CustomersDaoTestClass
    {
        private const string Id = "BBDFG";

        public static void Run()
        {
            var customer = new CustomerView()
            {
                CustomerID = "BBDFG",
                CompanyName = "Rene5874",
                ContactName = "Peter Prtrov"
            };

            CustomersDao.InsirtCustomer(customer);

            customer = CustomersDao.GetCustomerById(Id);
            Console.WriteLine($"Customer with ID {Id} was created");

            customer.ContactName = "Doly Popova";
            customer.City = "Sofia";
            customer.Phone = "12345890";

            CustomersDao.ModifyCustomer(customer);
            customer = CustomersDao.GetCustomerById(Id);
            Console.WriteLine($"Customer with ID {Id} was modified. New contact name is {customer.ContactName}");

            CustomersDao.DeleteCustomer(Id);

            try
            {
                customer = CustomersDao.GetCustomerById(Id);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}