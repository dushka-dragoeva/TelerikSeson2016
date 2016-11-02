using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Northwind.Tasks.Repositories;
using Northwind.Tasks.ViewModels;
using Northwind.Tasks.Utilities;

namespace Northwind.Data
{
    public class SqlCustomersRepository : ICustomerRepository
    {
        private readonly NorthwindEntities context;

        public SqlCustomersRepository()
        {
            this.context = new NorthwindEntities();
        }

        public IEnumerable<CustomerView> GetAllCustomers()
        {
            var customers = this.context.Customers
                .Select(c => c.ToViewCustomer())
                .AsEnumerable();

            return customers;
        }

        public CustomerView GetCustomerViewById(string customerId)
        {
            Validator<string>.ValidateId(customerId);
            var customer = GetCustomerById(customerId).ToViewCustomer();

            return customer;
        }

        public void InsirtCustomer(CustomerView newCustomer)
        {
            Validator<CustomerView>.ValidateNull(newCustomer, Convertors.FirstLetterToUpper(nameof(newCustomer)));
            var customer = ConvertToCustomer(newCustomer);
            this.context.Customers.Add(customer);
            this.context.SaveChanges();
        }

        public void ModifyCustomer(CustomerView modifiedCustomer)
        {
            Validator<CustomerView>.ValidateNull(modifiedCustomer, Convertors.FirstLetterToUpper(nameof(modifiedCustomer)));
            var customer = this.GetCustomerById(modifiedCustomer.CustomerID);
            var values = context.Entry(customer).CurrentValues;
            values.SetValues(modifiedCustomer);
            context.SaveChanges();
        }

        public void DeleteCustomer(string customerId)
        {
            Validator<string>.ValidateId(customerId);
            var customer = this.GetCustomerById(customerId);
            this.context.Customers.Remove(customer);
            this.context.SaveChanges();
        }

        private Customer ConvertToCustomer(CustomerView viewCustomer)
        {
            var customer = new Customer();
            customer.CustomerID = viewCustomer.CustomerID;
            customer.CompanyName = viewCustomer.CompanyName;
            customer.ContactName = viewCustomer.ContactName;
            customer.ContactTitle = viewCustomer.ContactTitle;
            customer.Address = viewCustomer.Address;
            customer.City = viewCustomer.City;
            customer.Region = viewCustomer.Region;
            customer.PostalCode = viewCustomer.PostalCode;
            customer.Country = viewCustomer.Country;
            customer.Phone = viewCustomer.Phone;
            customer.Fax = viewCustomer.Fax;

            return customer;
        }

        private Customer GetCustomerById(string customerId)
        {
            Validator<string>.ValidateId(customerId);
            var customer = this.context.Customers.SingleOrDefault(c => c.CustomerID == customerId);
            if (customer == null)
            {
                throw new ArgumentNullException(
                    Convertors.FirstLetterToUpper(nameof(customer)),
                    $"{Convertors.FirstLetterToUpper(nameof(customer))} with id {customerId} doesn't exist.");
            }

            return customer;
        }
    }
}
