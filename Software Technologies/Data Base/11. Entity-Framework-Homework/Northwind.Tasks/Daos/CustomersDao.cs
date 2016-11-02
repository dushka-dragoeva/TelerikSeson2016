using System;
using System.Linq;
using System.Collections.Generic;

using Northwind.Tasks.Repositories;
using Northwind.Tasks.ViewModels;
using Northwind.Tasks.Utilities;


namespace Northwind.Tasks.Daos
{

    ///02.  Create a DAO class with static methods which provide functionality for inserting, modifying and deleting customers.

    public class CustomersDao
    {
        private static ICustomerRepository customerRepository;

        public CustomersDao(ICustomerRepository repository)
        {
            if (repository == null)
            {
                throw new ArgumentNullException("repository");
            }

            customerRepository = repository;
        }

        /// Task 2
        public static void InsirtCustomer(CustomerView newCustomer)
        {
            if (newCustomer == null)
            {
                throw new NullReferenceException("Customer can not be null");
            }

            customerRepository.InsirtCustomer(newCustomer);
        }

        public static void ModifyCustomer(CustomerView modifiedCustomer)
        {
            Validator<CustomerView>.ValidateNull(modifiedCustomer, nameof(modifiedCustomer));

            customerRepository.ModifyCustomer(modifiedCustomer);
        }

        public static void DeleteCustomer(string id)
        {
            Validator<string>.ValidateId(id);

            customerRepository.DeleteCustomer(id);
        }

        public static CustomerView GetCustomerById(string id)
        {
            return customerRepository.GetCustomerViewById(id);
        }
    }
}
