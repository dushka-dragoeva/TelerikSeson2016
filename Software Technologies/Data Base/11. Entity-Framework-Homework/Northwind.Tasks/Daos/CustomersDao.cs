using System;
using System.Linq;

using Northwind.Tasks.ViewModels;
using Northwind.Tasks.Utilities;
using Northwind.Data;

namespace Northwind.Tasks.Daos
{
    public class CustomersDao
    {
        public static void InsirtCustomer(CustomerView newCustomer)
        {
            if (newCustomer == null)
            {
                throw new NullReferenceException("Customer can not be null");
            }

            var customer = ConvertCostumerViewToCustomer(newCustomer);

            var context = CustomersDao.GetDbContext();

            using (context)
            {
                context.Customers.Add(customer);
                context.SaveChanges();
            }
        }

        public static void ModifyCustomer(CustomerView modifiedCustomer)
        {
            Validator<CustomerView>.ValidateNull(modifiedCustomer, nameof(modifiedCustomer));

            var context = GetDbContext();
            var customerToModify = GetCustomerByIdFromDataBase(modifiedCustomer.CustomerID, context);
            var values = context.Entry(customerToModify).CurrentValues;
            values.SetValues(modifiedCustomer);
            context.SaveChanges();
        }

        public static void DeleteCustomer(string id)
        {
            Validator<string>.ValidateStringLenght(id, Constants.IdLenght, Constants.IdLenght, Convertor.FirstLetterToUpper(nameof(id)));

            var context = GetDbContext();
            var customerToDelete = GetCustomerByIdFromDataBase(id, context);
            context.Customers.Remove(customerToDelete);
            context.SaveChanges();
        }

        public static CustomerView GetCustomerById(string id)
        {
            var context = GetDbContext();
            var customer = GetCustomerByIdFromDataBase(id, context);
            var foundCustomer = ToCustomerView(customer);

            return foundCustomer;
        }

        private static Customer GetCustomerByIdFromDataBase(string id, NorthwindEntities context)
        {
            Validator<string>.ValidateNull(id, nameof(id).ToUpper());
            Validator<string>.ValidateStringLenght(id, Constants.IdLenght, Constants.IdLenght, Convertor.FirstLetterToUpper(nameof(id)));

            var customer = context.Customers.SingleOrDefault(c => c.CustomerID == id);
            if (customer == null)
            {
                throw new ArgumentNullException(
                    Convertor.FirstLetterToUpper(nameof(customer)),
                    $"{Convertor.FirstLetterToUpper(nameof(customer))} with id {id} doesn't exist.");
            }

            var foundCustomer = ToCustomerView(customer);
            return customer;
        }

        private static NorthwindEntities GetDbContext()
        {
            var dbcontext = new NorthwindEntities();
            return dbcontext;
        }

        private static Customer ConvertCostumerViewToCustomer(CustomerView newCustomer)
        {
            var customer = new Customer();

            customer.CustomerID = newCustomer.CustomerID;
            customer.CompanyName = newCustomer.CompanyName;
            customer.ContactName = newCustomer.ContactName;
            customer.ContactTitle = newCustomer.ContactTitle;
            customer.Address = newCustomer.Address;
            customer.City = newCustomer.City;
            customer.Region = newCustomer.Region;
            customer.PostalCode = newCustomer.PostalCode;
            customer.Country = newCustomer.Country;
            customer.Phone = newCustomer.Phone;
            customer.Fax = newCustomer.Fax;

            return customer;
        }

        private static CustomerView ToCustomerView(Customer dbCustomer)
        {
            var customer = new CustomerView();

            customer.CustomerID = dbCustomer.CustomerID;
            customer.CompanyName = dbCustomer.CompanyName;
            customer.ContactName = dbCustomer.ContactName;
            customer.ContactTitle = dbCustomer.ContactTitle;
            customer.Address = dbCustomer.Address;
            customer.City = dbCustomer.City;
            customer.Region = dbCustomer.Region;
            customer.PostalCode = dbCustomer.PostalCode;
            customer.Country = dbCustomer.Country;
            customer.Phone = dbCustomer.Phone;
            customer.Fax = dbCustomer.Fax;

            return customer;
        }
    }
}
